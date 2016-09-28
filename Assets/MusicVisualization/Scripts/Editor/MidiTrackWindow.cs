using UnityEngine;
using UnityEditor;
using System.Collections;

public class MidiTrackWindow : EditorWindow {
    
    
    [MenuItem("Midi/MidiTrackWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MidiTrackWindow), false, "Midi Track");
    }

    void OnGUI()
    {
        Rect rect;
        float titleHeight = 30f;
        float musicalScaleWidth = 60f;
        float timeHeight = 50f;

        //Draw Title Area
        rect = new Rect(0,0,this.position.width,30);
        GUI.Box(rect, "");
        GUILayout.BeginArea(rect);
        GUILayout.EndArea();

        //Draw Musical Area
        rect = new Rect(0, titleHeight, musicalScaleWidth, this.position.height - titleHeight);
        GUI.Box(rect, "");
        GUI.BeginGroup(rect);
        GUI.EndGroup();

        //Draw Track Area
        rect = new Rect(position.width * 0.75f, titleHeight, position.width * 0.25f, this.position.height - titleHeight);
        GUI.Box(rect, "");
        GUI.BeginGroup(rect);
        GUI.EndGroup();

        //Draw Time Area
        rect = new Rect(musicalScaleWidth, titleHeight, position.width * 0.75f - musicalScaleWidth, timeHeight);
        GUI.Box(rect, "");
        GUI.BeginGroup(rect);
        GUI.EndGroup();

        //Draw Note Area
        rect = new Rect(musicalScaleWidth, titleHeight+timeHeight, position.width * 0.75f - musicalScaleWidth, this.position.height - titleHeight - timeHeight);
        GUI.Box(rect, "");
        GUI.BeginGroup(rect);
        GUI.EndGroup();

    }
}
