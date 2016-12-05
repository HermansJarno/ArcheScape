using UnityEngine;
using System.Collections;

public class TargetDestroyer : MonoBehaviour {

  GameObject platformDestructionPoint;
  int spawnSpeed = 300;
  int maxRandomBuff = 10;

  // Use this for initialization
  void Start()
  {
    platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x < platformDestructionPoint.transform.position.x)
    {
      Destroy(gameObject);

    }
  }

  public GameObject buffPrefab;

  void OnCollisionEnter(Collision col)
  {
    if (col.gameObject.tag == "Bullet")
    {
      GameObject.Find("GameManager").GetComponent<GameManager>().Score++;
      int rndSpawn = Random.Range(0, maxRandomBuff);
      if (rndSpawn > 4 && rndSpawn < 7)
      {
        GameObject prefabBody = Instantiate(buffPrefab, transform.position, transform.localRotation) as GameObject;
        prefabBody.GetComponent<Rigidbody>().AddForce(transform.up * spawnSpeed);
        prefabBody.GetComponent<SphereCollider>().isTrigger = true;
        //prefabBody.GetComponent<Rigidbody>().useGravity = false;
      }
      Destroy(col.gameObject);
      Destroy(gameObject);
    }
  }
}
