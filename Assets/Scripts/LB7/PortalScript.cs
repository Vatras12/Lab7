using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;


public class PortalScript : MonoBehaviour
{
    GameObject hero;
    FadeDOTweenScript fade;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hero = GameObject.FindGameObjectWithTag("Player");
            fade = hero.GetComponent<FadeDOTweenScript>();
            if (PlayerPrefs.GetInt("CRYSTALS_AMOUNT") == 3) {
               
                //LR7 Analytics, counter of victories
                AnalyticsResult result =  Analytics.CustomEvent("Victory");
                Debug.Log("Result " + result);

                PlayerPrefs.SetInt("CRYSTALS_AMOUNT", 0);
                SceneManager.LoadScene(0);
                
            }
        }
    }
}
