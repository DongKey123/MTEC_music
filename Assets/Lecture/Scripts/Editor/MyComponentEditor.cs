using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomEditor(typeof(MyComponent))]
public class MyComponentEditor : Editor
{
    void OnEnable() //클릭하는순간
    {
    }

    public override void OnInspectorGUI() //보여지는동안
    {
        Debug.Log("Editor");
        ////base : 상위 객체
        //base.OnInspectorGUI();

        MyComponent myComponent = (MyComponent)target;
        myComponent.intVarialble = EditorGUILayout.IntField("Int Variable", myComponent.intVarialble);
        myComponent.floatVariable = EditorGUILayout.Slider("Float Variable", myComponent.floatVariable, 0f, 1f);

        myComponent.intVarialble = EditorGUILayout.IntField("Int Variable", myComponent.IntVar);
        //myComponemt.intVarialble = EditorGUILayout.IntField("Int Variable", myComponemt.IntVar);

        if (GUILayout.Button("Do something") == true)
        {
            myComponent.DoSomethig();
        }

    }

}
