using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONController : MonoBehaviour
{
    public Item item;

    public string file = "JSON.txt";

    public void LoadField() {
        item = JsonUtility.FromJson<Item>(File.ReadAllText("Assets/StreamingAssets/JSON.json"));
       
    }

    public void SaveField()
    {
        File.WriteAllText(Application.streamingAssetsPath + "/JSON.json", JsonUtility.ToJson(item));
    }

    [System.Serializable]
    public class Item
    {
        public string Name;
        public string loggedIn;
    }
}

