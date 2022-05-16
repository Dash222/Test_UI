using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    private Vector2 screenSize;
    private RectTransform panelTransform = null;
    // Start is called before the first frame update
    void Start()
    {
        screenSize.x = Screen.height;
        screenSize.y = Screen.width;

        Debug.Log(screenSize);
        panelTransform = GetComponent<RectTransform>();
        panelTransform.sizeDelta = screenSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
