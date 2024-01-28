using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Proximo : MonoBehaviour
{
    [SerializeField] Sprite[] imagens;

    [SerializeField] Sprite[] imagensPtBr;
    [SerializeField] Sprite[] imagensEng;

    [SerializeField] Image imagem;
    [SerializeField] int index;
    [SerializeField] Sistema_Traducao traducao;
    [SerializeField] bool duas_linguas;

    private void Start()
    {
        if (duas_linguas)
        {
            traducao = GameObject.FindGameObjectWithTag("Traducao").GetComponent<Sistema_Traducao>();
        }
        if(traducao)
        {
            if(traducao.escolha == Lingua.PtBr)
            {
                imagens = imagensPtBr;
                imagem.sprite = imagensPtBr[0];
            }
            if(traducao.escolha == Lingua.Eng)
            {
                imagens = imagensEng;
                imagem.sprite = imagensEng[0];
            }
        }
    }

    public void Passar()
    {
        index += 1;
        if(index == imagens.Length)
        {
            VoltarMenu();
            return;
        }
        imagem.sprite = imagens[index];    
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }
}
