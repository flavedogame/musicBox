using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public class SongInfoManager : Singleton<SongInfoManager> {

	public Dictionary<string,SongInfo> songDict;
	// Use this for initialization
	public  void Setup () {
		List<SongInfo> songList = CsvUtil.LoadObjects<SongInfo> ("Assets/Resources/songCsv.csv");
		//Debug.Log ("start card info Manager");
		songDict = new Dictionary<string, SongInfo> ();
		foreach (SongInfo info in songList) {
			//Debug.Log (info.identifier + " " + info.description);
			songDict [info.identifier] = info;
		}
	}
}
