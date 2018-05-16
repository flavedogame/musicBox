using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerManager : Singleton<GameManagerManager> {

	// Use this for initialization
	void Awake () {
		Debug.Log ("start game manager");
		CardInfoManager.Instance.Setup ();
		CardManager.Instance.Setup ();
		SongInfoManager.Instance.Setup ();
		MusicGameSongManager.Instance.Setup ();
		InfoManager.Instance.SetupGameLevel ();
		GameLevelManager.Instance.Setup ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
