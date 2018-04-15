using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDetailViewController : MonoBehaviour {
	public string cardIdentifier;
	public Text cardName;
	public Image cardPortrait;
	public Text description;
	public Text[] attributes;
	public Text specialAttribute;
	public Text skill;

	public Button closeButton;

	public Button selectToPlayButton;
	public Button selectToHelpButton;


	// Use this for initialization
	void Start () {

		//put in protected method
		closeButton.onClick.AddListener(() => CloseView());
	}

	public void Setup(string identifier){
		//Debug.Log ("cardIdentifier");
		cardIdentifier = identifier;
		Card card = CardManager.Instance.cardDict [identifier];
		CardInfo info = card.cardInfo;
		//Debug.Log (card.cardInfo.name+" cardIdentifier "+cardIdentifier);
		cardName.text = info.name;
		cardPortrait.sprite = info.image();
		specialAttribute.text = info.specialAttribute;
		skill.text = info.Skill ();
		description.text = info.description;

		for (int i = 0; i < attributes.Length; i++) {
			attributes [i].text = info.AllAttributes () [i].ToString();
		}

		selectToPlayButton.onClick.AddListener(() => SelectToPlay());
		selectToHelpButton.onClick.AddListener(() => SelectToHelp());

	}

	void CloseView() {
		Destroy (gameObject);
	}

	void SelectToPlay() {
		Debug.Log ("select to play");
		CardManager.Instance.SelectToPlay (cardIdentifier);
		CloseView ();
	}

	void SelectToHelp() {
		CloseView ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
