using UnityEngine;

public class CheckRockPos : MonoBehaviour
{
    public GameObject Rock;
    public GameObject RockPos;
    public static bool isRockPos;
    public static bool IsRockPos
    {
        get { return isRockPos; }
        set { isRockPos = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        isRockPos = false;
    }
    // Update is called once per frame
    void Update()
    {
        CheckRock();
    }
    void CheckRock()
    {
        if(Rock.transform.position == RockPos.transform.position)
        {
            isRockPos = true;
        }
        else
        {
            isRockPos = false;
        }

        if (BigDoor.isActive == false)
        {
            Rock.GetComponent<Rigidbody>().useGravity = true;
            Rock.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
