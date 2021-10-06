using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pump8 : MonoBehaviour
{
    // default Pump8 button is off
    public Button p8;
    public Text txt;
    public static bool pump8_on = false;
    public static bool clicked = false;
    public static int flow8;

    void Start()
    {
        Button btn = p8.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    public void Click()
    {
        if (clicked == false)
        {
            clicked = true;
            pump8_on = true;
            Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
            GetComponent<Image>().color = newColorOn;
            flow8 = 400;            
        }
        else
        {
            clicked = false;
            pump8_on = false;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
            flow8 = 0;
        }
    }

    void Update()
    {
        txt.text = flow8.ToString();
        if (pump8_on == false)
        {
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }
    }
}
