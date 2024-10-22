﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2016 //
/// http://unity3D.vetasoft.com/            //
//////////////////////////////////////////////

Shader "2DxFX/AL/ColorChange"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_Color("Tint", Color) = (1,1,1,1)
		_ColorX("Tint", Color) = (1,1,1,1)
		_HueShift("Hue", Range(0,1)) = 1.0
		_Alpha("Alpha", Range(0,1)) = 1.0
		_Tolerance("Tolerance", Range(0,1)) = 1.0
		_Sat("Saturation", Float) = 1
		_Val("Value", Float) = 1
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

#pragma target 3.0
		sampler2D _MainTex;
	float _Size;
	float _HueShift;
	float _Tolerance;
	fixed4 _Color;
	fixed4 _ColorX;
	fixed _Alpha;
	float _Sat;
	float _Val;

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
	float3 shift_col(float3 RGB, float3 shift)
	{

		float3 RESULT = float3(RGB);
		float a1 = shift.z*shift.y;
		float a2 = shift.x*3.14159265 / 180;
		float VSU = a1*cos(a2);
		float VSW = a1*sin(a2);

		RESULT.x = (.299*shift.z + .701*VSU + .168*VSW)*RGB.x
			+ (.587*shift.z - .587*VSU + .330*VSW)*RGB.y
			+ (.114*shift.z - .114*VSU - .497*VSW)*RGB.z;

		RESULT.y = (.299*shift.z - .299*VSU - .328*VSW)*RGB.x
			+ (.587*shift.z + .413*VSU + .035*VSW)*RGB.y
			+ (.114*shift.z - .114*VSU + .292*VSW)*RGB.z;

		RESULT.z = (.299*shift.z - .3*VSU + 1.25*VSW)*RGB.x
			+ (.587*shift.z - .588*VSU - 1.05*VSW)*RGB.y
			+ (.114*shift.z + .886*VSU - .203*VSW)*RGB.z;

		return (RESULT);
	}
	void surf(Input IN, inout SurfaceOutput o)
	{


		fixed4 c = tex2D(_MainTex,  IN.uv_MainTex)*IN.color;
		float3 shift = float3(_HueShift, _Sat, _Val);
		float3 shifted = shift_col(c, shift);

		float3 c1 = c.rgb;
		c1 = c1 - _ColorX.rgb;
		c1 = abs(c1);
		if (c1.r<_Tolerance) c.rgb = shifted;
		if (c1.g<_Tolerance) c.rgb = shifted;
		if (c1.b<_Tolerance) c.rgb = shifted;

		c.a = c.a - _Alpha;



		o.Albedo = c.rgb * c.a;
		o.Alpha = c.a;

		clip(o.Alpha - 0.05);
	}
	ENDCG
	}

		Fallback "Transparent/VertexLit"
}