using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 0.002f;
    private bool touchStart = false;
    Vector2 pointA;
    Vector2 pointB;

    public static bool trackingt1 = false;
    public static bool trackingt2 = false;
    public static bool tracking = false;
    public static double sum = 0d;
    public static int no = 0;

    Vector2 coord;
    Vector2 coordInitial;
    Vector2 prev;
    // Start is called before the first frame update
    void Start()
    {
        coord = player.position;
        coordInitial = player.position;
        prev = coord;
    }

    // Update is called once per frame
    void Update()
    {
        if (trackingt1 == true && tracking == true && touchStart == false)
        {
            coord.y -= 0.5f * Time.deltaTime;
            coord.x -= 0.5f * Time.deltaTime;
            player.position = coord;
        }
        if (trackingt2 == true && tracking == true && touchStart == false)
        {
            coord.y += 0.5f * Time.deltaTime;
            coord.x -= 0.5f * Time.deltaTime;
            player.position = coord;
        }
        if (tracking == false)
        {
            coord = coordInitial;
            player.position = coord;
        }
        if (coord != prev)
        {
            no++;
            sum = sum + (coordInitial.x - coord.x) * (coordInitial.x - coord.x) + (coordInitial.y - coord.y) * (coordInitial.y - coord.y);
            prev = coord;
        }

        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        if(Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction);
        }
    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
        coord = player.position;

    }
}
