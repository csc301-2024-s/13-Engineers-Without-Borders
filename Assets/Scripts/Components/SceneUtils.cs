using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Helper functions for scene loading. Mostly a wrapper around Unity's SceneManager.
/// </summary>
public class SceneUtils: MonoBehaviour
{
    /// <summary>
    /// Load the given scene and reset any static variables where appropriate.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public static void LoadScene(string sceneName) {
        // Reset any appropriate static variables if needed here
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
