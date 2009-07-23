//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- ColorToneEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Desaturation value
// ParameterType           :  double
// ParameterDefaultValue   :  0.5
// ParameterCoerce         :  Clamp(Desaturation, 0.0, 1.0)
float Desaturation : register(C0);

// ParameterComment        :  Toned value
// ParameterType           :  double
// ParameterDefaultValue   :  0.5
// ParameterCoerce         :  Clamp(Toned, 0.0, 1.0)
float Toned : register(C1);

// ParameterComment        :  LightColor value
// ParameterType           :  Color
// ParameterDefaultValue   :  MakeColor(0xFF, 0x7F, 0x00)
float4 LightColor : register(C2);

// ParameterComment        :  DarkColor value
// ParameterType           :  Color
// ParameterDefaultValue   :  MakeColor(0x00, 0x3F, 0x7F)
float4 DarkColor : register(C3);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 scnColor = LightColor * tex2D(implicitInputSampler, uv);
    float gray = dot(float3(0.3, 0.59, 0.11), scnColor.rgb);
    
    float3 muted = lerp(scnColor.rgb, gray.xxx, Desaturation);
    float3 middle = lerp(DarkColor, LightColor, gray);
    
    scnColor.rgb = lerp(muted, middle, Toned);
    return scnColor;
}


