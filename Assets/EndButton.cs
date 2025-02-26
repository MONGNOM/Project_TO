using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    public void Exit()
    {
        SceneChanger.instance.SceneChange("Main");
    }

    public void Retry()
    {
        SceneChanger.instance.SceneChange("Floor");
    }
}
