using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tela_Inicial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto_menu_1;
    [SerializeField] private TextMeshProUGUI texto_menu_2;
    [SerializeField] private TextMeshProUGUI texto_menu_3;
    [SerializeField] private Sistema_Traducao tradu;
    [SerializeField] public Lingua escolha;
    private void Start()
    {
        tradu = GameObject.FindGameObjectWithTag("Traducao").GetComponent<Sistema_Traducao>();
    }
    private void Update()
    {
        MudarMenu();
    }
    public void MudarMenu()
    {
        if (tradu.escolha == Lingua.Eng)
        {
            texto_menu_1.text = "Play";
            texto_menu_2.text = "Tutorial";
            texto_menu_3.text = "Credits";
        }
        if (tradu.escolha == Lingua.PtBr)
        {
            texto_menu_1.text = "Jogar";
            texto_menu_2.text = "Tutorial";
            texto_menu_3.text = "Créditos";
        }
    }
    public void LingaPTBR()
    {
        tradu = GameObject.FindGameObjectWithTag("Traducao").GetComponent<Sistema_Traducao>();
        escolha = Lingua.PtBr;
        tradu.escolha = escolha;
    }
    public void LingaENG()
    {
        tradu = GameObject.FindGameObjectWithTag("Traducao").GetComponent<Sistema_Traducao>();
        escolha = Lingua.Eng;
        tradu.escolha = escolha;
    }
}
