using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

[CustomEditor(typeof(MidiAsset))]
public class MidiAssetEditor : Editor {

    private bool _foldout = true;
	void OnEnable()
    {
    }

    public override void OnInspectorGUI()
    {
        MidiAsset midiAsset = (MidiAsset)target;

        GUILayout.Label("File Name" + Path.GetFileNameWithoutExtension(midiAsset.fileName));
        GUILayout.Label(string.Format("Total Tiime : {0:f1} sec",midiAsset.totalTime)); // {a,b} a - 순서 b - 타입( d : int, f : float , (아무것도 적혀있지 않았을 때) : string 등등
        _foldout = EditorGUILayout.Foldout(_foldout, "Time Signiture");
        if(_foldout == true)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField(string.Format("PPQN : {0:d}", midiAsset.PPQN));
            EditorGUILayout.LabelField(string.Format("Pulse : {0:f} sec", midiAsset.pulseTime));
            EditorGUILayout.LabelField(string.Format("BPM : {0:d}", midiAsset.BPM));
            EditorGUILayout.LabelField(string.Format("Numerator : {0:d}", midiAsset.numerator));
            EditorGUILayout.LabelField(string.Format("Denominator : {0:d}", midiAsset.denominator));
            EditorGUI.indentLevel--;
        }

        if(GUILayout.Button("Track Viewer"))
        {
            MidiTrackWindow.ShowWindow(midiAsset);
        }
    }
}
