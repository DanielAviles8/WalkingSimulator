using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoor : MonoBehaviour
{
    public GameObject BigFDoor;
    public static float counter;
    public static float Counter
    {
        get{return counter;}
        set{counter = value;}
    }

    private void Update()
    {
        if(counter >= 1)
        {
            BigFDoor.SetActive(false);
        }
    }
}
