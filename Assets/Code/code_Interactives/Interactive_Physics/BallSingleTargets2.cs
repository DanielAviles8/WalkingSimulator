using UnityEngine;

public class BallSingleTargets2 : MonoBehaviour
{
    public Material CheckMark;
    public Material Target;
    public static bool targetTwo;
    public static bool TargetTwo
    {
        get { return targetTwo; }
        set { targetTwo = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        targetTwo = false;
    }
    // Update is called once per frame
    void Update()
    {
        ReturnMaterial();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (BallTargets.check == true)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                this.GetComponent<MeshRenderer>().material = CheckMark;
                targetTwo = true;
            }
        }
    }
    void ReturnMaterial()
    {
        if (BallTargets.check == false)
        {
            this.GetComponent<MeshRenderer>().material = Target;
        }
    }
}
