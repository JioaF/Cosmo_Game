using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerTxt;

    public string timetxt;
    private float time;
    private float s;
    private float m;
    private float ms;

  
    public void TimerStart()
    {
        StartCoroutine("StartTimer");
    } 

    IEnumerator StartTimer()
    {
        while (true)
        {
            time += Time.deltaTime;
            ms = (int)((time - (int)time) * 100);
            s = (time % 60);
            m = (time / 60 % 60);

            timetxt = string.Format("{0:00}:{1:00}:{2,00}", m,s,ms);
            timerTxt.text = timetxt;
            
            yield return null;
        }
    }


}
