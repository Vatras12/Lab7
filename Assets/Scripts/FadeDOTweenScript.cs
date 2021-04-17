using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeDOTweenScript : MonoBehaviour
{

    public void Start() {
        FadeCircle();
    }
    public void FadeCircle()
    {
            FadeOut(2f);
            FadeIn(2f); 
    }

    public void FadeIn(float duration) {
        Fade(0,1,duration);
    }
    public void FadeOut(float duration)
    {
        Fade(1, 0, duration);
    }

    public void Fade(float startOpacity, float endOpacity, float duration) {
        Graphic graphic = gameObject.GetComponent<Graphic>();
      
            var startColor = graphic.color;
            startColor.a = startOpacity;
            graphic.color = startColor;

            var endColor = graphic.color;
            endColor.a = endOpacity;
            graphic.DOColor(endColor,duration);

    }
}
