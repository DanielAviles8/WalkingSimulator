using UnityEngine;
using UnityEngine.Events;
using com.amerike.rod;

public class GravityProps : MonoBehaviour
{
	public UnityEvent OnUse;
	public GameObject Hand;
	public float speed;
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
	}
	public void GetProp()
	{
		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<Rigidbody>().isKinematic = true;
		gameObject.transform.position = Hand.transform.position;
		gameObject.transform.parent = Hand.transform;
		print("agarre prop :D");
	}
	public void DropProp()
	{
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().isKinematic = false;
		gameObject.transform.parent = null;
		print("solte prop D:");
	}
	public void ThrowProp()
	{
		GetComponent<Rigidbody>().velocity = Hand.transform.forward * speed;
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Rigidbody>().isKinematic = false;
		gameObject.transform.parent = null;
		print("avente prop");
	}
}