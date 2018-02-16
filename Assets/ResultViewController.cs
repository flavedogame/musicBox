using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewController : MonoBehaviour {

	public Text finalResultText;
	public Text newBestText;
	public Text finalScoreText;
	public Text maxComboText;
	public Text[] countTextByBeat;

	public MusicGameScoreCalculator scoreCalculator;


	// Use this for initialization
	void Start () {


		finalScoreText.text = ((int)scoreCalculator.score).ToString();
		//read song info and set result and new best
		//finalResultText.text =  
		maxComboText.text = scoreCalculator.maxComboCount.ToString();

		for(int i = 0;i < scoreCalculator.countByBeatResult.Length;i++){
			//countTextByBeat[i].text = scoreCalculator.countByBeatResult[i].ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
