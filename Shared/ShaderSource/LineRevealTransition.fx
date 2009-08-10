float Progress : register(C0);
float2 LineOrigin : register(C1);
float2 LineNormal : register(C2);
float2 LineOffset : register(C3);
float FuzzyAmount : register(C4);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);

struct VS_OUTPUT
{
    float4 Position  : POSITION;
    float4 Color     : COLOR0;
    float2 UV        : TEXCOORD0;
};

float4 LineReveal(float2 uv)
{
	float2 currentLineOrigin = lerp(LineOrigin, LineOffset, Progress);
	float2 normLineNormal = normalize(LineNormal);
	float4 c1 = tex2D(oldInput, uv);
    float4 c2 = tex2D(implicitInput, uv);
    
	float distFromLine = dot(normLineNormal, uv-currentLineOrigin);
	float p = saturate((distFromLine + FuzzyAmount) / (2.0 * FuzzyAmount));
	return lerp(c2, c1, p);
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(VS_OUTPUT input) : COLOR0
{
	return LineReveal(input.UV);
}

