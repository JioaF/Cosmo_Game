using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioSource fx;
    public AudioClip hover;
    public AudioClip click;

    public GameObject InfoMenu;
    public GameObject MainMenu;

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

    public void backBtn()
    {
        MainMenu.SetActive(true);
        InfoMenu.SetActive(false);
    }

    public void NotesMenu()
    {
        MainMenu.SetActive(false);
        InfoMenu.SetActive(true);
    }

    public void openURL()
    {
        string url = "https://github.com/JioaF/Cosmo_Game";
        Application.OpenURL(url);
    }
}
