// TODO: Replace ScreenSize with ddxDdy 
//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- GrowablePoissonDiskEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Radius of disc
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
// ParameterCoerce         :  Clamp(DiscRadius, 0.0, 1.0)
float DiscRadius : register(C0);

// ParameterComment        :  Size of screen
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(100.0, 100.0)
// ParameterCoerce         :  Clamp(ScreenSize, MakePoint(1.0, 1.0), MakePoint(double.MaxValue, double.MaxValue))
float2 ScreenSize : register(C1);

static const float2 poisson[12] = 
{
        float2(-0.326212f, -0.40581f),
        float2(-0.840144f, -0.07358f),
        float2(-0.695914f, 0.457137f),
        float2(-0.203345f, 0.620716f),
        float2(0.96234f, -0.194983f),
        float2(0.473434f, -0.480026f),
        float2(0.519456f, 0.767022f),
        float2(0.185461f, -0.893124f),
        float2(0.507431f, 0.064425f),
        float2(0.89642f, 0.412458f),
        float2(-0.32194f, -0.932615f),
        float2(-0.791559f, -0.59771f)
};

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 cOut;

    // Center tap
    cOut = tex2D(implicitInputSampler, uv);
    for(int tap = 0; tap < 12; tap++)
    {
        float2 coord= uv.xy + ((poisson[tap] / ScreenSize) * DiscRadius);
        // Sample pixel
        cOut += tex2D(implicitInputSampler, coord);
    }

    return(cOut / 13.0f);
}


