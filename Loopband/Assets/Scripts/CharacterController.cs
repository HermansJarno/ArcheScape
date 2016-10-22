using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

  public float forwardSpeed = 400;
  Rigidbody myBody;
	CharacterController character;

	// Use this for initialization
	void Start () {
    myBody = GetComponent<Rigidbody>();
		character = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    Move(forwardSpeed);
  }

  public void Move(float speed)
  {
    Vector3 moveVel = myBody.velocity;
    moveVel.x = speed * Time.deltaTime;
    myBody.velocity = new Vector3(moveVel.x, myBody.velocity.y, moveVel.z);
		
    //myBody.rotation = Quaternion.Euler(transform.eulerAngles);
  }
}
