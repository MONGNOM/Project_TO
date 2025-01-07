using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Sword : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float gage;
    public TouchScreen touchScreen;
    public float fevertime;
    public bool fever;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
    }
    
    public void ChargeGage()
    {
        if (gage >= 1)
        {
            gage = 0f;
            fever = true;
            Debug.Log("fever");
        }
        else
        {
            gage += 0.01f;
            Debug.Log("Basic");
        }

        if (fever)
        {
            touchScreen.PointUp(2);
        }
        else
        { 
            touchScreen.PointUp(1);
        }



        touchScreen.TextPoint();
        spriteRenderer.color = new Color(1, 1, 1, gage);
    }
    private void Update()
    {
        if (fever)
        {
            fevertime += Time.deltaTime;
            if (fevertime >= 5)
            { 
                fever = false;
                fevertime = 0f;
            }
        }
    }

}
