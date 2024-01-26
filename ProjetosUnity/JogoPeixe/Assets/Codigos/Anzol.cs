using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anzol : MonoBehaviour
{
    [Header("Rigidbody2D")]
    [SerializeField] private Rigidbody2D corpo;

    [Header("Botão para esquerda")]
    [SerializeField] private KeyCode botao_para_esquerda;
    [Header("Botão para esquerda pressionada")]
    [SerializeField] private bool botao_esquerda;
    [Header("Botão para direita")]
    [SerializeField] private KeyCode botao_para_direita;
    [Header("Botão para direita pressionada")]
    [SerializeField] private bool botao_direita;
    [Header("Tempo de espera dos botões")]
    [SerializeField] private float tempo_espera;

    [Header("Força do anzol")]
    [SerializeField] private float forca;
    [Header("Fração da força para cima")]
    [SerializeField] private float fracao_forca_cima;
    [Header("Pode forçar")]
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
