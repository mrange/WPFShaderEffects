float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);

float4 Pixelate(float2 uv)
{
	float pixels;
	float segment_Progress;
	if (Progress < 0.5)
	{
		segment_Progress = 1 - Progress * 2;
	}
	else
	{		
		segment_Progress = (Progress - 0.5) * 2;

	}
    
    pixels = 5 + 1000 * segment_Progress * segment_Progress;
	float2 newUV = round(uv * pixels) / pixels;
	
    float4 c1 = tex2D(oldInput, newUV);
    float4 c2 = tex2D(implicitInput, newUV);

	float lerp_Progress = saturate((Progress - 0.4) / 0.2);
	return lerp(c1,c2, lerp_Progress);	
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD0) : COLOR0
{
	return Pixelate(uv);
}

