using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicGameScoreCalculator : MonoBehaviour {
	public Slider resultProgress;
	public MusicGameMusic songInfo;
	float score;

	// Use this for initialization
	void Start () {
		songInfo = GetComponent<MusicGameMusic> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetBeatResult(BeatResultType beatResult){
		float baseScore = 0;
		switch (beatResult) {
		case BeatResultType.Bad:
		case BeatResultType.Miss:
			baseScore = 0;
			break;
		case BeatResultType.Good:
			baseScore = 0.5f;
			break;
		case BeatResultType.Great:	
			baseScore = 1f;
			break;
		case BeatResultType.Perfect:
			baseScore = 1.5f;
			break;
		case BeatResultType.JustPerfect:
			baseScore = 2f;
			break;
		}
		score += baseScore*5;
		UpdateResultProgress ();
	}

	public void UpdateResultProgress(){
		int[] scores = songInfo.GetScores();
		resultProgress.value = score / (float)scores [3];
	}

}
