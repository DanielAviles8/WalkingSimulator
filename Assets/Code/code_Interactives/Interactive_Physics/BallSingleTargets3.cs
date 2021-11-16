using UnityEngine;

public class BallSingleTargets3 : MonoBehaviour
{
    public Material CheckMark;
    public Material Target;
    public static bool targetThree;
    public static bool TargetThree
    {
        get { return targetThree; }
        set { targetThree = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        targetThree = false;
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
                targetThree = true;
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
