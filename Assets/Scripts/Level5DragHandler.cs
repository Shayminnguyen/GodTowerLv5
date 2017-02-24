using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Level5DragHandler : MonoBehaviour,IDragHandler
{
    private int CANVAS_SIZE_X = 555;
    private int CANVAS_SIZE_Y = 480;

    //private int MapX = 555;
    //private int MapY = 588;
    //private float minX;
    //private float minY;
    //private float maxX;
    //private float maxY;
    private Image image;
    //private Vector3 startPosition;
    void Awake()
    {
        image = GetComponent<Image>();
        //float verExtent = Camera.main.orthographicSize;
        //float horExtend = verExtent * Screen.width / Screen.height;
        //// Calcalation assume map is position at the origin
        //minX = horExtend/2;
        //maxX = -horExtend/2;
        //minY = verExtent - MapY / 2;
        //maxY = MapY / 2 - verExtent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 p1 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        Vector3 p = transform.parent.InverseTransformPoint(p1);

        //p.x = Mathf.Clamp(p.x, -MAP_SIZE_X, MAP_SIZE_X);
        //p.y = Mathf.Clamp(p.y, -MAP_SIZE_Y, MAP_SIZE_Y);
        p.x = Mathf.Clamp(p.x, -CANVAS_SIZE_X/2, CANVAS_SIZE_X/2);
        p.y = Mathf.Clamp(p.y, -CANVAS_SIZE_Y/2, CANVAS_SIZE_Y/2);
        image.transform.localPosition = p;
    }

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    startPosition = transform.position;
    //}


    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    if(transform.position.x > maxX || transform.position.x < minX || transform.position.y > maxY || transform.position.y < minY)
    //        transform.position = startPosition;
    //}
}
