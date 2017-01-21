using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : AGameManager {

	[Header("GUI")]
	private Sprite loadingScreen;

	public static GameManager GM
	{ get; private set; }

	public enum World
	{ OLD, NEW }

	private List<SpriteManager> _objects;
	private World _currentWorld = World.NEW;
	private WaterEffect waterEffect;

	public World CurrentWorld
	{
		get
		{
			return _currentWorld;
		}
		private set
		{
			foreach (SpriteManager sp in _objects)
			{
				sp.GetComponent<SpriteManager> ().SwapSprite ();
			}
			waterEffect.UpdateEffectState ();
			_currentWorld = value;
		}
	}

	void Awake()
	{
		GM = this;
	}

	// Use this for initialization
	void Start ()
	{
		SpriteManager sp;

		foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
		{
			sp = obj.GetComponent<SpriteManager> ();
			if (sp != null)
				_objects.Add (sp);
		}
		waterEffect = Camera.main.GetComponent<WaterEffect> ();
	}

	public override void Pause ()
	{
		base.Pause ();
	}
}
