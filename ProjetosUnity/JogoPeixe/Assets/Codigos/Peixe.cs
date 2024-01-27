using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peixe : MonoBehaviour
{
    [SerializeField] private float pontos;
    [SerializeField] public float vida;
    [SerializeField] private GameObject placar_evolucao;
    [SerializeField] private Botao_Evoluir botao_evoluir1;
    [SerializeField] private Botao_Evoluir botao_evoluir2;
    [SerializeField] private Botao_Evoluir botao_evoluir3;
    [SerializeField] public Linha linha;
    public void AumentarPontos(float qt_pontos)
    {
        pontos += qt_pontos;
        Evoluir();
    }
    public void DiminuirVida()
    {
        vida -= 1;
    }
    public void AumentarVida()
    {

    }
    public void Perder()
    {

    }
    public void Evoluir()
    {
        if (pontos - 500 >= 0)
        {
            linha.pode_esticar = false;
            linha.pode_voltar = false;
            placar_evolucao.SetActive(true);
            botao_evoluir1.SetEvolucao();
            botao_evoluir2.SetEvolucao();
            botao_evoluir3.SetEvolucao();
            pontos -= 500;
        }
    }
}
