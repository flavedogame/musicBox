using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropingBeat : MonoBehaviour {
	RectTransform rect;
	public float duration;
	Vector3 direction;
	bool finishedSetup;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (finishedSetup) {
			rect.position += direction/duration*Time.deltaTime;
		}
	}

	public void Setup(RectTransform originRect, RectTransform targetRect){
		rect = GetComponent<RectTransform> ();
		rect.position = originRect.position;
		direction = targetRect.position - originRect.position;
		finishedSetup = true;
	}
}
