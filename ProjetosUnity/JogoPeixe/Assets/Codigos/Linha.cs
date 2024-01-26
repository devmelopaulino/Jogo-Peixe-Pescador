using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Linha : MonoBehaviour
{
    [Header("Ativar a permissão de usar a linha")]
    [SerializeField] private bool pode_usar;

    [Header("Ativar a permissão de esticar a linha")]
    [SerializeField] private bool pode_esticar;
    [Header("Ativar a permissão de voltar a linha")]
    [SerializeField] private bool pode_voltar;

    [Header("Seta para cima pressionada")]
    [SerializeField] private bool botao_cima;
    [Header("Seta para baixo pressionada")]
    [SerializeField] private bool botao_baixo;

    [Header("Objeto do anzol")]
    [SerializeField] private GameObject anzol;

    [Header("Distancia definida entre as linhas")]
    [SerializeField] private float linha_distancia;
    [Header("Grupo das linhas")]
    [SerializeField] private List<GameObject> linhas;
    [Header("Prefab de Instância da Linha")]
    [SerializeField] private GameObject linha;
    [Header("Limite de linhas")]
    [SerializeField] private float limite_linhas;

    [Header("Tempo para subir a linha")]
    [SerializeField] private float tempo_subida;
    [Header("Tempo para descer a linha")]
    [SerializeField] private float tempo_descida;

    private void Update()
    {
        DetectarBotao();
        StartCoroutine(Esticar());
        StartCoroutine(Voltar());
    }

    private IEnumerator Esticar()
    {
        if (pode_usar)
        {
            if (botao_baixo && pode_esticar && linhas.Count <= limite_linhas)
            {
                pode_esticar = false;
                GameObject nova_parte = Instantiate(linha, this.transform);
                nova_parte.name = "Linha " + (linhas.Count - 1);
                //nova_parte.transform.rotation = Quaternion.Euler(new Vector3(0, 0, linhas[linhas.Count - 1].transform.rotation.eulerAngles.z));
                nova_parte.transform.position = new Vector2(linhas[linhas.Count - 1].transform.position.x, linhas[linhas.Count - 1].transform.position.y + linha_distancia);
                nova_parte.GetComponent<HingeJoint2D>().connectedBody = linhas[linhas.Count - 1].GetComponent<Rigidbody2D>();
                linhas.Add(nova_parte);
                //linhas[linhas.Count - 2].transform.rotation = Quaternion.Euler(new Vector3(0, 0, linhas[linhas.Count - 1].transform.rotation.eulerAngles.z));
                anzol.GetComponent<HingeJoint2D>().connectedBody = linhas[linhas.Count - 1].GetComponent<Rigidbody2D>();
                anzol.transform.position =  new Vector2( linhas[linhas.Count - 1].transform.position.x, linhas[linhas.Count - 1].transform.position.y + linha_distancia);
                yield return new WaitForSeconds(tempo_descida);
                pode_esticar = true;
            }
        }
    }
    private IEnumerator Voltar()
    {
        if (pode_usar)
        {
            if(botao_cima && linhas.Count > 5 && pode_voltar)
            {
                pode_voltar = false;
                linhas[linhas.Count - 2].transform.rotation = Quaternion.Euler(new Vector3(0, 0, linhas[linhas.Count - 3].transform.rotation.eulerAngles.z));
                Destroy(linhas[linhas.Count - 1]);
                linhas.Remove(linhas[linhas.Count - 1]);
                anzol.GetComponent<HingeJoint2D>().connectedBody = linhas[linhas.Count - 1].GetComponent<Rigidbody2D>();
                anzol.transform.position = new Vector2(linhas[linhas.Count - 1].transform.position.x, linhas[linhas.Count - 1].transform.position.y + linha_distancia);
                yield return new WaitForSeconds(tempo_subida);
                pode_voltar = true;
            }
        }
    }
    private void DetectarBotao()
    {
        if(Input.GetMouseButton(0))
        {
            botao_baixo = true;
        }
        else
        {
            botao_baixo = false;
        }
        if (Input.GetMouseButton(1))
        {
            botao_cima = true;
        }
        else
        {
            botao_cima = false;
        }
    }

}
