using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arpao : MonoBehaviour
{
    public Camera cameraPrincipal;
    [SerializeField] private bool botao_baixo;
    [SerializeField] Rigidbody2D corpo;
    [SerializeField] bool pode_atacar = true;
    [SerializeField] float velocidade;
    [SerializeField] float tempo;
    [SerializeField] bool pode_girar = true;
    [SerializeField] Transform volta;
    [SerializeField] public Transform local_pesca;
    [SerializeField] public bool pode_destruir;
    [SerializeField] GameObject anzol;
    [SerializeField] public bool pode_usar = true;
    void Update()
    {
        DetectarBotao();
        StartCoroutine(Atacar(Girar()));
        if (pode_destruir && pode_girar)        
        {
            anzol.SetActive(true);
            gameObject.SetActive(false);        
        }
    }
    private Vector3 Girar()
    {
        if (pode_girar)
        {
            Vector3 posicaoDoMouse = Input.mousePosition;
            posicaoDoMouse.z = -cameraPrincipal.transform.position.z;
            Vector3 posicaoNoMundo = cameraPrincipal.ScreenToWorldPoint(posicaoDoMouse);
            Vector3 direcaoOposta = (transform.position - posicaoNoMundo).normalized;
            transform.up = direcaoOposta;
            return direcaoOposta;
        }
        return Vector3.zero;
    }
    private void DetectarBotao()
    {
        if (Input.GetMouseButton(0))
        {
            botao_baixo = true;
        }
        else
        {
            botao_baixo = false;
        }
    }
    private IEnumerator Atacar(Vector3 direcao)
    {
        if (botao_baixo && pode_atacar == true && pode_usar)
        {
            pode_girar = false;
            pode_atacar = false;
            corpo.velocity = (Vector2)(velocidade * -direcao);
            yield return new WaitForSeconds(tempo);
            corpo.velocity = Vector2.zero;
            this.transform.localScale = new Vector3 (1, -1, 1);
            while(this.transform.position != volta.transform.position)
            {
                Vector3 direcaoOposta = (transform.position - volta.position).normalized;
                transform.up = direcaoOposta;
                corpo.velocity = (Vector2)(-direcaoOposta * velocidade);
                yield return null;
            }
            corpo.velocity = Vector2.zero;
            this.transform.localScale = new Vector3(1, 1, 1);
            pode_girar = true;
            pode_atacar = true;
        }
    }
}
