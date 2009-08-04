//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- Multiply
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Transition
// ParameterType           :  double
// ParameterDefaultValue   :  0.0
// ParameterCoerce         :  Clamp(Transition, 0.0, 1.0)
float Transition : register(C0);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler   : register(S0);
sampler2D secondInput            : register(S1); 

float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
   float4 firstTexel    = tex2D(implicitInputSampler, uv); 
   float4 secondTexel   = tex2D(secondInput, uv); 

   return lerp(firstTexel, secondTexel, Transition);
}
