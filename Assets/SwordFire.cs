using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFire : MonoBehaviour
{
    public Animator ani;
    public SpriteRenderer sprite;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1, 0);

    }

}
