using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//script for managing some of ingame condition
//need an inspection from previous project

public class GameManager : MonoBehaviour
{
    public Text RockTxt;
    public Text WinTxt;

    private int MoonRocktotal = 30;
    private int MoonRock = 0;

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
         
    }
}
