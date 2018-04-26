using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongPickingViewController : MonoBehaviour {
	//song info
	public Image background;
	public Text songName;
	public Text songDescription;
	public Text difficulty;
	public Text highestScore;
	public AudioSource audioSource;
	public Text basicAttribute;
	public Text specialAttribute;

	public Button finishSelectionButton;
	// Use this for initialization
	void Start () {
		MusicGameSongManager.Instance.SongChange += SelectSong;
		MusicGameSongManager.Instance.SelectSong (0);
		finishSelectionButton.onClick.AddListener(() => DecideSong());
		Debug.Log ("add action" );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectSong(Song song) {
		SongInfo songInfo = song.songInfo;
		//background.sprite = songInfo.image();
		//songName.text = songInfo.name;
		//songDescription.text = songInfo.Description();
		//difficulty.text = songInfo.difficulty.ToString();
		//audioSource.clip = songInfo.audioClip ();
		//audioSource.time = 30;
		//audioSource.Play ();
		//basicAttribute.text = songInfo.basicAttribute ();
		songName.text = "???";
	}

	public void DecideSong() {
		Debug.Log ("switch scene");
		SceneManager.LoadScene ("card picking");
	}
}
