using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour {

	public SongInfo songInfo;
	int level;
	// Use this for initialization
	void Start () {

	}

	public Song(string infoKey,int l){
		songInfo = SongInfoManager.Instance.songDict[infoKey];
		level = l;
	}

	// Update is called once per frame
	void Update () {

	}
}
