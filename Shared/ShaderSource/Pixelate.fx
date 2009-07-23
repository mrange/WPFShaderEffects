//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- PixelateEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  PixelCount value
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(20.0, 20.0)
// ParameterCoerce         :  Clamp(PixelCount, MakePoint(20.0, 20.0), MakePoint(10000.0, 10000.0))
float2 PixelCount : register(C0);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float2 brickSize = 1.0 / PixelCount;

   // Offset every other row of bricks
   float2 offsetuv = uv;
   bool oddRow = floor(offsetuv.y / brickSize.y) % 2.0 >= 1.0;
   if (oddRow)
   {
       offsetuv.x += brickSize.x / 2.0;
   }
   
   float2 brickNum = floor(offsetuv / brickSize);
   float2 centerOfBrick = brickNum * brickSize + brickSize / 2;
   float4 color = tex2D(implicitInputSampler, centerOfBrick);

   return color;
}


