using UnityEngine.SceneManagement;

/// <summary>
/// Holding functions for scenemanagement.
/// </summary>
public static class LevelManager {

    /// <summary>
    /// Loads a scene from the game.
    /// </summary>
    /// <param name="scene">The name of the scene to load.</param>
    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// Get the name of the current scene.
    /// </summary>
    public static string GetCurrentSceneName
    {
        get { return SceneManager.GetActiveScene().name; }
    }

}
