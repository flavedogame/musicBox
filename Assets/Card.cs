using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	public CardInfo cardInfo;
	int level;
	// Use this for initialization
	void Start () {
		
	}

	public Card(string infoKey,int l){
		cardInfo = CardInfoManager.Instance.cardDict[infoKey];
		level = l;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
