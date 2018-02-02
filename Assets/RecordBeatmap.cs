﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordBeatmap : MonoBehaviour {

	public AudioSource audioSource;
	public Slider slider;

	float timePast = 0.0f;
	bool isStartedRecord = false;
	float audioLength;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isStartedRecord) {
			ChangeTime (timePast+ Time.deltaTime);
		}
	}

	void ChangeTime(float value) {
		timePast = value;
		slider.value = timePast / audioLength;
	}

	public void ChangeSlider() {
			timePast = slider.value * audioLength;
			audioSource.time = timePast;
	}

	public void HitButton(int index) {
		
	}

	public void StartRecord(){
		audioSource.Play ();
		timePast = 0.0f;
		audioLength = audioSource.clip.length;
		isStartedRecord = true;
	}

	public void PauseRecord(){
		if (isStartedRecord) {
			audioSource.Pause ();
			isStartedRecord = false;
		} else {
			ResumeRecord ();
		}
	}

	public void ResumeRecord(){
		audioSource.Play ();
		isStartedRecord = true;
	}

	public void Backward(){
		audioSource.time = Mathf.Max ((audioSource.time - 5.0f), 0);
		ChangeTime (audioSource.time);
	}

	public void Forward(){
		audioSource.time = Mathf.Min ((audioSource.time + 5.0f), audioLength-0.1f);
		ChangeTime (audioSource.time);
	}
}
