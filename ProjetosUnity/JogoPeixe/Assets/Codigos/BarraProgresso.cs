using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraProgresso : MonoBehaviour
{
    public float max;
    public float atual;
    public Image mascara;
    public void Progresso()
    {
        float progresso = atual/max;
        mascara.fillAmount = progresso;
    }
}
