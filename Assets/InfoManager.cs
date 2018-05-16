using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public class InfoManager : Singleton<InfoManager> {
	public List<GameLevelInfo> levelList;


	// Use this for initialization
	public  void SetupGameLevel () {
		levelList = CsvUtil.LoadObjects<GameLevelInfo> ("Assets/Resources/levelCsv.csv");
	}
}
