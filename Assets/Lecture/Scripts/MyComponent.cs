using UnityEngine;
using System.Collections;

public class MyComponent : MonoBehaviour {

    public int intVarialble;
    public float floatVariable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DoSomethig()
    {
        intVarialble++;
    }

    public int IntVar
    {
        get
        {
            return intVarialble;
        }
        set
        {
            intVarialble = value;
        }
    }
}
