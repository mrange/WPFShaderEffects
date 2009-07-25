//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- Sobel
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterDdxDdy         :  
float4 ddx_ddy : register(C2);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

const int NUM = 9;

const float pixelsize = 0.0078125;


const float2 c[9] = 
{
      float2(-1.00,-1.00),
      float2( 0.00,-1.00),
      float2( 1.00,-1.00),
      float2(-1.00, 0.00),
      float2( 0.00, 0.00),
      float2( 1.00, 0.00),
      float2(-1.00, 1.00), 
      float2( 0.00 ,1.00),
      float2( 1.00, 1.00),
};

float4 main(float2 uv : TEXCOORD) : COLOR
{
   const float3 rgb2lum = float3(0.30, 0.59, 0.11);
   
   float2x2 rotater =
      {
         ddx_ddy.x, ddx_ddy.y,
         ddx_ddy.z, ddx_ddy.w,
      };

   float3 col[9];    
   
   int i;
   for (i=0; i < 9; i++) 
   {
      col[i] = tex2D(implicitInputSampler, uv + mul(c[i], rotater));
   }

   float lum[9];
   for (i = 0; i < 9; i++) 
   {
      lum[i] = dot(col[i].xyz, rgb2lum);
   }

   float gy = 
       lum[0] + 2*lum[1] + lum[2]
      -lum[6] - 2*lum[7] - lum[8];
      
   float gx = 
       lum[0] + 2*lum[3] + lum[6]
      -lum[2] - 2*lum[5] - lum[8];

   float newlum = sqrt(gx * gx + gy * gy);

   float4 result;
   result.rgb = newlum.xxx;
   result.a = 1.0;
   
   return result;
}
