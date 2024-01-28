using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perdeu : MonoBehaviour
{
    Sistema_Traducao tradu;
    [SerializeField] Peixe peixe;
    [SerializeField] TextMeshProUGUI pontos;
    [SerializeField] TextMeshProUGUI perdeutexto;
    [SerializeField] TextMeshProUGUI jogarnovamente;
    private void Awake()
    {
        tradu = GameObject.FindGameObjectWithTag("Traducao").GetComponent<Sistema_Traducao>();
        if(tradu.escolha == Lingua.PtBr)
        {
            perdeutexto.text = "Fim de Jogo";
            jogarnovamente.text = "Jogar Novamente";
        }
        if (tradu.escolha == Lingua.Eng)
        {
            perdeutexto.text = "Game Over";
            jogarnovamente.text = "Play Again";
        }
    }
    public void ParaMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void JogarNovamente()
    {
        SceneManager.LoadScene(1);
    }
    private void OnEnable()
    {
        pontos.text = peixe.pontos_permantente.ToString();
    }
}
