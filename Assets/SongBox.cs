using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongBox : MonoBehaviour {

	Text songName;
	Image songImage;
	ListBox listBox;



	void Start(){
		
	}
	// Use this for initialization
	public void SetupBox(SongInfo songInfo) {
		songName = GetComponentInChildren<Text> ();
		songImage = GetComponent<Image> ();
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
