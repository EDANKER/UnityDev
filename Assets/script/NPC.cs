using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public GameObject desintionPoint;
    private NavMeshAgent _theAgent;
    
  
    void Start()
    {
        _theAgent = GetComponent<NavMeshAgent>();

    }

   
    void Update()
    {
        
    }
}
