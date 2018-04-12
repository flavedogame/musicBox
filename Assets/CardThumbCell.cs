using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardThumbCell : MonoBehaviour {

	public Image image;
	public string cardIdentifier;
	// Use this for initialization
	void Start () {
		
	}

	public void setup(string identifier) {
		cardIdentifier = identifier;
		image.sprite = CardInfoManager.Instance.cardDict [cardIdentifier].image();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
