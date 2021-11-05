using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject Door;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Rock") || other.gameObject.CompareTag("Ball"))
        {
            Door.SetActive(false);
        }
    }
}
