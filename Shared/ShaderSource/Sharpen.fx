//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- SharpenEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

// ParameterComment        :  Amount of sharpness
// ParameterType           :  double
// ParameterDefaultValue   :  0.4
// ParameterCoerce         :  Clamp(Amount, -1.0, 1.0)
float Amount : register(C0);

// ParameterComment        :  Width of sharpness in pixels
// ParameterType           :  double
// ParameterDefaultValue   :  2.0
// ParameterCoerce         :  Clamp(Width, 0.0, double.MaxValue)
float Width : register(C1);

// ParameterDdxDdy         :  
float4 ddx_ddy : register(C2);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   float2x2 rotater =
      {
         ddx_ddy.x, ddx_ddy.y,
         ddx_ddy.z, ddx_ddy.w,
      };

   float2 top_left      = { -1.0, -1.0 };
   float2 bottom_right  = {  1.0,  1.0 };
      
   float4 color = tex2D(implicitInputSampler, uv);
   color.rgb += tex2D(implicitInputSampler, uv + Width * mul(top_left, rotater)) * Amount;
   color.rgb -= tex2D(implicitInputSampler, uv + Width * mul(bottom_right, rotater)) * Amount;
   return color;
}


