using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicGameViewController : MonoBehaviour {

	public Image background;
	public AudioSource audioSource;


	// Use this for initialization
	void Start () {

		Debug.Log (MusicGameSongManager.Instance.SelectedSong());
		SongInfo songInfo = MusicGameSongManager.Instance.SelectedSong();
		Debug.Log (songInfo.image ());
		background.sprite = songInfo.image ();
		audioSource.clip = songInfo.audioClip ();
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
