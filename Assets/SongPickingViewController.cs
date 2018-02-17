using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongPickingViewController : MonoBehaviour {
	//song info
	public Image background;
	public Text songName;
	public Text songDescription;
	public Text difficulty;
	public Text highestScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectSong(SongInfo songInfo) {
		background.sprite = songInfo.image();
		songName.text = songInfo.name;
		songDescription.text = songInfo.Description();
		difficulty.text = songInfo.difficulty.ToString();
	}
}
