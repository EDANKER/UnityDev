using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
   [Header("Movement")]
   private float moveSpeed;
   public float walkSpeed;
   public float sprintSpeed;
  

   public float groundDrag;

   public float jumpForce;
   public float jumpCooldown;
   public float airMultiplier;
   
   bool _readyToJump;

   [Header("component")] 
   
   private CharacterController _controller;

  
   [Header("Keybinds")]
  
   public KeyCode sprintKey = KeyCode.LeftShift;
   public KeyCode Run = KeyCode.W;
   public KeyCode CtrlW = KeyCode.S;
   public KeyCode CtrlD = KeyCode.D;
   public KeyCode CtrlA = KeyCode.A;
   
   public bool isGrounded = false;
   public float speed = 5f;
   public float jumpSpeed = 8f;
   private float movement = 0f;
   

   [Header("Ground Check")]
   public float playerHeight;
   public LayerMask whatIsGround;
   bool _grounded;

  

   [Header("Slope Handling")] 
   public float maxSlopeAngel;

   private RaycastHit _slopeHit;
   private bool _exitingSlipeng;

   [Header("Animator")] 
   private Animator _animator;

  

   
   






   public Transform orientation;
   float _horizontalInput;
   float _verticalInput;

   Vector3 _moveDirection;

   Rigidbody _rb;

   public MovementState State;
   
   public enum MovementState
   {
      walking,
      sprinting,
      crouching,
      air
      
   }
   

   private void Start()
   {
      
      _animator = GetComponent<Animator>();
      _rb = GetComponent<Rigidbody>();
      _rb.freezeRotation = true;

      _readyToJump = true;

     
      
      
   }

   private void Update()
   {
     
    

      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      Vector3 movment = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;
      _rb.velocity = movment;
      
      if(Input.GetKeyUp(sprintKey))
      {
         _animator.SetBool("Run1", false);
      }
      
      if (Input.GetKeyUp(Run))
      {
         _animator.SetBool("CtrlW", false);
            
      }
      if (Input.GetKey(CtrlW))
      {
         _animator.SetBool("CtrlS", false);
            
      }
      
      if (Input.GetKeyUp(CtrlD))
      {
         _animator.SetBool("CtrlD", false);
            
      } 
      
      if (Input.GetKeyUp(CtrlA))
      {
         _animator.SetBool("CtrlA", false);
            
      }

    












      _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
      
      
      SpeedControl();
      StateHandler();

      if (_grounded)
      {
         _rb.drag = groundDrag;

      }
      else
      {
         _rb.drag = 0;
      }
      
   }

   private void FixedUpdate()
   {
      MovePlayer();
      
      
   }









   private void StateHandler()
   {
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








   private void MovePlayer()
   {
      _moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

      if (OnSlope() && !_exitingSlipeng)
      {
         _rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

        
      }
     
      if(_grounded)
         _rb.AddForce(Vector3.down * 150f, ForceMode.Force);

      // in air
      else if(!_grounded)
         _rb.AddForce(_moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
   
     
   }

   private void SpeedControl()
   {
      if (OnSlope() && !_exitingSlipeng)
      {
         if (_rb.velocity.magnitude > moveSpeed)
         {
            _rb.velocity = _rb.velocity.normalized * moveSpeed;

         }

        
      }
      
      Vector3 flatVel = new Vector3(_rb.velocity.x, 0f, _rb.rotation.z);
      
      if (flatVel.magnitude > moveSpeed)
      {
         Vector3 limitedVel = flatVel.normalized * moveSpeed;
         _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);

      }
   }

  
   private void ResetJump()
   {
      _readyToJump = true;

      
   }

   private bool OnSlope()
   {
      if (Physics.Raycast(transform.position, Vector3.down, out  _slopeHit, playerHeight * 0.5f + 0.3f))
      {
         float angel = Vector3.Angle(Vector3.up, _slopeHit.normal);
         return angel < maxSlopeAngel && angel != 0;

      }

      return false;
   }

   private Vector3 GetSlopeMoveDirection()
   {
      return Vector3.ProjectOnPlane(_moveDirection, _slopeHit.normal).normalized;
   }
   
}
