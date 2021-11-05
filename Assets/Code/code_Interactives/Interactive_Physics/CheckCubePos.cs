using UnityEngine;

public class CheckCubePos : MonoBehaviour
{
    public GameObject MetalCube;
    public GameObject CubePos;
    public static bool isCubePos;
    public static bool IsCubePos
    {
        get { return isCubePos; }
        set { isCubePos = value; }
    }
    private void Start()
    {
        isCubePos = false;
    }
    private void Update()
    {
        CheckPos();
    }
    void CheckPos()
    {
        if(MetalCube.transform.position == CubePos.transform.position)
        {
            isCubePos = true;
        }
        else
        {
            isCubePos = false;
        }

        if(BigDoor.isActive == false)
        {
            MetalCube.GetComponent<Rigidbody>().useGravity = true;
            MetalCube.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}