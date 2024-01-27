using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    [Header("Rigidbody2D")]
    [SerializeField] private Rigidbody2D corpo;
    [Header("SpriteRenderer")]
    [SerializeField] private SpriteRenderer sprite_renderer;

    [Header("Tipo")]
    [SerializeField] private Tipo tipo;

    [Header("Habilidade")]
    [SerializeField] private Habilidade habilidade;

    [Header("Velocidade de movimento")]
    [SerializeField] private float velociadade;
    private int definidor_direcao;

    [Header("Para qual direção")]
    [SerializeField] public Direcao direcao;

    [Header("Capturado")]
    [SerializeField] private bool capturado;

    [Header("Pode Movientar")]
    [SerializeField] private bool pode_movimentar;

    [Header("Sprite Capturado")]
    [SerializeField] private Sprite sprite_capturado;

    [Header("Corrente")]
    [SerializeField] private HingeJoint2D corrente;

    [Header("Isca")]
    [SerializeField] private GameObject isca;

    [Header("Pode Usar")]
    [SerializeField] private bool pode_usar;

    [SerializeField] private float valor_antingo_ida;
    [SerializeField] private float valor_antigo_volta;

    [SerializeField] private GameObject Collider_Capturado;

    [SerializeField] private Collider2D Collider_Normal;

    [SerializeField] private float qt_pontos;

    private bool pode_dash = true;

    private bool pode_devio = true;
    private void FixedUpdate()
    {
        Movimentar();
    }
    private void Update()
    {
        StartCoroutine(AtivarHabilidade());
        if (capturado)
        {
            this.transform.position = isca.transform.position;
        }
    }
    private void Movimentar()
    {
        if (pode_movimentar)
        {
            corpo.velocity = new Vector2(velociadade * definidor_direcao, 0) * Time.fixedDeltaTime * 100f;
        }
    }
    public void DefinirDirecao()
    {
        if (direcao == Direcao.Direta)
        {
            definidor_direcao = 1;
        }
        if (direcao == Direcao.Esquerda)
        {
            definidor_direcao = -1;
            transform.localScale = new Vector2(this.transform.localScale.x * -1,
                transform.localScale.y);
        }
        
    }
    private IEnumerator AtivarHabilidade()
    {
        if(habilidade == Habilidade.Nenhuma)
        {
            yield return null ;
        }
        if(habilidade == Habilidade.Pesado)
        {
            if(capturado && pode_usar) 
            {
                Pesar();
            }
        }
        if(habilidade == Habilidade.Dash && pode_dash)
        {
            pode_dash = false;
            yield return new WaitForSeconds(2.2f);
            velociadade = velociadade * 4f;
            yield return new WaitForSeconds(0.5f);
            velociadade = velociadade / 4;
        }
        if (habilidade == Habilidade.Desvio && pode_devio)
        {
            pode_devio = false;
            yield return new WaitForSeconds(2.2f);
            pode_movimentar = false;
            corpo.velocity = Vector2.zero;
            if (transform.position.y >= -2)
            {
                corpo.velocity = new Vector2(velociadade * definidor_direcao, velociadade * -1.7f) * Time.fixedDeltaTime * 100f;
            }
            if(transform.position.y <= -2)
            {
                corpo.velocity = new Vector2(velociadade * definidor_direcao, velociadade * 1.7f) * Time.fixedDeltaTime * 100f;
            }
            yield return new WaitForSeconds(0.5f);
            corpo.velocity = Vector2.zero;
            pode_movimentar = true;
        }

    }
    private void Pesar()
    {
        valor_antingo_ida = isca.GetComponent<Anzol>().linha.tempo_descida = isca.GetComponent<Anzol>().linha.tempo_descida;
        valor_antigo_volta = isca.GetComponent<Anzol>().linha.tempo_subida = isca.GetComponent<Anzol>().linha.tempo_subida;
        isca.GetComponent<Anzol>().linha.tempo_descida = isca.GetComponent<Anzol>().linha.tempo_descida / 2;
        isca.GetComponent<Anzol>().linha.tempo_subida = isca.GetComponent<Anzol>().linha.tempo_subida * 1.5f;
        pode_usar = false;
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
        if (colisao.gameObject.layer == 8 && tipo == Tipo.Humano &&
            colisao.gameObject.GetComponent<Anzol>().objetos.Count < colisao.gameObject.GetComponent<Anzol>().quantidade_anzol)
        {
            isca = colisao.gameObject;
            isca.GetComponent<Anzol>().objetos.Add(this.gameObject);
            capturado = true;
            sprite_renderer.sprite = sprite_capturado;
            this.transform.position = isca.transform.position;
            corrente.enabled = true;
            corrente.connectedBody = isca.GetComponent<Rigidbody2D>();
            Collider_Normal.enabled = false;
            Collider_Capturado.SetActive(true);
        }
        if (colisao.gameObject.layer == 9 && tipo == Tipo.Humano)
        {
            isca.GetComponent<Anzol>().objetos.Remove(isca.GetComponent<Anzol>().objetos[
                isca.GetComponent<Anzol>().objetos.Count - 1]);
            
            if (habilidade == Habilidade.Pesado)
            {
                isca.GetComponent<Anzol>().linha.tempo_descida = valor_antingo_ida;
                isca.GetComponent<Anzol>().linha.tempo_subida = valor_antigo_volta;
            }

            colisao.GetComponent<Peixe>().AumentarPontos(qt_pontos);
            Destroy(this.gameObject);
        }
        if(colisao.gameObject.layer == 8 && tipo == Tipo.Obstaculo)
        {
            isca = colisao.gameObject;
            isca.GetComponent<Anzol>().peixe.DiminuirVida();
            isca.GetComponent<Anzol>().linha.DestruirLinha();
            isca.GetComponent<Anzol>().DestruirHumanos();
            Destroy(this.gameObject);
        }
    }
    public void Destruir()
    {
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        if(habilidade == Habilidade.Pesado && capturado) 
        {
            isca.GetComponent<Anzol>().linha.tempo_descida = valor_antingo_ida;
            isca.GetComponent<Anzol>().linha.tempo_subida = valor_antigo_volta;
        }
    }
}
public enum Tipo
{
    Obstaculo,
    Humano
}
public enum Direcao
{
    Esquerda,
    Direta
}
public enum Habilidade
{
    Nenhuma,
    Pesado,
    Dash,
    Desvio
}
