//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- SmoothMagnifyEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

float2 Center : register(C0);
float InnerRadius: register(C2);
float Magnification : register(c3);
float OuterRadius : register(c4);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{


   float2 Center_to_pixel = uv - Center; // vector from Center to pixel
   
	float distance = length(Center_to_pixel);
	
	float4 color;
	
	float2 sample_point;
	
	if(distance < OuterRadius) {
	
      if( distance < InnerRadius ) {
         sample_point = Center + (Center_to_pixel / Magnification);
	   }
	   else {
	      float radius_diff = OuterRadius - InnerRadius;
	      float ratio = (distance - InnerRadius ) / radius_diff; // 0 == inner radius, 1 == OuterRadius
	      ratio = ratio * 3.14159; //  -pi/2 .. pi/2	      
	      float adjusted_ratio = cos( ratio );  // -1 .. 1
	      adjusted_ratio = adjusted_ratio + 1;   // 0 .. 2
	      adjusted_ratio = adjusted_ratio / 2;   // 0 .. 1
	   
	      sample_point = ( (Center + (Center_to_pixel / Magnification) ) * (  adjusted_ratio)) + ( uv * ( 1 - adjusted_ratio) );
	   }
	}
	else {
	   sample_point = uv;
	}

	return tex2D( implicitInputSampler, sample_point );
	
}
