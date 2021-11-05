using UnityEngine;

public class BallSingleTargets : MonoBehaviour
{
    public Material CheckMark;
    public Material Target;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        ReturnMaterial();   
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(BallTargets.check == true)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                this.GetComponent<MeshRenderer>().material = CheckMark;
                BallTargets.otherTargets = BallTargets.otherTargets + 1;
            }
        }
    }
    void ReturnMaterial()
    {
        if(BallTargets.check == false)
        {
            this.GetComponent<MeshRenderer>().material = Target;
        }
    }
}
