using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetName : MonoBehaviour
{
    public Text text;
    private JSONController json;
    void Start()
    {
        json = new JSONController();
        json.LoadField();
        if (json.item.loggedIn == "true")
        {
            text.text = PlayerPrefs.GetString("USERNAME");
        }
    }

}
