using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

	[SerializeField] private Sprite spriteOldWorld;
	[SerializeField] private Sprite spriteNewWorld;

	private SpriteRenderer _sp;

	// Use this for initialization
	void Start () {
		_sp = GetComponent<SpriteRenderer> ();
	}

	public void SwapSprite()
	{
		switch (GameManager.GM.CurrentWorld)
		{
		case GameManager.World.NEW:
			_sp.sprite = spriteNewWorld;
			break;
		case GameManager.World.OLD:
			_sp.sprite = spriteOldWorld;
			break;
		}
	}
}