using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pump3 : MonoBehaviour
{
    // default Pump3 button is off
    public Button p3;
    public Text txt;
    public static bool pump3_on = false;
    public static bool clicked = false;
    public static int flow3;

    void Start()
    {
        Button btn = p3.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    public void Click()
    {
        if (clicked == false)
        {
            clicked = true;
            pump3_on = true;
            Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
            GetComponent<Image>().color = newColorOn;
            flow3 = 800;
        }
        else
        {
            clicked = false;
            pump3_on = false;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
            flow3 = 0;
        }
    }

    void Update()
    {
        txt.text = flow3.ToString();
        if (pump3_on == false)
        {
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }
    }
}
