float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);


float4 MostBright(float2 uv)
{
    int c = 4;
	int c2 = 3;
	float oc = (c -1) / 2;
	float oc2 = (c2 -1) / 2;
	float offset = 0.01 * Progress;
	
	float mostBright = 1;
	float4 mostBrightColor;
	for(int y=0; y<c; y++)
	{
		for(int x=0; x<c2; x++)
		{
			float2 newUV = uv + (float2(x, y) - float2(oc2, oc)) * offset;
			float4 color = tex2D(oldInput, newUV);
			float brightness = dot(color.rgb, float3(1,1.1,0.9));
			if(brightness > mostBright)
			{
				mostBright = brightness;
				mostBrightColor = color;
			}
		}
	}
	
	float4 impl = tex2D(implicitInput, uv);	 
	   
	return lerp(mostBrightColor,impl, Progress);
}

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD0) : COLOR0
{
	return MostBright(uv);
}

