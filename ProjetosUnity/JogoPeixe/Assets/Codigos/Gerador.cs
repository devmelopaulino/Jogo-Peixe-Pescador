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
    [SerializeField] private bool pode_gerar;

    [Header("Ativar vareação")]
    [SerializeField] private bool vareacao_para_baixo;

    private void Update()
    {
        StartCoroutine(Gerar());
    }
    private IEnumerator Gerar()
    {
        if (pode_gerar)
        {
            pode_gerar = false;
            float tempo = Random.Range(min_tempo, max_tempo + 1);
            float objeto_escolhido = Random.Range(0, objetos.Count);
            yield return new WaitForSeconds(tempo);
            GameObject objeto;
            if (vareacao_para_baixo)
            {
                Vector2 variacao_vector = new Vector2(0, Random.Range(-1, 1));
                objeto = Instantiate(objetos[(int)objeto_escolhido], (Vector2)this.transform.position + variacao_vector, Quaternion.identity);
            }
            else
            {
                Vector2 variacao_vector = new Vector2(0, Random.Range(0, 1));
                objeto = Instantiate(objetos[(int)objeto_escolhido], (Vector2)this.transform.position + variacao_vector, Quaternion.identity);
            }
            objeto.GetComponent<Objetos>().direcao = direcao;
            objeto.GetComponent<Objetos>().DefinirDirecao();
            pode_gerar = true;
        }
    }
}

