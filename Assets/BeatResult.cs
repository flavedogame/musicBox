using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BeatResult : MonoBehaviour {
	bool finishedSetup;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public string resultNameByBeatResultType(BeatResultType type){
		switch (type) {
		case BeatResultType.JustPerfect:
			return "嚯厉害厉害";
		case BeatResultType.Perfect:
			return "厉害厉害";
		case BeatResultType.Great:
			return "真棒";
		case BeatResultType.Good:
			return "还行";
		case BeatResultType.Bad:
			return "哎呦喂早了";
		case BeatResultType.Miss:
			return "哎呦喂过去了";
		}
		return "???";
	}

	public void Setup(BeatResultType result, RectTransform r){
		RectTransform rect = GetComponent<RectTransform> ();
		rect.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
		rect.position = r.position;
		Text text = GetComponent<Text>();
		switch (result) {
		case BeatResultType.JustPerfect:
			text.text = "嚯厉害厉害";
			text.color = new Color (1, 1, 0);
			text.fontSize = 60;
			break;
		case BeatResultType.Perfect:
			text.text = "厉害厉害";
			text.color = new Color (1, 0.5f, 0);
			text.fontSize = 50;
			break;
		case BeatResultType.Great:
			text.text = "真棒";
			text.color = new Color (0, 0.2f, 1);
			text.fontSize = 40;
			break;
		case BeatResultType.Good:
			text.text = "还行";
			text.color = new Color (0, 1, 0);
			text.fontSize = 40;
			break;
		case BeatResultType.Bad:
		case BeatResultType.Miss:
			text.text = "哎呦喂。。";
			text.color = new Color (1, 0, 0);
			text.fontSize = 40;
			break;

		}
		Destroy (gameObject, 1);


		finishedSetup = true;
	}
}
