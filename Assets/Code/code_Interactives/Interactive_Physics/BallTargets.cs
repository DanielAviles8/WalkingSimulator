using UnityEngine;
using System.Collections;

public class BallTargets : MonoBehaviour
{
    public Material CheckMark;
    public Material Target;
    public GameObject ExitDoor;
    public AudioSource Song;

    public static float otherTargets;
    public static float OtherTargets
    {
        get { return otherTargets; }
        set { otherTargets = value; }
    }

    public static bool check;
    public static bool Check
    {
        get { return check; }
        set { check = value; }
    }
    private void Start()
    {
        check = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (check == true)
        {
            StartCoroutine(Counter());
            
        }
        if(check == false)
        {
            StopCoroutine(Counter());
            Song.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            this.GetComponent<MeshRenderer>().material = CheckMark;
            check = true;
            Song.Play();
        }
    }
    IEnumerator Counter()
    {
        StartCounting();
        yield return new WaitForSeconds(40);
        check = false;
        this.GetComponent<MeshRenderer>().material = Target;
    }
    public void StartCounting()
    {
        if(check == true && otherTargets >= 3)
        {
            ExitDoor.SetActive(false);
        }
    }
}
