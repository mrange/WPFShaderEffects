float Progress : register(C0);
float RandomSeed : register(C1);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);
sampler2D cloudInput : register(s2);

struct VS_OUTPUT
{
    float4 Position  : POSITION;
    float4 Color     : COLOR0;
    float2 UV        : TEXCOORD0;
};

float4 Water(float2 uv)
{
	float2 offset = tex2D(cloudInput, float2(uv.x / 10, frac(uv.y /10 + min(0.9, RandomSeed)))).xy * 2.0 - 1.0;
	float4 c1 = tex2D(oldInput, frac(uv + offset * Progress));
    float4 c2 = tex2D(implicitInput, uv);

	if (c1.a <= 0.0)
		return c2;
	else
		return lerp(c1, c2, Progress);
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(VS_OUTPUT input) : COLOR0
{
	return Water(input.UV);
}

