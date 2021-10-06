using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankD : MonoBehaviour
{
    Vector2 pos;
    Vector2 coord;
    public Text levelD;

    static int level = 2000;
    float scale = level / 0.09985277f;
    float flow3 = 0.008f;
    float flow6 = 0.006f;

    //empty is used to check if the tankD is empty
    bool empty = false;

    //max is used to check if the tankD has reached it's maximum capacity
    public static bool maxD = false;

    //Set rmflag to true when the resource management task starts
    bool rmflag = true;

    void Start()
    {
        pos = transform.localScale;
        coord = transform.position;

    }

    void Update()
    {
        if(rmflag == true)
        {
            if (pos.y < 0.09985277f)
            {
                maxD = false;
            }
            if (pump3.pump3_on == true && empty == false && tankB.maxB == false)
            {
                pos.y -= flow3 * Time.deltaTime;
                coord.y -= flow3 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    pump3.pump3_on = false;
                    empty = true;
                }
            }
            if (pump6.pump6_on == true && maxD == false)
            {
                pos.y += flow6 * Time.deltaTime;
                coord.y += flow6 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y >= 0.09985277f)
                {
                    maxD = true;
                }
            }
        }
        level = (int)(pos.y * scale);
        levelD.text = level.ToString();
    }
}
