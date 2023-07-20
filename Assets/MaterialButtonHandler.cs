using UnityEngine;
using UnityEngine.UI;
public class MaterialButtonHandler : MonoBehaviour
{
    public GameObject MaterialPopup; // Reference to the ColorPopup GameObject

    private void Start()
    {
        // Add a listener to the button's onClick event
        Button materialButton = GetComponent<Button>();
        materialButton.onClick.AddListener(ToggleLinePopup);
        GameObject.Find("Manager").GetComponent<LineDrawer>().ClosePopups();
    }

    private void ToggleLinePopup()
    {
        // Open or close the color popup based on its current state
        MaterialPopup.SetActive(!MaterialPopup.activeSelf);
    }
    
    
}
