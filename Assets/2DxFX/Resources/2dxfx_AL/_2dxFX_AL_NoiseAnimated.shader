﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2016 //
/// http://unity3D.vetasoft.com/            //
//////////////////////////////////////////////

Shader "2DxFX/AL/NoiseAnimated"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_Distortion("Distortion", Range(0,1)) = 0
		_Color("_Color", Color) = (1,1,1,1)
		_Alpha("Alpha", Range(0,1)) = 1.0
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
	float _Distortion;
	fixed _Alpha;
	fixed4 _Color;

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

	inline float rand(float2 co) {
		return frac(sin(dot(co.xy ,float2(12.9898,78.233))) * 43758.5453 *(_Time + 1));
	}
	void surf(Input IN, inout SurfaceOutput o)
	{

		float4 tex = tex2D(_MainTex, IN.uv_MainTex);
		float4 noise = lerp(tex,rand(IN.uv_MainTex),_Distortion);

		noise.a = tex.a * 1 - _Alpha;
		float4 r = noise* IN.color;

		o.Albedo = r.rgb * r.a;
		o.Alpha = r.a;

		clip(o.Alpha - 0.05);
	}
	ENDCG
	}

		Fallback "Transparent/VertexLit"
}