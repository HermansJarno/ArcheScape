using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

  public float shootSpeed = 20f;
  public float shootInterval = 3f, fastInterval = 0.3f;
	public GameObject normalBullet, bigBulletPrefab, doubleBulletPrefab, grenadeLauncherPrefab;
	public Transform spawnPoint;
  GameObject prefabBullet;
  float timeLeft = 10;

  BulletBuffID currentBulletBuffID = BulletBuffID.normal;

	// Use this for initialization
	void Start () {
    prefabBullet = normalBullet;
    Shoot();
	}

  private void Update()
  {
    if (currentBulletBuffID != BulletBuffID.normal)
    {
      timeLeft -= Time.deltaTime;
      if (timeLeft <= 0)
      {
        currentBulletBuffID = BulletBuffID.normal;
        timeLeft = 10;
      }
    }
  }

  void Shoot()
	{
    GameObject prefabBody;
    
    switch (currentBulletBuffID)
    {
      case BulletBuffID.normal:
        prefabBullet = normalBullet;
        prefabBody = Instantiate(prefabBullet, spawnPoint.position, GetComponentInChildren<Transform>().localRotation) as GameObject;
        prefabBody.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootSpeed);
        break;
      case BulletBuffID.trippleBullet:
        prefabBullet = normalBullet;
        prefabBody = Instantiate(prefabBullet, spawnPoint.position, GetComponentInChildren<Transform>().localRotation) as GameObject;
        prefabBody.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootSpeed);
        break;
      case BulletBuffID.fastShooter:
        prefabBullet = normalBullet;
        prefabBody = Instantiate(prefabBullet, spawnPoint.position, GetComponentInChildren<Transform>().localRotation) as GameObject;
        prefabBody.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootSpeed);
        break;
      case BulletBuffID.grenadeLauncher:
        prefabBullet = grenadeLauncherPrefab;
        prefabBody = Instantiate(prefabBullet, spawnPoint.position, GetComponentInChildren<Transform>().localRotation) as GameObject;
        prefabBody.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootSpeed);
        break;
      case BulletBuffID.doubleBullet:
        prefabBullet = doubleBulletPrefab;
        for (int i = 0; i < prefabBullet.transform.childCount; i++)
        {
          GameObject prefabChild = prefabBullet.transform.GetChild(i).gameObject;
          Vector3 placeToSpawn = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, (prefabChild.transform.position.z + spawnPoint.transform.position.z) / 2);
          prefabBody = Instantiate(prefabChild, placeToSpawn, GetComponentInChildren<Transform>().localRotation) as GameObject;
          prefabBody.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootSpeed);
        }

        break;
      case BulletBuffID.bigBullet:
        prefabBullet = bigBulletPrefab;
        prefabBody = Instantiate(prefabBullet, spawnPoint.position, GetComponentInChildren<Transform>().localRotation) as GameObject;
        prefabBody.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * shootSpeed);
        break;
      default:
        break;
    }



    if (currentBulletBuffID == BulletBuffID.fastShooter)
    {
      Invoke("Shoot", fastInterval);
    }
    else
    {
      Invoke("Shoot", shootInterval);
    }
	}

  public void SetBullefBuddID(BulletBuffID id)
  {
    currentBulletBuffID = id;
    timeLeft = 10;
  }
}
