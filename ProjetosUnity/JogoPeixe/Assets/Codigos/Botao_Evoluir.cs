using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
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
    [SerializeField] private float numero;
    [SerializeField] private Anzol anzol;
    [SerializeField] private Linha linha;

    [SerializeField] private TextMeshProUGUI titulo;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private Sistema_Traducao tradu;

    [SerializeField] private TextMeshProUGUI escolha;

    [SerializeField] Arpao arpao;
    private void Awake()
    {
        tradu = GameObject.FindGameObjectWithTag("Traducao").GetComponent<Sistema_Traducao>();
        if(escolha)
        {
            if (tradu.escolha == Lingua.PtBr)
            {
                escolha.text = "Escolha Um";
            }
            if (tradu.escolha == Lingua.Eng)
            {
                escolha.text = "Choose One";
            }
        }
    }
    public void SetEvolucao()
    {
        float evolucao_escolhida = Random.Range(0, numero_evoluoes);
        numero = (int)evolucao_escolhida;
        switch (numero)
        {
            case 0:
                cartao = CartaoEvolucao.dobro_perola;
                imagem.sprite = imagens_lista[1];

                if (tradu.escolha == Lingua.PtBr)
                {
                    titulo.text = "O mar tá pra peixe:";
                    texto.text = "Duplica o valor dos humanos por 15 segundos.";
                }
                if (tradu.escolha == Lingua.Eng)
                {
                    titulo.text = "Fish Around:";
                    texto.text = "Doubles the value of humans for 15 seconds.";
                }
                break;

            case 1:
                cartao = CartaoEvolucao.cinco_humanos;
                imagem.sprite = imagens_lista[3];

                if (tradu.escolha == Lingua.PtBr)
                {
                    titulo.text = "Nem tudo o que vem à rede é peixe:";
                    texto.text = "Aumenta permanentemente o valor de todos os humanos para +5.";
                }
                if (tradu.escolha == Lingua.Eng)
                {
                    titulo.text = "Drink Like A Fish:";
                    texto.text = "Increases the value of all humans permanently by +5.";
                }
                break;

            case 2:
                cartao = CartaoEvolucao.invencivel;
                imagem.sprite = imagens_lista[2];

                if (tradu.escolha == Lingua.PtBr)
                {
                    titulo.text = "Camarão que dorme a onda leva:";
                    texto.text = "Escudo que reflete dano por 10 segundos.";
                }
                if (tradu.escolha == Lingua.Eng)
                {
                    titulo.text = "Fish In Troubled Waters:";
                    texto.text = "Shield that reflects damage for 10 seconds.";
                }
                break;

            case 3:
                cartao = CartaoEvolucao.mais_anzol;
                imagem.sprite = imagens_lista[6];

                if (tradu.escolha == Lingua.PtBr)
                {
                    titulo.text = "“Pescraução“:";
                    texto.text = "Preenche um espaço vazio de anzol.";
                }
                if (tradu.escolha == Lingua.Eng)
                {
                    titulo.text = "A Cold Fish:";
                    texto.text = "Fills an empty hook slot.";
                }


                break;

            case 4:
                cartao = CartaoEvolucao.acelerar;
                imagem.sprite = imagens_lista[5];

                if (tradu.escolha == Lingua.PtBr)
                {
                    titulo.text = "Filho de peixe sabe pescar:";
                    texto.text = "Aumenta a velocidade de puxar a linha.";
                }
                if (tradu.escolha == Lingua.Eng)
                {
                    titulo.text = "Big Fish In A Small Pond:";
                    texto.text = "Increases the reeling speed of the line.";
                }

                break;

            case 5:
                cartao = CartaoEvolucao.arpao;
                imagem.sprite = imagens_lista[0];

                if (tradu.escolha == Lingua.PtBr)
                {
                    titulo.text = "Olho de peixe:";
                    texto.text = "Transforma a vara em um arpão por 10 segundos.";
                }
                if (tradu.escolha == Lingua.Eng)
                {
                    titulo.text = "Fish Eye:";
                    texto.text = "Transforms the fishing rod into a harpoon for 10 seconds.";
                }

                break;

            case 6:
                cartao = CartaoEvolucao.dobro_anzol;
                imagem.sprite = imagens_lista[4];

                if (tradu.escolha == Lingua.PtBr)
                {
                    titulo.text = "O peixe morre é pela boca:";
                    texto.text = "Duplica o anzol para pegar dois humanos ao mesmo tempo por 15 segundos.";
                }
                if (tradu.escolha == Lingua.Eng)
                {
                    titulo.text = "Like Shooting Fish In A Barrel:";
                    texto.text = "Duplicates the hook to catch two humans at once for 15 seconds.";
                }

                break;
        }

    }

    public void ClicarEvolucao()
    {
        if (cartao == CartaoEvolucao.dobro_perola)
        {
            peixe.StartCoroutine(peixe.DobrarPontos());
        }
        if (cartao == CartaoEvolucao.cinco_humanos)
        {
            peixe.qt_mais_humanos += 5;
        }
        if (cartao == CartaoEvolucao.invencivel)
        {
            peixe.StartCoroutine(peixe.Imortal());
        }
        if (cartao == CartaoEvolucao.mais_anzol)
        {
            peixe.AumentarVida();
        }
        if (cartao == CartaoEvolucao.acelerar)
        {
            linha.AcelerarLinha();
        }
        if (cartao == CartaoEvolucao.arpao)
        {
            peixe.StartCoroutine(peixe.Arpao());
        }
        if (cartao == CartaoEvolucao.dobro_anzol)
        {
            anzol.StartCoroutine(anzol.Dobrar());
        }
    }
    public void Fechar()
    {
        Painel.gameObject.SetActive(false);
        peixe.linha.pode_esticar = true;
        peixe.linha.pode_voltar = true;
        arpao.pode_usar = true;
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
