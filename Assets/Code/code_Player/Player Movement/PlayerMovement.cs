﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//Receives input and moves the main player
namespace com.amerike.rod
{
	[RequireComponent(typeof(CharacterController))]
	public class PlayerMovement : MonoBehaviour
	{
		public playerState state;
		public enum playerState
        {
			Moving, Static,
        }
		public UnityEvent OnPrepare;
	    public bool Active
	    {
	        get
	        {
	            return active;
	        }
	        set
	        {
	            active = value;
	        }
	    }
	
	    Keyboard keyBoard;
	    Gamepad gamePad;
	    CharacterController characterController;
	
	    private bool active;
	    private Vector3 velocity;
	    private Vector3 CamRight;
		private Vector3 CamForward;
	    private float verticalSpeed;
	    public float movementSpeed = 1.0f;
	    public float gravity = -30f;
	    public float jumpHeight = 3.5f;

		[SerializeField] LayerMask groundMask;
		Vector3 movementDirection;
		public bool jump;

		void Prepare()
	    {
	        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
	        keyBoard = Keyboard.current;
	        #endif
	        gamePad = Gamepad.current;
	        characterController = GetComponent<CharacterController>();
		    active = true;
		    if(OnPrepare != null)
		    {
		    	OnPrepare.Invoke();
		    }
	    }
	
	    public void Start()
	    {
	        Prepare();
			jump = false;
	    }
	    void Update()
	    {
	        if (active)
	        {
	            if(keyBoard != null)
	            {
	              if(state == playerState.Moving)
                    {
						CheckInputKeyBoard();
                    }
				  else if(state == playerState.Static)
                    {

                    }
	            }
				
	        }
		}
	    void CheckInputKeyBoard()
	    {
	        movementDirection = Vector3.zero;
	        CamForward = Camera.main.transform.forward;
	        CamRight = Camera.main.transform.right;
	        CamForward.y = 0;
	        CamRight.y = 0;
			if (keyBoard.anyKey.isPressed)
			{
				if (keyBoard.wKey.isPressed)
				{
					movementDirection += CamForward;
				}
				if (keyBoard.sKey.isPressed)
				{
					movementDirection -= CamForward;
				}
				if (keyBoard.aKey.isPressed)
				{
					movementDirection -= CamRight;
				}
				if (keyBoard.dKey.isPressed)
				{
					movementDirection += CamRight;
				}
			}
	        movementDirection.Normalize();
	        Move(movementDirection);
	    }
	    void Move(Vector3 direction)
	    {
	        characterController.Move((direction * 0.1f) * movementSpeed);
	    }
	}
}
