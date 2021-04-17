using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColladeCrystal : MonoBehaviour
{

    public GameObject gameObject;
    private int crystals;
    [SerializeField] private string saveCrystalKey = "CRYSTALS_AMOUNT";
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            if (PlayerPrefs.HasKey(saveCrystalKey))
            {
                crystals = PlayerPrefs.GetInt(saveCrystalKey)+1;
                PlayerPrefs.SetInt(saveCrystalKey,crystals);
            }
            else {
                PlayerPrefs.SetInt(saveCrystalKey,1);
            }
        }
    }
}
