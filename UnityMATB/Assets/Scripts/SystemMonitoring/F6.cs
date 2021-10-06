using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class F6 : MonoBehaviour
{
    public Button f6;
    public static bool clicked = false;

    //To check if the user has responded
    public static bool responded = false;

    public static int no = 0;
    public static int sumTime = 0;
    public static int correct = 0;

    void Start()
    {
        Button btn = f6.GetComponent<Button>();
        btn.onClick.AddListener(Click);
        Color newColorOn = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
        GetComponent<Image>().color = newColorOn;
    }

    //Click is disabled when it shouldn't be active
    public void Click()
    {
        if(sysMon.f6 == true)
        {
            //if responded = true means the time is taken into account
            if(responded == false)
            {
                responded = true;
                sysMon.f6 = false;
                correct++;
                sumTime = sumTime + (ElapsedTime.secs - sysMon.f6secs);
            }
            
            if (clicked == false)
            {
                clicked = true;
                Color newColorOn = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
                GetComponent<Image>().color = newColorOn;
            }
            else
            {
                clicked = false;
                Color newColorOff = new Color(1f, 0.2072f, 0.0896f, 1f);
                GetComponent<Image>().color = newColorOff;
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6) && sysMon.f6 == true && responded == false)
        {
            responded = true;
            correct++;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f6secs);
            Click();
            sysMon.f6 = false;
        }

        if (sysMon.f6 == true && clicked == false)
        {
            no++;
            Color newColorOff = new Color(1f, 0.2072f, 0.0896f, 1f);
            GetComponent<Image>().color = newColorOff;
        }

        if(ElapsedTime.secs == 15 && ElapsedTime.minutes == 3 && sysMon.f6 == true && responded == false)
        {
            responded = true;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f6secs);
            Click();
            sysMon.f6 = false;
        }
        //Debug.Log("Time =" + sumTime);
    }

}
