using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AGameManager : MonoBehaviour {

	public enum eGameState
	{ PAUSE, PLAY }

	private eGameState _gameState = eGameState.PLAY;

	public eGameState GameState
	{
		get
		{
			return _gameState;
		}
		protected set
		{
			_gameState = value;
		}
	}

	/// <summary>
	/// Loads the level.
	/// </summary>
	public void LoadLevel(int level)
	{
		SceneManager.LoadSceneAsync (level);
	}

	/// <summary>
	/// Quit the game.
	/// </summary>
	public void Quit()
	{
		Application.Quit ();
	}

	public virtual void Pause()
	{
		if (_gameState == eGameState.PAUSE)
		{
			_gameState = eGameState.PLAY;
			Time.timeScale = 1;
		}
		else if (_gameState == eGameState.PLAY)
		{
			_gameState = eGameState.PAUSE;
			Time.timeScale = 0;
		}
	}
}
