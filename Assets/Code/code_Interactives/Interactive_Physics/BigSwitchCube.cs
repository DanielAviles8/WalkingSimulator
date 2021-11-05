using UnityEngine;

public class BigSwitchCube : MonoBehaviour
{
    public GameObject CubePos;
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("MetalCube"))
        {
            other.transform.GetComponent<Rigidbody>().useGravity = false;
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = CubePos.transform.position;
        }
    }
}
