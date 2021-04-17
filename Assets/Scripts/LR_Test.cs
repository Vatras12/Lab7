using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LR_Test : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    LineRenderer lineRenderer;
    public int value;
    public Button button;
   
    public void DrawLine() {
        lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        value = RandomPickPoint(); 
        button.enabled = false; 
    }

    public void Update()
    {
        if (lineRenderer != null && points[value]!= null) {
            lineRenderer.SetPosition(0,points[0].position);
            lineRenderer.SetPosition(1,points[value].position);
        }
        if (points[value] == null)
        {
            lineRenderer.enabled = false;
        }
    }

    public int RandomPickPoint() {
        if (points[1] == null) { return Random.Range(2, 3); }
        else if (points[3] == null) { return Random.Range(1, 2); }
        else if (points[2] == null) { return 1; }
        else { return Random.Range(1, 3);}
    }

}
