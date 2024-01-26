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


    private void FixedUpdate()
    {
        Movimentar();
    }
    private void Update()
    {
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
    private void Prender()
    {
        this.transform.position = isca.transform.position;
        corrente.enabled = true;
        corrente.connectedBody = isca.GetComponent<Rigidbody2D>();
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
            Prender();
        }
        if (colisao.gameObject.layer == 9 && tipo == Tipo.Humano)
        {
            isca.GetComponent<Anzol>().objetos.Remove(isca.GetComponent<Anzol>().objetos[
                isca.GetComponent<Anzol>().objetos.Count - 1]);
            colisao.GetComponent<Peixe>().AumentarPontos();
            Destroy(this.gameObject);
        }
    }
    public void Destruir()
    {
        Destroy(this.gameObject);
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
