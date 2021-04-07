using System.Collections;
using UnityEngine;

public class PreviewItemData : MonoBehaviour
{
    public GameObject[] ModifableColorOb;

    public float yScale;

    private Renderer[] rend;

    private bool hitTrig;
    private bool Changed;

    private Material Valid;
    private Material NonValid;

    private ItemPreviewer ItemPreviewerScript;

    private bool placeKey;

    private void Awake()
    {
        placeKey = false;
        Changed = false;
        hitTrig = false;
        rend = new Renderer[ModifableColorOb.Length];
        for(int i = 0; i < rend.Length;i++)
        {
            rend[i] = ModifableColorOb[i].GetComponent<Renderer>();
        }
    }

    public void SetMats(Material a, Material b, ItemPreviewer c)
    {
        Valid = a;
        NonValid = b;
        ItemPreviewerScript = c;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            placeKey = true;
        }
    }
    private void FixedUpdate()
    {
        if(hitTrig)
        {
            if(Changed)
            {
                ChangeMat(Valid);
                Changed = false;
            }
            if(placeKey)
            {
                PlaceSensor();
            }
            hitTrig = false;
        }
        else
        {
            if (!Changed)
            {
                ChangeMat(NonValid);
                Changed = true;
            }  
        }
        placeKey = false;
    }

    private void OnTriggerStay(Collider collider)
    {
        
        hitTrig = true;
        
    }
    
    private void PlaceSensor()
    {
        Debug.Log("UWU");
        ItemPreviewerScript.DefaultSet();
    }

    public void ChangeMat(Material mat)
    {
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].material = mat;
        }
    }
}
