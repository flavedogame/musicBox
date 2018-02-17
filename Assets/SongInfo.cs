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
