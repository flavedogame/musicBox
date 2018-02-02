using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordBeatmap : MonoBehaviour {

	public AudioSource audioSource;

	float timePast = 0.0f;
	bool isStartedRecord = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isStartedRecord) {
			timePast += Time.deltaTime;
		}
	}

	public void HitButton(int index) {
		
	}

	public void StartRecord(){
		audioSource.Play ();
		timePast = 0.0f;
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
	}

	public void Forward(){
		audioSource.time = Mathf.Min ((audioSource.time + 5.0f), audioSource.clip.length-0.1f);
	}
}
