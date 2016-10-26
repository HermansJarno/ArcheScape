using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIHandler : MonoBehaviour
{

    public Button bttnStart, bttnQuit, bttnResume, bttnQuitGame, bttnPause;
    public GameObject pnlPause;

    private string currentScene;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == SceneManager.GetSceneByName(Scenes.MainMenu.ToString()).name) // current scene = main menu
        {
            bttnStart.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.Room));
            bttnQuit.onClick.AddListener(() => Application.Quit());
        }
        else if (currentScene == SceneManager.GetSceneByName(Scenes.Room.ToString()).name) // current scene = room
        {
            bttnPause.onClick.AddListener(() => Pause());
            bttnResume.onClick.AddListener(() => Pause());
            bttnQuitGame.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetSceneByName(Scenes.MainMenu.ToString()).name));
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.timeScale);
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
        bttnPause.gameObject.SetActive(!pnlPause.activeSelf);

        if (pnlPause.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
