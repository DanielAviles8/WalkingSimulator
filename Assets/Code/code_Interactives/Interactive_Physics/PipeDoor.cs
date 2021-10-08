using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PipeDoor : MonoBehaviour
{
	Mouse minimouse;
	bool active;
	public bool Active
	{
		get { return active; }
		set { active = value; }
	}
	void Start()
    {
		Prepare();
    }

	void Prepare()
	{
		#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR || UNITY_STANDALONE_LINUX
		minimouse = Mouse.current;
		#endif

		active = true;
	}
	private void Update()
    {
		CheckInput();
    }
	void CheckInput()
	{
        if (minimouse.leftButton.wasPressedThisFrame)
        {
			print("abrete sesamo");
			this.gameObject.GetComponent<HingeJoint>().axis = new Vector3(0,0,1);
			this.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, .5f);
        }
	}
}
