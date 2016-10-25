using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InstantiateKeypad : MonoBehaviour {

    public Transform go, parent;
    public Keypad kp;

    void Awake()
    {
        kp = new Keypad(go, parent);
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
