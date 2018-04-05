using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongBox : MonoBehaviour {

	Text songName;
	ListBox listBox;

	public Image songImage;


	void Start(){
		
	}
	// Use this for initialization
	public void SetupBox(SongInfo songInfo) {
		songName = GetComponentInChildren<Text> ();
		listBox = GetComponent<ListBox> ();
		songName.text = songInfo.name;
		songImage.sprite = songInfo.icon();
	}

	public void didClick(){
		MusicGameSongManager.Instance.SelectSong (listBox.listBoxID);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
