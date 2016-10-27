using UnityEngine;
using System.Collections;

public class ObjectMoving : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * Time.deltaTime * GameObject.Find("GameManager").GetComponent<SettingsRunner>().MovementSpeed;
	}
}
