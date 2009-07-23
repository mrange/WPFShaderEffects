//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- DirectionalBlurEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Blur direction (in radians)
// ParameterType           :  double
// ParameterDefaultValue   :  0.1
// ParameterCoerce         :  Angle % (2.0 * Pi)
float Angle : register(C0);

// ParameterComment        :  Amount of blur
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
// ParameterCoerce         :  Clamp(BlurAmount, 0.0, double.MaxValue)
float BlurAmount : register(C1);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D  implicitInputSampler : register(S0);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 c = 0;
    float xOffset = cos(Angle);
    float yOffset = sin(Angle);

    for(int i=0; i<16; i++)
    {
        uv.x = uv.x - BlurAmount * xOffset;
        uv.y = uv.y - BlurAmount * yOffset;
        c += tex2D(implicitInputSampler, uv);
    }
    c /= 16;
    
    return c;
}