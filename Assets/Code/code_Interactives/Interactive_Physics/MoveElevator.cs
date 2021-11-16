using UnityEngine;
using DG.Tweening;

public class MoveElevator : MonoBehaviour
{
    public Transform Elevator;
    public float animDuration;
    public GameObject Rock;
    public GameObject RockPos;
    public GameObject newRockPos;
    public bool isPlaceRock;

    public GameObject ExitDoor;

    public PathType pathType;
    public PathMode pathMode;

    public Vector3[] path;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FirstMove();
        if(isPlaceRock == true)
        {
            Rock.transform.position = newRockPos.transform.position;
        }
    }
    void FirstMove()
    {
        if(Rock.transform.position == RockPos.transform.position)
        {
            Elevator.DOPath(path, animDuration, pathType, pathMode, 10);
            isPlaceRock = true;
            ExitDoor.SetActive(false);
        }
    }
}