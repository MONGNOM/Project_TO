using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    public void TouchScreen()
    {
        ani.SetTrigger("GGang");
        Debug.Log("123");
    }
}
