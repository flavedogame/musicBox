using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicGameLogic : MonoBehaviour {

	public AudioSource audioSource;

	float timePast = 0.0f;
	bool isStartedRecord = false;
	float audioLength;

	int beatMapIndex;
	List<Beat> [] tapBeats;

	public float showPadsBeforeSeconds = 2;
	public float missSeconds = 0.5f;
	public float perfectSeconds = 0.1f;
	public float greatSeconds = 0.3f;
	public float goodSeconds = 0.5f;
	public float badSeconds = 1.0f;

	public RectTransform originRect;
	public RectTransform[] targetRects;

	public GameObject padPrefab;

	BeatmapEvent beatmap;

	// Use this for initialization
	void Start () {
		StartPlay ();
	}

	// Update is called once per frame
	void Update () {
		int i = 0;
		if (isStartedRecord) {
			ChangeTime (timePast+ Time.deltaTime);

			foreach (List<Beat> beatRaw in tapBeats) {
				while (beatRaw.Count >= 1 && beatRaw [0].time + missSeconds <= timePast) {
						beatRaw.RemoveAt (0);
						Debug.Log ("miss!");
						i++;
						if (i > 10) {
							break;
						}
				}
			}
			while (beatmap.beats.Count>=1 && beatmap.beats [0].time <= timePast + showPadsBeforeSeconds) {
				Beat beat = beatmap.beats [0];
				beatmap.beats.RemoveAt (0);
				tapBeats [beat.key].Add (beat);
				Debug.Log ("show pads");
				ShowPads (beat);
			}
		}
	}

	void ShowPads(Beat beat){
		GameObject go = Instantiate (padPrefab) as GameObject;
		go.transform.parent = transform;
		go.GetComponent<DropingBeat>().Setup(originRect, targetRects [beat.key]);
	}

	void ChangeTime(float value) {
		timePast = value;
	}

	public void HitKey(int index){
		RecordKey (index, TouchType.single);
	}

	public void StartPlay(){
		audioSource.Play ();
		timePast = 0.0f;
		audioLength = audioSource.clip.length;
		isStartedRecord = true;
		beatmap = JSONFactory.JSONAssembly.RunJSONFactoryForBeatmap ("quiet");
		tapBeats = new List<Beat>[4];
		for (int i = 0; i < 4; i++) {
			tapBeats [i] = new List<Beat> ();
		}
		beatMapIndex = 0;
	}

	public void PauseRecord(){
		if (isStartedRecord) {
			audioSource.Pause ();
			isStartedRecord = false;
		} else {
			ResumeRecord ();
		}
	}

	void ResumeRecord(){
		audioSource.Play ();
		isStartedRecord = true;
	}

	public void RecordKey(int key, TouchType touchType){
		beatmap.beats.Add (new Beat (timePast, key, touchType));
		Debug.Log (beatmap.beats);
	}

//	public void SaveBeatmap() {
//		JSONFactory.JSONAssembly.SaveBeatmapToJson (beatmap,"quite");
//	}
}
