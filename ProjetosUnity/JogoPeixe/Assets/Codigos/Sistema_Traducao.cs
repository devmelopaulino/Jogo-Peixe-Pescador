using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Sistema_Traducao : MonoBehaviour
{
    [SerializeField] public Lingua escolha;
    private static GameObject instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }  
}
public enum Lingua
{
    PtBr,
    Eng
}
