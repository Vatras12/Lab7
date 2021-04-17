using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalCounter : MonoBehaviour
{
    public Text text;

    [SerializeField] private string saveCrystalKey = "CRYSTALS_AMOUNT";

    void Start()
    {
        PlayerPrefs.SetInt(saveCrystalKey, 0);
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("CRYSTALS_AMOUNT")>0)
        {
            text.text = PlayerPrefs.GetInt("CRYSTALS_AMOUNT") + "/3";
        }
    }
}
