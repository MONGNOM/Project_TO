using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchBlock : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public bool touchPossible;
    [SerializeField] int countNumber;
    [SerializeField] SwitchBlock switchblock;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (touchPossible)
        {
            Debug.Log("�����ġ ��");
            switchblock.SwapStart();
            touchPossible = false;
            gameObject.SetActive(false);
            
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
       /* if (touchPossible)
        {
            Debug.Log("�����ġ ��");
            switchblock.SwapStart();
            gameObject.SetActive(false);
        }*/

        //switchblock.PosChange();
        //gameObject.transform.position = preLocation;
        // ������� ���� ��ġ �������־���ϴ°žƴϳ� switch block���� ��ġ�̵� ���� �Լ� ��������
        //������� �ö�� Ÿ�̹� switch block���� random �̱� �� �ٸ��� ��������

        //bool �� �༭ �ǹ��� true ==> �巡�׷� ���� �� ����
        // ������ ��ü��Ͽ� ���ִ� ������ �����ҷ���� �޸� �δ㿡 �߰��� ������ ���� �ݺ���Ű�� �۾��̰� ��ü�� �ø��鼭 ������Ű�� �Ϳ����� ������� ���� �� �������� ��ġ�� ������Ʈ�� ���½����� ���� �ϰ� �ؿ��� ���� �÷��ִ� ��Ǹ� ������ �� ���� �� ����� �����ִ� ����� �ٽ� ���ְ� �ؿ� ����� �ٽ� ������ ������. 
    }
}
