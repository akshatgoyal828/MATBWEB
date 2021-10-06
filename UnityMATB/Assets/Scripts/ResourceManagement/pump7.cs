using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pump7 : MonoBehaviour
{
    // default Pump7 button is off
    public Button p7;
    public Text txt;
    public static bool pump7_on = false;
    public static bool clicked = false;
    public static int flow7;

    void Start()
    {
        Button btn = p7.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    public void Click()
    {
        if (clicked == false)
        {
            clicked = true;
            pump7_on = true;
            Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
            GetComponent<Image>().color = newColorOn;
            flow7 = 400;
        }
        else
        {
            clicked = false;
            pump7_on = false;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
            flow7 = 0;
        }
    }

    void Update()
    {
        txt.text = flow7.ToString();
        if (pump7_on == false)
        {
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }
    }
}
