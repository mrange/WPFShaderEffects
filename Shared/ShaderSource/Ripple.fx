//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- RippleEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

float2 Center : register(C0);
float Amplitude : register(C1);
float Frequency: register(C2);
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
