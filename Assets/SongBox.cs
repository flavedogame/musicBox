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
	public void SetupBox(string name,Sprite sprite) {
		songName = GetComponentInChildren<Text> ();
		songImage = GetComponent<Image> ();
		songName.text = name;
		songImage.sprite = sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
