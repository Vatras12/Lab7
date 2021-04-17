using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //[SerializeField] private Button _button;

    //private void Start()
    //{
    //    _button.onClick.AddListener(() => LoadScene(1));
    //}

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
   
    public void ExitGame() {
        Application.Quit();
    }
}
