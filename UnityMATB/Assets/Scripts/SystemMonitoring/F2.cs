using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2 : MonoBehaviour
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
        if (sysMon.sysmon == true && sysMon.f2 == true)
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
                pos.y -= 1f * Time.deltaTime;
                transform.position = pos;
            }
            else if (trend == true)
            {
                pos.y += 1f * Time.deltaTime;
                transform.position = pos;
            }
        }
        else if (alternate == true)
        {
            alternate = false;
            pos.y += 2.5f * Time.deltaTime;
            transform.position = pos;
        }

        else
        {
            alternate = true;
            pos.y -= 2.5f * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.F2) && sysMon.f2 == true && responded == false)
        {
            responded = true;
            correct++;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f2secs);
            Click();
            sysMon.f2 = false;
        }

        if (ElapsedTime.secs == 10 && ElapsedTime.minutes == 2 && sysMon.f2 == true && responded == false)
        {
            responded = true;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f2secs);
            Click();
            sysMon.f2 = false;
        }

        if (ElapsedTime.secs == 40 && ElapsedTime.minutes == 6 && sysMon.f2 == true && responded == false)
        {
            responded = true;
            sumTime = sumTime + (ElapsedTime.secs - sysMon.f2secs);
            Click();
            sysMon.f2 = false;
        }

        //Debug.Log("Time f2 =" + sumTime);
    }

    public void Click()
    {
        if (sysMon.f2 == true)
        {
            //if responded = true means the time is taken into account
            if (responded == false)
            {
                responded = true;
                sysMon.f2 = false;
                correct++;
                sumTime = sumTime + (ElapsedTime.secs - sysMon.f2secs);
            }

            pos.y = 2.212f;
            transform.position = pos;
            sysMon.f2 = false;
        }
    }
}
