﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2016 //
/// http://unity3D.vetasoft.com/            //
//////////////////////////////////////////////

Shader "2DxFX/Standard/SkyCloud"
{
Properties
{
_MainTex ("Base (RGB)", 2D) = "white" {}
_MainTex2 ("Pattern (RGB)", 2D) = "white" {}
_Alpha ("Alpha", Range (0,1)) = 1.0
_OffsetX ("OffsetX", Range (0,1)) = 0
_OffsetY ("OffsetY", Range (0,1)) = 0
_Zoom ("Zoom", Range (0,1)) = 0
_Intensity ("Intensity", Range (0,1)) = 0
_Color ("Tint", Color) = (1,1,1,1)
// required for UI.Mask
_StencilComp ("Stencil Comparison", Float) = 8
_Stencil ("Stencil ID", Float) = 0
_StencilOp ("Stencil Operation", Float) = 0
_StencilWriteMask ("Stencil Write Mask", Float) = 255
_StencilReadMask ("Stencil Read Mask", Float) = 255
_ColorMask ("Color Mask", Float) = 15

}

SubShader
{

Tags {"Queue"="Transparent" "IgnoreProjector"="true" "RenderType"="Transparent"}
ZWrite Off Blend SrcAlpha OneMinusSrcAlpha Cull Off

// required for UI.Mask
Stencil
{
Ref [_Stencil]
Comp [_StencilComp]
Pass [_StencilOp] 
ReadMask [_StencilReadMask]
WriteMask [_StencilWriteMask]
}


Pass
{
CGPROGRAM

#pragma vertex vert
#pragma fragment frag

struct appdata_t
{
float4 vertex   : POSITION;
float4 color    : COLOR;
float2 texcoord : TEXCOORD0;
};

struct v2f
{
half2 texcoord  : TEXCOORD0;
float4 vertex   : SV_POSITION;
fixed4 color    : COLOR;
};



v2f vert(appdata_t IN)
{
v2f OUT;
OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
OUT.texcoord = IN.texcoord;
OUT.color = IN.color;

return OUT;
}

sampler2D _MainTex;
sampler2D _MainTex2;
fixed4 _Color;
fixed _Alpha;
float _OffsetX;
float _OffsetY;
float _Zoom;
float _Intensity;

fixed4 frag(v2f IN) : COLOR
{
float2 p=IN.texcoord;
fixed4 t =  tex2D(_MainTex, p);
p*=_Zoom;
fixed4 t2 = tex2D(_MainTex2, p+float2(_OffsetX,_OffsetY))*IN.color;
t2.rgb = t.rgb - (t2.rgb*_Intensity);
t2.a = t2.a * t.a - _Alpha;
return t2;
}
ENDCG
}
}
Fallback "Sprites/Default"

}