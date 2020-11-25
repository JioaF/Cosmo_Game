using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
TODO: 
make a walkpoint for the enemy to patrol the map
then another another prefab of that enemy object after destroyed

OR

recreate the script for chasing the player only
give cd to the enemy after destroyed and then spawn the enemy
 */
public class GameManager : MonoBehaviour
{
    public Text RockTxt;
    public Text WinTxt;
    public GameObject Go;
    public GameObject Gover;
    public GameObject Gc;
    public GameObject player;
    public Transform spawner;
    public GameObject mob;

    private int MoonRocktotal = 10;
    private int MoonRock = 0;

    private void Start()
    {
        Go.SetActive(true);
    }

    public void ContinueBtn()
    {
        Gc.SetActive(true);
        Go.SetActive(false);
        player.SetActive(true);
        Invoke(nameof(spawn), 10f);
    }

    public void RetryBtn()
    {
        Go.SetActive(false);
        Respawn();
    }
    public void ExitBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void setMoonRock()
    {
        MoonRock += 1;
    }

    void Update()
    {
        RockTxt.text = "Rock : " + MoonRock.ToString() + "/" + MoonRocktotal.ToString();
    }

    void insertTxt(Text txt, string text = "")
    {
        txt.text = text;
    }

    //experimental
    public void WinCondition()
    {
        if (MoonRock == MoonRocktotal)
        {
           insertTxt(WinTxt, "You win");
        }
        else if(MoonRock <= 10)
        {
            insertTxt(WinTxt, "You need atleast 10 rock or more to proceed");
            
        }
    }
    void Respawn()
    {
        Debug.Log("called");
        //player.transform.position.Set();
        Gover.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void spawn()
    {
        Debug.Log("function called");
        mob.SetActive(true);
        
    }
}
