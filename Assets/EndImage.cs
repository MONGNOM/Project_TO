using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndImage : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void EndGame()
    { 
        gameObject.SetActive(true);
    }
}
