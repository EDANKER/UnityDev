using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDiogonal : MonoBehaviour
{
    private Camera _camera;
    
    void Start()
    {
        _camera = Camera.main;

    }

   
    void Update()
    {
        Vector3 screenmousePosition = Input.mousePosition;
        Vector3 worlMoisePostition = _camera.ScreenToViewportPoint(screenmousePosition);
        transform.LookAt(worlMoisePostition);
    }
}
