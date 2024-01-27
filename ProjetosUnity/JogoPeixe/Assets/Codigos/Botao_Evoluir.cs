using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botao_Evoluir : MonoBehaviour
{
    [SerializeField] private Peixe peixe;
    [SerializeField] private float numero_evoluoes;
    [SerializeField] private CartaoEvolucao cartao;
    [SerializeField] private GameObject Painel;
    [SerializeField] private Image imagem;
    [SerializeField] private List<Sprite> imagens_lista;

    public void SetEvolucao()
    {
        float evolucao_escolida = Random.Range(0, numero_evoluoes + 1);
        switch((int)evolucao_escolida)
        {
            case 0:
                cartao = CartaoEvolucao.dobro_perola;
                imagem.sprite = imagens_lista[1];
                break;

            case 1:
                cartao = CartaoEvolucao.cinco_humanos;
                imagem.sprite = imagens_lista[3];
                break;

            case 3:
                cartao = CartaoEvolucao.invencivel;
                imagem.sprite = imagens_lista[2];
                break;

            case 4:
                cartao = CartaoEvolucao.mais_anzol;
                imagem.sprite = imagens_lista[6];
                break;

            case 5:
                cartao = CartaoEvolucao.acelerar;
                imagem.sprite = imagens_lista[5];
                break;

            case 6:
                cartao = CartaoEvolucao.arpao;
                imagem.sprite = imagens_lista[0];
                break;

            case 7:
                cartao = CartaoEvolucao.dobro_anzol;
                imagem.sprite = imagens_lista[4];
                break;
        }

    }

    public void ClicarEvolucao()
    {
        if(cartao == CartaoEvolucao.dobro_perola)
        {
            Debug.Log("Dobrar perolas");
        }
        if (cartao == CartaoEvolucao.cinco_humanos)
        {
            Debug.Log("Cinco humanos");
        }
        if (cartao == CartaoEvolucao.invencivel)
        {
            Debug.Log("Invencivel");
        }
        if (cartao == CartaoEvolucao.mais_anzol)
        {
            Debug.Log("Mais Anzol");
        }
        if (cartao == CartaoEvolucao.acelerar)
        {
            Debug.Log("Acelerar");
        }
        if (cartao == CartaoEvolucao.arpao)
        {
            Debug.Log("Arpão");
        }
        if (cartao == CartaoEvolucao.dobro_anzol)
        {
            Debug.Log("Dobro Anzol");
        }
    }   
    public void Fechar()
    {
        Painel.gameObject.SetActive(false);
        peixe.linha.pode_esticar = true;
        peixe.linha.pode_voltar = true;
    }
}
public enum CartaoEvolucao
{
    dobro_perola,
    cinco_humanos,
    invencivel,
    mais_anzol,
    acelerar,
    arpao,
    dobro_anzol
}
