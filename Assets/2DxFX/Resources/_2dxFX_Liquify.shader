﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2016 //
/// http://unity3D.vetasoft.com/            //
//////////////////////////////////////////////

Shader "2DxFX/Standard/Liquify"
{
Properties
{
_MainTex ("Base (RGB)", 2D) = "white" {}
[HideInInspector] _MainTex2 ("Pattern (RGB)", 2D) = "white" {}
_Color ("_Color", Color) = (1,1,1,1)
_Distortion ("Distortion", Range(0,1)) = 0
_Alpha ("Alpha", Range (0,1)) = 1.0
_Speed ("Speed", Range (0,1)) = 1.0
EValue ("EValue", Range (0,1)) = 1.0
Light ("Light", Range (0,1)) = 1.0
TurnToLiquid ("TurnToLiquid", Range (0,1)) = 1.0
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
#pragma fragmentoption ARB_precision_hint_fastest
#pragma target 3.0
#include "UnityCG.cginc"

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


sampler2D _MainTex;
sampler2D _MainTex2;
float _Distortion;
fixed _Alpha;
float _Speed;
float EValue;
fixed4 _Color;
float Light;
float TurnToLiquid;

v2f vert(appdata_t IN)
{
v2f OUT;
OUT.vertex = mul(UNITY_MATRIX_MVP, IN.vertex);
OUT.texcoord = IN.texcoord;
OUT.color = IN.color;

return OUT;
}

float4 frag (v2f i) : COLOR
{
float2 p = i.texcoord.xy;
fixed c1=1;
float noffset=TurnToLiquid*sin(p.x*16*(TurnToLiquid+1))/2;
float _ClipUp=1-TurnToLiquid*2;
c1= saturate(((1+noffset)/(1-_ClipUp+0.04))*(1-i.texcoord.y)-noffset);
float r=1-c1+sin(p.x*_Distortion)*TurnToLiquid/3+TurnToLiquid/2;
//float r=1-c1+sin(p.x*_Distortion)*TurnToLiquid/3+TurnToLiquid/2;
p.y+=r;
float2 p2=i.texcoord.xy;
p2.y+=TurnToLiquid-0.5;
p2/=3;
float4 col2 = tex2D(_MainTex2,p2);

col2*=TurnToLiquid*20;
p+=float2(col2.r/16,col2.g/16);
p-=TurnToLiquid;

fixed4 col = tex2D(_MainTex,p)*i.color;

col.rgb+=r/2;
col.rgb+=col2.rgb/8;


fixed alpha=1-((0.4+p.y)*TurnToLiquid*2);
return float4(col.rgb,col.a*alpha*(1-_Alpha));
}

ENDCG
}
}
Fallback "Sprites/Default"

}