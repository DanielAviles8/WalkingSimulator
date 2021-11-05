using UnityEngine;
using UnityEngine.Events;
using com.amerike.rod;

public class GravityProps : MonoBehaviour
{
	public UnityEvent OnUse;
	public GameObject Hand; 
	public float speed;
	public GameObject Player;
	public bool CanInteract
	{
		get
		{
			return canInteract;
		}
		set
		{
			canInteract = value;
		}
	}
	bool canInteract;
	public void Use()
	{
		if(OnUse != null)
		{
			OnUse.Invoke();
		}
		GetProp();
		DropProp();
		ThrowProp();
		MoveAwayProp();
		BringCloserProp();
	}
	public void GetProp()
	{
		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<Rigidbody>().isKinematic = true;
		gameObject.transform.position = Hand.transform.position;
		gameObject.transform.parent = Hand.transform;
	}
	public void DropProp()
	{
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().isKinematic = false;
		gameObject.transform.parent = null;
        if (gameObject.CompareTag("MetalCube"))
        {
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
	}
	public void ThrowProp()
	{
		GetComponent<Rigidbody>().velocity = Hand.transform.forward * speed;
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().isKinematic = false;
		gameObject.transform.parent = null;
	}
	public void MoveAwayProp()
	{
		float distance = Vector3.Distance(Hand.transform.position, Player.transform.position);
		Mathf.Round(distance);
		if(distance <= 10 && distance >= 1.5f)
		{
			Hand.transform.Translate(0, 0, .1f);
		}
	}
	public void BringCloserProp()
	{
		float distance = Vector3.Distance(Hand.transform.position, Player.transform.position);
		Mathf.Round(distance);
		if(distance <= 10.5f && distance >= 2)
        {
			Hand.transform.Translate(0, 0, -.1f);
		}
	}
}