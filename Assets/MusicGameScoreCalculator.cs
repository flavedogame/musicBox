using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGameScoreCalculator : MonoBehaviour {
	public MusicGameMusic songInfo;
	public MusicGameLogic gameLogic;

	public int[] countByBeatResult;
	[HideInInspector]
	public int comboCount;
	public int maxComboCount;

	public float score;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		songInfo = GetComponent<MusicGameMusic> ();
		//countByBeatResult = new int[6];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetBeatResult(BeatResultType beatResult){
		float baseScore = 0;
		comboCount += 1;
		switch (beatResult) {
		case BeatResultType.Bad:
		case BeatResultType.Miss:
			baseScore = 0;
			comboCount = 0;
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
		maxComboCount = Mathf.Max (comboCount, maxComboCount);
		countByBeatResult [(int)beatResult]++;
		score += baseScore*5;

		UpdateGameLogic ();
	}

	public void UpdateGameLogic(){
		gameLogic.updateComboText (comboCount);

		int[] scores = songInfo.GetScores();
		gameLogic.UpdatePregressSlide(score / (float)scores [3]);
	}
}
