using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class SwitchBlock : MonoBehaviour
{
    [Header("올라가는데 걸리는 시간")]
    [SerializeField] float posUpTime;

    [Header("올라오는 최대 시간")]
    [SerializeField] float checkTime;

    [Header("올라오는 속도 조절")]
    [SerializeField] float upSpeed;

    [Header("블록 클릭 갯수")]
    [SerializeField] int countNumber;

    

    [SerializeField] TouchBlock[] blocks;

    [SerializeField] private List<int> numbers = new List<int>();
    [SerializeField] private Vector3 preLocation;
    [SerializeField] private UnderGround underground;
  

    public int randomNumber;


    void Start()
    {
        ResetNumbers();
        numbers.Remove(numbers[13]);
        Debug.Log(blocks.Length);
    }

    public void GetNextNumber()
    {
        // 리스트가 비었다면 다시 초기화
        if (numbers.Count == 0)
        {
            ResetNumbers();
        }
        
        randomNumber = Random.Range(0, 16); // 0~15 사이의 랜덤 숫자 선택
        Debug.Log(randomNumber);
        while (!numbers.Contains(randomNumber)) // 리스트에 없는 숫자라면 다시 뽑기
        {
            randomNumber = Random.Range(0, 16);
        }

        numbers.Remove(randomNumber);
        underground.countBlock++;
    }

    public void BlockSet()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].gameObject.SetActive(true);
            Debug.Log("3");
        }
    }

    private void ResetNumbers()
    {
        numbers.Clear();
        for (int i = 0; i < 16; i++)
        {
            numbers.Add(i);
        }
    }


    IEnumerator MoveUp()
    {
        preLocation = blocks[randomNumber].transform.position;   //예전 위치 저장
        Vector3 targetLocation = preLocation + Vector3.up;      //이동 해야할 위치 저장
        
        posUpTime = 0;

        while (posUpTime < checkTime)
        {
            posUpTime += Time.deltaTime / upSpeed;
            blocks[randomNumber].transform.position = Vector3.Lerp(preLocation, targetLocation, posUpTime);
            yield return null;
        }
        blocks[randomNumber].transform.position = targetLocation;
        Debug.Log("MoveUp" + blocks[randomNumber].transform.position);
        Debug.Log("MoveUpPre" + preLocation);
    }

    public void SwapStart()
    {
        GetNextNumber();
        StartCoroutine(MoveUp());
        blocks[randomNumber].touchPossible = true;
    }

}

