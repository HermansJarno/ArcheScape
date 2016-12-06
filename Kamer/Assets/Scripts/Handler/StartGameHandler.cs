using UnityEngine;

public class StartGameHandler : MonoBehaviour {

	void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == Collections.Tags.GameController.ToString())
        {
            LevelManager.LoadScene(Collections.Scenes.RoomScene.ToString());
        }
    }
}
