using UnityEngine;
using System.Collections;
using System;

public class BuffController : MonoBehaviour {

  Vector3 startPos, startScale;
  Vector3 endPos, endScale;
  float scale = 10, lerpF;
  float speed = 1f;
  private bool readyToMove = false;
  BulletSpawner bSpawner;

  private void Start()
  {
    bSpawner = GameObject.Find("Camera (eye)").GetComponent<BulletSpawner>();
    startScale = transform.localScale;
    endScale = transform.localScale * 1.5f;
    Invoke("SetValues", 1);
  }

  private void SetValues()
  {
    startPos = transform.position;
    startScale = transform.localScale;
    endScale = transform.localScale / scale;
    endPos = GameObject.Find("Camera (eye)").GetComponent<Transform>().transform.position;
    endPos.y -= 0.5f;
    lerpF = 0;
    readyToMove = true;
  }

  // Use this for initialization
  void Update () {
    if (readyToMove)
    {
      lerpF += speed * Time.deltaTime;
      transform.position = Vector3.Lerp(startPos, endPos, lerpF);
      transform.localScale = Vector3.Lerp(startScale, endScale, lerpF);
    }
    else
    {
      lerpF += (speed * 2) * Time.deltaTime;
      transform.localScale = Vector3.Lerp(startScale, endScale, lerpF);
    }
  }

  void ExecuteBuff()
  {
    int rndBuff = UnityEngine.Random.Range(1, 3);
    Debug.Log(rndBuff);
    switch (rndBuff)
    {
      case 1:
        BulletBuffID buffId = BulletBuffID.bigBullet;
        int rndID = 0;
        do
        {
          rndID = UnityEngine.Random.Range(0, Enum.GetNames(typeof(BulletBuffID)).Length);
        } while ((BulletBuffID)rndID == BulletBuffID.normal);
        buffId = (BulletBuffID)rndID;
        Debug.Log(buffId.ToString());
        bSpawner.SetBullefBuddID(buffId);
        break;
      case 2:
        ScoreBuffID scoreBuffId = ScoreBuffID.bonusScore;
        int rndScoreID = 0;
        do
        {
          rndScoreID = UnityEngine.Random.Range(0, Enum.GetNames(typeof(ScoreBuffID)).Length);
        } while ((ScoreBuffID)rndScoreID == ScoreBuffID.normal);
        scoreBuffId = (ScoreBuffID)rndScoreID;
        Debug.Log(scoreBuffId.ToString());
        break;
      default:
        break;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.name == "Camera (eye)")
    {
      ExecuteBuff();
      Destroy(gameObject);
    }
  }
}
