using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class MidiPlayer : MonoBehaviour {

    public MidiAsset midi;
    public AudioClip music;
    public AudioSource audioSource;
    public float playDelayTime = 0f;
    public float playSpeed = 1f;

    private bool _isPlaying = false;
    private float _playTime = 0f;
    private float _totalTime = 0f;
    private float _audioDelayTime;
    private float _midiDelayTime;
    private bool _audioStarted = false;
    private MidiTrack[] _tracks;
    private int[] _noteIndex;
    private float _pulseTime;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if(_isPlaying == true)
        {
            //audio delay
            if(_audioDelayTime > 0f)
            {
                _audioDelayTime -= Time.deltaTime;
            }
            else
            {
                if(_audioStarted == false)
                {
                    _audioStarted = true;
                    if (audioSource != null)
                    {
                        audioSource.Play();
                    }
                }
            }
            //midi delay
            if (_midiDelayTime > 0f)
            {
                _midiDelayTime -= Time.deltaTime;
            }
            else
            {
                _playTime += Time.deltaTime * playSpeed;
                for(int i =0;i<_tracks.Length;i++)
                {
                    for(int j =_noteIndex[i];j<_tracks[i].Number;j++)
                    {
                        MidiNote note = _tracks[i].Notes[_noteIndex[i]];
                        float sTime = note.StartTime * _pulseTime;
                        float eTime = note.EndTime * _pulseTime;
                        if (_playTime < sTime)
                        {
                            break;
                        }

                       // Debug.Log(note.Number);

                        if (_playTime > eTime)
                        {
                            _noteIndex[i] = j + 1;
                        }
                    }

                }
            }
        }
	}

    public void Play()
    {
        if (midi == null)
            return;

        if (music != null && audioSource != null)
        {
            audioSource.clip = music;
        }


        _isPlaying = true;
        _playTime = 0f;
        _totalTime = midi.totalTime;
        if(playDelayTime == 0)
        {
            _audioDelayTime = 0;
            _midiDelayTime = 0;
        }
        else if (playDelayTime > 0)
        {
            _audioDelayTime = playDelayTime;
            _midiDelayTime = 0f;
        }
        else
        {
            _audioDelayTime = 0f;
            _midiDelayTime = -playDelayTime;
        }
        _audioStarted = false;
        _tracks = midi.tracks;
        _noteIndex = new int[_tracks.Length];
        for (int i = 0; i < _noteIndex.Length; i++)
            _noteIndex[i] = 0;
    }

    public void Pause()
    {
        if(audioSource != null)
        {
            audioSource.Pause();
        }
        _isPlaying = false;
    }

    public void Resume()
    {
        if (audioSource != null)
        {
            audioSource.UnPause();
        }
        _isPlaying = true;
    }

    public void Stop()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
        _isPlaying = false;
        _playTime = 0f;
    }


    public bool IsPlaying
    {
        get
        {
            return _isPlaying;
        }
    }

    public float playTime
    {
        get
        {
            return _playTime;
        }
    }

    public float totalTime
    {
        get
        {
            return _totalTime;
        }
    }
}
