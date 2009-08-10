float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);

struct VS_OUTPUT
{
    float4 Position  : POSITION;
    float4 Color     : COLOR0;
    float2 UV        : TEXCOORD0;
};

float4 Blinds(float2 uv)
{		
	if(frac(uv.y * 5) < Progress)
	{
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
	return Blinds(input.UV);
}

