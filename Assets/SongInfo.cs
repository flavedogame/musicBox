using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Sinbad;

public class SongInfo : MonoBehaviour {
		public string identifier;
		public string name;
		public string description;
		public int okScore;
		public int greatScore;
		public int perfectScore;
		public int justPerfectScore;
	public int difficulty;
	//public float songSampleStartTime;
	//public float songSampleEndTime;

	public Sprite image() {
		string path = "songBG/" + identifier;
		Sprite sprite = Resources.Load<Sprite> (path);//format to be decided
		//Debug.Log(sprite);
		if (sprite == null) {
			Debug.LogError ("sprite not exist for path: "+path);
		}
		return sprite;
	}

	public Sprite icon() {
		string path = "songBG/" + identifier+"_i";
		Sprite sprite = Resources.Load<Sprite> (path);//format to be decided
		//Debug.Log(sprite);
		if (sprite == null) {
			Debug.LogError ("sprite not exist for path: "+path);
		}
		return sprite;
	}

	public AudioClip audioClip(){
		string path = "music/" + identifier;
		AudioClip clip = Resources.Load<AudioClip> (path);
		if (clip == null) {
			Debug.LogError ("clip not exist for path: " + path);
		}
		return clip;
	}

	public string Description() {
		return "\"" + description + "\"";
	}

	static public List<SongInfo> loadSongInfo(TextAsset songInfos) {
		List<SongInfo> objs;
		using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(songInfos.text))) {
			using (var sr = new StreamReader(ms,System.Text.Encoding.UTF8)) {
				objs = CsvUtil.LoadObjects<SongInfo>(sr);
			}
		}
		return objs;
	}

	static public List<SongInfo> loadSongInfo(string songInfosName) {
		return CsvUtil.LoadObjects<SongInfo> (songInfosName);
	}
}
