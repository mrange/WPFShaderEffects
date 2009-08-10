float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);


float4 SampleWithBorder(float4 border, sampler2D tex, float2 uv)
{
	if (any(saturate(uv) - uv))
	{
		return border;
	}
	else
	{
		return tex2D(tex, uv);
	}
}

float4 Shrink(float2 uv)
{
	float speed = 200;
	float2 center = float2(0.5,0.5);
	float2 toUV = uv - center;
	float distanceFromCenter = length(toUV);
	float2 normToUV = toUV / distanceFromCenter;
	
	float2 newUV = center + normToUV * (distanceFromCenter * (Progress * speed + 1));
	
	float4 c1 = SampleWithBorder(float4(0,0,0,0), oldInput, newUV); 

	if(c1.a <= 0)
	{
		return tex2D(implicitInput, uv);
	}
	
	return c1;

}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD0) : COLOR0
{
	return Shrink(uv);
}

