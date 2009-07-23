//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- PinchEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Center of pinching
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(0.5,0.5)
float2 Center : register(C0);

// ParameterComment        :  Radius of pinching
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
// ParameterCoerce         :  Clamp(Radius, 0.0, double.MaxValue)
float Radius : register(C1);

// ParameterComment        :  Amount of pinching
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
// ParameterCoerce         :  Clamp(Amount, 0.0, double.MaxValue)
float Amount : register(C2);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 displace = Center - uv;
    float range = saturate(1 - (length(displace) / (abs(-sin(Radius * 8) * Radius) + 0.00000001F)));
    return tex2D(implicitInputSampler, uv + displace * range * Amount);
}


