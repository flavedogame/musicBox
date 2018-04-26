using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameSongManager : Singleton<MusicGameSongManager> {

	public TextAsset songInfosText;
	//[HideInInspector]
	public List<string> songNames;
	int selectedIndex;
	public delegate void Action (Song song);
	public event Action SongChange; 
	public Dictionary<string,Song> songDict;


	// Use this for initialization
	public void Setup () {
		//songs = SongInfo.loadSongInfo (songInfosText);
		//should select the song player owns
		songNames = new List<string> ();
		songDict = new Dictionary<string,Song> ();
		foreach (string key in SongInfoManager.Instance.songDict.Keys) {
			Song song = new Song (key, 1);
			songDict [key] = song;
			songNames.Add (key);
		}
	}

	public void SelectSong(int index) {
		if (index >= songNames.Count) {
			Debug.LogError ("index larger than song's count"+songNames.Count);
			return;
		}
		SongChange (songDict[songNames[index]]);
		selectedIndex = index;

		string test = CardManager.Instance.cardList [0];
	}

	public SongInfo SelectedSong(){
		Debug.Log (selectedIndex);
		foreach (string test2 in songDict.Keys) {
			Debug.Log (test2);
			Debug.Log (songDict [test2].songInfo);
		}

		string test = CardManager.Instance.cardList [0];
		return songDict[songNames[selectedIndex]].songInfo;
	}

	public int[] GetScores() {
		//good,great,perfect,justPerfect
		int[] result = new int[]{100,200,300,400};
		return result;
	}
}
