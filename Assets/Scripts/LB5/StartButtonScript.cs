using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    JSONController json;

    private void OnStart() {
      
    }
    public void OnClick() {
        json = new JSONController();
        json.LoadField();
        if (json.item.loggedIn == "true") {
            SceneManager.LoadScene(3);
        }
        else {
            SceneManager.LoadScene(2);
        }
    }
}
