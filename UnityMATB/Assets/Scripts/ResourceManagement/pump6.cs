using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pump6 : MonoBehaviour
{
    // default Pump6 button is off
    public Button p6;
    public Text txt;
    public static bool pump6_on = false;
    public static bool clicked = false;
    public static int flow6;

    void Start()
    {
        Button btn = p6.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    public void Click()
    {
        if (clicked == false)
        {
            clicked = true;
            pump6_on = true;
            Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
            GetComponent<Image>().color = newColorOn;
            flow6 = 600;
        }
        else
        {
            clicked = false;
            pump6_on = false;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
            flow6 = 0;
        }
    }

    void Update()
    {
        txt.text = flow6.ToString();
        if (pump6_on == false)
        {
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }
    }
}
