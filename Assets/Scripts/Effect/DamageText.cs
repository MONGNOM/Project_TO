using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public float speed;
    public float destoryTime;
    public TextMeshProUGUI[] damagetext;
    private int random;
    
    public void TextUp()
    {
        for (int i = 0; i < damagetext.Length; i++)
        {
            damagetext[i].gameObject.SetActive(false);
        }

        random = Random.Range(0, damagetext.Length);
        damagetext[random].gameObject.SetActive(true);

    }


    void Update()
    {
        destoryTime += Time.deltaTime;
        if (destoryTime >= 0.3f)
        {
            destoryTime = 0;
            Destroy(gameObject);
        }
    }


}
