using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
TODO: 
simulate the win condition
OR create pause menu;
 */
public class GameManager : MonoBehaviour
{
    public Text RockTxt;
    public Text WinTxt;
    public GameObject Go;//gameobjective 
    public GameObject Gover;//gameover
    public GameObject Gc;//gamecomponent
    public GameObject pause;
    public GameObject WinS;
    public GameObject player;
    public GameObject Camera;
    public Transform spawner;
    public GameObject mob;
    public AudioSource fx;
    public AudioClip click;
    public AudioClip hover;

    private int MoonRocktotal = 10;
    private int MoonRock = 0;
    private bool isPause = false;
    private bool isWin = false;

    private void Start()
    {
        
    }

    //button section
    public void ContinueBtn()
    {
        Gc.SetActive(true);
        Go.SetActive(false);
        Gover.SetActive(false);
        Invoke(nameof(spawn), 10f);
        //uiSound.enabled = false;
        Camera.SetActive(true);
    }

    public void clickSound()
    {
        fx.PlayOneShot(click);
    }

    public void hoverSound()
    {
        fx.PlayOneShot(hover);
    }
    public void RetryBtn()
    {
        Respawn();
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //end of button section


    public void setMoonRock()
    {
        MoonRock += 1;
    }

    void Update()
    {
        RockTxt.text = "Rock : " + MoonRock.ToString() + "/" + MoonRocktotal.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            
            resumeGame();
        }

    }

    public void pauseGame()
    {
        FindObjectOfType<audioManager>().Pause(true);
        isPause = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        pause.SetActive(isPause);
    }

    public void exitPausebtn()
    {
        isPause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void resumeGame()
    {
        isPause = false;
        FindObjectOfType<audioManager>().Pause(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pause.SetActive(isPause);
    }

    public void WintextGone()
    {
        WinTxt.text = " ";
    }
   
    public void WinCondition()
    {
        if (MoonRocktotal == MoonRock)
        {
            isWin = true;
            WinTxt.text = "YOU WIN";
            Invoke("WinScene", 1.5f);
        }
        else if(MoonRocktotal != MoonRock && isWin == false)
        {
            WinTxt.text = "YOU DONT HAVE ENOUGH ROCK";
            Invoke("WintextGone", 2f);
        }
    }

    public void WinScene()
    {
        FindObjectOfType<audioManager>().Stop("EnemyAppear");
        FindObjectOfType<audioManager>().Play("Winning");
        WinS.SetActive(isWin);
        Cursor.lockState = CursorLockMode.None;
        Camera.SetActive(false);
        Gc.SetActive(false);
        
    }
    void Respawn()
    {
        Debug.Log("called");
        Gover.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void spawn()
    {
        Debug.Log("GM Spawn");
        mob.SetActive(true);
        mob.transform.position = spawner.transform.position;
    }
}
