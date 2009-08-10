float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);

struct VS_OUTPUT
{
    float4 Position  : POSITION;
    float4 Color     : COLOR0;
    float2 UV        : TEXCOORD0;
};

float4 Ripple(float2 uv)
{
	float frequency = 20;
	float speed = 10;
	float amplitude = 0.05;
	float2 center = float2(0.5,0.5);
	float2 toUV = uv - center;
	float distanceFromCenter = length(toUV);
	float2 normToUV = toUV / distanceFromCenter;

	float wave = cos(frequency * distanceFromCenter - speed * Progress);
	float offset1 = Progress * wave * amplitude;
	float offset2 = (1.0 - Progress) * wave * amplitude;
	
	float2 newUV1 = center + normToUV * (distanceFromCenter + offset1);
	float2 newUV2 = center + normToUV * (distanceFromCenter + offset2);
	
	float4 c1 = tex2D(oldInput, newUV1); 
    float4 c2 = tex2D(implicitInput, newUV2);

	return lerp(c1, c2, Progress);
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(VS_OUTPUT input) : COLOR0
{
	return Ripple(input.UV);
}

