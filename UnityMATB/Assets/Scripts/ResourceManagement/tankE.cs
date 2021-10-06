using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankE : MonoBehaviour
{
    Vector2 pos;
    Vector2 coord;
    /*float flow2 = 0.006f;
    float flow5 = 0.006f;

    //empty is used to check if the tankE is empty
    bool empty = false;

    //max is used to check if the tankE has reached it's maximum capacity
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
            /*if (pump2.pump2_on == true && empty == false)
            {
                pos.y -= flow2 * Time.deltaTime;
                coord.y -= flow2 * Time.deltaTime * 6.35f;
                transform.position = coord;
                transform.localScale = pos;
                if (pos.y <= 0)
                {
                    empty = true;
                }
            }
            if (pump5.pump5_on == true && max == true)
            {
                pos.y -= flow5 * Time.deltaTime;
                coord.y -= flow5 * Time.deltaTime * 6.35f;
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
