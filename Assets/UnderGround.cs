using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderGround : MonoBehaviour
{
    [SerializeField] private SwitchBlock block;
    [SerializeField] private PointChange pointchange;
    [SerializeField] private Vector3 prePos;

    public int countBlock;
    public int countFloor;


    [SerializeField] float checkTime;
    [SerializeField] float upSpeed;
    [SerializeField] float posUpTime;

    private void Start()
    {
        countFloor = 1;
        pointchange.PointSpriteChange();
    }
    public void GroundSet()
    {
        if (countBlock >= 16)
        {
            countBlock = 0;
            StartCoroutine(CoUpGround());
        }
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
        Debug.Log("1");
        block.BlockSet();
        DownGround();
        countFloor++;
        pointchange.PointSpriteChange();
    }

    public void DownGround()
    {
        gameObject.transform.position = prePos;
        Debug.Log("2");
    }


}

