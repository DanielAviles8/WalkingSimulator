using UnityEngine;

public class CheckBallPos : MonoBehaviour
{
    public GameObject Ball;
    public GameObject BallPos;
    public static bool isBallPos;
    public static bool IsBallPos
    {
        get { return isBallPos; }
        set { isBallPos = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        isBallPos = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckBall();
    }
    void CheckBall()
    {
        if(Ball.transform.position == BallPos.transform.position)
        {
            isBallPos = true;
        }
        else
        {
            isBallPos = false;
        }

        if(BigDoor.isActive == false)
        {
            Ball.GetComponent<Rigidbody>().useGravity = true;
            Ball.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
