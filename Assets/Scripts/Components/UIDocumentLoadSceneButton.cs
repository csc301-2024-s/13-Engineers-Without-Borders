using System;
using UnityEngine;
using UnityEngine.UIElements;

// Original Author: Andy Wang
/// <summary>
/// Put this on a UIDocument with buttons in it.
/// This script makes it so all the buttons with class "load-scene-button" load a scene upon click.
/// </summary>
public class UIDocumentLoadSceneButton : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;
    
    // Start is called before the first frame update
    void Start()
    {
        _uiDocument = GetComponent<UIDocument>();
        _root = _uiDocument.rootVisualElement;

        // query all buttons of class load-scene-button to handle their click
        _root.Query<Button>(className: "load-scene-button").ForEach(btn => {
            btn.clicked += HandleLoadSceneButton(btn);
        });
    }

    // Return action that, when called, loads scene to sceneName
    Action HandleLoadSceneButton(Button btn)
    {
        return () => {
            SceneUtils.LoadScene(btn.tooltip);
        };
    }
}
