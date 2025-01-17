using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointChange : MonoBehaviour
{
    [SerializeField] private Sprite[] pointSprites;

    public void PointSpriteChange()
    {
        Debug.Log("imageChange");
    }
}
