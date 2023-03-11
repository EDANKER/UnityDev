using System;
using UnityEngine;
using UnityEngine.UI;

public class ScanLuch : MonoBehaviour
{
   [SerializeField] private Camera _playerCamera;
   private float _maxRayDistance = 4f;
   private Outline _lastOutLineObject;

   private void Update()
   {
      Debug.DrawRay(_playerCamera.transform.position, _playerCamera.transform.forward * _maxRayDistance, Color.cyan);

      RaycastHit hit;

      if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out hit, _maxRayDistance))
      {
         if (hit.transform.gameObject.CompareTag("item"))
         {
            if (_lastOutLineObject != null)
            { 
               _lastOutLineObject.enabled = false;
            }
            _lastOutLineObject =  hit.transform.gameObject.GetComponent<Outline>();
           _lastOutLineObject.enabled = true;

         }
         else if (_lastOutLineObject != null)
         {
            _lastOutLineObject.enabled = false;
            _lastOutLineObject = null;
            Console.WriteLine(_lastOutLineObject);

         }
         
         
      }
   }
}
    
    

