float Progress : register(C0);
sampler2D implicitInput : register(S0);
sampler2D oldInput : register(S1);

struct VS_OUTPUT
{
    float4 Position  : POSITION;
    float4 Color     : COLOR0;
    float2 UV        : TEXCOORD0;
};

float DistanceFromCenterToSquareEdge(float2 dir)
{
	dir = abs(dir);
	float dist = dir.x > dir.y ? dir.x : dir.y;
	return dist;
}

float4 CircleStretch(float2 uv)
{
	float2 center = float2(0.5,0.5);
	float radius = Progress * 0.70710678;
	float2 toUV = uv - center;
	float len = length(toUV);
	float2 normToUV = toUV / len;
	
	if(len < radius)
	{
		float distFromCenterToEdge = DistanceFromCenterToSquareEdge(normToUV) / 2.0;
		float2 edgePoint = center + distFromCenterToEdge * normToUV;
	
		float minRadius = min(radius, distFromCenterToEdge);
		float percentFromCenterToRadius = len / minRadius;
		
		float2 newUV = lerp(center, edgePoint, percentFromCenterToRadius);
		return tex2D(implicitInput, newUV);
	}
	else
	{
		float distFromCenterToEdge = DistanceFromCenterToSquareEdge(normToUV);
		float2 edgePoint = center + distFromCenterToEdge * normToUV;
		float distFromRadiusToEdge = distFromCenterToEdge - radius;
		
		float2 radiusPoint = center + radius * normToUV;
		float2 radiusToUV = uv - radiusPoint;
		
		float percentFromRadiusToEdge = length(radiusToUV) / distFromRadiusToEdge;
		
		float2 newUV = lerp(center, edgePoint, percentFromRadiusToEdge);
		return tex2D(oldInput, newUV);
	}
}


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------
float4 main(VS_OUTPUT input) : COLOR0
{
	return CircleStretch(input.UV);
}

