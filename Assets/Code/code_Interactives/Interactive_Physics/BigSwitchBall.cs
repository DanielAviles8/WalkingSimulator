using UnityEngine;

public class BigSwitchBall : MonoBehaviour
{
    public GameObject BallPos;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.transform.GetComponent<Rigidbody>().useGravity = false;
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = BallPos.transform.position;
        }
    }
}
