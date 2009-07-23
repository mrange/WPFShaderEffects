//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- ToneMappingEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Exposure value of tone mapping effect
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
float Exposure : register(C0);

// ParameterComment        :  Defog value of tone mapping effect
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
float Defog : register(C1);

// ParameterComment        :  Gamma value of tone mapping effect
// ParameterType           :  double
// ParameterDefaultValue   :  0.1
float Gamma : register(C2);

// ParameterComment        :  FogColor value of tone mapping effect
// ParameterType           :  Color
// ParameterDefaultValue   :  MakeColor(0xAF, 0xAF, 0xAF)
float4 FogColor : register(C3);

// ParameterComment        :  VignetteRadius value of tone mapping effect
// ParameterType           :  double
// ParameterDefaultValue   :  0.1
// ParameterCoerce         :  Clamp(VignetteRadius, 0.0, double.MaxValue)
float VignetteRadius : register(C4);

// ParameterComment        :  VignetteCenter value of tone mapping effect
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(0.5,0.5)
float2 VignetteCenter : register(C5);

// ParameterComment        :  BlueShift value of tone mapping effect
// ParameterType           :  double
// ParameterDefaultValue   :  0.1
// ParameterCoerce         :  Clamp(BlueShift, 0.0, 1.0)
float BlueShift : register(C6);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 c = tex2D(implicitInputSampler, uv);
    c.rgb = max(0, c.rgb - Defog * FogColor.rgb);
    c.rgb *= pow(2.0f, Exposure);
    c.rgb = pow(c.rgb, Gamma);

    float2 tc = uv - VignetteCenter;
    float v = 1.0f - dot(tc, tc);
    c.rgb += pow(v, 4) * VignetteRadius;

    float3 d = c.rgb * float3(1.05f, 0.97f, 1.27f);
    c.rgb = lerp(c.rgb, d, BlueShift);
    
    return c;
}


