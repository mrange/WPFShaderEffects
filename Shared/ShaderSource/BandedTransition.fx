
// ParameterComment        :  Progress of transition
// ParameterType           :  double
// ParameterDefaultValue   :  0.0
// ParameterCoerce         :  Clamp(Progress, 0.0, 1.0)
float Progress : register(C0);

// ParameterComment        :  Height of bands
// ParameterType           :  double
// ParameterDefaultValue   :  0.2
// ParameterCoerce         :  Clamp(BandHeight, 0.0, 1.0)
float BandHeight : register(C1);

// ParameterComment        :  Offset of bands
// ParameterType           :  double
// ParameterDefaultValue   :  0.0
// ParameterCoerce         :  Clamp(BandOffset, 0.0, 1.0)
float BandOffset : register(C2);

// ParameterDdxDdy         :  
float4 ddx_ddy : register(C3);

sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(float2 uv : TEXCOORD0) : COLOR0
{
   float4 oldColor = tex2D(oldInput, uv);

	float choice = ((uv.y + BandOffset) / max(max(BandHeight, ddx_ddy.w), 0.000001)) % 2;
	
	float invertedProgress = 1.0 - Progress;
	
	float4 newColor;
	
	if (choice > 1.0)
	{
	   if (uv.x > invertedProgress)
	   {
	      newColor = tex2D(implicitInput, float2(uv.x - invertedProgress, uv.y));
	   }
	   else
	   {
	      newColor = oldColor;
	   }
	}
	else
	{
	   if (uv.x < Progress)
	   {
	      newColor = tex2D(implicitInput, float2(invertedProgress + uv.x, uv.y));
	   }
	   else
	   {
	      newColor = oldColor;
	   }
	}
	
	return lerp(oldColor, newColor, Progress);
}

