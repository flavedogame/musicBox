using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameSongManager : Singleton<MusicGameSongManager> {

	public TextAsset songInfosText;
	//[HideInInspector]
	public List<SongInfo> songs;
	int selectedIndex;
	public delegate void Action (SongInfo songInfo);
	public event Action SongChange; 

	// Use this for initialization
	public void Setup () {
		//songs = SongInfo.loadSongInfo (songInfosText);
		//should select the song player owns
		songs = SongInfo.loadSongInfo("Assets/Resources/songCsv.csv");
		//SelectSong (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectSong(int index) {
		if (index >= songs.Count) {
			Debug.LogError ("index larger than song's count"+songs.Count);
			return;
		}
		Debug.Log ("song index" + songs [index].name);
		Debug.Log (SongChange);
		SongChange (songs[index]);
		selectedIndex = index;
		Debug.Log (songs [selectedIndex].name);
	}

	public SongInfo SelectedSong(){
		Debug.Log (songs.Count);
		Debug.Log (selectedIndex);
		Debug.Log (songs [selectedIndex].name);
		return songs [selectedIndex];
	}

	public int[] GetScores() {
		//good,great,perfect,justPerfect
		int[] result = new int[]{100,200,300,400};
		return result;
	}
}
