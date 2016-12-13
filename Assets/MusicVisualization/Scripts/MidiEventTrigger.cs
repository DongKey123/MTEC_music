using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MidiEventTrigger : MonoBehaviour
{
    public GameObject[] notes;

    public MidiPlayer midiPlayer;
    public bool[] instrumentFilter = new bool[129];
    public bool[] noteFilter = new bool[128];

    public UnityEvent eventNoteOn;
    public UnityEvent eventNoteOff;

    private bool _noteOn = false;

	public void Play()
	{
        _noteOn = false;
        OnPlay();
	}

	public void Pause()
	{
        OnPause();
	}

	public void Resume()
	{
        OnResume();
	}

	public void Stop()
	{
        OnStop();
    }

	public void NoteOn(int instrument, int noteNumber)
	{
        if(_noteOn == false)
        {
            _noteOn = true;
            if(instrumentFilter[instrument] == true && noteFilter[noteNumber] == true)
            {
                if(notes[noteNumber] != null)
                {
                    notes[noteNumber].SetActive(true);
                }
                eventNoteOn.Invoke();
                OnNoteOn(noteNumber);
            }
        }
	}

	public void NoteOff(int instrument, int noteNumber)
	{
        _noteOn = false;
        if (instrumentFilter[instrument] == true && noteFilter[noteNumber] == true)
        {
            if (notes[noteNumber] != null)
            {
                notes[noteNumber].SetActive(false);
            }
            eventNoteOff.Invoke();
            OnNoteOff(noteNumber);
        }
	}

    protected virtual void OnPlay()
    {

    }

    protected virtual void OnPause()
    {

    }

    protected virtual void OnResume()
    {

    }

    protected virtual void OnStop()
    {

    }

    protected virtual void OnNoteOn(int note)
    {

    }

    protected virtual void OnNoteOff(int note)
    {

    }
}
