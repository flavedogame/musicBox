using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPickingViewController : MonoBehaviour {
	public GameObject cardList;
	public GameObject thumbCardPrefab;
	// Use this for initialization
	void Start () {
		Debug.Log ("cardList in picking" + CardInfoManager.Instance.cardDict.Keys);
		foreach (string key in CardManager.Instance.cardDict.Keys) {
			GameObject go = Instantiate (thumbCardPrefab) as GameObject;
			go.GetComponent<CardThumbCell> ().setup (key);
			go.transform.parent = cardList.transform;
			go.GetComponentInChildren<Button>().onClick.AddListener(() => ClickCard(go.GetComponent<CardThumbCell>().cardIdentifier));
		}
	}

	void ClickCard(string cardIdentifier) {
		Debug.Log ("click"+cardIdentifier);
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
