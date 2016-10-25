using UnityEngine;
using System.Collections;

public class TargetGenerator : MonoBehaviour {

	public Transform generationPoint;
  public GameObject Target;
	public float minDist = 200, maxDist = 1000;
  public float minOffsetZ = 100, maxOffsetZ = 150;
  public float minOffsetY = 5, maxOffsetY = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x)
		{
			float randomDist = Random.Range(minDist, maxDist);
      float offsetZ = Random.Range(minOffsetZ, maxOffsetZ);
      float offsetY = Random.Range(minOffsetY, maxOffsetY);
      int randomSide = Random.Range(-1, 1);
      if (randomSide == 0)
      {
        offsetZ = offsetZ - (offsetZ * 2);
      }

      //Quaternion rotationTarget = new Quaternion(0,Target.r, 0, 0);
      Vector3 targetPosition = new Vector3(transform.position.x + randomDist, transform.position.y + offsetY, offsetZ);
      Instantiate(Target, targetPosition, Target.transform.localRotation);
			transform.position = new Vector3(transform.position.x + randomDist, transform.position.y, transform.position.z);
		}
	}
}
