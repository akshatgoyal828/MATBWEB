using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankF : MonoBehaviour
{
    Vector2 pos;
    Vector2 coord;
    /*float flow4 = 0.006f;
    float flow6 = 0.006f;

    //empty is used to check if the tankF is empty
    bool empty = false;

    //max is used to check if the tankF has reached it's maximum capacity
    bool max = true;*/

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
            /*if (pump4.pump4_on == true && empty == false)
            {
                pos.y -= flow4 * Time.deltaTime;
                coord.y -= flow4 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    empty = true;
                }
            }
            if (pump6.pump6_on == true && max == true)
            {
                pos.y -= flow6 * Time.deltaTime;
                coord.y -= flow6 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    max = false;
                }
            }*/
        }
    }
}
