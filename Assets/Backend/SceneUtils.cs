using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Helper functions related to scene loading
public class SceneUtils: MonoBehaviour
{
    // Load the given scene and reset the appropriate static variables
    public static void LoadScene(string sceneName) {
        // Reset any appropriate static variables if needed here
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
