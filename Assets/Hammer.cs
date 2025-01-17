using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    Animator ani;
    [SerializeField]
    private Sword sword;
    public CameraShake cameraShake;
    public ParticleSystem particleFire;
    public ParticleSystem feverparticleFire;
    public GameObject text;
    public Canvas canvas;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void TouchScreen()
    {
        ani.SetTrigger("GGang");
        cameraShake.CameraGGang();
        Debug.Log("123");
    }

/*    public void Fire()
    {
        Instantiate(text, canvas.transform);
        if (sword.fever)
        {
            feverparticleFire.Play();
            return;
        }

        particleFire.Play();

    }*/
}
