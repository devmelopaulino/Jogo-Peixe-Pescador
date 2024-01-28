using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Vida_Hud : MonoBehaviour
{
    [SerializeField] GameObject obj_vida;
    [SerializeField] List<GameObject> vidas;
    public void ApgarVida()
    {
        GameObject vida = vidas[vidas.Count - 1];
        Destroy(vida);
        vidas.Remove(vidas[vidas.Count - 1]);
    }
    public void AddVida()
    {
        GameObject vida = Instantiate(obj_vida, this.transform);
        vidas.Add(vida);
    }
}
