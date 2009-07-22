//--------------------------------------------------------------------------------------
//
// WPF ShaderEffect HLSL -- BandedSwirlEffect
// Swirl shader with bands going in different directions
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

float2 Center : register(C0);
float SpiralStrength : register(C1);
float DistanceThreshold : register(C2);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float2 dir = uv - Center;
   float l = length(dir);
   
   dir = dir/l;
   float angle = atan2(dir.y, dir.x);

   float remainder = frac(l / DistanceThreshold);

   float preTransitionWidth = 0.25;
   float fac;   

   if (remainder < .25)
   {
      fac = 1.0;
   }
   else if (remainder < 0.5)
   {
      // transition zone - go smoothly from previous zone to next.
      fac = 1 - 8 * (remainder - preTransitionWidth);
   }
   else if (remainder < 0.75)
   {
      fac = -1.0;
   }
   else
   {
      // transition zone - go smoothly from previous zone to next.
      fac = -(1 - 8 * (remainder - 0.75));
   }

   float newAng = angle + fac * SpiralStrength * l;
  
   float xAmt = cos(newAng) * l;
   float yAmt = sin(newAng) * l;
      
   float2 newCoord = Center + float2(xAmt, yAmt);
   
   return tex2D( implicitInputSampler, newCoord );
}
