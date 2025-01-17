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

    public SwordFire swordfire;
    public GameObject fire;
    public GameObject fire1;
    public GameObject hammerfire2;
    public GameObject hammerbody;
    public DamageText damage;

    private void Awake()
    {
        swordfire = GetComponentInChildren<SwordFire>();
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
            swordfire.ani.SetBool("Fire", true);
            swordfire.sprite.color = Color.white;
            fire1.SetActive(true);
            hammerfire2.SetActive(true);
            hammerbody.SetActive(true);
            gage = 0f;
            cameraShake.CameraFever();
            Debug.Log("fever");
            
        }
        else
        {
            Debug.Log("Basic");
        }

        if (fever)
        {
            gage += 0.02f;
            damage.FeverGaugeText(2);
            touchScreen.PointUp(2);
          
        }
        else
        {
            gage += 0.01f;
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
            if (fevertime >= 3)
            {
                fever = false;
                fevertime = 0f;
                swordfire.sprite.color = new Color(1, 1, 1, 0);
                fire1.SetActive(false);
                hammerfire2.SetActive(false);
                hammerbody.SetActive(false);
                cameraShake.EndShake();
                swordfire.ani.SetBool("Fire", false);

            }
        }
    }

}
