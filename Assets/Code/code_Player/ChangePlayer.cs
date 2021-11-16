using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Player2;
    public Camera myCamera;
    public GameObject Rock;
    public GameObject cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        Player2.SetActive(false);
        Rock.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            print("chocando");
            myCamera.transform.parent = null;
            myCamera.transform.position = cameraPos.transform.position;
            Player2.SetActive(true);
            myCamera.transform.parent = Player2.transform;
            Player.SetActive(false);
            Rock.SetActive(true);
        }
    }
}
