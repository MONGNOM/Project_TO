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
            Debug.Log("블록터치 됨");
            switchblock.SwapStart();
            touchPossible = false;
            gameObject.SetActive(false);
            
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
       /* if (touchPossible)
        {
            Debug.Log("블록터치 됨");
            switchblock.SwapStart();
            gameObject.SetActive(false);
        }*/

        //switchblock.PosChange();
        //gameObject.transform.position = preLocation;
        // 사라질떄 원래 위치 가지고있어야하는거아니낙 switch block에서 위치이동 구현 함수 가져오기
        //다음블록 올라올 타이밍 switch block에서 random 뽑기 및 다른거 가져오기

        //bool 값 줘서 피버면 true ==> 드래그로 지울 수 있음
        // 원래는 전체블록에 꺼주는 식으로 진행할려했찌만 메모리 부담에 추가및 삭제를 무한 반복시키는 작업이고 전체를 올리면서 삭제시키는 것에대한 어려움이 존재 맨 위층만을 터치시 오브젝트를 끄는식으로 변경 하고 밑에는 위로 올려주는 모션만 진행한 후 다음 층 진행시 꺼져있던 블록을 다시 켜주고 밑에 블록은 다시 밑으로 내린다. 
    }
}
