using UnityEngine;
using System.Collections;

public class MidiAsset : ScriptableObject //MonoBehavoir  : 엔진상에서 동작하는 , ScriptableObject :Data 저장과 관리를 위해
{
    [SerializeField]
    private MidiFile _midiFile;
    private bool[] _EnableInstrumentFilters;
    private bool[] _EnableNoteFilters;

    public MidiFile GetMidiFile()
    {
        return _midiFile;
    }

    public bool[] GetInstrumentFilter()
    {
        _EnableInstrumentFilters = new bool[129];
        //Initalize
        for (int i=0;i< _EnableInstrumentFilters.Length;++i)
        {
            _EnableInstrumentFilters[i] = false;
        }

        for(int i =0;i<tracks.Length;++i)
        {
            Debug.Log(tracks[i].Instrument);
            _EnableInstrumentFilters[tracks[i].Instrument] = true;
        }

        return _EnableInstrumentFilters;
    }

    public bool[] GetNoteFilter()
    {
        _EnableNoteFilters = new bool[128];
        //Initalize
        for (int i = 0; i < _EnableNoteFilters.Length; ++i)
        {
            _EnableNoteFilters[i] = false;
        }

        for (int i = 0; i < tracks.Length; ++i)
        {
            MidiNote[] notes = tracks[i].Notes.ToArray();
            for (int j = 0; j < notes.Length; j++)
            {
                _EnableNoteFilters[notes[j].Number] = true;
            }
            
        }

        return _EnableNoteFilters;
    }


    public void FileLoad(string path)
    {
        _midiFile = new MidiFile(path); 
    }

    public string fileName
    {
        get
        {
            return _midiFile.FileName;
        }
    }

    public float pulseTime
    {
        get
        {
            return (_midiFile.Time.Tempo / _midiFile.Time.Quarter / 1000000f);
        }
    }


    public float totalTime
    {
        get
        {
            return _midiFile.TotalPulses * pulseTime;
        }
    }

    public int numerator
    {
        get
        {
            return _midiFile.Time.Numerator;
        }
    }

    public int denominator
    {
        get
        {
            return _midiFile.Time.Denominator;
        }
    }

    public int PPQN
    {
        get
        {
            return _midiFile.Time.Quarter;
        }
    }

    public int BPM
    {
        get
        {
            return (int)(60000000 / _midiFile.Time.Tempo);
        }
    }

    public MidiTrack[] tracks
    {
        get
        {
            return _midiFile.Tracks.ToArray();
        }
    }
}
