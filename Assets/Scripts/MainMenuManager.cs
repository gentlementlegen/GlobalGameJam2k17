using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : AGameManager {

	private bool isLoadingLevel = false;
	[SerializeField] private Fading fader;
	[SerializeField] private AudioSource audioSource;

	void Start()
	{
		fader = GetComponent<Fading> ();
	}

	void Update()
	{
		if (Input.GetButtonDown("Submit"))
		{
			if (!isLoadingLevel)
				StartCoroutine (LoadCoroutine ());
		}
	}

	IEnumerator LoadCoroutine()
	{
		isLoadingLevel = true;
		fader.BeginFade (1);
		for (float i = audioSource.volume; i >= 0; i -= fader.fadeSpeed / 10f)
		{
			audioSource.volume = i;
			yield return new WaitForSeconds (fader.fadeSpeed / 10f);
		}
//		yield return new WaitForSeconds (fader.fadeSpeed);
		LoadLevel (1);
	}
}
