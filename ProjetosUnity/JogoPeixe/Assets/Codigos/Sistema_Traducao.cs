using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Sistema_Traducao : MonoBehaviour
{
    [SerializeField] public Lingua escolha;

    [SerializeField] private TextMeshProUGUI texto_menu_1;
    [SerializeField] private TextMeshProUGUI texto_menu_2;
    [SerializeField] private TextMeshProUGUI texto_menu_3;

    [SerializeField] GameObject Sistema;

    private void Start()
    {
        escolha = Sistema.GetComponent<Sistema_Traducao>().escolha;
        if(texto_menu_1)
        {
            MudarMenu(escolha);
        }
    }
    public void LingaPTBR()
    {
        escolha = Lingua.PtBr;
        Sistema.GetComponent<Sistema_Traducao>().escolha = escolha;
        MudarMenu(escolha);
    }
    public void LingaENG()
    {
        escolha = Lingua.Eng;
        Sistema.GetComponent<Sistema_Traducao>().escolha = escolha;
        MudarMenu(escolha);
    }

    private void MudarMenu(Lingua escolha_lingua)
    {
        if(escolha_lingua == Lingua.Eng) 
        {
            texto_menu_1.text = "Play";
            texto_menu_2.text = "Tutorial";
            texto_menu_3.text = "Credits";
        }
        if (escolha_lingua == Lingua.PtBr)
        {
            texto_menu_1.text = "Jogar";
            texto_menu_2.text = "Tutorial";
            texto_menu_3.text = "Créditos";
        }
    }

}
public enum Lingua
{
    PtBr,
    Eng
}
