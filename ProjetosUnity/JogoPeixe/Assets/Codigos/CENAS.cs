using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CENAS : MonoBehaviour
{
    public void CenaJogo()
    {
        SceneManager.LoadScene(4);
    }
    public void CenaTutorial()
    {
        SceneManager.LoadScene(2);
    }
    public void CenaCreditos()
    {
        SceneManager.LoadScene(3);
    }
}
