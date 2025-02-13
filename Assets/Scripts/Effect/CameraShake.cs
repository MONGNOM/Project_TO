    using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraShake : MonoBehaviour
{
    public Animator ani;
    public bool basic;

    new Camera camera;

    private void Start()
    {
        basic = true;
        camera = GetComponent<Camera>();
        BackGroundColor();
    }


    public void BackGroundColor()
    {
        if (!basic)
        {
            camera.backgroundColor = new Color(0.3411765f, 0.1098039f, 0.8039216f, 0);
            return;
        }

        camera.backgroundColor = new Color(0.1647059f, 0.1647059f, 0.1843137f, 0);
    }

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


