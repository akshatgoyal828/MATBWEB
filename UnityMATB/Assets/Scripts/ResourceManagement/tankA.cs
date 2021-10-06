using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankA : MonoBehaviour
{
    Vector2 pos;
    Vector2 coord;
    public Text levelA;

    static int level = 4000;
    float scale = level / 0.1037675f;
    float flow7 = 0.004f;
    float flow8 = 0.004f;
    float flow1 = 0.008f;
    float flow2 = 0.006f;
    float consumptionA = 0.008f;

    //Set rmflag to true when the resource management task starts
    bool rmflag = true;

    //empty is used to check if the tankA is empty
    bool empty = false;

    //max is used to check if the tankA has reached it's maximum capacity
    public static bool maxA = false;

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
        if(rmflag == true)
        {
            if (pos.y > 0)
            {
                empty = false;
            }
            if (pos.y < 0.1037675f)
            {
                maxA = false;
            }
            if (empty == false)
            {
                pos.y -= consumptionA * Time.deltaTime;
                coord.y -= consumptionA * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    empty = true;
                    pump7.pump7_on = false;
                    pump7.clicked = false;
                    pump7.flow7 = 0;
                }
            }

            if (pump7.pump7_on == true && empty == false)
            {
                pos.y -= flow7 * Time.deltaTime;
                coord.y -= flow7 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    empty = true;
                    pump7.pump7_on = false;
                    pump7.clicked = false;
                    pump7.flow7 = 0;
                }
            }

            if (pump8.pump8_on == true && maxA == false)
            {
                pos.y += flow8 * Time.deltaTime;
                coord.y += flow8 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y >= 0.1037675f)
                {
                    maxA = true;
                }
            }

            if (pump1.pump1_on == true && maxA == false)
            {
                pos.y += flow1 * Time.deltaTime;
                coord.y += flow1 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y >= 0.1037675f)
                {
                    maxA = true;
                }
            }

            if (pump2.pump2_on == true && maxA == false)
            {
                pos.y += flow2 * Time.deltaTime;
                coord.y += flow2 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y >= 0.1037675f)
                {
                    maxA = true;
                }
            }
        }
        level = (int) (pos.y * scale);
        levelA.text = level.ToString();

        no++;
        sum = sum + (2500 - level) * (2500 - level);

    }
}
