using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class BarraProgresso : MonoBehaviour
{
    public int max;
    public int atual;
    public Image mascara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Progresso();
    }
    void Progresso()
    { 
        float progresso = (float)atual/(float)max;
        mascara.fillAmount = progresso;
    }
}
