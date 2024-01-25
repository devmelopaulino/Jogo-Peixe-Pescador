using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
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
    [SerializeField] private Direcao direcao;

    [Header("Capturado")]
    [SerializeField] private bool capturado;

    [Header("Sprite Capturado")]
    [SerializeField] private Sprite sprite_capturado;

    [Header("Isca")]
    [SerializeField] private GameObject isca;


    private void FixedUpdate()
    {
        Movimentar();
    }
    private void Update()
    {
        if(capturado)
        {
            Prender();
        }
    }
    private void Start()
    {
        DefinirDirecao();
    }
    private void Movimentar()
    {
        corpo.velocity = new Vector2 (velociadade * definidor_direcao , 0) * Time.fixedDeltaTime * 100f;
    }
    private void DefinirDirecao()
    {
        if (direcao == Direcao.Direta)
        {
            definidor_direcao = 1;
        }
        if (direcao == Direcao.Esquerda)
        {
            definidor_direcao = -1;
        }
        
    }
    private void Prender()
    {
        this.transform.position = isca.transform.position;
        //this.transform.rotation = isca.transform.rotation;
    }
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
        if (colisao.gameObject.layer == 8 && tipo == Tipo.Humano)
        {
            capturado = true;
            isca = colisao.gameObject;
            sprite_renderer.sprite = sprite_capturado;
            //colisao.gameObject.GetComponent<Anzol>().Captutar(this.gameObject);
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
