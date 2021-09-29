using UnityEngine;
using UnityEngine.Events;
using com.amerike.rod;

public class GravityProps : MonoBehaviour, IUsable
{
	public UnityEvent OnUse;
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
		
	}
	public void GetProp()
	{
		print("awebo");
	}
}