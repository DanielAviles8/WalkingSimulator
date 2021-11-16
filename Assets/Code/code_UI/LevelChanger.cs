using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public GameObject Player;
    public int levelindex;
    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y <= -10)
        {
            FadeOut();
        }
    }
    void FadeOut()
    {
        levelToLoad = levelindex;
        animator.SetTrigger("FadeOut");
    }
    void OnFadeComplete()
    {
        SceneManager.LoadSceneAsync(levelToLoad);
    }
}
