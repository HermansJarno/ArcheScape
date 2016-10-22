using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

  public GameObject theStartPlatform;
  public Transform generationPoint;

  private float platformWidth;
  float[] platformWidths;

  public GameObject[] thePlatforms;
  int platformSelector;
  public ObjectPooling[] theObjectPools;
  GameObject lastActivatedPlatform;


  // Use this for initialization
  void Start () {
    //platformWidth = thePlatform.GetComponent<BoxCollider>().size.z;

    platformWidths = new float[theObjectPools.Length];
    for (int i = 0; i < theObjectPools.Length; i++)
    {
      platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider>().size.x;
    }
    lastActivatedPlatform = theStartPlatform;
	}
	
	// Update is called once per frame
	void Update () {
    if (transform.position.x < generationPoint.position.x)
    {
      platformSelector = Random.Range(0, theObjectPools.Length);

      float xPoint = lastActivatedPlatform.transform.position.x + lastActivatedPlatform.GetComponent<Collider>().bounds.size.x / 2;
      transform.position = new Vector3(xPoint, transform.position.y, transform.position.z);

      GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

      newPlatform.transform.position = transform.position;
      newPlatform.transform.rotation = transform.rotation;
      newPlatform.SetActive(true);
      lastActivatedPlatform = newPlatform;

      transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
      //Instantiate(thePlatform, transform.position, transform.rotation);
    }
	}
}
