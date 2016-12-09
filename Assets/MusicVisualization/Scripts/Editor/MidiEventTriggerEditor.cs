using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(MidiEventTrigger))]
public class MidiEventTriggerEditor : Editor {

    SerializedProperty midiPlayer;
    private bool foldout = false;
    private bool foldout2 = false;
    private bool[] _enableInstrumentFilters;
    private bool[] _enableNoteFilters;

    SerializedProperty eventNoteOn;
    SerializedProperty eventNoteOff;

    void OnEnable()
    {
        midiPlayer = serializedObject.FindProperty("midiPlayer");
        eventNoteOn = serializedObject.FindProperty("eventNoteOn");
        eventNoteOff = serializedObject.FindProperty("eventNoteOff");

        MidiEventTrigger trigger = (MidiEventTrigger)target;
        MidiPlayer player = trigger.midiPlayer;
        _enableInstrumentFilters = player.midi.GetInstrumentFilter();
        _enableNoteFilters = player.midi.GetNoteFilter();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(midiPlayer);
        EditorGUILayout.PropertyField(eventNoteOn, new GUIContent("Note On"));
        EditorGUILayout.PropertyField(eventNoteOff, new GUIContent("Note Off"));

        serializedObject.ApplyModifiedProperties();


        MidiEventTrigger trigger = (MidiEventTrigger)target;

        #region instrumentFilter
        foldout = EditorGUILayout.Foldout(foldout, "Instrument Filter");
        if (foldout == true)
        {
            if (GUILayout.Button("Check All"))
            {
                for (int i = 0; i < 129; i++)
                {
                    trigger.instrumentFilter[i] = true;
                }
            }
            if (GUILayout.Button("Clear All"))
            {
                for (int i = 0; i < 129; i++)
                {
                    trigger.instrumentFilter[i] = false;
                }
            }
            for (int i = 0; i < 129; i++)
            {
                if (_enableInstrumentFilters[i] == false)
                {
                    continue;
                }

                bool newValue = GUILayout.Toggle(trigger.instrumentFilter[i], MidiFile.Instruments[i]);
                if (newValue != trigger.instrumentFilter[i])
                {
                    trigger.instrumentFilter[i] = newValue;
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                }
            }
        }
        #endregion
        
        foldout2 = EditorGUILayout.Foldout(foldout2, "Note Filter");
        if (foldout2 == true)
        {
            if (GUILayout.Button("Check All"))
            {
                for (int i = 0; i < 128; i++)
                {
                    trigger.noteFilter[i] = true;
                }
            }
            if (GUILayout.Button("Clear All"))
            {
                for (int i = 0; i < 128; i++)
                {
                    trigger.noteFilter[i] = false;
                }
            }

            #region Button C~B
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("C"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 0)
                    {
                        if(trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if(allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 0)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 0)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("C#"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 1)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 1)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 1)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("D"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 2)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 2)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 2)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("D#"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 3)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 3)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 3)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("E"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 4)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 4)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 4)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("F"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 5)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 5)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 5)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("F#"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 6)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 6)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 6)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("G"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 7)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 7)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 7)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("G#"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 8)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 8)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 8)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("A"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 9)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 9)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 9)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("A#"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 10)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 10)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 10)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }

            if (GUILayout.Button("B"))
            {
                bool allTrue = true;
                for (int i = 0; i < 128; i++)
                {
                    if ((int)i % 12 == 11)
                    {
                        if (trigger.noteFilter[i] == false)
                        {
                            allTrue = false;
                        }
                    }
                }

                if (allTrue == true)
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 11)
                        {
                            trigger.noteFilter[i] = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 128; i++)
                    {
                        if ((int)i % 12 == 11)
                        {
                            trigger.noteFilter[i] = true;
                        }
                    }
                }
            }
            EditorGUILayout.EndHorizontal();
            #endregion


            for (int i = 0; i < 128; i++)
            {
                //if (_enableNoteFilters[i] == false)
                //{
                //    GUILayout.Label(NoteNumberToString(i));
                //}

                bool newValue = GUILayout.Toggle(trigger.noteFilter[i], NoteNumberToString(i));
                if (newValue != trigger.noteFilter[i])
                {
                    trigger.noteFilter[i] = newValue;
                    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
                }
            }
        }
    }

    string NoteNumberToString(int number)
    {
        int index = (int)(number % 12);
        int octave = (int)(number / 12);
        switch (index)
        {
            case 0:
                {
                    return string.Format("C{0:d}", octave);
                }
            case 1:
                {
                    return string.Format("C#{0:d}", octave);
                }
            case 2:
                {
                    return string.Format("D{0:d}", octave);
                }
            case 3:
                {
                    return string.Format("D#{0:d}", octave);
                }
            case 4:
                {
                    return string.Format("E{0:d}", octave);
                }
            case 5:
                {
                    return string.Format("F{0:d}", octave);
                }
            case 6:
                {
                    return string.Format("F#{0:d}", octave);
                }
            case 7:
                {
                    return string.Format("G{0:d}", octave);
                }
            case 8:
                {
                    return string.Format("G#{0:d}", octave);
                }
            case 9:
                {
                    return string.Format("A{0:d}", octave);
                }
            case 10:
                {
                    return string.Format("A#{0:d}", octave);
                }
            case 11:
                {
                    return string.Format("B{0:d}", octave);
                }
        }
        return "UnKnown";
    }

}
