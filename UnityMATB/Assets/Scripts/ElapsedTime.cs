using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElapsedTime : MonoBehaviour
{
    public Text txt;
    public Text tracktxt;

    public static int minutes = 0;
    public float intervalmin = 60;

    public static int secs = 0;
    public float intervalsec = 1;

    void Start()
    {
        triggerThisFunction();
        triggerThisFunctionsec();
    }

    public void triggerThisFunction()
    {
        minutes = minutes + 1;
        secs = 0;
        Invoke("triggerThisFunction", intervalmin);
    }

    public void triggerThisFunctionsec()
    {
        secs = secs + 1;
        Invoke("triggerThisFunctionsec", intervalsec);
    }

    void Update()
    {
        txt.text = (minutes-1).ToString() +" : " + secs.ToString();

        //System Monitoring Task
        if (minutes == 1 && secs == 15 && sysMon.f5 == false)
        {
            sysMon.f5 = true;
            sysMon.f5secs = 15;
            F5.no++;
        }
        
        if (minutes == 2 && secs == 0 && sysMon.f2 == false)
        {
            sysMon.sysmon = true;
            sysMon.f2 = true;
            sysMon.f2secs = 0;
            F2.no++;
        }

        if (minutes == 2 && secs == 10 && sysMon.f1 == false)
        {
            sysMon.sysmon = true;
            sysMon.f1 = true;
            sysMon.f1secs = 10;
            F1.no++;
        }

        if (minutes == 3 && secs == 0 && sysMon.f6 == false)
        {
            sysMon.f6 = true;
            sysMon.f6secs = 0;
            F6.no++;
        }

        if (minutes == 3 && secs == 30 && sysMon.f3 == false)
        {
            sysMon.sysmon = true;
            sysMon.f3 = true;
            sysMon.f3secs = 0;
            F3.no++;
        }

        if (minutes == 4 && secs == 15 && sysMon.f1 == false)
        {
            sysMon.sysmon = true;
            sysMon.f1 = true;
            sysMon.f1secs = 15;
            F1.responded = false;
            F1.no++;
        }

        if (minutes == 4 && secs == 45 && sysMon.f4 == false)
        {
            sysMon.sysmon = true;
            sysMon.f4 = true;
            sysMon.f4secs = 45;
            F4.no++;
        }

        if (minutes == 5 && secs == 15 && sysMon.f5 == false)
        {
            sysMon.sysmon = true;
            sysMon.f5 = true;
            sysMon.f5secs = 15;
            F5.responded = false;
            F5.no++;
        }

        if (minutes == 5 && secs == 40 && sysMon.f4 == false)
        {
            sysMon.sysmon = true;
            sysMon.f4 = true;
            sysMon.f4secs = 40;
            F4.responded = false;
            F4.no++;
        }

        if (minutes == 6 && secs == 30 && sysMon.f2 == false)
        {
            sysMon.sysmon = true;
            sysMon.f2 = true;
            sysMon.f2secs = 30;
            F2.responded = false;
            F2.no++;
        }

        if (minutes == 7 && secs == 15 && sysMon.f1 == false)
        {
            sysMon.sysmon = true;
            sysMon.f1 = true;
            sysMon.f1secs = 15;
            F1.responded = false;
            F1.no++;
        }

        //Tracking Task
        if (minutes >= 2 && minutes < 4)
        {
            Joystick.trackingt1 = true;
            Joystick.tracking = true;
            tracktxt.text = "MANUAL";
        }
        if (minutes >= 7 && minutes < 9)
        {
            Joystick.trackingt2 = true;
            Joystick.tracking = true;
            tracktxt.text = "MANUAL";
        }
        if (minutes >= 4 && minutes < 7)
        {
            Joystick.trackingt1 = false;
            Joystick.trackingt2 = false;
            Joystick.tracking = false;
            tracktxt.text = "AUTO ON";
        }

        //Communications task
        if (minutes >= 3 && minutes < 9)
        {
            Enter.comtask = true;
        }
    }
}
