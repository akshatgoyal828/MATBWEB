using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pump2 : MonoBehaviour
{
    // default Pump2 button is off
    public Button p2;
    public Text txt;
    public static bool pump2_on = false;
    public static bool clicked = false;
    public static int flow2;

    void Start()
    {
        Button btn = p2.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    public void Click()
    {
        if (clicked == false)
        {
            clicked = true;
            pump2_on = true;
            Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
            GetComponent<Image>().color = newColorOn;
            flow2 = 600;
        }
        else
        {
            clicked = false;
            pump2_on = false;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
            flow2 = 0;
        }
    }

    void Update()
    {
        txt.text = flow2.ToString();
        if (pump2_on == false)
        {
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }
    }
}
