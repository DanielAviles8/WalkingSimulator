using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSwitch : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("ball"))
        {
            other.gameObject.transform.position = this.transform.position;
            BigDoor.counter = BigDoor.counter + 1;
            print(BigDoor.counter);
        }
    }
}
