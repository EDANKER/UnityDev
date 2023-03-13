using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Muisik : MonoBehaviour
{
   public AudioSource foolstopeSpond;

   private void Update()
   {
      if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
      {
         foolstopeSpond.enabled = true;

      }
      else
      {
         foolstopeSpond.enabled = false;
      }
   }
}
