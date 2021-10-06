using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pump4 : MonoBehaviour
{
    // default Pump4 button is off
    public Button p4;
    public Text txt;
    public static bool pump4_on = false;
    public static bool clicked = false;
    public static int flow4;
    
    void Start()
    {
        Button btn = p4.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    public void Click()
    {
        if (clicked == false)
        {
            clicked = true;
            pump4_on = true;
            Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
            GetComponent<Image>().color = newColorOn;
            flow4 = 600;
        }
        else
        {
            clicked = false;
            pump4_on = false;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
            flow4 = 0;
        }
    }

    void Update()
    {
        txt.text = flow4.ToString();
        if (pump4_on == false)
        {
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }
    }
}
