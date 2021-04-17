using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text text;
    JSONController json = new JSONController();
    void Start()
    {
        json.LoadField();
        text.text = json.item.Name;
    }
}
