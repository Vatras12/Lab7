using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using UnityEngine.UI;

public class NameChange : MonoBehaviour
{
    public Text userName;
    string name = "default";
    public struct userAttributes { }
    public struct appAttributes { }
    void Awake()
    {
        ConfigManager.FetchCompleted += SetName;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void SetName(ConfigResponse response)
    {
        userName.text = ConfigManager.appConfig.GetString("name");
    }
    void OnDestroy()
    {
        ConfigManager.FetchCompleted += SetName;
    }
    
}
