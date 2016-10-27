using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

    public GameObject player, keypad, parent, KEY_PAD;
    public Keypad kp;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        CalcDistance(player, KEY_PAD);
	}

    void CalcDistance(GameObject go1, GameObject go2)
    {
        //Debug.Log(Vector3.Distance(go1.transform.position, go2.transform.position));
        if(Vector3.Distance(go1.transform.position, go2.transform.position) < 2 && Input.GetKey(KeyCode.X))
        {
            if (GameObject.Find("Keypad") == null)
            {
                kp = new Keypad(keypad.transform, parent.transform);
            }
        }
        else if(Vector3.Distance(go1.transform.position, go2.transform.position) > 2 && GameObject.Find("Keypad") != null || Input.GetKey(KeyCode.C))
        {
            Destroy(GameObject.Find("Keypad"));
        }

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    RayCast(go1.transform.position);
        //}
    }

    //void RayCast(Vector3 orig)
    //{
    //    RaycastHit hit;
    //    Ray r = new Ray(orig, transform.forward);
    //    Debug.DrawRay(transform.position, Vector3.forward);

    //    if (Physics.Raycast(r, out hit))
    //    {
    //        Debug.Log(hit.transform.name);
    //    }
    //}
}
