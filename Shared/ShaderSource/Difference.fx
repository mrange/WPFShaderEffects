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

// ParameterComment        :  Multiplier to apply at end of calculation (can be used invert the result)
// ParameterType           :  double
// ParameterDefaultValue   :  1.0
// ParameterCoerce         :  Clamp(Multiplier, -1.0, 1.0)
float Multiplier : register(C1);

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
   result.rgb = Multiplier * (firstTexel.a * firstTexel.rgb - secondTexel.a * secondTexel.rgb) / result.a;
   result.rgb = lerp(firstTexel.rgb, result.rgb, Alpha);

   return result;
}
