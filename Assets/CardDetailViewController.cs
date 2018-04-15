using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDetailViewController : MonoBehaviour {

	public Text cardName;
	public Image cardPortrait;
	public Text description;
	public Text[] attributes;
	public Text specialAttribute;
	public Text skill;

	public Button closeButton;


	// Use this for initialization
	void Start () {

		//put in protected method
		closeButton.onClick.AddListener(() => CloseView());
	}

	public void Setup(string cardIdentifier){
		//Debug.Log ("cardIdentifier");
		Card card = CardManager.Instance.cardDict [cardIdentifier];
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

	}

	void CloseView() {
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
