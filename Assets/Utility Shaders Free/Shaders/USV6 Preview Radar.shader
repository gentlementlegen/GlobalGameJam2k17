// Shader created with Shader Forge Beta 0.35 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.35;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.945098,fgcg:0.9137255,fgcb:0.8470588,fgca:1,fgde:0.02,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:30851,y:33829|emission-175-OUT,alpha-176-OUT;n:type:ShaderForge.SFN_TexCoord,id:88,x:35411,y:33124,uv:0;n:type:ShaderForge.SFN_Distance,id:90,x:35097,y:33237|A-92-OUT,B-88-UVOUT;n:type:ShaderForge.SFN_Vector2,id:92,x:35108,y:33122,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_RemapRange,id:94,x:34918,y:33237,cmnt:V coordinate,frmn:0,frmx:1,tomn:0,tomx:2|IN-90-OUT;n:type:ShaderForge.SFN_Subtract,id:98,x:35108,y:32971|A-88-UVOUT,B-92-OUT;n:type:ShaderForge.SFN_ArcTan2,id:100,x:35108,y:32663|A-102-R,B-102-G;n:type:ShaderForge.SFN_ComponentMask,id:102,x:35108,y:32811,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-98-OUT;n:type:ShaderForge.SFN_Pi,id:104,x:35108,y:32544;n:type:ShaderForge.SFN_Add,id:106,x:34898,y:32523|A-104-OUT,B-100-OUT;n:type:ShaderForge.SFN_Divide,id:108,x:34714,y:32718|A-106-OUT,B-110-OUT;n:type:ShaderForge.SFN_Multiply,id:110,x:34898,y:32735|A-112-OUT,B-104-OUT;n:type:ShaderForge.SFN_Vector1,id:112,x:34898,y:32663,v1:2;n:type:ShaderForge.SFN_Relay,id:175,x:31189,y:33805,cmnt:Color|IN-522-OUT;n:type:ShaderForge.SFN_Relay,id:176,x:31227,y:34249,cmnt:Alpha|IN-518-OUT;n:type:ShaderForge.SFN_Step,id:187,x:32885,y:34485|A-210-OUT,B-188-OUT;n:type:ShaderForge.SFN_Vector1,id:188,x:33101,y:34601,v1:1;n:type:ShaderForge.SFN_Relay,id:210,x:33476,y:34342|IN-559-U;n:type:ShaderForge.SFN_Distance,id:302,x:33101,y:34672|A-312-OUT,B-314-OUT;n:type:ShaderForge.SFN_Frac,id:312,x:33282,y:34584|IN-313-OUT;n:type:ShaderForge.SFN_Multiply,id:313,x:33282,y:34459|A-210-OUT,B-586-OUT;n:type:ShaderForge.SFN_Vector1,id:314,x:33858,y:34784,v1:0.5;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:316,x:32843,y:34692|IN-302-OUT,IMIN-587-OUT,IMAX-314-OUT,OMIN-317-OUT,OMAX-319-OUT;n:type:ShaderForge.SFN_Vector1,id:317,x:33382,y:34941,v1:0;n:type:ShaderForge.SFN_Vector1,id:319,x:33382,y:35005,v1:1;n:type:ShaderForge.SFN_Multiply,id:324,x:32613,y:34654|A-187-OUT,B-574-OUT;n:type:ShaderForge.SFN_Relay,id:325,x:33041,y:33770|IN-347-OUT;n:type:ShaderForge.SFN_Distance,id:326,x:32728,y:33928|A-325-OUT,B-328-OUT;n:type:ShaderForge.SFN_Vector1,id:328,x:33011,y:34024,v1:0.5;n:type:ShaderForge.SFN_ConstantLerp,id:331,x:33011,y:33865,a:0.49,b:0.495|IN-94-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:336,x:32728,y:34070|IN-326-OUT,IMIN-331-OUT,IMAX-328-OUT,OMIN-338-OUT,OMAX-340-OUT;n:type:ShaderForge.SFN_Vector1,id:338,x:33011,y:34087,v1:0;n:type:ShaderForge.SFN_Vector1,id:340,x:33011,y:34148,v1:1;n:type:ShaderForge.SFN_Clamp01,id:341,x:32546,y:34070|IN-336-OUT;n:type:ShaderForge.SFN_Clamp01,id:342,x:32449,y:34654|IN-324-OUT;n:type:ShaderForge.SFN_Add,id:346,x:33165,y:33576|A-583-OUT,B-108-OUT;n:type:ShaderForge.SFN_Frac,id:347,x:33165,y:33715|IN-346-OUT;n:type:ShaderForge.SFN_Distance,id:348,x:32811,y:31832|A-350-UVOUT,B-355-OUT;n:type:ShaderForge.SFN_Clamp01,id:349,x:32811,y:31548|IN-367-OUT;n:type:ShaderForge.SFN_TexCoord,id:350,x:33016,y:31688,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:355,x:33016,y:31832|IN-365-OUT,IMIN-357-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:357,x:33212,y:31783|IN-588-OUT;n:type:ShaderForge.SFN_Vector1,id:358,x:34140,y:29604,v1:0;n:type:ShaderForge.SFN_Append,id:365,x:33212,y:31576|A-600-OUT,B-598-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:367,x:32811,y:31688|IN-348-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Distance,id:378,x:32811,y:31331|A-382-UVOUT,B-384-OUT;n:type:ShaderForge.SFN_Clamp01,id:380,x:32811,y:31047|IN-398-OUT;n:type:ShaderForge.SFN_TexCoord,id:382,x:33016,y:31188,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:384,x:33016,y:31331|IN-396-OUT,IMIN-388-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:388,x:33212,y:31293|IN-588-OUT;n:type:ShaderForge.SFN_Append,id:396,x:33212,y:31103|A-604-OUT,B-602-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:398,x:32811,y:31188|IN-378-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Distance,id:400,x:32811,y:30849|A-404-UVOUT,B-406-OUT;n:type:ShaderForge.SFN_Clamp01,id:402,x:32811,y:30565|IN-420-OUT;n:type:ShaderForge.SFN_TexCoord,id:404,x:33016,y:30706,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:406,x:33016,y:30849|IN-418-OUT,IMIN-410-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:410,x:33193,y:30803|IN-588-OUT;n:type:ShaderForge.SFN_Append,id:418,x:33193,y:30629|A-608-OUT,B-606-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:420,x:32811,y:30706|IN-400-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Distance,id:422,x:32811,y:30368|A-426-UVOUT,B-428-OUT;n:type:ShaderForge.SFN_Clamp01,id:424,x:32811,y:30084|IN-442-OUT;n:type:ShaderForge.SFN_TexCoord,id:426,x:33016,y:30225,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:428,x:33016,y:30368|IN-440-OUT,IMIN-432-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:432,x:33190,y:30320|IN-588-OUT;n:type:ShaderForge.SFN_Append,id:440,x:33190,y:30154|A-612-OUT,B-610-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:442,x:32811,y:30225|IN-422-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Distance,id:446,x:32812,y:29890|A-450-UVOUT,B-452-OUT;n:type:ShaderForge.SFN_Clamp01,id:448,x:32812,y:29606|IN-464-OUT;n:type:ShaderForge.SFN_TexCoord,id:450,x:33017,y:29747,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:452,x:33017,y:29890|IN-462-OUT,IMIN-454-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:454,x:33186,y:29841|IN-588-OUT;n:type:ShaderForge.SFN_Vector1,id:458,x:34140,y:29679,v1:1;n:type:ShaderForge.SFN_Append,id:462,x:33197,y:29668|A-616-OUT,B-614-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:464,x:32812,y:29747|IN-446-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Distance,id:466,x:32812,y:29426|A-470-UVOUT,B-472-OUT;n:type:ShaderForge.SFN_Clamp01,id:468,x:32812,y:29142|IN-480-OUT;n:type:ShaderForge.SFN_TexCoord,id:470,x:33017,y:29283,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:472,x:33017,y:29426|IN-478-OUT,IMIN-474-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:474,x:33186,y:29377|IN-588-OUT;n:type:ShaderForge.SFN_Append,id:478,x:33197,y:29204|A-620-OUT,B-618-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:480,x:32812,y:29283|IN-466-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Add,id:481,x:31867,y:32501|A-483-OUT,B-546-OUT;n:type:ShaderForge.SFN_Add,id:483,x:32050,y:31302|A-485-OUT,B-402-OUT,C-380-OUT,D-349-OUT,E-530-OUT;n:type:ShaderForge.SFN_Add,id:485,x:32248,y:29090|A-505-OUT,B-489-OUT,C-468-OUT,D-448-OUT,E-424-OUT;n:type:ShaderForge.SFN_Distance,id:487,x:32809,y:28971|A-491-UVOUT,B-493-OUT;n:type:ShaderForge.SFN_Clamp01,id:489,x:32809,y:28687|IN-501-OUT;n:type:ShaderForge.SFN_TexCoord,id:491,x:33014,y:28828,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:493,x:33014,y:28971|IN-499-OUT,IMIN-495-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:495,x:33183,y:28922|IN-588-OUT;n:type:ShaderForge.SFN_Append,id:499,x:33194,y:28749|A-624-OUT,B-622-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:501,x:32809,y:28828|IN-487-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Distance,id:503,x:32810,y:28520|A-507-UVOUT,B-509-OUT;n:type:ShaderForge.SFN_Clamp01,id:505,x:32810,y:28236|IN-517-OUT;n:type:ShaderForge.SFN_TexCoord,id:507,x:33015,y:28377,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:509,x:33015,y:28520|IN-515-OUT,IMIN-511-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:511,x:33184,y:28471|IN-588-OUT;n:type:ShaderForge.SFN_Append,id:515,x:33195,y:28298|A-628-OUT,B-626-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:517,x:32810,y:28377|IN-503-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Lerp,id:518,x:31227,y:34082|A-519-OUT,B-578-OUT,T-581-OUT;n:type:ShaderForge.SFN_Vector1,id:519,x:31394,y:34098,v1:1;n:type:ShaderForge.SFN_Lerp,id:522,x:31160,y:33580|A-579-OUT,B-580-OUT,T-578-OUT;n:type:ShaderForge.SFN_Distance,id:528,x:32811,y:32892|A-532-UVOUT,B-534-OUT;n:type:ShaderForge.SFN_Clamp01,id:530,x:32811,y:32608|IN-542-OUT;n:type:ShaderForge.SFN_TexCoord,id:532,x:33016,y:32748,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:534,x:33016,y:32892|IN-540-OUT,IMIN-536-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:536,x:33212,y:32843|IN-588-OUT;n:type:ShaderForge.SFN_Append,id:540,x:33212,y:32636|A-591-OUT,B-592-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:542,x:32811,y:32748|IN-528-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_Distance,id:544,x:32809,y:32312|A-548-UVOUT,B-550-OUT;n:type:ShaderForge.SFN_Clamp01,id:546,x:32809,y:32028|IN-558-OUT;n:type:ShaderForge.SFN_TexCoord,id:548,x:33014,y:32168,uv:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:550,x:33014,y:32312|IN-556-OUT,IMIN-552-OUT,IMAX-588-OUT,OMIN-358-OUT,OMAX-458-OUT;n:type:ShaderForge.SFN_Negate,id:552,x:33210,y:32263|IN-588-OUT;n:type:ShaderForge.SFN_Append,id:556,x:33199,y:32072|A-594-OUT,B-596-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:558,x:32809,y:32168|IN-544-OUT,IMIN-358-OUT,IMAX-590-OUT,OMIN-458-OUT,OMAX-358-OUT;n:type:ShaderForge.SFN_TexCoord,id:559,x:33634,y:34272,uv:0;n:type:ShaderForge.SFN_Distance,id:562,x:33101,y:34807|A-564-OUT,B-314-OUT;n:type:ShaderForge.SFN_Frac,id:564,x:33295,y:34725|IN-566-OUT;n:type:ShaderForge.SFN_Multiply,id:566,x:33440,y:34610|A-559-V,B-586-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:570,x:32843,y:34840|IN-562-OUT,IMIN-587-OUT,IMAX-314-OUT,OMIN-317-OUT,OMAX-319-OUT;n:type:ShaderForge.SFN_Clamp01,id:571,x:32688,y:34885|IN-570-OUT;n:type:ShaderForge.SFN_Clamp01,id:573,x:32674,y:34771|IN-316-OUT;n:type:ShaderForge.SFN_Max,id:574,x:32517,y:34796|A-573-OUT,B-571-OUT;n:type:ShaderForge.SFN_Max,id:575,x:32053,y:34237|A-341-OUT,B-342-OUT;n:type:ShaderForge.SFN_Multiply,id:576,x:31744,y:33346|A-630-OUT,B-577-OUT;n:type:ShaderForge.SFN_Vector1,id:577,x:31964,y:33443,v1:2;n:type:ShaderForge.SFN_Max,id:578,x:31600,y:33939|A-576-OUT,B-575-OUT;n:type:ShaderForge.SFN_Vector3,id:579,x:31426,y:33266,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Vector3,id:580,x:31554,y:33677,v1:0,v2:0.7,v3:1;n:type:ShaderForge.SFN_Vector1,id:581,x:31394,y:34329,v1:0;n:type:ShaderForge.SFN_Time,id:582,x:33414,y:33001;n:type:ShaderForge.SFN_Multiply,id:583,x:33248,y:33122|A-582-T,B-584-OUT;n:type:ShaderForge.SFN_Vector1,id:584,x:33387,y:33199,v1:0.2;n:type:ShaderForge.SFN_Frac,id:585,x:32620,y:33338|IN-634-OUT;n:type:ShaderForge.SFN_Vector1,id:586,x:33734,y:34553,v1:4;n:type:ShaderForge.SFN_Vector1,id:587,x:32949,y:35068,v1:0.45;n:type:ShaderForge.SFN_Vector1,id:588,x:34140,y:29739,v1:10;n:type:ShaderForge.SFN_Vector1,id:590,x:33390,y:28494,v1:0.04;n:type:ShaderForge.SFN_Vector1,id:591,x:33570,y:32520,v1:-5;n:type:ShaderForge.SFN_Vector1,id:592,x:33713,y:32486,v1:1;n:type:ShaderForge.SFN_Vector1,id:594,x:33484,y:32032,v1:-3;n:type:ShaderForge.SFN_Vector1,id:596,x:33627,y:31998,v1:-8;n:type:ShaderForge.SFN_Vector1,id:598,x:33476,y:31596,v1:4;n:type:ShaderForge.SFN_Vector1,id:600,x:33450,y:31483,v1:5;n:type:ShaderForge.SFN_Vector1,id:602,x:33484,y:31123,v1:2;n:type:ShaderForge.SFN_Vector1,id:604,x:33458,y:31010,v1:-6;n:type:ShaderForge.SFN_Vector1,id:606,x:33498,y:30699,v1:7;n:type:ShaderForge.SFN_Vector1,id:608,x:33472,y:30586,v1:-3;n:type:ShaderForge.SFN_Vector1,id:610,x:33470,y:30222,v1:8;n:type:ShaderForge.SFN_Vector1,id:612,x:33444,y:30109,v1:2;n:type:ShaderForge.SFN_Vector1,id:614,x:33421,y:29781,v1:-3;n:type:ShaderForge.SFN_Vector1,id:616,x:33395,y:29668,v1:5;n:type:ShaderForge.SFN_Vector1,id:618,x:33408,y:29244,v1:-1;n:type:ShaderForge.SFN_Vector1,id:620,x:33382,y:29131,v1:1;n:type:ShaderForge.SFN_Vector1,id:622,x:33404,y:28849,v1:-4;n:type:ShaderForge.SFN_Vector1,id:624,x:33378,y:28736,v1:-8;n:type:ShaderForge.SFN_Vector1,id:626,x:33401,y:28319,v1:-0.5;n:type:ShaderForge.SFN_Vector1,id:628,x:33375,y:28206,v1:-8;n:type:ShaderForge.SFN_Add,id:629,x:31736,y:32981|A-481-OUT,B-346-OUT;n:type:ShaderForge.SFN_Multiply,id:630,x:31750,y:33175|A-481-OUT,B-633-OUT;n:type:ShaderForge.SFN_Frac,id:631,x:34701,y:32868;n:type:ShaderForge.SFN_RemapRange,id:633,x:32345,y:33430,frmn:0,frmx:1,tomn:0.5,tomx:1.2|IN-585-OUT;n:type:ShaderForge.SFN_OneMinus,id:634,x:32855,y:33430|IN-346-OUT;pass:END;sub:END;*/

