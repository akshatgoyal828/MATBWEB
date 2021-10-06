using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enter : MonoBehaviour
{
    public Button enter;
    public static float nav1;
    public static float nav2;
    public static float com1;
    public static float com2;
    public AudioClip[] audioClipArray;
    public AudioSource audioSource;
    public static bool comtask = false;
    public static int correct = 0;
    public static int no = 0;

    public static int min = 3;
    public static int sec = 5;
    // clipi is the index of the clip to be chosen
    public static int clipi = 0;

    // used to store the name of audio file as a string
    // clipArray[0] stores OWN or OTHER
    // clipArray[1] stores COM1, COM2, NAV1 or NAV2
    // clipArray[2] stores integer value of radio frequency
    // clipArray[3] stores the decimal value of radio frequency
    public static string[] clipArray;
    public static string clip;

    //adding a wait time for the audio to finish playing
    public static bool playing = false;

    void Start()
    {
        Button btn = enter.GetComponent<Button>();
        btn.onClick.AddListener(Click);
        clipArray = new string[4];
    }

    void Update()
    {
        if(comtask == true)
        {
            //This code segment plays a correct audio file once every minute
            if(ElapsedTime.minutes == min && ElapsedTime.secs == sec && playing == false)
            {
                sec = sec + 30;
                playing = true;
                audioSource.PlayOneShot(playClip(clipi));
                clipi++;
                no++;
            }
            else if (ElapsedTime.minutes == min && ElapsedTime.secs == sec && playing == true)
            {
                playing = false;
                sec = 5;
            }

            //This code segment plays a wrong audio file once every minute
            else if (ElapsedTime.minutes == min && ElapsedTime.secs == 40 && playing == false)
            {
                min++;
                playing = true;
                audioSource.PlayOneShot(RandomClip());
                no++;
            }
            else if (ElapsedTime.minutes == min && ElapsedTime.secs == 10 && playing == true)
            {
                playing = false;
            }

            else if (ElapsedTime.minutes >= 9 )
            {
                comtask = false;
            }

        }
    }

    public void Click()
    {
        //no response is also marked as an incorrect response

        nav1 = NAV1.value;
        nav2 = NAV2.value;
        com1 = COM01.value;
        com2 = COM02.value;
        float value = int.Parse(clipArray[2]) + int.Parse(clipArray[3]) / 1000.0f;

        //Storing the default values
        float nav1D = 108.000f;
        float nav2D = 108.000f;
        float com1D = 118.000f;
        float com2D = 118.000f;

        
        //Debug.Log(value);
        if (clipArray[0] == "OWN")
        {
            if(clipArray[1] == "COM1")
            {
                if(com1 == value && com2 == com2D && nav1 == nav1D && nav2 == nav2D)
                {
                    //marked as correct response and save time taken to respond
                    correct++;

                }
            }
            else if (clipArray[1] == "COM2")
            {
                if (com2 == value && com1 == com1D && nav1 == nav1D && nav2 == nav2D)
                {
                    //marked as correct response and save time taken to respond
                    correct++;

                }
            }
            else if (clipArray[2] == "NAV1")
            {
                if (com1 == com1D && com2 == com2D && nav1 == value && nav2 == nav2D)
                {
                    //marked as correct response and save time taken to respond
                    correct++;

                }
            }
            else if (clipArray[2] == "NAV2")
            {
                if (com1 == com1D && com2 == com2D && nav1 == nav1D && nav2 == value)
                {
                    //marked as correct response and save time taken to respond
                    correct++;

                }
            }
        }
        if (clipArray[0] == "OTHER")
        {
            if (com1 != com1D && com2 != com2D && nav1 != nav1D && nav2 == nav2D)
            {
                //marked as incorrect response
            }
            else
                correct++;
        }
    }

    AudioClip RandomClip()
    {
        int randint = Random.Range(7, 14);
        clip = "" + audioClipArray[randint] + " ";

        //Random Clip audio file name: OTHER_NAV2_108-750
        clipArray[0] = clip.Substring(0, 5);
        clipArray[1] = clip.Substring(6, 4);
        clipArray[2] = clip.Substring(11, 3);
        clipArray[3] = clip.Substring(15, 3);

        return audioClipArray[randint];
    }

    AudioClip playClip(int index)
    {
        clip = "" + audioClipArray[index] + " ";

        //Own Clip audio file name: OWN_COM1_108-550
        clipArray[0] = clip.Substring(0, 3);
        clipArray[1] = clip.Substring(4, 4);
        clipArray[2] = clip.Substring(9, 3);
        clipArray[3] = clip.Substring(13, 3);

        return audioClipArray[index];
    }
}
