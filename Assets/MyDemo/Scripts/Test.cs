using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public MidiPlayer midiPlayer;

	// Use this for initialization
	void Start () {
        Debug.Log(midiPlayer.midi.GetNoteFilter());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
