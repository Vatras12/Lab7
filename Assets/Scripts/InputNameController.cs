using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputNameController : MonoBehaviour
{
    [SerializeField] private InputField InputField1;

    /*[Header("Keys")]
    [SerializeField] private string saveNameKey = "NAME_VALUE";
    [SerializeField] private string playerName;*/
    JSONController json = new JSONController();
    public void SaveName() {
        if (InputField1.text != "") {
            json.item.Name = InputField1.text;
            json.SaveField();
            //playerName = InputField1.text;
            //PlayerPrefs.SetString(saveNameKey, playerName);
        }
    }

    
    
}
