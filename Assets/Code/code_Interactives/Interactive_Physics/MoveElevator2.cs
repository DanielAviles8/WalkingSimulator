using UnityEngine;
using DG.Tweening;

public class MoveElevator2 : MonoBehaviour
{
    public GameObject Rock;
    public GameObject newRock;
    // Start is called before the first frame update
    void Start()
    {
        newRock.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        ActiveRocks();
    }
    void ActiveRocks()
    {
        if (BallTargets.check == true && BallSingleTargets.targetOne == true && BallSingleTargets2.targetTwo == true && BallSingleTargets3.targetThree == true)
        {
            Rock.SetActive(false);
            newRock.SetActive(true);
        }
    }
}