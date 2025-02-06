using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchBlock : MonoBehaviour
{

    [SerializeField] int countNumber;

    [SerializeField] TouchBlock[] blocks;
    // [SerializeField] List<int> numberList = new List<int>();

    [SerializeField] private List<int> numbers = new List<int>();
    [SerializeField] Vector3 preLocation;

    private void Awake()
    {
        preLocation = new Vector3(0, 0, 0);
        //numberList.Clear();
    }

    void Start()
    {
        ResetNumbers();
    }

    public int GetNextNumber()
    {
        int randomNumber;

        do
        {
            randomNumber = Random.Range(0, 16); // 0~15 ������ ���� ���� ����
            Debug.Log(randomNumber);
        }
        while (!numbers.Contains(randomNumber)); // ����Ʈ�� ���� ���ڶ�� �ٽ� �̱�

        numbers.Remove(randomNumber); // ����Ʈ���� ����

        // ����Ʈ�� ����ٸ� �ٽ� �ʱ�ȭ
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


// Start is called before the first frame update
public void SwapStart()
    {
        /*  if (numberList.Count <= 0)
          {
              numberList.Clear();

              for (int i = 0; i < blocks.Length; i++)
              {
                  numberList.Add(i);
              }
          }*/

        /* countNumber = Random.Range(0, usedNumbers.Count);
         Debug.Log("�̱�");
         if (usedNumbers.Contains(countNumber))
         {
             Debug.Log(usedNumbers[countNumber]);
             usedNumbers.Remove(countNumber);
         }*/


        countNumber = GetNextNumber(); 
        //Random.Range(0, blocks.Length -1);
         Debug.Log("for�� i:" + countNumber);


        preLocation = blocks[countNumber].transform.position;

        //���� ��ġ ������

        blocks[countNumber].transform.position = new Vector3(blocks[countNumber].transform.position.x, blocks[countNumber].transform.position.y + 1f, 0); //���� ��ġ�� �̵�

        blocks[countNumber].touchPossible = true;

        // ������� ���� ��ġ�� ������
    }

    public void PosChange()
    {
        blocks[countNumber].transform.position = preLocation;
        Debug.Log("�� ��ġ" + blocks[countNumber].transform.position);
    }

}

