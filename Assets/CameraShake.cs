using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void CameraFever()
    {
        ani.SetTrigger("Shake");
        ani.SetBool("Shaking", true);
        Debug.Log("Ω¶¿Ã≈© ©ê»˚");
    }

    public void EndShake()
    { 
        ani.SetBool("Shaking", false);
    }

    public void CameraGGang()
    {
        ani.SetTrigger("GGang");
    }
}


