float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);



float4 Saturate(float2 uv)
{
	float4 c1 = tex2D(oldInput, uv); 
	c1 = saturate(c1 * (2 * Progress + 1));
    float4 c2 = tex2D(implicitInput, uv);

	if ( Progress > 0.8)
	{
		float new_Progress = (Progress - 0.8) * 5.0;
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
	return Saturate(uv);
}

