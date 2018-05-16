using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelManager : Singleton<GameLevelManager> {

	public void Setup(){
	}
	// Use this for initialization
	void Start () {
		
	}

	public GameLevelInfo CurrentLevelInfo(){
		return InfoManager.Instance.levelList [0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
