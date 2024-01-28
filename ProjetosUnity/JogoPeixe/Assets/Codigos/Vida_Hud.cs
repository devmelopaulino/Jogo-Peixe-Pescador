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
        Destroy(vidas[vidas.Count - 1]);
        vidas.Remove(vidas[vidas.Count - 1]);
    }
    public void AddVida()
    {
        Instantiate(obj_vida, this.transform);
        vidas.Add(obj_vida);
    }
}
