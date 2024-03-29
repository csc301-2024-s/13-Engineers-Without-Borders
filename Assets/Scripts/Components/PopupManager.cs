using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Author: Andy Wang
/// <summary>
/// Helper class to show popups during the simulation.
/// </summary>
public class PopupManager : MonoBehaviour
{
    /// <summary>
    /// Describes a popup.
    /// </summary>
    struct Popup {
        /// <summary>
        /// The title.
        /// </summary>
        /// <value>Title.</value>
        public string Title { get; private set; }

        /// <summary>
        /// The description.
        /// </summary>
        /// <value>Description.</value>
        public string Description { get; private set; }

        /// <summary>
        /// The text on the button to close it.
        /// </summary>
        /// <value>Close button text.</value>
        public string CloseText { get; private set; }

        /// <summary>
        /// Creates a popup with the given fields.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="description">Description.</param>
        /// <param name="closeText">Close button text.</param>
        public Popup(string title, string description, string closeText)
        {
            Title = title;
            Description = description;
            CloseText = closeText;
        }
    }

    [SerializeField] GameObject popup;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI closeText;
    
    private static GameObject _popup;
    private static TextMeshProUGUI _title, _description, _closeText;
    private static Queue<Popup> _queue = new();  // maintain a queue of popups in case multiple get shown at the same time
    
    void Awake()
    {
        _popup = popup;
        _title = title;
        _description = description;
        _closeText = closeText;

        // listen to the close button - when closed, dequeue the next popup
        Button closeButton = _closeText.transform.parent.GetComponent<Button>();
        closeButton.onClick.AddListener(() => {
            _popup.SetActive(false);
            ShowNextPopup();
        });
    }

    void Start()
    {
        // This is a workaround the fact that scene loading takes time, and sometimes the popup would show
        // before the scene changed
        ShowNextPopup();
    }

    // Enqueue a new popup to be shown once the current queue is exhausted
    // <immediate> is in case we want to queue a popup in the middle of a scene and not loading another scene right after
    public static void QueuePopup(string title, string description, string closeText, bool immediate = false)
    {
        _queue.Enqueue(new Popup(title, description, closeText));

        if (immediate) ShowNextPopup();
    }

    // Show the next enqueued popup to the player
    private static void ShowNextPopup()
    {
        if (_queue.Count == 0) return;  // do nothing if nothing enqueued

        Popup next = _queue.Dequeue();
        ShowPopup(next);
    }

    // Show a specific popup to the user
    private static void ShowPopup(Popup popup)
    {
        _title.text = popup.Title;
        _description.text = popup.Description;
        _closeText.text = popup.CloseText;
        _popup.SetActive(true);  // show the actual popup
    }
}