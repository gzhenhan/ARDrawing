using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI; 
public class MaterialChanged : MonoBehaviour, IPointerDownHandler
{
    public Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        //mat = GetComponent<Button>().GetComponent<Image>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClicked()
    {
        GameObject.Find("Manager").GetComponent<LineDrawer>().ChangeTexture(mat);        
    }
    
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        onClicked();
    }
}
