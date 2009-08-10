float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);


float4 PixelateOut(float2 uv)
{
	float pixels = max(4, 100 * (1.0 - Progress));
	float2 newUV = round(uv * pixels) / pixels;
    float4 c1 = tex2D(oldInput, newUV);
    float4 c2 = tex2D(implicitInput, uv);

	if (Progress > 0.8)
	{
		float new_Progress = (Progress - 0.8) * 5;
		return lerp(c1,c2, new_Progress);	
	}
	else
	{
		return c1;
	}
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD0) : COLOR0
{
	return PixelateOut(uv);
}

