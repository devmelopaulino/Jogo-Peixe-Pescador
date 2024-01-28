using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cut : MonoBehaviour
{
    [SerializeField] Sprite[] imagens;

    [SerializeField] GameObject[] textos;
    [SerializeField] GameObject[] textosEng;
    [SerializeField] GameObject[] textosBr;

    [SerializeField] Image imagem;
    [SerializeField] int index;
    [SerializeField] Sistema_Traducao traducao;


    private void Start()
    {
        traducao = GameObject.FindGameObjectWithTag("Traducao").GetComponent<Sistema_Traducao>();
        if (traducao)
        {
            if (traducao.escolha == Lingua.PtBr)
            {
                textos = textosBr;
            }
            if (traducao.escolha == Lingua.Eng)
            {
                textos = textosEng;
            }
        }
        textos[0].gameObject.SetActive(true);
    }

    public void Passar()
    {
        index += 1;
        if(index == 0)
        {
            textos[0].gameObject.SetActive(true);
        }
        if (index == 1)
        {
            textos[0].gameObject.SetActive(false);
            textos[1].gameObject.SetActive(true);
        }
        if (index == 2)
        {
            textos[1].gameObject.SetActive(false);
            textos[2].gameObject.SetActive(true);
        }
        if (index == 3)
        {
            textos[2].gameObject.SetActive(false);
            textos[3].gameObject.SetActive(true);
        }
        if (index == 4)
        {
            textos[3].gameObject.SetActive(false);
            textos[4].gameObject.SetActive(true);
        }
        if (index == imagens.Length)
        {
            Jogar();
            return;
        }
        imagem.sprite = imagens[index];
    }
    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }
}
