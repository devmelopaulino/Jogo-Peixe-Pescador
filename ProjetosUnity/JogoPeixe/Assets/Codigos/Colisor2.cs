using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisor2 : MonoBehaviour
{
    [SerializeField] private Objeto objeto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //objeto.Destruir();
    }
}
