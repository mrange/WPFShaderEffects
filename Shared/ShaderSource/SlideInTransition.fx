float Progress : register(C0);
float2 SlideAmount : register(C1);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);

struct VS_OUTPUT
{
    float4 Position  : POSITION;
    float4 Color     : COLOR0;
    float2 UV        : TEXCOORD0;
};

float4 SlideLeft(float2 uv)
{
	uv += SlideAmount * Progress;
	if(any(saturate(uv)-uv))
	{	
		uv = frac(uv);
		return tex2D(implicitInput, uv);
	}
	else
	{
		return tex2D(oldInput, uv);
	}
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(VS_OUTPUT input) : COLOR0
{
	return SlideLeft(input.UV);
}

