﻿//////////////////////////////////////////////
/// 2DxFX - 2D SPRITE FX - by VETASOFT 2016 //
//////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
[AddComponentMenu ("2DxFX/Advanced Lightning/Mystic_Distortion")]
[System.Serializable]
public class _2dxFX_AL_Mystic_Distortion : MonoBehaviour
{
[HideInInspector] public Material ForceMaterial;
// Advanced Lightning
[HideInInspector] public bool ActiveChange = true;
[HideInInspector] public bool AddShadow = true;
[HideInInspector] public bool ReceivedShadow = false;
[HideInInspector] public int BlendMode = 0;

private string shader = "2DxFX/AL/Mystic_Distortion";
[HideInInspector] [Range(0, 1)] public float _Alpha = 1f;
[HideInInspector] [Range(0f, 0.45f)] public float _Pitch = 0.45f;
[HideInInspector] public bool Pitch_Wave=true; 
[HideInInspector] [Range(0f, 16f)] public float _Pitch_Speed = 1.0f;
[HideInInspector] [Range(0f, 1f)] public float _Pitch_Offset = 0.0f;
[HideInInspector] [Range(0f, 128f)] public float _OffsetX = 56f;
[HideInInspector] [Range(0f, 128f)] public float _OffsetY = 28f;
[HideInInspector] [Range(0f, 1f)] public float _DistanceX = 0.01f;
[HideInInspector] [Range(0f, 1f)] public float _DistanceY = 0.04f;
[HideInInspector] [Range(0f, 6.28f)] public float _WaveTimeX = 1.16f;
[HideInInspector] [Range(0f, 6.28f)] public float _WaveTimeY = 5.12f;
[HideInInspector] public bool AutoPlayWaveX=false; 
[HideInInspector] [Range(0f, 5f)] public float AutoPlaySpeedX=5f;
[HideInInspector] public bool AutoPlayWaveY=false;
[HideInInspector] [Range(0f, 50f)] public float AutoPlaySpeedY=5f;
[HideInInspector] public bool AutoRandom=false;
[HideInInspector] [Range(0f, 50f)] public float AutoRandomRange=10f;

[HideInInspector] public int ShaderChange=0;
Material tempMaterial;
Material defaultMaterial;
Image CanvasImage;


void Awake()
{
if (this.gameObject.GetComponent<Image> () != null) 
{
CanvasImage = this.gameObject.GetComponent<Image> ();
}
}
void Start ()
{  
ShaderChange = 0;
}

public void CallUpdate()
{
Update ();
}

void Update()
{
if (this.gameObject.GetComponent<Image> () != null) 
{
if (CanvasImage==null) CanvasImage = this.gameObject.GetComponent<Image> ();
}		
if ((ShaderChange == 0) && (ForceMaterial != null)) 
{
ShaderChange=1;
if (tempMaterial!=null) DestroyImmediate(tempMaterial);
if(this.gameObject.GetComponent<SpriteRenderer>() != null)
{
this.GetComponent<Renderer>().sharedMaterial = ForceMaterial;
}
else if(this.gameObject.GetComponent<Image>() != null)
{
CanvasImage.material = ForceMaterial;
}
ForceMaterial.hideFlags = HideFlags.None;
ForceMaterial.shader=Shader.Find(shader);


}
if ((ForceMaterial == null) && (ShaderChange==1))
{
if (tempMaterial!=null) DestroyImmediate(tempMaterial);
tempMaterial = new Material(Shader.Find(shader));
tempMaterial.hideFlags = HideFlags.None;
if(this.gameObject.GetComponent<SpriteRenderer>() != null)
{
this.GetComponent<Renderer>().sharedMaterial = tempMaterial;
}
else if(this.gameObject.GetComponent<Image>() != null)
{
CanvasImage.material = tempMaterial;
}
ShaderChange=0;
}

#if UNITY_EDITOR
string dfname = "";
if(this.gameObject.GetComponent<SpriteRenderer>() != null) dfname=this.GetComponent<Renderer>().sharedMaterial.shader.name;
if(this.gameObject.GetComponent<Image>() != null) 
{
Image img = this.gameObject.GetComponent<Image>();
if (img.material==null)	dfname="Sprites/Default";
}
if (dfname == "Sprites/Default")
{
ForceMaterial.shader=Shader.Find(shader);
ForceMaterial.hideFlags = HideFlags.None;
if(this.gameObject.GetComponent<SpriteRenderer>() != null)
{
this.GetComponent<Renderer>().sharedMaterial = ForceMaterial;
}
else if(this.gameObject.GetComponent<Image>() != null)
{
Image img = this.gameObject.GetComponent<Image>();
if (img.material==null)
{
CanvasImage.material = ForceMaterial;
}
}
}
#endif
if (ActiveChange)
{

if (Pitch_Wave)
{
_Pitch_Offset=Mathf.Sin ( Time.time*_Pitch_Speed )*0.05f;
Debug.Log(_Pitch_Offset);
} else
{
_Pitch_Offset=0;
}

if(this.gameObject.GetComponent<SpriteRenderer>() != null)
{
this.GetComponent<Renderer>().sharedMaterial.SetFloat("_Alpha", 1-_Alpha); 
  if (_2DxFX.ActiveShadow && AddShadow)
                {
                    this.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                    if (ReceivedShadow)
                    {
                        this.GetComponent<Renderer>().receiveShadows = true;
                        this.GetComponent<Renderer>().sharedMaterial.renderQueue = 2450;
                        this.GetComponent<Renderer>().sharedMaterial.SetInt("_Z", 1);
                    }
                    else
                    {
                        this.GetComponent<Renderer>().receiveShadows = false;
                        this.GetComponent<Renderer>().sharedMaterial.renderQueue = 3000;
                        this.GetComponent<Renderer>().sharedMaterial.SetInt("_Z", 0);
                    }
                }
                else
                {
                    this.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    this.GetComponent<Renderer>().receiveShadows = false;
                    this.GetComponent<Renderer>().sharedMaterial.renderQueue = 3000;
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_Z", 0);
                }

                if (BlendMode == 0) // Normal
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                }
                if (BlendMode == 1) // Additive
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                }
                if (BlendMode == 2) // Darken
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.ReverseSubtract);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.DstColor);
                }
                if (BlendMode == 3) // Lighten
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Max);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                }
                if (BlendMode == 4) // Linear Burn
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.ReverseSubtract);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                }
                if (BlendMode == 5) // Linear Dodge
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Max);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                }
                if (BlendMode == 6) // Multiply
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.DstColor);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                }
                if (BlendMode == 7) // Soft Aditive
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.Add);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusDstColor);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                }
                if (BlendMode == 8) // 2x Multiplicative
                {
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_BlendOp", (int)UnityEngine.Rendering.BlendOp.ReverseSubtract);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.DstAlpha);
                    this.GetComponent<Renderer>().sharedMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.DstColor);
                }
