using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioSource fx;
    public AudioClip hover;
    public AudioClip click;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }  

    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    public void hoverSound(){
        fx.PlayOneShot(hover);
    }

    public void clickSound()
    {
        fx.PlayOneShot(click);
    }
}
