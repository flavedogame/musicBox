using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	public int deep;
	public int pure;
	public int passion;
	public int funny;
	public int think;

	public string keyWords;

	public string okPrize;
	public string greatPrize;
	public string perfectPrize;
	public string justPerfectPrize;


	public int difficulty;

	public string special;

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

	public enum BasicAttribute {deep,pure,passion,funny,think};

	public string basicAttribute() {
		Dictionary<BasicAttribute,int> basicMap = new Dictionary<BasicAttribute, int> ();
		basicMap [BasicAttribute.deep] = deep;
		basicMap [BasicAttribute.pure] = pure;
		basicMap [BasicAttribute.passion] = passion;
		basicMap [BasicAttribute.funny] = funny;
		basicMap [BasicAttribute.think] = think;
		var newDict = basicMap.OrderByDescending(x => x.Value);
		string result = "";
		foreach (KeyValuePair<BasicAttribute, int> kvp in newDict) {
			Debug.Log ("key " + kvp.Key + " value " + kvp.Value);
			result += kvp.Key;
		}
		return result;

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
