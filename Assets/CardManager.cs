using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : Singleton<CardManager> {

	public Dictionary<string,Card> cardDict;

	// Use this for initialization
	public void Start () {
	}

	public void Setup() {
		Debug.Log ("start cardManager");
		cardDict = new Dictionary<string, Card> ();
		foreach (string key in CardInfoManager.Instance.cardDict.Keys) {
			Card card = new Card (key, 1);
			cardDict [key] = card;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
