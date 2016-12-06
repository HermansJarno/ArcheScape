using UnityEngine;
using System.Collections;

public class BulletDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5);
	}
}
