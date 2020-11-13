using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//script for managing some of ingame condition
//need an inspection from previous project

public class GameManager : MonoBehaviour
{
    public Text RockTxt;

    private int MoonRocktotal = 30;
    public int MoonRock = 0;

    void Update()
    {
        RockTxt.text = MoonRock.ToString("0");   
    }

    void WinCondition()
    {
        if (MoonRock == MoonRocktotal)
        {

        }
    }
    void Respawn()
    {
         
    }
}