this.GetComponent<Renderer>().sharedMaterial.SetFloat("_Pitch", _Pitch+_Pitch_Offset);
this.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetX", _OffsetX);
this.GetComponent<Renderer>().sharedMaterial.SetFloat("_OffsetY", _OffsetY);
this.GetComponent<Renderer>().sharedMaterial.SetFloat("_DistanceX", _DistanceX);
this.GetComponent<Renderer>().sharedMaterial.SetFloat("_DistanceY", _DistanceY);
this.GetComponent<Renderer>().sharedMaterial.SetFloat("_WaveTimeX", _WaveTimeX);
this.GetComponent<Renderer>().sharedMaterial.SetFloat("_WaveTimeY", _WaveTimeY);
}
else if(this.gameObject.GetComponent<Image>() != null)
{
CanvasImage.material.SetFloat("_Alpha", 1-_Alpha);

CanvasImage.material.SetFloat("_Pitch", _Pitch+_Pitch_Offset);
CanvasImage.material.SetFloat("_OffsetX", _OffsetX);
CanvasImage.material.SetFloat("_OffsetY", _OffsetY);
CanvasImage.material.SetFloat("_DistanceX", _DistanceX);
CanvasImage.material.SetFloat("_DistanceY", _DistanceY);
CanvasImage.material.SetFloat("_WaveTimeX", _WaveTimeX);
CanvasImage.material.SetFloat("_WaveTimeY", _WaveTimeY);
}

