using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BeatResultType  {JustPerfect,Perfect,Great,Good,Bad,Miss};
public class MusicGameLogic : MonoBehaviour {

	public AudioSource audioSource;

	float timePast = 0.0f;
	bool isStartedRecord = false;
	float audioLength;

	int beatMapIndex;
	List<Beat> [] tapBeats;

	public float showPadsBeforeSeconds = 2;
	public float missSeconds = 0.5f;
	public float perfectMissSeconds = 0.05f;
	public float greatMissSeconds = 0.15f;
	public float goodMissSeconds = 0.25f;
	public float justPerfectSeconds = 0.03f;
	public float perfectSeconds = 0.1f;
	public float greatSeconds = 0.3f;
	public float goodSeconds = 0.5f;
	public float badSeconds = 1.0f;

	public Text timeText;

	public RectTransform originRect;
	public RectTransform[] targetRects;

	public GameObject padPrefab;

	public RectTransform beatRect;
	public GameObject beatResultPrefab;

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
						ShowBeatResult (BeatResultType.Miss);
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
				//Debug.Log ("show pads");
				ShowPads (beat);
			}
		}
	}

	void ShowPads(Beat beat){
		GameObject go = Instantiate (padPrefab) as GameObject;
		go.transform.parent = transform;
		go.GetComponent<DropingBeat>().Setup(originRect, targetRects [beat.key]);
	}


	void ShowBeatResult(BeatResultType result) {
		GameObject go = Instantiate (beatResultPrefab) as GameObject;
		go.transform.parent = transform;
		go.GetComponent<BeatResult>().Setup(result,beatRect);
	}

	void ChangeTime(float value) {
		timePast = value;
		timeText.text = timePast.ToString();
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
		if (tapBeats [key].Count >= 1) {
			Beat beat = tapBeats [key] [0];
			if (beat.time >= timePast + badSeconds) {
				//ignore
				return;
			} else if (beat.time >= timePast + goodSeconds) {
				ShowBeatResult (BeatResultType.Bad);
				Debug.Log ("bad!"+beat.time+" "+timePast);
			} else if (beat.time >= timePast + greatSeconds) {
				ShowBeatResult (BeatResultType.Good);
				Debug.Log ("good!"+beat.time+" "+timePast);
			} else if (beat.time >= timePast + perfectSeconds) {
				ShowBeatResult (BeatResultType.Great);
				Debug.Log ("great!"+beat.time+" "+timePast);
			} else if (beat.time >= timePast + justPerfectSeconds) {
				ShowBeatResult (BeatResultType.Perfect);
				Debug.Log ("perfect!"+beat.time+" "+timePast);
			} else if (beat.time >= timePast - justPerfectSeconds) {
				ShowBeatResult (BeatResultType.JustPerfect);
				Debug.Log ("perfect!"+beat.time+" "+timePast);
			} else if (beat.time >= timePast - perfectMissSeconds) {
				ShowBeatResult (BeatResultType.Perfect);
				Debug.Log ("perfect!"+beat.time+" "+timePast);
			} else if (beat.time >= timePast - greatMissSeconds) {
				ShowBeatResult (BeatResultType.Great);
				Debug.Log ("great!"+beat.time+" "+timePast);
			} else if (beat.time >= timePast - goodMissSeconds) {
				ShowBeatResult (BeatResultType.Good);
				Debug.Log ("good!"+beat.time+" "+timePast);
			} else {
				ShowBeatResult (BeatResultType.Bad);
				Debug.Log ("bad!"+beat.time+" "+timePast);
			} 
			tapBeats [key].RemoveAt (0);
		}
	}

//	public void SaveBeatmap() {
//		JSONFactory.JSONAssembly.SaveBeatmapToJson (beatmap,"quite");
//	}
}
