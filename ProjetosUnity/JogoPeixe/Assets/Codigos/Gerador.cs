using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    [Header("Direção")]
    [SerializeField] private Direcao direcao;

    [Header("Lista de Objetos")]
    [SerializeField] private List<GameObject> objetos;

    [Header("Minimo de tempo")]
    [SerializeField] private float min_tempo;

    [Header("Minimo de tempo")]
    [SerializeField] private float max_tempo;

    [Header("Pode gerar")]
    [SerializeField] public bool pode_gerar;

    [Header("Ativar vareação")]
    [SerializeField] public bool vareacao_para_baixo;
    public void Gerar(GameObject objetoSelecionado)
    {
        GameObject objeto;
        if (vareacao_para_baixo)
        {
            Vector2 variacao_vector = new Vector2(0, Random.Range(-1, 1));
            objeto = Instantiate(objetoSelecionado, (Vector2)this.transform.position + variacao_vector, Quaternion.identity);
        }
        else
        {
            Vector2 variacao_vector = new Vector2(0, Random.Range(0, 1));
            objeto = Instantiate(objetoSelecionado, (Vector2)this.transform.position + variacao_vector, Quaternion.identity);
        }
        objeto.GetComponent<Objeto>().direcao = direcao;
        objeto.GetComponent<Objeto>().DefinirDirecao();
    }
}

