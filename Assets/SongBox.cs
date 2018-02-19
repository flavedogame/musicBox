using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongBox : MonoBehaviour {

	Text songName;
	Image songImage;


	void Start(){
		
	}
	// Use this for initialization
	public void SetupBox(SongInfo songInfo) {
		songName = GetComponentInChildren<Text> ();
		songImage = GetComponent<Image> ();
		songName.text = songInfo.name;
		songImage.sprite = songInfo.icon();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
