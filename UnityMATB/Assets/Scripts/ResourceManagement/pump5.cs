using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pump5 : MonoBehaviour
{
    // default Pump5 button is off
    public Button p5;
    public Text txt;
    public static bool pump5_on = false;
    public static bool clicked = false;
    public static int flow5;

    void Start()
    {
        Button btn = p5.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    public void Click()
    {
        if (clicked == false)
        {
            clicked = true;
            pump5_on = true;
            Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
            GetComponent<Image>().color = newColorOn;
            flow5 = 600;
        }
        else
        {
            clicked = false;
            pump5_on = false;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
            flow5 = 0;
        }
    }

    void Update()
    {
        txt.text = flow5.ToString();
        if (pump5_on == false)
        {
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }
    }
}
