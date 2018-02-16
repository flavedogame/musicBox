using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewController : MonoBehaviour {

	public Text finalResultText;
	public Text newBestText;
	public Text finalScoreText;
	public Text maxComboText;
	public GameObject[] countTextByBeat;

	public MusicGameScoreCalculator scoreCalculator;


	// Use this for initialization
	void Start () {
		GameObject characterManager = GameObject.Find ("CharacterManager");
		scoreCalculator = characterManager.GetComponent<MusicGameScoreCalculator> ();

		finalScoreText.text = ((int)scoreCalculator.score).ToString();
		//read song info and set result and new best
		//finalResultText.text =  
		maxComboText.text = scoreCalculator.maxComboCount.ToString();

		for(int i = 0;i < scoreCalculator.countByBeatResult.Length;i++){
			Text value = countTextByBeat[i].GetComponentsInChildren<Text>()[0];
			Text key = countTextByBeat[i].GetComponentsInChildren<Text>()[1];
			key.text = BeatResult.resultNameByBeatResultType ((BeatResultType)i);
			value.text = scoreCalculator.countByBeatResult[i].ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
