using System.Collections;
using UnityEngine;

public class PreviewItemData : MonoBehaviour
{
    public GameObject[] ModifableColorOb;

    private Renderer[] rend;

    private void Awake()
    {
        rend = new Renderer[ModifableColorOb.Length];
        for(int i = 0; i < rend.Length;i++)
        {
            rend[i] = ModifableColorOb[i].GetComponent<Renderer>();
        }
    }
    public void ChangeMat(Material mat)
    {
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].material = mat;
        }
    }
}
