using Backend;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// author: Jacqueline Zhu
public class ShowFamilyMembers : MonoBehaviour
{

    [SerializeField] string text;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = string.Format(text, GameState.s_Player.Family.GetChildrenAmount() + GameState.s_Player.Family.GetAdultAmount());
    }
}
