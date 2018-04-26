using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardManager : Singleton<CardManager> {

	public Dictionary<string,Card> cardDict;
	public List<string> cardList;

	public List<string> selectedPlayingCards;
	public List<string> selectedHelpingCards;

	public delegate void Action ();
	public event Action CardChange;

	// Use this for initialization
	public void Start () {
	}

	public void Setup() {
		Debug.Log ("start cardManager");
		cardDict = new Dictionary<string, Card> ();
		cardList = new List<string> ();
		selectedPlayingCards = new List<string> ();
		selectedHelpingCards = new List<string> ();
		foreach (string key in CardInfoManager.Instance.cardDict.Keys) {
			Card card = new Card (key, 1);
			Debug.Log ("ccc" + card.cardInfo);
			cardDict [key] = card;
			cardList.Add (key);
		}
	}

	public void SelectToPlay(string cardIdentifier){
		//check if the same person

		//check if there is room for playing

		selectedPlayingCards.Add (cardIdentifier);
		Debug.Log ("select in manager"+cardIdentifier);
		CardChange ();
	}

	public List<string> UseableCards() {
		if( selectedPlayingCards.Count>0)
		Debug.Log ("selectedPlaying Cards " + selectedPlayingCards[0]);
		return cardList.FindAll((x)=>(!selectedHelpingCards.Contains(x) && !selectedPlayingCards.Contains(x)));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
