using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class LineButtonHandler : MonoBehaviour
{
    public GameObject linePopup; // Reference to the ColorPopup GameObject

    private void Start()
    {
        // Add a listener to the button's onClick event
        Button lineButton = GetComponent<Button>();
        lineButton.onClick.AddListener(ToggleLinePopup);
        //linePopup = transform.parent.Find("WidthWindow").gameObject;
        GameObject.Find("Manager").GetComponent<LineDrawer>().ClosePopups();
    }

    private void ToggleLinePopup()
    {
        // Open or close the color popup based on its current state
        linePopup.SetActive(!linePopup.activeSelf);
    }
}