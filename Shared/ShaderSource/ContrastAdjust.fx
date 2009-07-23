//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- ContrastAdjustEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Brightness color
// ParameterType           :  Color
// ParameterDefaultValue   :  MakeColor(0x2F, 0x2F, 0x2F)
float4 Brightness : register(C0);

// ParameterComment        :  Contrast value
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
// ParameterCoerce         :  Clamp(Contrast, 0.0, 1.0)
float Contrast : register(C1);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 pixelColor = tex2D(implicitInputSampler, uv);
    
    //contrast
    pixelColor.rgb = (pixelColor.rgb - 0.5f) * Contrast + 0.5f;
    
    //brightness
    pixelColor.rgb = pixelColor.rgb + Brightness;
    
    // return final pixel color
    return pixelColor;
}


