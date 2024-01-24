using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos_Movimentacao : MonoBehaviour
{
    [Header("Rigidbody2D")]
    [SerializeField] private Rigidbody2D corpo;

    [Header("Velocidade de movimento")]
    [SerializeField] private float velociadade;

    [Header("Para qual direção")]
    [SerializeField] private Direcao direcao;

    private void FixedUpdate()
    {
        Movimentar();
    }

    private void Movimentar()
    {
        if(direcao == Direcao.Direta)
        {
            Debug.Log("oi");
        }

        corpo.velocity = new Vector2 (velociadade , 0);
    }


}
public enum Direcao
{
    Esquerda,
    Direta
}
