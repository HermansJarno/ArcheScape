using UnityEngine;

public class StartGameHandler : MonoBehaviour {

	void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == Collections.ToString(Collections.Tags.GameController))
        {
            
        }
    }
}
