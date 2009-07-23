//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- SharpenEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Amount of sharpness
// ParameterType           :  double
// ParameterDefaultValue   :  0.1
// ParameterCoerce         :  Clamp(Amount, -1.0, 1.0)
float Amount : register(C0);

// ParameterComment        :  Width of sharpness
// ParameterType           :  double
// ParameterDefaultValue   :  0.01
// ParameterCoerce         :  Clamp(Width, 0.0, 1.0)
float Width : register(C1);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInputSampler, uv);
    color.rgb += tex2D(implicitInputSampler, uv - Width) * Amount;
    color.rgb -= tex2D(implicitInputSampler, uv + Width) * Amount;
    return color;
}


