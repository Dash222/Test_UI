using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown : MonoBehaviour
{
    [SerializeField] private GameObject gameObject = null;
    private Button dropdownButton = null;
    void Start()
    {
        if (!dropdownButton)
            dropdownButton = GetComponent<Button>();

        dropdownButton.onClick.AddListener(OpenDropdown);
    }

    private void OpenDropdown()
    {
        if (gameObject)
        {
            gameObject.SetActive(!gameObject.active);
        }
    }
}
