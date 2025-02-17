using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDonw : MonoBehaviour
{
    [SerializeField] private float donwTime;
    [SerializeField] private float downHeight;

    void Start()
    {
        StartCoroutine(DownBlock());
    }


    IEnumerator DownBlock()
    {
        float pos = gameObject.transform.position.y;
        
        while (pos > 4)
        {
            Debug.Log("DownBlock++");
            gameObject.transform.position = new Vector2(0, pos -= downHeight);
            yield return new WaitForSeconds(donwTime);
        }

        // 게임종료 함수;
    }



}
