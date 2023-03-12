using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject opentext;

    public AudioSource doorSound;

    public bool inReach;

    private void Start()
    {
        inReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {

            inReach = true;
            opentext.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            opentext.SetActive(false);

        }
    }

    private void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            DoorOpens();
            
        }
        else
        {
            DoorCloses();
        }
    }

    void DoorOpens()
    {
        door.SetBool("open", true);
        door.SetBool("close", false);
        doorSound.Play();
        
    }

    void DoorCloses()
    {
        door.SetBool("open", false);
        door.SetBool("close", true);
        
        
    }
}
