using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatmapEvent{
	public List<Beat> beats;
	public BeatmapEvent(){
		beats = new List<Beat> ();
	}

}

public enum TouchType{
	single,longTouch,swipe
}

public enum AttributeType{
	deep,pure,passion,fun,think
}

public struct Beat{
	public float time;
	public TouchType touch;
	public int key;

	public Beat(float t, int k, TouchType tou) {
		time = t;
		key = k;
		touch = tou;
	}
}