Shader "Utility Shaders/Preview/Radar Grid" {
    Properties {
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float node_588 = 10.0;
                float node_511 = (-1*node_588);
                float node_358 = 0.0;
                float node_458 = 1.0;
                float node_590 = 0.04;
                float node_495 = (-1*node_588);
                float node_474 = (-1*node_588);
                float node_454 = (-1*node_588);
                float node_432 = (-1*node_588);
                float node_410 = (-1*node_588);
                float node_388 = (-1*node_588);
                float node_357 = (-1*node_588);
                float node_536 = (-1*node_588);
                float node_552 = (-1*node_588);
                float node_481 = (((saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2((-8.0),(-0.5)) - node_511) * (node_458 - node_358) ) / (node_588 - node_511))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358)))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2((-8.0),(-4.0)) - node_495) * (node_458 - node_358) ) / (node_588 - node_495))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358)))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2(1.0,(-1.0)) - node_474) * (node_458 - node_358) ) / (node_588 - node_474))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358)))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2(5.0,(-3.0)) - node_454) * (node_458 - node_358) ) / (node_588 - node_454))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358)))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2(2.0,8.0) - node_432) * (node_458 - node_358) ) / (node_588 - node_432))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358))))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2((-3.0),7.0) - node_410) * (node_458 - node_358) ) / (node_588 - node_410))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358)))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2((-6.0),2.0) - node_388) * (node_458 - node_358) ) / (node_588 - node_388))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358)))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2(5.0,4.0) - node_357) * (node_458 - node_358) ) / (node_588 - node_357))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358)))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2((-5.0),1.0) - node_536) * (node_458 - node_358) ) / (node_588 - node_536))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358))))+saturate((node_458 + ( (distance(i.uv0.rg,(node_358 + ( (float2((-3.0),(-8.0)) - node_552) * (node_458 - node_358) ) / (node_588 - node_552))) - node_358) * (node_358 - node_458) ) / (node_590 - node_358))));
                float4 node_582 = _Time + _TimeEditor;
                float node_104 = 3.141592654;
                float2 node_88 = i.uv0;
                float2 node_92 = float2(0.5,0.5);
                float2 node_102 = (node_88.rg-node_92).rg;
                float node_346 = ((node_582.g*0.2)+((node_104+atan2(node_102.r,node_102.g))/(2.0*node_104)));
                float node_328 = 0.5;
                float node_331 = lerp(0.49,0.495,(distance(node_92,node_88.rg)*2.0+0.0));
                float node_338 = 0.0;
                float2 node_559 = i.uv0;
                float node_210 = node_559.r;
                float node_586 = 4.0;
                float node_314 = 0.5;
                float node_587 = 0.45;
                float node_317 = 0.0;
                float node_319 = 1.0;
                float node_578 = max(((node_481*(frac((1.0 - node_346))*0.7+0.5))*2.0),max(saturate((node_338 + ( (distance(frac(node_346),node_328) - node_331) * (1.0 - node_338) ) / (node_328 - node_331))),saturate((step(node_210,1.0)*max(saturate((node_317 + ( (distance(frac((node_210*node_586)),node_314) - node_587) * (node_319 - node_317) ) / (node_314 - node_587))),saturate((node_317 + ( (distance(frac((node_559.g*node_586)),node_314) - node_587) * (node_319 - node_317) ) / (node_314 - node_587))))))));
                float3 emissive = lerp(float3(0,0,0),float3(0,0.7,1),node_578);
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,lerp(1.0,node_578,0.0));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}