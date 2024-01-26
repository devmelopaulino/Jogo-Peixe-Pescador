using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sistema_Traducao : MonoBehaviour
{
    [SerializeField] private Lingua escolha;

    [SerializeField] private TextMeshProUGUI texto_menu_1;
    [SerializeField] private TextMeshProUGUI texto_menu_2;
    [SerializeField] private TextMeshProUGUI texto_menu_3;

    public void LingaPTBR()
    {
        escolha = Lingua.PtBr;
        MudarMenu(escolha);
    }
    public void LingaENG()
    {
        escolha = Lingua.Eng;
        MudarMenu(escolha);
    }

    private void MudarMenu(Lingua escolha_lingua)
    {
        if(escolha_lingua == Lingua.Eng) 
        {
            texto_menu_1.text = "Play";
        }
        if (escolha_lingua == Lingua.PtBr)
        {
            texto_menu_1.text = "Jogar";
        }
    }
}
public enum Lingua
{
    PtBr,
    Eng
}
