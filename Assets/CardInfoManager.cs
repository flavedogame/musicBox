using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sinbad;

public class CardInfoManager : Singleton<CardInfoManager> {
	public Dictionary<string,CardInfo> cardDict;
	// Use this for initialization
	public  void Setup () {
		List<CardInfo> cardList = CsvUtil.LoadObjects<CardInfo> ("Assets/Resources/cardCsv.csv");
		//Debug.Log ("start card info Manager");
		cardDict = new Dictionary<string, CardInfo> ();
		foreach (CardInfo info in cardList) {
			//Debug.Log (info.identifier + " " + info.description);
			cardDict [info.identifier] = info;
		}
	}
}
