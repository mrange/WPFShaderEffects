//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- SwirlEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Center of Swirl
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(0.5,0.5)
float2 Center : register(C0);

// ParameterComment        :  Strength of spiral in swirl effect
// ParameterType           :  double
// ParameterDefaultValue   :  0.5
float SpiralStrength : register(C1);

// ParameterComment        :  AngleFrequency of spiral in swirl effect
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(2.0,2.0)
// ParameterCoerce         :  Clamp(AngleFrequency, MakePoint(0.0,0.0), MakePoint(double.MaxValue,double.MaxValue))
float2 AngleFrequency : register(C2);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float2 dir = uv - Center;
   float l = length(dir);
   float angle = atan2(dir.y, dir.x);
   
   float newAng = angle + SpiralStrength * l;
   float xAmt = cos(AngleFrequency.x * newAng) * l;
   float yAmt = sin(AngleFrequency.y * newAng) * l;
   
   float2 newCoord = Center + float2(xAmt, yAmt);
   
   return tex2D( implicitInputSampler, newCoord );
}


