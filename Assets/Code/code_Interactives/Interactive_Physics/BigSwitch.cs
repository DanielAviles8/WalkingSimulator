using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSwitch : MonoBehaviour
{
    public Vector3 offset;
    void Start()
    {
        offset = new Vector3(.5f, -.5f, 1f);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ball"))
        {
            other.transform.GetComponent<Rigidbody>().useGravity = false;
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.position = this.transform.position-offset;
            BigDoor.counter = BigDoor.counter + 1;
            print(BigDoor.counter);
        }
    }
}
