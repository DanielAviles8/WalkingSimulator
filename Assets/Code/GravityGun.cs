using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float maxGrabDistance, throwForce, lerpSpeed;
    [SerializeField] Transform objectHolder;

    Rigidbody rigidbody;
    void Start()
    {
        
    }
    void Update()
    {
        if (rigidbody)
        {
            rigidbody.MovePosition(objectHolder.transform.position);
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (rigidbody)
            {
                rigidbody.isKinematic = false;
                rigidbody = null;
            }
            else
            {
                RaycastHit hit;
                Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDistance))
                {
                    rigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (rigidbody)
                    {
                        rigidbody.isKinematic = true;
                    }
                }
            }
        }
    }
}
