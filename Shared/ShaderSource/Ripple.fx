//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- RippleEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Center of ripple
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(0.5,0.5)
float2 Center : register(C0);

// ParameterComment        :  Amplitude of ripple
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
// ParameterCoerce         :  Clamp(Amplitude, 0.0, double.MaxValue)
float Amplitude : register(C1);

// ParameterComment        :  Frequency of ripple
// ParameterType           :  double
// ParameterDefaultValue   :  4.0
// ParameterCoerce         :  Clamp(Frequency, 0.0, double.MaxValue)
float Frequency: register(C2);

// ParameterComment        :  Phase of ripple
// ParameterType           :  double
// ParameterDefaultValue   :  0.0
// ParameterCoerce         :  Phase % (2 * Pi)
float Phase: register(C3);

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
   
   float2 toPixel = uv - Center; // vector from Center to pixel
	float distance = length(toPixel);
	float2 direction = toPixel/distance;
	float angle = atan2(direction.y, direction.x);
	float2 wave;
	sincos(Frequency * distance + Phase, wave.x, wave.y);
		
	float falloff = saturate(1-distance);
	falloff *= falloff;
		
	distance += Amplitude * wave.x * falloff;
   sincos(angle, direction.y, direction.x);
   float2 uv2 = Center + distance * direction;
   
   float lighting = saturate(wave.y * falloff) * 0.2 + 0.8;
   
   float4 color = tex2D( implicitInputSampler, uv2 );
   color.rgb *= lighting;
   
   return color;
}
