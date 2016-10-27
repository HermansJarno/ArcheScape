using UnityEngine;
using System.Collections;

public class BulletDestroyer : MonoBehaviour {

	public GameObject prefabTarget;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "schietschijf(Clone)")
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().Score++;
			Destroy(col.gameObject);
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5);
	}
}
