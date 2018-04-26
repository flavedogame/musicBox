﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardPickingViewController : MonoBehaviour {
	public GameObject cardList;
	public GameObject thumbCardPrefab;
	public GameObject cardDetailViewPrefab;

	public CardThumbCell[] selectedPlayingCards;
	public CardThumbCell[] selectedHelpingCards;

	//song info
	public Text songName;
	public Text songAttribute;
	public Text songSpecialAttribute;

	public Button backButton;
	public Button cancelButton;
	public Button nextButton;

	// Use this for initialization
	void Start () {
		updateView ();
		CardManager.Instance.CardChange += updateView;
		backButton.onClick.AddListener(() => Back());
		nextButton.onClick.AddListener(() => DecideCards());
	}

	public void updateView(){
		updateCardView ();
		updateSongView ();
	}

	public void updateCardView() {
		//Debug.Log ("update view");
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

	public void updateSongView() {
		SongInfo songInfo = MusicGameSongManager.Instance.SelectedSong ();
		Debug.Log (songInfo.name);
		songName.text = songInfo.name;
		songAttribute.text = songInfo.basicAttribute ();
		songSpecialAttribute.text = songInfo.special;
	}

	void ClickCard(string cardIdentifier) {
		Debug.Log ("click"+cardIdentifier);
		GameObject cardDetailView = Instantiate (cardDetailViewPrefab,transform) as GameObject;
		//cardDetailView.SetActive (true);
		cardDetailView.GetComponent<CardDetailViewController> ().Setup (cardIdentifier);
	}

	void Back(){
			Debug.Log ("switch scene");
			SceneManager.LoadScene ("song picking");

	}

	public void DecideCards() {
		Debug.Log ("switch scene");
		SceneManager.LoadScene ("music game");
	}

	void OnDestroy(){
		CardManager.Instance.CardChange -= updateView;
		backButton.onClick.RemoveAllListeners ();
		nextButton.onClick.RemoveAllListeners ();
	}
}
