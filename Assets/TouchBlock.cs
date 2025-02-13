using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchBlock : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public bool touchPossible;
    public bool fever;
    [SerializeField] int countNumber;
    [SerializeField] SwitchBlock switchblock;
    [SerializeField] UnderGround underblock;
    [SerializeField] Vector3 prePos;
    [SerializeField] DamageText damageText;
    [SerializeField] GameObject textPrab;
    [SerializeField] Gauge gauge;
    [SerializeField] new  CameraShake camera;

    public Canvas canve;

    private void Start()
    {
        prePos = transform.position;
        fever = false;
        gauge = FindAnyObjectByType<Gauge>();
        camera = FindAnyObjectByType<CameraShake>();
        underblock = FindAnyObjectByType<UnderGround>();
    }




    public void OnPointerClick(PointerEventData eventData)
    {
        if (touchPossible)                          // 블록 터치 후 상황
        {   
            switchblock.SwapStart();                // 랜덤 번호 뽑기 후 벽돌 올리기
            gauge.AddGauge();
            damageText.TextUp();                    // 랜덤 텍스트 뽑기
            Instantiate(textPrab, transform.position, Quaternion.identity, canve.transform); // 텍스트 생성

            touchPossible = false;
            gameObject.SetActive(false);
            gameObject.transform.position = prePos; // 블록 원위치
            underblock.GroundSet();                 // 이거 옮기고 switch로 바꿔서 해야할듯
        }
    }
    private void Update()
    {
        if (gauge.imageFillAmount.fillAmount >= 1)
        {
            fever = true;
            camera.basic = false;
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gauge.feverTime >= gauge.delayTime)
        {
           
            gauge.feverTime = 0f;
            gauge.imageFillAmount.fillAmount = 0;
            fever = false;
            camera.basic = true;
        }

        if (fever)
        {
            camera.BackGroundColor();
            underblock.countBlock++;
            gameObject.SetActive(false);
            underblock.GroundSet();                 // 이거 옮기고 switch로 바꿔서 해야할듯
            Debug.Log("블록터치 됨");
        }

        //switchblock.PosChange();
        //gameObject.transform.position = preLocation;
        // 사라질떄 원래 위치 가지고있어야하는거아니낙 switch block에서 위치이동 구현 함수 가져오기
        //다음블록 올라올 타이밍 switch block에서 random 뽑기 및 다른거 가져오기

        //bool 값 줘서 피버면 true ==> 드래그로 지울 수 있음
        // 원래는 전체블록에 꺼주는 식으로 진행할려했찌만 메모리 부담에 추가및 삭제를 무한 반복시키는 작업이고 전체를 올리면서 삭제시키는 것에대한 어려움이 존재 맨 위층만을 터치시 오브젝트를 끄는식으로 변경 하고 밑에는 위로 올려주는 모션만 진행한 후 다음 층 진행시 꺼져있던 블록을 다시 켜주고 밑에 블록은 다시 밑으로 내린다. 
    }
}
