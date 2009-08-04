//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- Difference
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Amount of alpha applied on effect
// ParameterType           :  double
// ParameterDefaultValue   :  1.0
// ParameterCoerce         :  Clamp(Alpha, 0.0, 1.0)
float Alpha : register(C0);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler   : register(S0);
sampler2D secondInput            : register(S1); 

float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
   float4 firstTexel    = tex2D(implicitInputSampler, uv); 
   float4 secondTexel   = tex2D(secondInput, uv); 

   float4 result;
   result.a = firstTexel.a;
   result.rgb = 1 - (firstTexel.a * firstTexel.rgb + secondTexel.a * secondTexel.rgb) / result.a;
   result.rgb = max(0, result.rgb);
   result.rgb = 1 - result.rgb;
   result.rgb = lerp(firstTexel.rgb, result.rgb, Alpha);

   return result;
}
