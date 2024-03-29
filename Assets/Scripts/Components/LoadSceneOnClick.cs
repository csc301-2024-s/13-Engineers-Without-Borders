using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
/// <summary>
/// Makes a Button component load a scene on click, the scene is specified by a serialized field.
/// </summary>
public class LoadSceneOnClick : MonoBehaviour
{
    [SerializeField] string sceneName;  // this field is for dependency injection to be possible

    void Start() {
        // If on an object with a button component, assign it automatically
        Button btn = GetComponent<Button>();

        if (btn) {
            btn.onClick.AddListener(OnClick);
        }
    }

    /// <summary>
    /// Click handler.
    /// </summary>
    public void OnClick() {
        SceneUtils.LoadScene(sceneName);
    }
}
