//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- MonoChromeEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Monochrome color
// ParameterType           :  Color
// ParameterDefaultValue   :  MakeColor(0x7F, 0x7F, 0x7F)
float4 FilterColor : register(C0);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D  implicitInputSampler : register(S0);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float2 texuv = uv;
   float4 srcColor = tex2D(implicitInputSampler, texuv);
   float4 luminance = srcColor.r*0.30 + srcColor.g*0.59 + srcColor.b*0.11;
   luminance.a = 1.0;

   return luminance * FilterColor;
}


