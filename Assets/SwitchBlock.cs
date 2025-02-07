using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchBlock : MonoBehaviour
{
    [Header("올라가는데 걸리는 시간")]
    [SerializeField] float posUpTime;

    [Header("올라오는 최대 시간")]
    [SerializeField] float checkTime;

    [Header("올라오는 속도 조절")]
    [SerializeField] float upSpeed;

    [SerializeField] int countNumber;
    

    [SerializeField] TouchBlock[] blocks;

    [SerializeField] private List<int> numbers = new List<int>();
 

    void Start()
    {
        ResetNumbers();
        numbers.Remove(numbers[13]);
        
    }

    public int GetNextNumber()
    {
        int randomNumber;

        do
        {
            randomNumber = Random.Range(0, 16); // 0~15 사이의 랜덤 숫자 선택
            Debug.Log(randomNumber);
        }
        while (!numbers.Contains(randomNumber)); // 리스트에 없는 숫자라면 다시 뽑기

        numbers.Remove(randomNumber); // 리스트에서 제거

        // 리스트가 비었다면 다시 초기화
        if (numbers.Count == 0)
        {
            ResetNumbers();
        }

        return randomNumber;
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
        Vector3 preLocation = blocks[countNumber].transform.position; //예전 위치 저장
        Vector3 targetLocation = preLocation + Vector3.up;            //이동 해야할 위치 저장
        
        posUpTime = 0;

        while (posUpTime < checkTime)
        {
            posUpTime += Time.deltaTime / upSpeed;
            blocks[countNumber].transform.position = Vector3.Lerp(preLocation, targetLocation, posUpTime);
            yield return null;
        }
        blocks[countNumber].transform.position = targetLocation;

    }

// Start is called before the first frame update
public void SwapStart()
    {
        countNumber = GetNextNumber();
        StartCoroutine(MoveUp());
         blocks[countNumber].touchPossible = true;

        // 사라질때 원래 위치로 가야함
    }

    public void PosChange()
    {
        //blocks[countNumber].transform.position = preLocation;
        Debug.Log("후 위치" + blocks[countNumber].transform.position);
    }

}

