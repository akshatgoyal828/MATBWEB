using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pump1 : MonoBehaviour
{
    // default Pump1 button is off
    public Button p1;
    public Text txt;
    public static bool pump1_on = false;
    public static bool clicked = false;
    public static int flow1;

    void Start()
    {
        Button btn = p1.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    // Update is called once per frame
    public void Click()
    {
        if (clicked == false)
        {
            clicked = true;
            pump1_on = true;
            Color newColorOn = new Color(0.6313726f, 0.9921569f, 0.3803922f, 1f);
            GetComponent<Image>().color = newColorOn;
            flow1 = 800;
        }
        else
        {
            clicked = false;
            pump1_on = false;
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
            flow1 = 0;
        }
    }

    void Update()
    {
        txt.text = flow1.ToString();
        if (pump1_on == false)
        {
            Color newColorOff = new Color(0.7843138f, 0.7843138f, 0.7843138f, 1f);
            GetComponent<Image>().color = newColorOff;
        }
    }
}
