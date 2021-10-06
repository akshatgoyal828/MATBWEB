using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tankC : MonoBehaviour
{
    Vector2 pos;
    Vector2 coord;
    public Text levelC;

    static int level = 2000;
    float scale = level / 0.09985277f;
    float flow1 = 0.008f;
    float flow5 = 0.006f;

    //empty is used to check if the tankC is empty
    bool empty = false;

    //max is used to check if the tankC has reached it's maximum capacity
    public static bool maxC = false;

    //Set rmflag to true when the resource management task starts
    bool rmflag = true;

    void Start()
    {
        pos = transform.localScale;
        coord = transform.position;

    }

    void Update()
    {
        if (rmflag == true)
        {
            if (pos.y < 0.09985277f)
            {
                maxC = false;
            }
            if (pump1.pump1_on == true && empty == false && tankA.maxA == false)
            {
                pos.y -= flow1 * Time.deltaTime;
                coord.y -= flow1 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    pump1.pump1_on = false;
                    empty = true;
                }
            }
            if (pump5.pump5_on == true && maxC == false)
            {
                pos.y += flow5 * Time.deltaTime;
                coord.y += flow5 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y >= 0.09985277f)
                {
                    maxC = true;
                }
            }
        }
        level = (int)(pos.y * scale);
        levelC.text = level.ToString();
    }
}
