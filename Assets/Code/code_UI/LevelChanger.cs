using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y <= -10)
        {
            FadeOut(4);
        }
    }
    void FadeOut(int levelindex)
    {
        levelToLoad = levelindex;
        animator.SetTrigger("FadeOut");
    }
    void OnFadeComplete()
    {
        SceneManager.LoadSceneAsync(levelToLoad);
    }
}
