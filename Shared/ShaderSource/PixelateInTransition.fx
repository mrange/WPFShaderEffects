float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);



float4 PixelateIn(float2 uv)
{
	float pixels = 10 + 1000 * Progress * Progress;
	float2 newUV = round(uv * pixels) / pixels;
    float4 c2 = tex2D(implicitInput, newUV);

	return c2;
}


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD0) : COLOR0
{
	return PixelateIn(uv);
}

