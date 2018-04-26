﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songListViewController : MonoBehaviour {

	public GameObject songBoxPrefab;

	// Use this for initialization
	void Start () {
		ListBox lastBoxScript = null;
		ListBox firstBoxScript = null;
		for (int i = 0; i < MusicGameSongManager.Instance.songNames.Count; i++) {
			SongInfo songInfo = MusicGameSongManager.Instance.songDict[MusicGameSongManager.Instance.songNames [i]].songInfo;
			GameObject songBox = Instantiate (songBoxPrefab,transform) as GameObject;
			songBox.name = songInfo.identifier;
			songBox.transform.parent = transform;
			songBox.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (0, 0, 0);

			SongBox songBoxScript = songBox.GetComponent<SongBox> ();
			songBoxScript.SetupBox (songInfo);

			ListBox listBoxScript = songBox.GetComponent<ListBox> ();
			if (lastBoxScript != null) {
				lastBoxScript.nextListBox = listBoxScript;
			} else {
				firstBoxScript = listBoxScript;
			}
			listBoxScript.listBoxID = i;
			listBoxScript.lastListBox = lastBoxScript;
			lastBoxScript = listBoxScript;
		}
		firstBoxScript.lastListBox = lastBoxScript;
		lastBoxScript.nextListBox = firstBoxScript;

		GetComponent<ListPositionCtrl> ().Start ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
