using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class Sword : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public TouchScreen touchScreen;
    public CameraShake cameraShake;
    public float gage;
    public float fevertime;
    public bool fever;
    public GameObject fire;
    public GameObject fire1;
    public GameObject hammerfire2;
    public GameObject hammerbody;
    public DamageText damage;

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
            fever = true;
            fire.SetActive(true);
            fire1.SetActive(true);
            hammerfire2.SetActive(true);
            hammerbody.SetActive(true);
            gage = 0f;
            cameraShake.CameraFever();
            Debug.Log("fever");
            
        }
        else
        {
            gage += 0.01f;
            Debug.Log("Basic");
        }

        if (fever)
        {
            damage.FeverGaugeText(1);
            touchScreen.PointUp(2);
          
        }
        else
        {
            damage.GaugeText(1);
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
                gage = 0f;
                fever = false;
                fevertime = 0f;
                fire.SetActive(false);
                fire1.SetActive(false);
                hammerfire2.SetActive(false);
                hammerbody.SetActive(false);
                cameraShake.EndShake();

            }
        }
    }

}
