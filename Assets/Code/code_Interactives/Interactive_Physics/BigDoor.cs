using UnityEngine;

public class BigDoor : MonoBehaviour
{
    public GameObject BigFDoor;
    public GameObject FirstSwitch;
    public GameObject SecondSwitch;
    public GameObject ThirdSwitch;
    public static bool isActive;
    public static bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }
    private void Start()
    {
        isActive = true;
    }
    private void Update()
    {
        if(CheckCubePos.isCubePos == true && CheckRockPos.isRockPos == true && CheckBallPos.isBallPos == true)
        {
            print("abierto");
            BigFDoor.SetActive(false);
            FirstSwitch.SetActive(false);
            SecondSwitch.SetActive(false);
            ThirdSwitch.SetActive(false);
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }
}
