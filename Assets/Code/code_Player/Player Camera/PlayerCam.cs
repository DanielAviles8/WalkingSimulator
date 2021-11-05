using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace com.amerike.rod
{
	public class PlayerCam : MonoBehaviour
	{
		public delegate void HandlerPlayerCam (PlayerCam sender);
		public event HandlerPlayerCam OnUse;
		public event HandlerPlayerCam OnGrab;
		
		[HideInInspector]public GameObject GrabbedObj;

		public cameraState state;
		public enum cameraState
        {
			Static, Moving,
        }
	    Mouse mouse;
		Keyboard keyBoard;
	    Camera myCamera;
		float rotationLimit = 0f;
	    float rotationX = 0f;
	
	    [Header("Player")]
	    [SerializeField] private Transform player;

	    [Header("Camera")]
	    [Range(0f,1f)]
	    [SerializeField] private float speedCamera = 1;
	
	    [Header("Rycast")]
	    
	    [Range(0f,3f)]
	    [SerializeField]float distanceHit = 1;
	
	    bool active;
	    bool invertedYAxis;
	    bool invertedXAxis;
		[SerializeField] private FloatVariable MouseSensibility;
		[SerializeField] private BoolVariable InvertedYState;
		[SerializeField] private BoolVariable InvertedXState;
		bool hasprop;
		GravityProps grabbedObj;
		public bool HasProp
		{
			get{return hasprop;}
			set{hasprop = value;}
		}
	    public bool Active 
	    {
	        get{return active;}
	        set{ active = value;}
	    }
	    public bool InvertedYAxis
	    {
	        get{return invertedYAxis;}
	        set{invertedYAxis = value;}
	    }
	    public bool InvertedXAxis
	    {
	        get{return invertedXAxis;}
	        set{invertedXAxis = value;}
	    }
	
	    void Start()
	    {
	        Prepare();
	    }    
	    void Update()
	    {
	        if(active)
	        {
	            if(mouse != null && myCamera != null)
                {
					if(state == cameraState.Moving)
                    {
						CheckMouseInput();
						BlockMouse();
					}
					else if(state == cameraState.Static)
                    {
						UnblockedMouse();
					}
                }
	        }
			
	    }
	
	    void Prepare()
	    {
	        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
			    mouse = Mouse.current;
				keyBoard = Keyboard.current;
			#endif
	        
	        try{myCamera = Camera.main;}
	        catch{myCamera = GetComponent<Camera>();}
	
			active = true;
			
	    }
	
	    void CheckMouseInput()
	    {
	        Vector2 mouseMovement = mouse.delta.ReadValue();
	        rotationX = mouseMovement.x * MouseSensibility.Value;
			rotationLimit += mouseMovement.y * MouseSensibility.Value;
	        rotationLimit = Mathf.Clamp(rotationLimit,-80  ,80f);
			if(InvertedYState != null)
			{
				InvertedYAxis = InvertedYState.Value;
			}
	    	if(InvertedXState != null)
			{
				InvertedXAxis = InvertedXState.Value;
			}
	        if(!InvertedYAxis) 
	            myCamera.transform.localRotation = Quaternion.Euler(rotationLimit*-1,0,0);
	    
	       if(InvertedYAxis)
	            myCamera.transform.localRotation = Quaternion.Euler(rotationLimit*1,0,0);
	        
	        if(!InvertedXAxis)
	            player.Rotate(Vector3.up * rotationX);
	        if(InvertedXAxis)
	            player.Rotate(Vector3.up * rotationX*-1);
			
			GetViewInfo();
	    }
	    public void GetViewInfo()
	    {
	        RaycastHit hit;
	        Vector2 coordinate = new Vector2 (Screen.width/2,Screen.height/2);
	        Ray myRay = myCamera.ScreenPointToRay(coordinate);
			if(mouse.leftButton.wasPressedThisFrame)
	        {
	            if(Physics.Raycast (myRay, out hit, distanceHit))
	        	{
	            	IUsable usable = hit.transform.GetComponent<IUsable>();
	            	if(usable !=null)
	            	{
	                	usable.Use();
	            	}
		        	GravityProps gravityProps = hit.transform.GetComponent<GravityProps>();
		        	if(gravityProps != null)
		        	{
						gravityProps.GetProp();
						grabbedObj = hit.transform.GetComponent<GravityProps>();
		        	}
	        	}
				hasprop = true;
	        }
			if(mouse.rightButton.wasPressedThisFrame)
			{
				if(grabbedObj)
				{
					grabbedObj.DropProp();
					hasprop = false;
					grabbedObj = null;
				}
			}
			if(keyBoard.qKey.wasPressedThisFrame)
			{
				if(grabbedObj)
				{
					grabbedObj.ThrowProp();
					hasprop = false;
					grabbedObj = null;
				}
			}
			if(keyBoard.rKey.isPressed)
			{
				if(grabbedObj)
				{
					hasprop = true;
					grabbedObj.MoveAwayProp();
				}
			}
			if(keyBoard.eKey.isPressed)
			{
				if(grabbedObj)
				{
					hasprop = true;
					grabbedObj.BringCloserProp();
				}
			}
	    }
		private void BlockMouse()
        {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
        }
		private void UnblockedMouse()
        {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
        }
	}
}
