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
        if (touchPossible)                          // ��� ��ġ �� ��Ȳ
        {   
            switchblock.SwapStart();                // ���� ��ȣ �̱� �� ���� �ø���
            gauge.AddGauge();
            damageText.TextUp();                    // ���� �ؽ�Ʈ �̱�
            Instantiate(textPrab, transform.position, Quaternion.identity, canve.transform); // �ؽ�Ʈ ����

            touchPossible = false;
            gameObject.SetActive(false);
            gameObject.transform.position = prePos; // ��� ����ġ
            underblock.GroundSet();                 // �̰� �ű�� switch�� �ٲ㼭 �ؾ��ҵ�
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
            underblock.GroundSet();                 // �̰� �ű�� switch�� �ٲ㼭 �ؾ��ҵ�
            Debug.Log("�����ġ ��");
        }

        //switchblock.PosChange();
        //gameObject.transform.position = preLocation;
        // ������� ���� ��ġ �������־���ϴ°žƴϳ� switch block���� ��ġ�̵� ���� �Լ� ��������
        //������� �ö�� Ÿ�̹� switch block���� random �̱� �� �ٸ��� ��������

        //bool �� �༭ �ǹ��� true ==> �巡�׷� ���� �� ����
        // ������ ��ü��Ͽ� ���ִ� ������ �����ҷ���� �޸� �δ㿡 �߰��� ������ ���� �ݺ���Ű�� �۾��̰� ��ü�� �ø��鼭 ������Ű�� �Ϳ����� ������� ���� �� �������� ��ġ�� ������Ʈ�� ���½����� ���� �ϰ� �ؿ��� ���� �÷��ִ� ��Ǹ� ������ �� ���� �� ����� �����ִ� ����� �ٽ� ���ְ� �ؿ� ����� �ٽ� ������ ������. 
    }
}
