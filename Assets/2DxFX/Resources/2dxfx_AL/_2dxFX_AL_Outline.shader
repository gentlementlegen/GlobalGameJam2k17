﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2016 //
/// http://unity3D.vetasoft.com/            //
//////////////////////////////////////////////

Shader "2DxFX/AL/Outline"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_OutLineSpread("Outline Spread", Range(0,0.01)) = 0.007
		_Color("Tint", Color) = (1,1,1,1)
		_ColorX("Tint", Color) = (1,1,1,1)
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
	float _OutLineSpread;
	fixed4 _Color;
	fixed4 _ColorX;

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




		fixed4 mainColor = (tex2D(_MainTex, IN.uv_MainTex + float2(-_OutLineSpread,_OutLineSpread))
			+ tex2D(_MainTex, IN.uv_MainTex + float2(_OutLineSpread,-_OutLineSpread))
			+ tex2D(_MainTex, IN.uv_MainTex + float2(_OutLineSpread,_OutLineSpread))
			+ tex2D(_MainTex, IN.uv_MainTex - float2(_OutLineSpread,_OutLineSpread)));

		mainColor.rgb = _ColorX.rgb;

		fixed4 addcolor = tex2D(_MainTex, IN.uv_MainTex)*IN.color;

		if (mainColor.a > 0.40) { mainColor = _ColorX; }
		if (addcolor.a > 0.40) { mainColor = addcolor; mainColor.a = addcolor.a; }

		float4 r = mainColor*IN.color.a;


		o.Albedo = r.rgb * r.a;
		o.Alpha = r.a;

		clip(o.Alpha - 0.05);
	}
	ENDCG
	}

		Fallback "Transparent/VertexLit"
}