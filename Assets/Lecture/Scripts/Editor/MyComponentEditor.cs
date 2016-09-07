using UnityEngine;
using UnityEditor; //에디터 편집시 필수사항
using UnityEditor.SceneManagement;
using System.Collections;


[CustomEditor(typeof(MyComponent))]//누구(클래스,등등)를 위한 에디터인지 알려주기 위해
public class MyComponentEditor : Editor
{
    SerializedProperty intVariable;
    SerializedProperty floatVariable;
    SerializedProperty gameObjectlist;

    void OnEnable() //클릭하는순간
    {
        intVariable = serializedObject.FindProperty("intVariable");
        floatVariable = serializedObject.FindProperty("floatVariable");
        gameObjectlist = serializedObject.FindProperty("gameObjectlist");
    }

    public override void OnInspectorGUI() //보여지는동안
    {
        ////base : 상위 객체
        //base.OnInspectorGUI();

        // Automatic Management(변경사항을 자동으로 관리)
        serializedObject.Update(); //동기화,리플레쉬
        EditorGUILayout.PropertyField(intVariable, new GUIContent("Var1"));
        EditorGUILayout.PropertyField(floatVariable, new GUIContent("Var2"));
        EditorGUILayout.PropertyField(gameObjectlist, new GUIContent("List"),true);

        serializedObject.ApplyModifiedProperties();


        //Menual management (커스텀)
        MyComponent myComponent = (MyComponent)target;

        int a = EditorGUILayout.IntField("Int Var", myComponent.IntVar);
        if (a != myComponent.IntVar)
        {
            myComponent.IntVar = a;
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        if (GUILayout.Button("Do something") == true)
        {
            myComponent.DoSomethig();
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        //if ( GUILayout.Button("Show My Window") == true)
        //{
        //    //MyEditorWindow.ShowWindow();
        //}

    }

}
