using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatmapEvent{
	public List<Beatmap> dialogues;

}

public enum TouchType{
	single,longTouch,swipe
}

public enum AttributeType{
	deep,pure,passion,fun,think
}

public struct Beatmap{
	public float time;
	public AttributeType attr;
	public TouchType touch;
	public int key;
}
