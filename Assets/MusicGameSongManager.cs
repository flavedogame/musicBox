using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameSongManager : MonoBehaviour {

	public TextAsset songInfosText;
	List<SongInfo> songs;

	// Use this for initialization
	void Start () {
		songs = SongInfo.loadSongInfo (songInfosText);
		Debug.Log (songs [0].name);
		Debug.Log (songs [0].description);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public int[] GetScores() {
		//good,great,perfect,justPerfect
		int[] result = new int[]{100,200,300,400};
		return result;
	}
}
