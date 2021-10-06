using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class LoginScript : MonoBehaviour
{

    [Header("===Login Attribute===")]

    public InputField logininputField;
    public Text loginerrorText;
    public GameObject loginErrorPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnSubmitBtnClick()
    {
        if (string.IsNullOrEmpty(logininputField.text))
        {
            loginerrorText.text = "UserName is not empty";
            StopCoroutine(ErrorClose());
            StartCoroutine(ErrorClose());
            loginErrorPanel.SetActive(true);
            return;
        }
    }



    IEnumerator ErrorClose()
    {
        yield return new WaitForSeconds(2f);
        loginerrorText.text = "";
        loginErrorPanel.SetActive(false);
        
        yield return null;
    }
}
