using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI; 
public class ColorChanged : MonoBehaviour, IPointerDownHandler
{
    private Color colorValue;
    // private Material material;

    private void Start()
    {
        colorValue = GetComponent<Button>().GetComponent<Image>().color;
        // material = GetComponent<Button>().GetComponent<Image>().material;
    }

    public void onClicked()
    {
        Shader shader = Shader.Find("Unlit/Color");
        Material material = new Material(shader); // 直接赋值给 material 变量

        material.color = colorValue;
        
        GameObject manager = GameObject.Find("Manager");
        manager.GetComponent<LineDrawer>().ChangeTexture(material);
        //manager.GetComponent<LineDrawer>().ChangeColor(colorValue);       
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        onClicked();
    }
}
