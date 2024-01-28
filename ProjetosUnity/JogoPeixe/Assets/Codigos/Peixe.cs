using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Peixe : MonoBehaviour
{
    [SerializeField] private float nivel;
    [SerializeField] public float vida;
    [SerializeField] private GameObject placar_evolucao;
    [SerializeField] private Botao_Evoluir botao_evoluir1;
    [SerializeField] private Botao_Evoluir botao_evoluir2;
    [SerializeField] private Botao_Evoluir botao_evoluir3;
    [SerializeField] public Linha linha;

    [SerializeField] public bool dobro_pontos;
    [SerializeField] public float qt_mais_humanos = 0;

    [SerializeField] public float pontos_permantente;

    [SerializeField] Arpao arpao;
    [SerializeField] GameObject anzol;
    [SerializeField] GameObject anzol2;

    [SerializeField] BarraProgresso barra;

    [SerializeField] TextMeshProUGUI perolas;

    [SerializeField] Vida_Hud hud_vida;

    [SerializeField] Animator animator;

    [SerializeField] GameObject perdeu;

    [SerializeField] GameObject pause_menu;
    private void Update()
    {
        Pausar();
    }
    public void AumentarPontos(float qt_pontos)
    {
        nivel += qt_pontos;
        barra.atual = nivel;
        Evoluir();
        if(dobro_pontos)
        {
            qt_pontos = qt_pontos * 2;
        }
        pontos_permantente += qt_pontos + qt_mais_humanos;
        perolas.text = pontos_permantente.ToString();
        barra.Progresso();
    }
    public IEnumerator Imortal()
    {
        animator.SetBool("Imortal", true);
        anzol2.GetComponent<Anzol>().pode_morrer = false;
        yield return new WaitForSeconds(10f);
        animator.SetBool("Imortal", false);
        anzol2.GetComponent<Anzol>().pode_morrer = true; 
    }
    public IEnumerator DobrarPontos()
    {
        dobro_pontos = true;
        yield return new WaitForSeconds(10f);
        dobro_pontos = false;
    }
    public IEnumerator Arpao()
    {
        arpao.pode_destruir = false;
        anzol.SetActive(false);
        arpao.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        arpao.pode_destruir = true;
    }
    public void AumentarVida()
    {
        vida += 1;
        hud_vida.AddVida();
    }
    public void DiminuirVida()
    {
        vida -= 1;
        hud_vida.ApgarVida();
        Perder();
    }
    public void Perder()
    {
        if(vida <= 0)
        {
            perdeu.gameObject.SetActive(true);
        }
    }
    public void Pausar()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause_menu.gameObject.SetActive(true);
        }
    }
    public void Evoluir()
    {
        if (nivel - 500 >= 0)
        {
            linha.pode_esticar = false;
            linha.pode_voltar = false;
            arpao.pode_usar = false;
            placar_evolucao.SetActive(true);
            botao_evoluir1.SetEvolucao();
            botao_evoluir2.SetEvolucao();
            botao_evoluir3.SetEvolucao();
            nivel -= 500;
            barra.Progresso();
        }
    }
}
