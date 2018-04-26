using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerManager : Singleton<CardInfoManager> {

	// Use this for initialization
	void Awake () {
		Debug.Log ("start game manager");
		CardInfoManager.Instance.Setup ();
		CardManager.Instance.Setup ();
		SongInfoManager.Instance.Setup ();
		MusicGameSongManager.Instance.Setup ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
