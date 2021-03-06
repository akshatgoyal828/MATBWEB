using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NAV1 : MonoBehaviour
{
    public Button lup;
    public Button ldown;
    public Button rup;
    public Button rdown;

    public Text txt;
    public static float value = 108.000f;

    void Start()
    {
        Button btnlup = lup.GetComponent<Button>();
        btnlup.onClick.AddListener(Clicklup);
        Button btnldown = ldown.GetComponent<Button>();
        btnldown.onClick.AddListener(Clickldown);

        Button btnrup = rup.GetComponent<Button>();
        btnrup.onClick.AddListener(Clickrup);
        Button btnrdown = rdown.GetComponent<Button>();
        btnrdown.onClick.AddListener(Clickrdown);

        txt.text = value.ToString();
    }

    void Update()
    {
        if (value >= 117.950f)
            value = 108.000f;
    }

    public void Clicklup()
    {
        value = value + 1f;
        txt.text = value.ToString();
    }

    public void Clickldown()
    {
        value = value - 1f;
        txt.text = value.ToString();
    }

    public void Clickrup()
    {
        value = value + 0.050f;
        txt.text = value.ToString();
    }

    public void Clickrdown()
    {
        value = value - 0.050f;
        txt.text = value.ToString();
    }
}

