using UnityEngine;
using com.amerike.rod;
public class MainPlayer : MonoBehaviour
{
	public com.amerike.rod.PlayerMovement _PlayerMovement;
	public com.amerike.rod.PlayerCam _PlayerCamera;
	public Transform myHand;
	void Awake()
	{
		Prepare();
	}
	void Prepare()
	{
		if(_PlayerCamera != null)
		{
			_PlayerCamera.OnGrab += HandleOnGrab;
		}
	}
	void HandleOnGrab (PlayerCam sender)
	{
		sender.GrabbedObj.transform.position = myHand.transform.position;
		sender.GrabbedObj.transform.parent = myHand.transform;
	}
}
