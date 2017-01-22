using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.ImageEffects
{
    
    [ExecuteInEditMode]
    [AddComponentMenu("Image Effects/Color Adjustments/Color Correction Fade (Ramp)")]
    public class ColorRampFade : ImageEffectBase
    {
        public float alpha;
        public float duration;
        public Texture textureRamp;
        public Texture textureRamp1;
        public int factor = 1;
        public bool loop = true;
        private bool play = true;
        private bool init = false;
        private Texture2D finalTexture;
        private Material m_Material1;
        private float lerp = 0;
        private float curval;

        protected override void Start()
        {
            base.Start();
            finalTexture = Instantiate(textureRamp) as Texture2D;
        }

        protected Material material1
        {
            get
            {
                if (m_Material1 == null)
                {
                    m_Material1 = new Material(shader);
                    m_Material1.hideFlags = HideFlags.HideAndDontSave;
                }
                return m_Material1;
            }
        }

        private Material m_Material2;


        protected Material material2
        {
            get
            {
                if (m_Material2 == null)
                {
                    m_Material2 = new Material(shader);
                    m_Material2.hideFlags = HideFlags.HideAndDontSave;
                }
                return m_Material2;
            }
        }

        // Called by camera to apply image effect
        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (!init && play)
            {
                material.SetTexture("_RampTex", textureRamp1);
                Graphics.Blit(source, destination, material);
                init = true;
                lerp = 0;
            }
            else if (loop)
            {
                lerp = Mathf.PingPong(Time.time, duration) / duration;
                Texture2D t1 = textureRamp as Texture2D;
                Texture2D t2 = textureRamp1 as Texture2D;
                float fact1 = lerp;
                float fact2 = Mathf.Abs(1 - lerp);
                Color factor1 = new Color(fact1, fact1, fact1, 1);
                Color factor2 = new Color(fact2, fact2, fact2, 1);
                for (int y = 0; y < textureRamp.height; y++)
                {
                    for (int x = 0; x < textureRamp.width; x++)
                    {
                        Color col1 = t1.GetPixel(x, y);
                        Color col2 = t2.GetPixel(x, y);
                        col1.a = 0f;
                        col2.a = 0f;
                        finalTexture.SetPixel(x, y, col1 * factor1 + col2 * factor2);
                    }
                }
                finalTexture.Apply();
                material.SetTexture("_RampTex", finalTexture);
                Graphics.Blit(source, destination, material);
                play = false;
            }
            else if (factor == -1)
            {
                lerp = Mathf.Lerp(0, 1, lerp + Time.deltaTime * duration);
                Texture2D t1 = textureRamp as Texture2D;
                Texture2D t2 = textureRamp1 as Texture2D;
                float fact1 = lerp;
                float fact2 = Mathf.Abs(1 - lerp);
                Color factor1 = new Color(fact1, fact1, fact1, 1);
                Color factor2 = new Color(fact2, fact2, fact2, 1);
                for (int y = 0; y < textureRamp.height; y++)
                {
                    for (int x = 0; x < textureRamp.width; x++)
                    {
                        Color col1 = t1.GetPixel(x, y);
                        Color col2 = t2.GetPixel(x, y);
                        col1.a = 0f;
                        col2.a = 0f;
                        finalTexture.SetPixel(x, y, col1 * factor1 + col2 * factor2);
                    }
                }
                finalTexture.Apply();
                material.SetTexture("_RampTex", finalTexture);
                Graphics.Blit(source, destination, material);
                play = false;
            }
            else if (factor == 1)
            {
                lerp = Mathf.Lerp(0, 1, lerp + Time.deltaTime * duration);
                Texture2D t1 = textureRamp as Texture2D;
                Texture2D t2 = textureRamp1 as Texture2D;
                float fact1 = lerp;
                float fact2 = Mathf.Abs(1 - lerp);
                Color factor1 = new Color(fact1, fact1, fact1, 1);
                Color factor2 = new Color(fact2, fact2, fact2, 1);
                for (int y = 0; y < textureRamp.height; y++)
                {
                    for (int x = 0; x < textureRamp.width; x++)
                    {
                        Color col1 = t1.GetPixel(x, y);
                        Color col2 = t2.GetPixel(x, y);
                        col1.a = 0f;
                        col2.a = 0f;
                        finalTexture.SetPixel(x, y, col2 * factor1 + col1 * factor2);
                    }
                }
                finalTexture.Apply();
                material.SetTexture("_RampTex", finalTexture);
                Graphics.Blit(source, destination, material);
                play = false;
            }
            else
                lerp = 0;
        }
        public void PlayOnce()
        {
            play = true;
        }

        public void Play()
        {
            factor = 1;
        }

        public void PlayBackward()
        {
            factor = -1;
        }
    }
}
