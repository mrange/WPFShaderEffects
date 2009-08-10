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

float4 Wave(float2 uv)
{
	float mag = 0.1;
	float phase = 14;
	float freq = 20;
	
	float2 newUV = uv + float2(mag * Progress * sin(freq * uv.y + phase * Progress), 0);
	
	float4 c1 = SampleWithBorder(0, oldInput, newUV);
    float4 c2 = tex2D(implicitInput, uv);

    return lerp(c1,c2, Progress);
}

float4 StandingWave(float2 uv)
{
	float pi = 3.141592;
	float mag = 0.01;
	float freq = 8 * pi;
	float freq2 = 6 * pi;
	
	float2 newUV = uv + mag * sin(Progress*freq2) * float2(cos(freq * uv.x), sin(freq * uv.y));
	
	float4 c1 = tex2D(oldInput, frac(newUV));
    float4 c2 = tex2D(implicitInput, uv);

    return lerp(c1,c2, Progress);
}

float4 MotionBlur(float2 uv)
{
	float4 c1 = 0;
	int count = 26;
	float2 direction = float2(0.05, 0.05);
	float2 offset = Progress * direction;
	float2 startUV = uv - offset * 0.5;
	float2 delta = offset / (count-1);
	
	for(int i=0; i<count; i++)
	{
		c1 += tex2D(oldInput, startUV + delta*i);
	}
	
	c1 /= count;
    return c1;
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD0) : COLOR0
{
	return Wave(uv);
}

