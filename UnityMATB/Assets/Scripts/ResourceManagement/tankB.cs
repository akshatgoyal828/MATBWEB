using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankB : MonoBehaviour
{
    Vector2 pos;
    Vector2 coord;
    public Text levelB;

    static int level = 4000;
    float scale = level / 0.1037675f;
    float flow7 = 0.004f;
    float flow8 = 0.004f;
    float flow3 = 0.008f;
    float flow4 = 0.006f;
    float consumptionB = 0.008f;

    //empty is used to check if the tankB is empty
    bool empty = false;

    //max is used to check if the tankB has reached it's maximum capacity
    public static bool maxB = false;

    //Set rmflag to true when the resource management task starts
    bool rmflag = true;

    //To calculate rmsd
    public static int no = 0;
    public static double sum = 0d;

    void Start()
    {
        pos = transform.localScale;
        coord = transform.position;

    }

    void Update()
    {
        if (rmflag == true)
        {
            if(pos.y > 0)
            {
                empty = false;
            }
            if (pos.y < 0.1037675f)
            {
                maxB = false;
            }
            if (empty == false)
            {
                pos.y -= consumptionB * Time.deltaTime;
                coord.y -= consumptionB * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    empty = true;
                    pump8.pump8_on = false;
                    pump8.clicked = false;
                    pump8.flow8 = 0;

                }
            }
            
            if (pump8.pump8_on == true && empty == false)
            {
                pos.y -= flow8 * Time.deltaTime;
                coord.y -= flow8 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    empty = true;
                    pump8.pump8_on = false;
                    pump8.clicked = false;
                    pump8.flow8 = 0;
                }
            }

            if (pump7.pump7_on == true && maxB == false)
            {
                pos.y += flow7 * Time.deltaTime;
                coord.y += flow7 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y >= 0.1037675f)
                {
                    maxB = true;
                }
            }

            if (pump3.pump3_on == true && maxB == false)
            {
                pos.y += flow3 * Time.deltaTime;
                coord.y += flow3 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y >= 0.1037675f)
                {
                    maxB = true;
                }
            }

            if (pump4.pump4_on == true && maxB == false)
            {
                pos.y += flow4 * Time.deltaTime;
                coord.y += flow4 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y >= 0.1037675f)
                {
                    maxB = true;
                }
            }
        }
        level = (int)(pos.y * scale);
        levelB.text = level.ToString();

        no++;
        sum = sum + (2500 - level) * (2500 - level);
    }
}
