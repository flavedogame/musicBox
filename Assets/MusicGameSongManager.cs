using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameSongManager : MonoBehaviour {

	public TextAsset songInfosText;
	List<SongInfo> songs;
	public SongPickingViewController pickingView;

	// Use this for initialization
	void Start () {
		//songs = SongInfo.loadSongInfo (songInfosText);
		songs = SongInfo.loadSongInfo("Assets/Resources/songCsv.csv");
		SelectSong (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectSong(int index) {
		if (index >= songs.Count) {
			Debug.LogError ("index larger than song's count");
			return;
		}
		pickingView.SelectSong (songs [index]);
	}

	public int[] GetScores() {
		//good,great,perfect,justPerfect
		int[] result = new int[]{100,200,300,400};
		return result;
	}
}
