using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class checkModeBulid : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    public static bool _active = false;
    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(TaskOnClick);
        if (_active) { _text.color = new Color32(55, 137, 61, 228); } else { _text.color = new Color32(127, 64, 55, 228); }
    }

    void TaskOnClick()
    {
        if (_active) 
        { 
            _active = false; 
            _text.color = new Color32(127, 64, 55, 228);

        } 
        else 
        { 
            _active = true; 
            _text.color = new Color32(55, 137, 61, 228);
        }
    }
}
