using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public static bool ground;
    public static bool Ground
    {
        get { return ground; }
        set { ground = value; }
    }
    private void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    }
    private void Update()
    {
        print(ground);
    }
}
