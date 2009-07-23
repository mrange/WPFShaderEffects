//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- EmbossedEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Amount of emboss
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
// ParameterCoerce         :  Clamp(Amount, -1.0, 1.0)
float Amount : register(C0);

// ParameterComment        :  Width of emboss
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
    float4 outC = {0.5, 0.5, 0.5, 1.0};

    outC -= tex2D(implicitInputSampler, uv - Width) * Amount;
    outC += tex2D(implicitInputSampler, uv + Width) * Amount;
    outC.rgb = (outC.r + outC.g + outC.b) / 3.0f;

    return outC;
}


