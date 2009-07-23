//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- MagnifyEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Radii of Magnify
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(0.1,0.1)
// ParameterCoerce         :  Clamp(Radii, MakePoint(0.00001, 0.00001), MakePoint(double.MaxValue, double.MaxValue))
float2 Radii : register(C0);

// ParameterComment        :  Center of Magnify
// ParameterType           :  Point
// ParameterDefaultValue   :  MakePoint(0.5,0.5)
float2 Center : register(C1);

// ParameterComment        :  Amount of Magnify
// ParameterType           :  double
// ParameterDefaultValue   :  2.0
float  Amount : register(C2);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D  implicitInputSampler : register(S0);

//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float2 origUv = uv;
   float2 ray = origUv - Center;
   float2 rt = ray / Radii;

   // Outside of Radii, we jus show the regular image.  Radii is ellipse Radii, so width x height radius 
   float lengthRt = length(rt);
   
   float2 texuv;
   if (lengthRt > 1)
   {
       texuv = origUv;
   }
   else
   {
       texuv = Center + Amount * ray;
   }
   
   return tex2D(implicitInputSampler, texuv);
}

