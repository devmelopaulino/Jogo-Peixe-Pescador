using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos_Movimentacao : MonoBehaviour
{
    [Header("Rigidbody2D")]
    [SerializeField] private Rigidbody2D corpo;

    [Header("Velocidade de movimento")]
    [SerializeField] private float velociadade;
    private int definidor_direcao;

    [Header("Para qual direção")]
    [SerializeField] private Direcao direcao;

    private void FixedUpdate()
    {
        Movimentar();
    }
    private void Start()
    {
        DefinirDirecao();
    }
    private void Movimentar()
    {
        corpo.velocity = new Vector2 (velociadade * definidor_direcao , 0) * Time.fixedDeltaTime * 100f;
    }
    private void DefinirDirecao()
    {
        if (direcao == Direcao.Direta)
        {
            definidor_direcao = 1;
        }
        if (direcao == Direcao.Esquerda)
        {
            definidor_direcao = -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
    }
}
public enum Direcao
{
    Esquerda,
    Direta
}
