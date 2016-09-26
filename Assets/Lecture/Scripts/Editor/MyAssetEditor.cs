﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(MyAsset))]
public class MyAssetEditor : Editor {
    
    void OnEnable()
    {

    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        MyAsset myAsset = (MyAsset)target;

        myAsset.intVar = EditorGUILayout.IntField("IntVar", myAsset.intVar);
        myAsset.floatVar = EditorGUILayout.FloatField("FloatVar", myAsset.floatVar);

        if(GUILayout.Button("Apply") == true)
        {
            EditorUtility.SetDirty(target); //에디터에게 저장될 것을 알려주는 함수
            AssetDatabase.SaveAssets(); //디스크에 저장되지 않는 모든 변경사항을 저장 (codo : 나중에 질문)
        }

        if (GUILayout.Button("Revert") == true)
        {
            myAsset.Revert();
            EditorUtility.SetDirty(target);
            AssetDatabase.SaveAssets();
        }
    }

    [MenuItem("Assets/Create/MyAsset")]
    public static void CreateMyAsset()
    {
        MyAsset asset = CreateInstance<MyAsset>();

        //EditorUtility.OpenFilePanel("Save", null, null);

        AssetDatabase.CreateAsset(asset, "Assets/MyAsset.asset");
        AssetDatabase.SaveAssets();
    }

}