float timerange;
if (AutoRandom) 
{
timerange=(Random.Range (1,AutoRandomRange)/5)*Time.deltaTime;
} 
else 
{
timerange=Time.deltaTime;
}

if (AutoPlayWaveX) _WaveTimeX += AutoPlaySpeedX * timerange;
if (AutoPlayWaveY) _WaveTimeY += AutoPlaySpeedY * timerange;
if (_WaveTimeX > 6.28f) _WaveTimeX = 0f;
if (_WaveTimeY > 6.28f) _WaveTimeY = 0f;			
}

}

void OnDestroy()
{
if (this.gameObject.GetComponent<Image> () != null) 
{
if (CanvasImage==null) CanvasImage = this.gameObject.GetComponent<Image> ();
}
if ((Application.isPlaying == false) && (Application.isEditor == true)) {

if (tempMaterial!=null) DestroyImmediate(tempMaterial);

if (gameObject.activeSelf && defaultMaterial!=null) {
if(this.gameObject.GetComponent<SpriteRenderer>() != null)
{
this.GetComponent<Renderer>().sharedMaterial = defaultMaterial;
this.GetComponent<Renderer>().sharedMaterial.hideFlags = HideFlags.None;
}
else if(this.gameObject.GetComponent<Image>() != null)
{
CanvasImage.material = defaultMaterial;
CanvasImage.material.hideFlags = HideFlags.None;
}
}	
}
}
void OnDisable()
{ 
if (this.gameObject.GetComponent<Image> () != null) 
{
if (CanvasImage==null) CanvasImage = this.gameObject.GetComponent<Image> ();
} 
if (gameObject.activeSelf && defaultMaterial!=null) {
if(this.gameObject.GetComponent<SpriteRenderer>() != null)
{
this.GetComponent<Renderer>().sharedMaterial = defaultMaterial;
this.GetComponent<Renderer>().sharedMaterial.hideFlags = HideFlags.None;
}
else if(this.gameObject.GetComponent<Image>() != null)
{
CanvasImage.material = defaultMaterial;
CanvasImage.material.hideFlags = HideFlags.None;
}
}		
}

void OnEnable()
{
if (this.gameObject.GetComponent<Image> () != null) 
{
if (CanvasImage==null) CanvasImage = this.gameObject.GetComponent<Image> ();
} 
if (defaultMaterial == null) {
defaultMaterial = new Material(Shader.Find("Sprites/Default"));


}
if (ForceMaterial==null)
{
ActiveChange=true;
tempMaterial = new Material(Shader.Find(shader));
tempMaterial.hideFlags = HideFlags.None;
if(this.gameObject.GetComponent<SpriteRenderer>() != null)
{
this.GetComponent<Renderer>().sharedMaterial = tempMaterial;
}
else if(this.gameObject.GetComponent<Image>() != null)
{
CanvasImage.material = tempMaterial;
}
}
else
{
ForceMaterial.shader=Shader.Find(shader);
ForceMaterial.hideFlags = HideFlags.None;
if(this.gameObject.GetComponent<SpriteRenderer>() != null)
{
this.GetComponent<Renderer>().sharedMaterial = ForceMaterial;
}
else if(this.gameObject.GetComponent<Image>() != null)
{
CanvasImage.material = ForceMaterial;
}
}

}
}

