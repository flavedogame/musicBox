using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
