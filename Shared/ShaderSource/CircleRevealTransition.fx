float Progress : register(C0);
float FuzzyAmount : register(C1);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);

struct VS_OUTPUT
{
    float4 Position  : POSITION;
    float4 Color     : COLOR0;
    float2 UV        : TEXCOORD0;
};

float4 Circle(float2 uv)
{
	float radius = -FuzzyAmount + Progress * (0.70710678 + 2.0 * FuzzyAmount);
	float fromCenter = length(uv - float2(0.5,0.5));
	float distFromCircle = fromCenter - radius;
	
	float4 c1 = tex2D(oldInput, uv); 
    float4 c2 = tex2D(implicitInput, uv);
    
	float p = saturate((distFromCircle + FuzzyAmount) / (2.0 * FuzzyAmount));
	return lerp(c2, c1, p);
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(VS_OUTPUT input) : COLOR0
{
	return Circle(input.UV);
}

