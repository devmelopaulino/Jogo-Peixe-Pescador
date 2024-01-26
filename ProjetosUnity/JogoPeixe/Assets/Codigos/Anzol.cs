using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anzol : MonoBehaviour
{
    [Header("Rigidbody2D")]
    [SerializeField] private Rigidbody2D corpo;

    [Header("Bot�o para esquerda")]
    [SerializeField] private KeyCode botao_para_esquerda;
    [Header("Bot�o para esquerda pressionada")]
    [SerializeField] private bool botao_esquerda;
    [Header("Bot�o para direita")]
    [SerializeField] private KeyCode botao_para_direita;
    [Header("Bot�o para direita pressionada")]
    [SerializeField] private bool botao_direita;
    [Header("Tempo de espera dos bot�es")]
    [SerializeField] private float tempo_espera;

    [Header("For�a do anzol")]
    [SerializeField] private float forca;
    [Header("Fra��o da for�a para cima")]
    [SerializeField] private float fracao_forca_cima;
    [Header("Pode for�ar")]
    [SerializeField] private bool pode_forcar;

    private void Update()
    {
        DetectarBotao();
        StartCoroutine(Movimentar());
    }
    private IEnumerator Movimentar()
    {       
        if (botao_direita && pode_forcar)
        {
            corpo.velocity = Vector2.zero;
            pode_forcar = false;
            corpo.AddForce(1000 * forca * Vector2.right);
            corpo.AddForce(Vector2.up * forca / fracao_forca_cima * 1000);          
            yield return new WaitForSeconds(tempo_espera);
            pode_forcar = true;
        }
        if (botao_esquerda && pode_forcar)
        {
            corpo.velocity = Vector2.zero;
            pode_forcar = false;
            corpo.AddForce(1000 * forca * Vector2.left);
            corpo.AddForce(Vector2.up * forca / fracao_forca_cima * 1000);
            yield return new WaitForSeconds(tempo_espera);
            pode_forcar = true;
        }
    }  

    private void DetectarBotao()
    {
        botao_esquerda = Input.GetKeyDown(botao_para_esquerda);
        botao_direita = Input.GetKeyDown(botao_para_direita);
    }
}
