using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private Animator anim;
    
    //Animator referencing.
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    //Method called when Play is clicked and will start the animation that makes the screen black.
    public void FadeOutToLevel1()
    {
        anim.SetTrigger("FadeOut");
    }

    //At the end of the FadeOut animation, this method will be called switching to the next scene.
    public void Level1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //In case the player pulses Exit, this method will be called and the game will close.
    public void ExitGame()
    {
        Application.Quit();
    }
}
