using UnityEngine;
using UnityEngine.Events;

namespace com.amerike.rod
{
	public class Letter : MonoBehaviour, IUsable
	{
		public UnityEvent OnUse;
		[SerializeField] private PlayerMovement Player;
		[SerializeField] private PlayerCam Camera;
		public GameObject Table;
		public bool isReading;
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
        private void Start()
        {
			isReading = false;
        }
        public void Use()
		{
			if (OnUse != null)
			{
				OnUse.Invoke();
			}
		}
		public void MakeStatic()
		{
			Player.state = PlayerMovement.playerState.Static;
			Camera.state = PlayerCam.cameraState.Static;
			isReading = true;
		}
		public void MakeMovible()
        {
			Player.state = PlayerMovement.playerState.Moving;
			Camera.state = PlayerCam.cameraState.Moving;
        }
        private void Update()
        {
            if(isReading == true)
            {
				Table.SetActive(false);
            }
        }
    }
}

