﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2016 //
/// http://unity3D.vetasoft.com/            //
//////////////////////////////////////////////

Shader "2DxFX/AL/SkyCloud"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_MainTex2("Pattern (RGB)", 2D) = "white" {}
	_Alpha("Alpha", Range(0,1)) = 1.0
		_OffsetX("OffsetX", Range(0,1)) = 0
		_OffsetY("OffsetY", Range(0,1)) = 0
		_Zoom("Zoom", Range(0,1)) = 0
		_Intensity("Intensity", Range(0,1)) = 0
		_Color("Tint", Color) = (1,1,1,1)
		[HideInInspector]_SrcBlend("_SrcBlend", Float) = 0
		[HideInInspector]_DstBlend("_DstBlend", Float) = 0
		[HideInInspector]_BlendOp("_BlendOp",Float) = 0
		[HideInInspector]_Z("_Z", Float) = 0
	}

		SubShader
	{
		Tags
	{
		"IgnoreProjector" = "True"
		"RenderType" = "TransparentCutout"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}
		Cull Off
		Lighting Off
		ZWrite[_Z]
		BlendOp[_BlendOp]
		Blend[_SrcBlend][_DstBlend]

		CGPROGRAM
#pragma surface surf Lambert vertex:vert nofog keepalpha addshadow fullforwardshadows

		sampler2D _MainTex;
	sampler2D _MainTex2;
	fixed4 _Color;
	fixed _Alpha;
	float _OffsetX;
	float _OffsetY;
	float _Zoom;
	float _Intensity;


	struct Input
	{
		float2 uv_MainTex;
		fixed4 color;
	};

	void vert(inout appdata_full v, out Input o)
	{
		v.vertex = UnityPixelSnap(v.vertex);
		UNITY_INITIALIZE_OUTPUT(Input, o);
		o.color = v.color * _Color;
	}

	void surf(Input IN, inout SurfaceOutput o)
	{

		float2 p = IN.uv_MainTex;
		fixed4 t = tex2D(_MainTex, p);
		p *= _Zoom;
		fixed4 c = tex2D(_MainTex2, p + float2(_OffsetX,_OffsetY))*IN.color;
		c.rgb = t.rgb - (c.rgb*_Intensity);
		c.a = c.a * t.a - _Alpha;


		o.Albedo = c.rgb * c.a;
		o.Alpha = c.a;

		clip(o.Alpha - 0.05);
	}
	ENDCG
	}

		Fallback "Sprites/Default"
}