#if UNITY_EDITOR
[CustomEditor(typeof(_2dxFX_AL_Mystic_Distortion)),CanEditMultipleObjects]
public class _2dxFX_AL_Mystic_Distortion_Editor : Editor
{
private SerializedObject m_object;

public void OnEnable()
{

m_object = new SerializedObject(targets);
}

public override void OnInspectorGUI()
{
m_object.Update();
DrawDefaultInspector();

_2dxFX_AL_Mystic_Distortion _2dxScript = (_2dxFX_AL_Mystic_Distortion)target;

Texture2D icon = Resources.Load ("2dxfxinspector-al") as Texture2D;
if (icon)
{
Rect r;
float ih=icon.height;
float iw=icon.width;
float result=ih/iw;
float w=Screen.width;
result=result*w;
r = GUILayoutUtility.GetRect(ih, result);
EditorGUI.DrawTextureTransparent(r,icon);
}
 EditorGUILayout.LabelField("Advanced Lightning may work on mobile high-end devices and may be slower than the Standard 2DxFX effects due to is lightning system. Use it only if you need it.", EditorStyles.helpBox);
        EditorGUILayout.PropertyField(m_object.FindProperty("AddShadow"), new GUIContent("Add Shadow", "Use a unique material, reduce drastically the use of draw call"));
        if (_2dxScript.AddShadow)
        {
            EditorGUILayout.PropertyField(m_object.FindProperty("ReceivedShadow"), new GUIContent("Received Shadow : No Transparency and Use Z Buffering instead of Sprite Order Layers", "Received Shadow, No Transparency and Use Z Buffering instead of Sprite Order Layers"));
            if (_2dxScript.ReceivedShadow)
            {
                EditorGUILayout.LabelField("Note 1: Blend Fusion work but without transparency\n", EditorStyles.helpBox);
            }
        }

        // Mode Blend
        EditorGUILayout.BeginVertical("Box");
        string BlendMethode = "Normal";

        if (_2dxScript.BlendMode == 0) BlendMethode = "Normal";
        if (_2dxScript.BlendMode == 1) BlendMethode = "Additive";
        if (_2dxScript.BlendMode == 2) BlendMethode = "Darken";
        if (_2dxScript.BlendMode == 3) BlendMethode = "Lighten";
        if (_2dxScript.BlendMode == 4) BlendMethode = "Linear Burn";
        if (_2dxScript.BlendMode == 5) BlendMethode = "Linear Dodge";
        if (_2dxScript.BlendMode == 6) BlendMethode = "Multiply";
        if (_2dxScript.BlendMode == 7) BlendMethode = "Soft Aditive";
        if (_2dxScript.BlendMode == 8) BlendMethode = "2x Multiplicative";

EditorGUILayout.PropertyField(m_object.FindProperty("ForceMaterial"), new GUIContent("Shared Material", "Use a unique material, reduce drastically the use of draw call"));

if (_2dxScript.ForceMaterial == null)
{
_2dxScript.ActiveChange = true;
}
else
{
if(GUILayout.Button("Remove Shared Material"))
{
_2dxScript.ForceMaterial= null;
_2dxScript.ShaderChange = 1;
_2dxScript.ActiveChange = true;
_2dxScript.CallUpdate();
}

EditorGUILayout.PropertyField (m_object.FindProperty ("ActiveChange"), new GUIContent ("Change Material Property", "Change The Material Property"));
}

if (_2dxScript.ActiveChange)
{

EditorGUILayout.BeginVertical("Box");

Texture2D icone = Resources.Load ("2dxfx-icon-clip_left") as Texture2D;

EditorGUILayout.PropertyField(m_object.FindProperty("_OffsetX"), new GUIContent("Offset X", icone, "Change the offset of X"));
icone = Resources.Load ("2dxfx-icon-clip_right") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("_OffsetY"), new GUIContent("Offset Y", icone, "Change the offset of Y"));
icone = Resources.Load ("2dxfx-icon-clip_right") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("_Pitch"), new GUIContent("Pitch", icone, "Change the Pitch Offset"));
icone = Resources.Load ("2dxfx-icon-time") as Texture2D;


EditorGUILayout.PropertyField(m_object.FindProperty("Pitch_Wave"), new GUIContent("Active Pitch Wave", icone, "Active the pitch wave FX"));

icone = Resources.Load ("2dxfx-icon-size_x") as Texture2D;
if (_2dxScript.Pitch_Wave)
{
EditorGUILayout.PropertyField(m_object.FindProperty("_Pitch_Speed"), new GUIContent("Pitch Speed", icone, "Change the Speed of the pitch FX"));
}

icone = Resources.Load ("2dxfx-icon-size_x") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("_DistanceX"), new GUIContent("Distance X", icone, "Change the distance of X"));
icone = Resources.Load ("2dxfx-icon-size_y") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("_DistanceY"), new GUIContent("Distance Y", icone, "Change the distance of Y"));
icone = Resources.Load ("2dxfx-icon-time") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("_WaveTimeX"), new GUIContent("Wave Time X", icone, "Change the time speed of the wave X"));
icone = Resources.Load ("2dxfx-icon-time") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("_WaveTimeY"), new GUIContent("Wave Time Y", icone, "Change the time speed of the wave Y"));
icone = Resources.Load ("2dxfx-icon-time") as Texture2D;


