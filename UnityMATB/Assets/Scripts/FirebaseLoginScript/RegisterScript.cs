using System;
using LitJson;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Register
{
    public string first_name;
    public string last_name;
    public string email;
    public string password;
    public string mobile_number;
}

public class Login
{
    public string email;
    public string password;
}

public class RegisterData
{
}

public class RegisterRoot
{
    public int status;
    public string message;
    public RegisterData data;
}

public class LData
{
    public string _id;
    public string first_name;
    public string last_name;
    public string email;
    public string password;
    public string mobile_number;
}

public class LoginRoot
{
    public int status;
    public string message;
    public LData data;
}

public class RegisterScript : MonoBehaviour
{

    [Header("Registration Data")]

    public InputField firstName;
    public InputField lastName;
    public InputField email;
    public InputField passowrdText;
    public InputField mobileNumber;

    [Header("Login Data")]

    public InputField emailID;
    public InputField passwordT;

    string register_URL;
    string login_URL;

    public Text errorMsg;
    [Header("GameObject Data")]

    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject errorPanel;
    public Canvas canvas;

    private void Start()
    {
        if (PlayerPrefs.GetString("Login") == "1")
        {
            canvas.enabled = false;
        }
        else {
            canvas.enabled = true;
        }
    }
    public void OnRegisterBtnClick()
    {
        if (string.IsNullOrEmpty(firstName.text))
        {
            errorPanel.SetActive(true);
            errorMsg.text = "First Name Can't be Blank";
            StopCoroutine(ErrorClose());
            StartCoroutine(ErrorClose());
            return;
        }
        if (string.IsNullOrEmpty(lastName.text))
        {
            errorPanel.SetActive(true);
            errorMsg.text = "Last Name Can't be Blank";
            StopCoroutine(ErrorClose());
            StartCoroutine(ErrorClose());
            return;
        }
        if (string.IsNullOrEmpty(email.text))
        {
            errorPanel.SetActive(true);
            errorMsg.text = "Email Can't be Blank";
            StopCoroutine(ErrorClose());
            StartCoroutine(ErrorClose());
            return;
        }
        if (string.IsNullOrEmpty(passowrdText.text))
        {
            errorPanel.SetActive(true);
            errorMsg.text = "Password Can't be Blank";
            StopCoroutine(ErrorClose());
            StartCoroutine(ErrorClose());
            return;
        }
        if (string.IsNullOrEmpty(mobileNumber.text))
        {
            errorPanel.SetActive(true);
            errorMsg.text = "Mobile Number Can't be Blank";
            StopCoroutine(ErrorClose());
            StartCoroutine(ErrorClose());
            return;
        }
        StartCoroutine(RegisterData());
    }
    IEnumerator RegisterData()
    {
        Register register = new Register();
        register.first_name = firstName.text;
        register.last_name = lastName.text;
        register.email = email.text;
        register.password = passowrdText.text;
        register.mobile_number = mobileNumber.text;
        Debug.Log("Name" + firstName.text);
        Debug.Log("Last" + lastName.text);
        Debug.Log("email" + email.text);
        Debug.Log("pass" + passowrdText.text);
        Debug.Log("mobile" + mobileNumber.text);
        String jsonvale = JsonMapper.ToJson(register);
        register_URL = "http://34.209.9.154:2021/v1/auth/fcmRegister";
        using (UnityWebRequest webRequest = new UnityWebRequest(register_URL, "POST"))
        {
            Debug.Log(register_URL);
            byte[] encodedPayload = new System.Text.UTF8Encoding().GetBytes(jsonvale);
            webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(encodedPayload);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();
            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.Log("Weberror" + webRequest.downloadHandler.text);
                Debug.Log(webRequest.error);
                errorPanel.SetActive(true);
                errorMsg.text = webRequest.downloadHandler.text;
                StopCoroutine(ErrorClose());
                StartCoroutine(ErrorClose());
                //Open Error Menu
                //RetryPannel.SetActive(true);
                //LoadingObjectMainPage.SetActive(false);
                //Retry.onClick.RemoveAllListeners();
                //Retry.onClick.AddListener(APIManager.instance.DeactivateRetryPanel);
            }
            else
            {
                Debug.Log("Register" + webRequest.downloadHandler.text);
                string msg = webRequest.downloadHandler.text;
                var token = JsonUtility.FromJson<RegisterRoot>(msg);
                int status = token.status;
                string messgae = token.message;
                //Debug.Log(token.message);
                if (status == 200)
                {
                    registerPanel.SetActive(false);
                    loginPanel.SetActive(true);
                }
                else if (status == 422)
                {
                    errorPanel.SetActive(true);
                    errorMsg.text = messgae;
                    StopCoroutine(ErrorClose());
                    StartCoroutine(ErrorClose());
                }
            }
        }
    }
    public void OnLoginBtnClick()
    {
        if (string.IsNullOrEmpty(emailID.text))
        {
            errorPanel.SetActive(true);
            errorMsg.text = "Email ID Can't be Blank";
            StopCoroutine(ErrorClose());
            StartCoroutine(ErrorClose());
            return;
        }
        if (string.IsNullOrEmpty(passwordT.text))
        {
            errorPanel.SetActive(true);
            errorMsg.text = "Password Can't be Blank";
            StopCoroutine(ErrorClose());
            StartCoroutine(ErrorClose());
            return;
        }
        StartCoroutine(LoginData());
    }
    IEnumerator LoginData()
    {
        Login login = new Login();
        login.email = emailID.text;
        login.password = passwordT.text;
        String jsonvale = JsonMapper.ToJson(login);
        login_URL = "http://34.209.9.154:2021/v1/auth/fcmLogin";
        using (UnityWebRequest webRequest = new UnityWebRequest(login_URL, "POST"))
        {
            Debug.Log(login_URL);
            byte[] encodedPayload = new System.Text.UTF8Encoding().GetBytes(jsonvale);
            webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(encodedPayload);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();
            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.Log("Weberror" + webRequest.downloadHandler.text);
                Debug.Log(webRequest.error);
                errorPanel.SetActive(true);
                errorMsg.text = webRequest.downloadHandler.text;
                StopCoroutine(ErrorClose());
                StartCoroutine(ErrorClose());
                //Open Error Menu
                //RetryPannel.SetActive(true);
                //LoadingObjectMainPage.SetActive(false);
                //Retry.onClick.RemoveAllListeners();
                //Retry.onClick.AddListener(APIManager.instance.DeactivateRetryPanel);
            }
            else
            {
                Debug.Log("Login" + webRequest.downloadHandler.text);
                string msg = webRequest.downloadHandler.text;
                var token = JsonUtility.FromJson<LoginRoot>(msg);
                int status = token.status;
                string messgae = token.message;

                if (status == 200)
                {
                    loginPanel.SetActive(false);
                    canvas.enabled = false;
                    PlayerPrefs.SetString("Login", "1");
                }
                else if (status == 422)
                {
                    errorPanel.SetActive(true);
                    errorMsg.text = messgae;
                    StopCoroutine(ErrorClose());
                    StartCoroutine(ErrorClose());
                }
            }
        }
    }
    IEnumerator ErrorClose()
    {
        yield return new WaitForSeconds(2.9f);
        errorPanel.SetActive(false);
        errorMsg.text = "";
        yield return null;
    }
}
