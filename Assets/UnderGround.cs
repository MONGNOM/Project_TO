using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGround : MonoBehaviour
{
    [SerializeField] private Vector3 prePos;


    [SerializeField] float checkTime;
    [SerializeField] float upSpeed;
    [SerializeField] float posUpTime;
    public void UpGround()
    {
        StartCoroutine(CoUpGround());
    }

    IEnumerator CoUpGround()
    {
        posUpTime = 0;
        prePos = gameObject.transform.position;
        Vector3 targetPos = prePos + Vector3.up;

        while (posUpTime < checkTime)
        {
            posUpTime += Time.deltaTime / upSpeed;
            gameObject.transform.position = Vector3.Lerp(prePos, targetPos, posUpTime);
            yield return null;
        }
        gameObject.transform.position = targetPos;
    }

    public void DownGround()
    {
        gameObject.transform.position = prePos;
    }


}