EditorGUILayout.PropertyField(m_object.FindProperty("AutoPlayWaveX"), new GUIContent("Active AutoPlay Wave X", icone, "Active the time speed"));
if (_2dxScript.AutoPlayWaveX)
{
icone = Resources.Load ("2dxfx-icon-time") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("AutoPlaySpeedX"), new GUIContent("AutoPlay Speed X", icone, "Speed of the auto play X"));
}
icone = Resources.Load ("2dxfx-icon-time") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("AutoPlayWaveY"), new GUIContent("Active AutoPlay Wave Y", icone, "Active the time speed"));
if (_2dxScript.AutoPlayWaveY)
{
icone = Resources.Load ("2dxfx-icon-time") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("AutoPlaySpeedY"), new GUIContent("AutoPlay Speed Y", icone, "Speed of the auto play Y"));
}
icone = Resources.Load ("2dxfx-icon-pixel") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("AutoRandom"), new GUIContent("Auto Random", icone, "Active the random value"));
if (_2dxScript.AutoRandom)
{
icone = Resources.Load ("2dxfx-icon-value") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("AutoRandomRange"), new GUIContent("Auto Random Range", icone, "Change the random value"));
}

EditorGUILayout.BeginVertical("Box");



icone = Resources.Load ("2dxfx-icon-fade") as Texture2D;
EditorGUILayout.PropertyField(m_object.FindProperty("_Alpha"), new GUIContent("Fading", icone, "Fade from nothing to showing"));

EditorGUILayout.EndVertical();
EditorGUILayout.EndVertical();

 EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField("Change Blend Fusion = " + BlendMethode, EditorStyles.whiteLargeLabel);
            if (_2dxScript.ReceivedShadow)
            {
                EditorGUILayout.LabelField("Note: Blend Fusion is not working correctly with Received Shadow", EditorStyles.helpBox);
            }

            EditorGUILayout.BeginHorizontal("Box");

            if (GUILayout.Button("Normal", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 0;
                _2dxScript.CallUpdate();
            }
            if (GUILayout.Button("Additive", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 1;
                _2dxScript.CallUpdate();
            }
            if (GUILayout.Button("Darken", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 2;
                _2dxScript.CallUpdate();
            }
            if (GUILayout.Button("Lighten", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 3;
                _2dxScript.CallUpdate();
            }
            if (GUILayout.Button("Linear Burn", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 4;
                _2dxScript.CallUpdate();
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal("Box");

            if (GUILayout.Button("Linear Dodge", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 5;
                _2dxScript.CallUpdate();
            }
            if (GUILayout.Button("Multiply", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 6;
                _2dxScript.CallUpdate();
            }
            if (GUILayout.Button("Soft Aditive", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 7;
                _2dxScript.CallUpdate();
            }
            if (GUILayout.Button("2x Multiplicative", EditorStyles.toolbarButton))
            {
                _2dxScript.BlendMode = 8;
                _2dxScript.CallUpdate();

            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
}

m_object.ApplyModifiedProperties();

}
}
#endif