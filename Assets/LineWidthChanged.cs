using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LineWidthChanged : MonoBehaviour, IPointerDownHandler
{   
    public Slider scrollbar;

    public float minValue = 0.01f; // Minimum value to output
    public float maxValue = 0.05f; // Maximum value to output

    private float lineWidth;

    private Text showedText;

    // Start is called before the first frame update
    void Start()
    {  
        scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
        showedText = GameObject.Find("Text").GetComponent<Text>();
        //lineWidth = scrollbar.GetComponent<Slider>().value;
    }

    void Update()
    {
        showedText.text = "Pen thickness: " + lineWidth;
    }

    private void OnScrollbarValueChanged(float value)
    {
        lineWidth = Mathf.Lerp(minValue, maxValue, value);
    }

    public void onClicked()
    {
        GameObject.Find("Manager").GetComponent<LineDrawer>().ChangeWidth(lineWidth);
    }
    
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        onClicked();
    }
    
}
