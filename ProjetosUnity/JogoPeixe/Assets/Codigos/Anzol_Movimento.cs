using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anzol_Movimento : MonoBehaviour
{
    [Header("Rigidbody2D")]
    [SerializeField] private Rigidbody2D corpo;

    [Header("Seta para esquerda pressionada")]
    [SerializeField] private bool botao_esquerda;
    [Header("Seta para direita pressionada")]
    [SerializeField] private bool botao_direita;

    [Header("Pode forçar")]
    [SerializeField] private bool pode_forcar;

    [Header("Força do anzol")]
    [SerializeField] public float forca;

    private void Update()
    {
        DetectarBotao();
        StartCoroutine(Movimentar());
    }
    private IEnumerator Movimentar()
    {       
        if (botao_direita && pode_forcar)
        {
            pode_forcar = false;
            corpo.AddForce(Vector2.right * forca * 1000);
            corpo.AddForce(Vector2.up * forca / 1.5f * 1000);
            yield return new WaitForSeconds(0.2f);
            corpo.velocity = Vector2.zero;
            pode_forcar = true;
        }
        if (botao_esquerda && pode_forcar)
        {
            pode_forcar = false;
            corpo.AddForce(Vector2.left * forca * 1000);
            corpo.AddForce(Vector2.up  * forca / 1.5f * 1000);
            yield return new WaitForSeconds(0.2f);
            corpo.velocity = Vector2.zero;
            pode_forcar = true;
        }
    } 
    private void DetectarBotao()
    {
        botao_direita = Input.GetKeyDown(KeyCode.E);
        botao_esquerda = Input.GetKeyDown(KeyCode.Q);
    }
}
