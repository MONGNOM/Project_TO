using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class SwitchBlock : MonoBehaviour
{
    [Header("�ö󰡴µ� �ɸ��� �ð�")]
    [SerializeField] float posUpTime;

    [Header("�ö���� �ִ� �ð�")]
    [SerializeField] float checkTime;

    [Header("�ö���� �ӵ� ����")]
    [SerializeField] float upSpeed;

    [Header("��� Ŭ�� ����")]
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
        // ����Ʈ�� ����ٸ� �ٽ� �ʱ�ȭ
        if (numbers.Count == 0)
        {
            ResetNumbers();
        }
        
        randomNumber = Random.Range(0, 16); // 0~15 ������ ���� ���� ����
        Debug.Log(randomNumber);
        while (!numbers.Contains(randomNumber)) // ����Ʈ�� ���� ���ڶ�� �ٽ� �̱�
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
        preLocation = blocks[randomNumber].transform.position;   //���� ��ġ ����
        Vector3 targetLocation = preLocation + Vector3.up;      //�̵� �ؾ��� ��ġ ����
        
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

