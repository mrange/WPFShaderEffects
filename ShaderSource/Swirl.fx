//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- SwirlEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

float2 Center : register(C0);
float SpiralStrength : register(C1);
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


