float Progress : register(C0);
float2 TwistAmount : register(C1);
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

float4 SwirlGrid(float2 uv)
{
	float cellcount = 10;
	float cellsize = 1.0 / cellcount;
	
	float2 cell = floor(uv * cellcount);
	float2 oddeven = fmod(cell, 2.0);
	float cellTwistAmount = TwistAmount;
	if (oddeven.x < 1.0)
	{
		cellTwistAmount *= -1;
	}
	if (oddeven.y < 1.0)
	{
		cellTwistAmount *= -1;
	}
		
	float2 newUV = frac(uv * cellcount);
	
	float2 center = float2(0.5,0.5);
	float2 toUV = newUV - center;
	float distanceFromCenter = length(toUV);
	float2 normToUV = toUV / distanceFromCenter;
	float angle = atan2(normToUV.y, normToUV.x);
	
	angle += distanceFromCenter * distanceFromCenter * cellTwistAmount * Progress;
	float2 newUV2;
	sincos(angle, newUV2.y, newUV2.x);
	newUV2 *= distanceFromCenter;
	newUV2 += center;
	
	newUV2 *= cellsize;
	newUV2 += cell * cellsize;
	
	float4 c1 = tex2D(oldInput, newUV2);
    float4 c2 = tex2D(implicitInput, uv);

    return lerp(c1,c2, Progress);
}


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD0) : COLOR0
{
	return SwirlGrid(uv);
}

