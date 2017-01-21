using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityStandardAssets.ImageEffects;

// TODO : smooth transition vortex
using UnityEngine.Audio;


public class GameManager : AGameManager {

	[Header("GUI")]
	private Sprite loadingScreen;
	[Header("Particles")]
	[SerializeField] private GameObject particlesUnderwater;
	[Header("Terrain")]
	[SerializeField] private GameObject terrainWorldNew;
	[SerializeField] private GameObject terrainWorldOld;

	public static GameManager GM
	{ get; private set; }

	public enum World
	{ OLD, NEW }

	private List<SpriteRenderer> _objectsWorldNew = new List<SpriteRenderer>();
	private List<SpriteRenderer> _objectsWorldOld = new List<SpriteRenderer>();

	private World _currentWorld = World.NEW;
	private WaterEffect waterEffect;
	private Bloom bloomEffect;
	[SerializeField] private AudioMixerSnapshot[] audioSnapshots;

	public World CurrentWorld
	{
		get
		{
			return _currentWorld;
		}
		private set
		{
			StopAllCoroutines ();
			StartCoroutine (ChangeWorldCoroutine (CurrentWorld == World.NEW ? 1 : -1));
		}
	}

	void Awake()
	{
		GM = this;
	}

	// Use this for initialization
	void Start ()
	{
		GetAllChildren (terrainWorldNew, ref _objectsWorldNew);
		GetAllChildren (terrainWorldOld, ref _objectsWorldOld);
		waterEffect = Camera.main.GetComponent<WaterEffect> ();
		bloomEffect = Camera.main.GetComponent<Bloom> ();
	}

	void GetAllChildren(GameObject go, ref List<SpriteRenderer> list)
	{
		SpriteRenderer[] sp = go.GetComponentsInChildren<SpriteRenderer> ();

		if (sp.Length > 0)
			list.AddRange (sp.ToList<SpriteRenderer> ());
	}

	public override void Pause ()
	{
		base.Pause ();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			StartCoroutine (ChangeWorldCoroutine ());
		}
		if (Input.GetKeyDown(KeyCode.O))
		{
			StartCoroutine (ChangeWorldCoroutine (-1));
		}
	}

	/// <summary>
	/// Changes the world. 1 goes from new to old, -1 from old to new
	/// </summary>
	/// <returns>The world coroutine.</returns>
	/// <param name="fadeDir">Fade dir.</param>
	public IEnumerator ChangeWorldCoroutine(int fadeDir = 1)
	{
		UpdateAudioMixer ();
		if (fadeDir == 1)
		{
			for (float i = 0; i < 1; i += 0.025f)
			{
				foreach (SpriteRenderer sp in _objectsWorldNew)
				{
					sp.color = new Color (sp.color.r, sp.color.g, sp.color.b, 1 - i);
				}
				foreach (SpriteRenderer sp in _objectsWorldOld)
				{
					sp.color = new Color (sp.color.r, sp.color.g, sp.color.b, i);
				}
				waterEffect.UpdateVortexAngle (1 - i);

				if (i < 0.5f)
				{
					bloomEffect.bloomIntensity = i * 2;
				}
				else if (Mathf.Round(i * 100f) / 100f == 0.5f)
				{
					waterEffect.UpdateEffectState ();
					_currentWorld = World.OLD;
					particlesUnderwater.SetActive (false);
					yield return new WaitForSeconds (.25f);
				}
				else
				{
					bloomEffect.bloomIntensity = 2 - i * 2;
				}
				yield return new WaitForSeconds (0.01f);
			}
		}
		else
		{
			for (float i = 1; i >= 0; i -= 0.025f)
			{
				foreach (SpriteRenderer sp in _objectsWorldNew)
				{
					sp.color = new Color (sp.color.r, sp.color.g, sp.color.b, 1 - i);
				}
				foreach (SpriteRenderer sp in _objectsWorldOld)
				{
					sp.color = new Color (sp.color.r, sp.color.g, sp.color.b, i);
				}
				waterEffect.UpdateVortexAngle (1 - i);

				if (i < 0.5f)
				{
					bloomEffect.bloomIntensity = i * 2;
				}
				else if (Mathf.Round(i * 100f) / 100f == 0.5f)
				{
					waterEffect.UpdateEffectState ();
					_currentWorld = World.NEW;
					particlesUnderwater.SetActive (true);
					yield return new WaitForSeconds (.25f);
				}
				else
				{
					bloomEffect.bloomIntensity = 2 - i * 2;
				}
				yield return new WaitForSeconds (0.01f);
			}			
		}
	}

	void UpdateAudioMixer()
	{
		if (CurrentWorld == World.NEW)
		{
			audioSnapshots [0].TransitionTo (1f);
		}
		else
		{
			audioSnapshots [1].TransitionTo (1f);
		}
	}
}
