using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager intstance;

    public GameObject btnGameOver;

    private void Awake()
    {
        UIManager.intstance= this;
        btnGameOver.SetActive(false);   
    }
}
