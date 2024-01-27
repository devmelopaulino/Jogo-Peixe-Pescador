using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador_Mestre : MonoBehaviour
{
    [SerializeField] List<Gerador> lista_geradores;
    [SerializeField] private List<GameObject> objetos;
    [SerializeField] private float tempo_normal;
    [SerializeField] private float tempo_cow;
    [SerializeField] private float tempo_astro;
    [SerializeField] private float tempo_empre;
    [SerializeField] private float tempo_pesca;
    private bool pode_gerar_normal = true;
    private bool pode_gerar_cow = true;
    private bool pode_gerar_astro = true;
    private bool pode_gerar_empre = true;
    private bool pode_gerar_pesca = true;

    [SerializeField] private float tempo_meteoro1;
    [SerializeField] private float tempo_meteoro2;
    [SerializeField] private float tempo_mickey;
    [SerializeField] private float tempo_gato;
    [SerializeField] private float tempo_pizza;
    [SerializeField] private float tempo_sate;
    private bool pode_gerar_meteoro1 = true;
    private bool pode_gerar_meteoro2 = true;
    private bool pode_gerar_mickey = true; 
    private bool pode_gerar_gato = true;
    private bool pode_gerar_pizza = true;
    private bool pode_gerar_sate = true;
    private void Update()
    {
        StartCoroutine(GerarNormal());
        StartCoroutine(GerarCow());
        StartCoroutine(GerarEmpre());
        StartCoroutine(GerarPesca());
        StartCoroutine(GerarAstro());
        StartCoroutine(GerarMeteoro1());
        StartCoroutine(GerarMeteoro2());
        StartCoroutine(GerarMickey());
        StartCoroutine(GerarSate());
        StartCoroutine(GerarGato());
        StartCoroutine(GerarPizza());
    }
    private IEnumerator GerarMeteoro1()
    {
        if (pode_gerar_meteoro1)
        {
            pode_gerar_meteoro1 = false;
            yield return new WaitForSeconds(tempo_meteoro1);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[5]);
            pode_gerar_meteoro1 = true;
        }
    }
    private IEnumerator GerarMeteoro2()
    {
        if (pode_gerar_meteoro2)
        {
            pode_gerar_meteoro2 = false;
            yield return new WaitForSeconds(tempo_meteoro2);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[6]);
            pode_gerar_meteoro2 = true;
        }
    }
    private IEnumerator GerarMickey()
    {
        if (pode_gerar_mickey)
        {
            pode_gerar_mickey = false;
            yield return new WaitForSeconds(tempo_mickey);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[7]);
            pode_gerar_mickey = true;
        }
    }
    private IEnumerator GerarSate()
    {
        if (pode_gerar_sate)
        {
            pode_gerar_sate = false;
            yield return new WaitForSeconds(tempo_sate);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[8]);
            pode_gerar_sate = true;
        }
    }
    private IEnumerator GerarGato()
    {
        if (pode_gerar_gato)
        {
            pode_gerar_gato = false;
            yield return new WaitForSeconds(tempo_gato);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[9]);
            pode_gerar_gato = true;
        }
    }
    private IEnumerator GerarPizza()
    {
        if (pode_gerar_pizza)
        {
            pode_gerar_pizza = false;
            yield return new WaitForSeconds(tempo_pizza);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[10]);
            pode_gerar_pizza = true;
        }
    }
    private IEnumerator GerarNormal()
    {
        if (pode_gerar_normal)
        {
            pode_gerar_normal = false;
            yield return new WaitForSeconds(tempo_normal);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[0]);
            pode_gerar_normal = true;
        }
    }
    private IEnumerator GerarCow()
    {
        if (pode_gerar_cow)
        {
            pode_gerar_cow = false;
            yield return new WaitForSeconds(tempo_cow);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[1]);
            pode_gerar_cow = true;
        }
    }
    private IEnumerator GerarAstro()
    {
        if (pode_gerar_astro)
        {
            pode_gerar_astro = false;
            yield return new WaitForSeconds(tempo_astro);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[2]);
            pode_gerar_astro = true;
        }
    }
    private IEnumerator GerarEmpre()
    {
        if (pode_gerar_empre)
        {
            pode_gerar_empre = false;
            yield return new WaitForSeconds(tempo_empre);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[3]);
            pode_gerar_empre = true;
        }
    }
    private IEnumerator GerarPesca()
    {
        if (pode_gerar_pesca)
        {
            pode_gerar_pesca = false;
            yield return new WaitForSeconds(tempo_pesca);
            lista_geradores[(int)SortearGerador()].Gerar(objetos[4]);
            pode_gerar_pesca = true;
        }
    }

    private float SortearGerador()
    {
        float geradorSorteado = Random.Range(0, lista_geradores.Count);
        return geradorSorteado;
    }

}
