using UnityEngine;

public class BigSwitch : MonoBehaviour
{
    public GameObject RockPos;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Rock"))
        {
            other.transform.GetComponent<Rigidbody>().useGravity = false;
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.transform.position = RockPos.transform.position;
        }
    }
}
