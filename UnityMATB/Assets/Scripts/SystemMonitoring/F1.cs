using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1 : MonoBehaviour
{
    Vector2 pos;

    //to check if trend is positive or negative
    bool trend = false;

    //to go alternately up and down
    bool alternate = false;

    //To check if the user has responded
    public static bool responded = false;

    public static int no = 0;
    public static int sumTime = 0;
    public static int correct = 0;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        if (sysMon.sysmon == true && sysMon.f1 == true)
        {
            if (pos.y <= 1.05f)
            {
                trend = true;
                pos.y = 2.212f;
                transform.position = pos;
            }
            else if (pos.y >= 3.01f)
            {
                trend = false;
                pos.y = 2.212f;
                transform.position = pos;
            }

            if (trend == false)
            {
                pos.y -= 1.5f * Time.deltaTime;
                transform.position = pos;
            }
            else if (trend == true)
            {
                pos.y += 1.5f * Time.deltaTime;
                transform.position = pos;
            }
        }

        else if (alternate == false)
        {
            alternate = true;
            pos.y += 2.5f * Time.deltaTime;
            transform.position = pos;
        }

        else
        {
            alternate = false;
            pos.y -= 2.5f * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.F1) && sysMon.f1 == true && responded == false)
        {
            responded = true;
            correct++;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f1secs);
            Click();
            sysMon.f1 = false;
        }

        if (ElapsedTime.secs == 20 && ElapsedTime.minutes == 2 && sysMon.f1 == true && responded == false)
        {
            responded = true;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f1secs);
            Click();
            sysMon.f1 = false;
        }

        if (ElapsedTime.secs == 25 && ElapsedTime.minutes == 4 && sysMon.f1 == true && responded == false)
        {
            responded = true;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f1secs);
            Click();
            sysMon.f1 = false;
        }

        if (ElapsedTime.secs == 25 && ElapsedTime.minutes == 7 && sysMon.f1 == true && responded == false)
        {
            responded = true;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f1secs);
            Click();
            sysMon.f1 = false;
        }

        //Debug.Log("Time f1 =" + sumTime);
    }

    public void Click()
    {
        if (sysMon.f1 == true)
        {
            //if responded = true means the time is taken into account
            if (responded == false)
            {
                responded = true;
                sysMon.f1 = false;
                correct++;
                sumTime = sumTime + (ElapsedTime.secs - sysMon.f1secs);
            }

            pos.y = 2.212f;
            transform.position = pos;
            sysMon.f1 = false;
        }
    }
}
