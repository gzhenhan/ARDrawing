using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class LineDrawer : MonoBehaviour
{

    // 线条的预制件
    public GameObject linePrefab;

    // main camera
    private Camera targetCamera;
    private LineRenderer lineRenderer;

    // 线段与屏幕距离
    public float drawOffset;

    // drawing state
    private bool isDrawing;

    public float lineWidth;
    
    //实例化的线条
    private GameObject lineClone;

    private int lineCounter;

    public GameObject drawRoot;
    
    [SerializeField]
    private Material currentMaterial;

    /*[SerializeField]
    private Color currentColor;*/
    
    // color selection UI
    public GameObject colorPopup;

    // material selection UI
    public GameObject materialPopup;
    
    // line width UI
    public GameObject widthPopup;
    
    

    void Start() {
        targetCamera = Camera.main;
        isDrawing = false;
        currentMaterial = Resources.Load("Materials/White", typeof(Material)) as Material;

        lineCounter = 0;
        linePrefab = Resources.Load("Line") as GameObject;
        //Debug.Log(currentMaterial);

    }

    void Update() {
        // Debug.Log(lineWidth);
        if(Input.touchCount > 0){
            if(!IsPointerOverUIObject()){
                // close all UI layers
                ClosePopups();

                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        lineClone = Instantiate(linePrefab) as GameObject;
                        lineClone.GetComponent<LineRenderer>().material = currentMaterial;

                        // 将lineClone的父级设为drawRoot
                        lineClone.transform.parent = drawRoot.transform;
                        lineRenderer = lineClone.GetComponent<LineRenderer>();
                        lineRenderer.startWidth = lineWidth;
                        lineRenderer.endWidth = lineWidth;

                        isDrawing = true;
                        lineCounter = 0;
                        break;
                    case TouchPhase.Moved:
                        break;
                    case TouchPhase.Ended:
                        isDrawing = false;
                        break;
                }

                if(isDrawing){
                    lineCounter++;
                    lineRenderer.positionCount = lineCounter;
                    // 依据屏幕触摸位置确定线段位置
                    lineRenderer.SetPosition(lineCounter - 1, targetCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, drawOffset)));
                }
            }
        }
    }

     //判断当前点击位置是否是UI组件，避免在点击按钮时，还继续画画
    private bool IsPointerOverUIObject()
    {   
        // 创建一个PointerEventData对象，并将其位置设置为当前鼠标的屏幕位置
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        // 创建一个列表来存储射线检测的结果
        List<RaycastResult> results = new List<RaycastResult>();
        
        // 执行射线检测，将结果存储在results列表中
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        
        // 如果results列表中有命中的UI对象，则返回true；否则返回false
        return results.Count > 0;
    }

    //清除线段
    public void Clean()
    {
        int childCount = drawRoot.transform.childCount;
        for (int j = 0; j < childCount; j++)
        {
            Destroy(drawRoot.transform.GetChild(j).gameObject);
        }
        ClosePopups();
    }
    

    // called in the class ColorChanged to be able change the line color
    public void ChangeTexture(Material material)
    {
        currentMaterial = (Material)Instantiate(material);
        
        // close the popup window after pressing the color button
        ClosePopups();
    }

    /*public void ChangeColor(Color color)
    {
        currentColor = color;
        //Debug.Log(currentColor);
    }*/
    
    public void ChangeMaterial(Material newMaterial)
    {
        lineRenderer.material = newMaterial;
    }
    
    
    // called in the class LineWidthChanged to be able change the line width
    public void ChangeWidth(float width)
    {
        lineWidth = width;
        Debug.Log(lineWidth);
        //ClosePopups();        
    }
    
    
    
    public void ClosePopups()
    {
        //close popups
        widthPopup.SetActive(false);
        colorPopup.SetActive(false);
        materialPopup.SetActive(false);
        
    }
}
