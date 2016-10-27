using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

  public float shootSpeed = 20f;
  public float shootInterval = 3f;
	public GameObject bulletPrefab;
	public Transform spawnPoint;

	// Use this for initialization
	void Start () {
    Shoot();
	}

	void Shoot()
	{
		GameObject prefabBody = Instantiate(bulletPrefab,spawnPoint.position,GetComponentInChildren<Transform>().localRotation) as GameObject;
    prefabBody.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootSpeed);

    GameObject.Find("GameManager").GetComponent<GameManager>().Ammo -= 1;
    Debug.Log(GameObject.Find("GameManager").GetComponent<GameManager>().Ammo);

    if (GameObject.Find("GameManager").GetComponent<GameManager>().Ammo > 0)
    {
      Invoke("Shoot", shootInterval);
    }
	}
}
