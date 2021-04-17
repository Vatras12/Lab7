using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logout : MonoBehaviour
{
    public Text text;
    public Button button;
    JSONController json;

    public void OnClickLogout() {
        json = new JSONController();
        json.LoadField();
        json.item.loggedIn = "false";
        json.item.Name = "";
        json.SaveField();
        text.text = "None";
        PlayerPrefs.DeleteKey("EMAIL");
        PlayerPrefs.DeleteKey("PASSWORD");
    }
}
