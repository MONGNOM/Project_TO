using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);        
        }
    }

    public void GameOver()
    {
        SceneChanger.instance.SceneChange("End");
        Debug.Log("얼음!!!");
        // 랭킹씬으로 넘어가는 함수 구현
    }

    
}
