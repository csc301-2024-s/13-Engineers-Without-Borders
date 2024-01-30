using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Used to make a button load a scene on click
public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName;  // this field is for dependency injection to be possible

    void Start() {
        // If on an object with a button component, assign it automatically
        Button btn = GetComponent<Button>();

        if (btn) {
            btn.onClick.AddListener(OnClick);
        }
    }

    public void OnClick() {
        SceneUtils.LoadScene(sceneName);
    }
}
