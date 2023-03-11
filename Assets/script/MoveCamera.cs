using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
   public Transform camera;

   private void Update()
   {
      transform.position = camera.position;
   }
}
