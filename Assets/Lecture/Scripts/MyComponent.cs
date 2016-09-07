using UnityEngine;
using System.Collections;

[AddComponentMenu("Effects/MyComponent Script")]
public class MyComponent : MonoBehaviour {

    public int intVariable;
    public float floatVariable;
    public GameObject[] gameObjectlist;

    [SerializeField]
    private int _IntVar;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DoSomethig()
    {
        intVariable++;
    }

    public int IntVar
    {
        get
        {
            return _IntVar;
        }
        set
        {
            _IntVar = value;
        }
    }
}
