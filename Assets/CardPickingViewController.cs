﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPickingViewController : MonoBehaviour {
	public GameObject cardList;
	public GameObject thumbCardPrefab;
	public GameObject cardDetailViewPrefab;

	public CardThumbCell[] selectedPlayingCards;
	public CardThumbCell[] selectedHelpingCards;
	// Use this for initialization
	void Start () {
		updateView ();
		CardManager.Instance.CardChange += updateView;
	}

	public void updateView(){
		Debug.Log ("update view");
		foreach (Transform child in cardList.transform) {
			Destroy (child.gameObject);
		}

		foreach (string key in CardManager.Instance.UseableCards()) {
			GameObject go = Instantiate (thumbCardPrefab) as GameObject;
			go.GetComponent<CardThumbCell> ().setup (key);
			go.transform.parent = cardList.transform;
			go.GetComponentInChildren<Button>().onClick.AddListener(() => ClickCard(go.GetComponent<CardThumbCell>().cardIdentifier));
		}

		for (int i = 0; i < CardManager.Instance.selectedPlayingCards.Count; i++) {
			selectedPlayingCards [i].setup (CardManager.Instance.selectedPlayingCards [i]);
		}
	}

	void ClickCard(string cardIdentifier) {
		Debug.Log ("click"+cardIdentifier);
		GameObject cardDetailView = Instantiate (cardDetailViewPrefab,transform) as GameObject;
		//cardDetailView.SetActive (true);
		cardDetailView.GetComponent<CardDetailViewController> ().Setup (cardIdentifier);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
