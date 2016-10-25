using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIHandler : MonoBehaviour
{

    public Button bttnStart, bttnQuit, bttnResume, bttnQuitGame;
    public GameObject pnlPause;

    private string currentScene;
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;

        Debug.Log("in awake - CURRENT SCENE: " + currentScene + "--> int: " + ((int)Scenes.Room) + " - BUILD INDEX: " + SceneManager.GetActiveScene().buildIndex);

        if (currentScene == SceneManager.GetSceneAt((int)Scenes.MainMenu).name) // current scene = main menu
        {
            Debug.Log("DEBUG: in main");
            bttnStart.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.Room));
            bttnQuit.onClick.AddListener(() => Application.Quit());
        }
        else if (currentScene == SceneManager.GetSceneAt((int)Scenes.Room).name) // current scene = room
        {
            Debug.Log("DEBUG: in room");
            bttnResume.onClick.AddListener(() => Pause());
            bttnQuitGame.onClick.AddListener(() => SceneManager.GetSceneAt((int)Scenes.MainMenu));
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene == SceneManager.GetSceneAt(0).name)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Pauses the game.
    /// </summary>
    /// <remarks>Should we implement TimeScale?</remarks>
    private void Pause()
    {
        // Set the state of the pause menu equal to the inverse state
        // So when state = visible (true) -> result = go off (false)
        pnlPause.SetActive(!pnlPause.activeSelf);
    }
}
