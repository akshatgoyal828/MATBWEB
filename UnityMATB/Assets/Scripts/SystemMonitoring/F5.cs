using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F5 : MonoBehaviour
{
    public Button f5;
    public static bool clicked = false;

    //To check if the user has responded
    public static bool responded = false;

    public static int no = 0;
    public static int sumTime = 0;
    public static int correct = 0;

    void Start()
    {
        Button btn = f5.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    public void Click()
    {
        if (sysMon.f5 == true)
        {
            //if responded = true means the time is taken into account
            if (responded == false)
            {
                responded = true;
                sysMon.f5 = false;
                correct++;
                sumTime = sumTime + (ElapsedTime.secs - sysMon.f5secs);
            }

            if (clicked == false)
            {
                clicked = true;
                Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
                GetComponent<Image>().color = newColorOn;
            }
            else
            {
                clicked = false;
                Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
                GetComponent<Image>().color = newColorOff;
            }
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5) && sysMon.f5 == true && responded == false)
        {
            responded = true;
            correct++;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f5secs);
            Click();
            sysMon.f5 = false;
        }

        if(sysMon.f5 == true && clicked == false)
        {
            no++;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }

        if (ElapsedTime.secs == 30 && ElapsedTime.minutes == 1 && sysMon.f5 == true && responded == false)
        {
            responded = true;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f5secs);
            Click();
            sysMon.f5 = false;
        }

        if (ElapsedTime.secs == 30 && ElapsedTime.minutes == 5 && sysMon.f5 == true && responded == false)
        {
            responded = true;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f5secs);
            Click();
            sysMon.f5 = false;
        }
        //Debug.Log("Time f5=" + sumTime);
    }

}
