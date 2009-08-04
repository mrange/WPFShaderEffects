//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- Alpha
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Amount of alpha on input
// ParameterType           :  double
// ParameterDefaultValue   :  1.0
// ParameterCoerce         :  Clamp(Alpha, 0.0, 1.0)
float Alpha : register(C0);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler   : register(S0);

float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
   float4 firstTexel    = tex2D(implicitInputSampler, uv); 

   firstTexel.a *= Alpha;

   return firstTexel;
}
