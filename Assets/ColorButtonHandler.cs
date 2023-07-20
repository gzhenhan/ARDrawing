using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ColorButtonHandler : MonoBehaviour
{
    public GameObject colorPopup; // Reference to the ColorPopup GameObject
    public GameObject widthPopup;
    public GameObject materialPopup;

    private void Start()
    {
        // Add a listener to the button's onClick event
        Button colorButton = GetComponent<Button>();
        colorButton.onClick.AddListener(ToggleColorPopup);
        //colorPopup = transform.parent.Find("ColorWindow").gameObject;
        GameObject.Find("Manager").GetComponent<LineDrawer>().ClosePopups();
    }

    private void ToggleColorPopup()
    {
        // Open or close the color popup based on its current state
        colorPopup.SetActive(!colorPopup.activeSelf);
    }

    private void Update()
    {
        if (colorPopup.activeSelf)
        {
            widthPopup.SetActive(!colorPopup.activeSelf);
            materialPopup.SetActive(!colorPopup.activeSelf);
        }
    }
}

