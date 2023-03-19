using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator _animator;
    
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode Run = KeyCode.W;
    public KeyCode CtrlW = KeyCode.S;
    public KeyCode CtrlD = KeyCode.D;
    public KeyCode CtrlA = KeyCode.A;
    private Rigidbody _rigidbody;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movment = new Vector3(horizontalInput, 0f, verticalInput);
        _rigidbody.velocity = movment;

        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool("Run", true);

            if (Input.GetKey(sprintKey))
            {
                _animator.SetBool("Run1", true);


            }

            else
            {
                _animator.SetBool("Run1", false);
            }

        }

        else
        {
            _animator.SetBool("Run", false);

        }

        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("Wall", true);

        }
        else
        {
            _animator.SetBool("Wall", false);

        }

        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("Left", true);

        }
        else
        {
            _animator.SetBool("Left", false);

        }

        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("Right", true);

        }
        else
        {
            _animator.SetBool("Right", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _animator.SetBool("Ctrl", true);

            if (Input.GetKey(CtrlD))
            {
                _animator.SetBool("CtrlD", true);

            }

            if (Input.GetKey(CtrlA))
            {
                _animator.SetBool("CtrlA", true);

            }

            if (Input.GetKey(CtrlW))
            {
                _animator.SetBool("CtrlS", true);

            }
            else
            {
                _animator.SetBool("CtrlS", false);
            }


            if (Input.GetKey(Run))
            {
                _animator.SetBool("CtrlW", true);

            }
            else
            {
                _animator.SetBool("CtrlW", false);
            }

        }
        else
        {
            _animator.SetBool("Ctrl", false);
        }
    }
}
   

