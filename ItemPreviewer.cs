using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPreviewer : MonoBehaviour
{

    [SerializeField] private KeyCode Cancel;

    [SerializeField] private GameObject GameManager;

    [SerializeField] private LayerMask previewLayer;

    [SerializeField] private float previewDist;

    [SerializeField] private Material Green;
    [SerializeField] private Material Red;

    private PreviewItemData PrevItData; 

    private GameObject previewOb;
    private bool pending;

    private bool attachCol;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(previewOb);
        attachCol = false;
        pending = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(Cancel))
        {
            DefaultSet();
        }
        if(pending)
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            if(Physics.Raycast(transform.position, transform.forward* previewDist, out hit, previewDist, previewLayer))
            {
                previewOb.SetActive(true);

                previewOb.transform.rotation = Quaternion.FromToRotation(hit.transform.up, hit.normal);
                previewOb.transform.position = hit.point + previewOb.transform.up * (PrevItData.yScale/2);

                //previewOb.transform.rotation = Quaternion.FromToRotation(hit.transform.forward, hit.normal);
                
            }
            else
            {
                previewOb.SetActive(false);
            }
        }
    }

    public void DefaultSet()
    {
        pending = false;
        Destroy(previewOb);
    }

    public GameObject Selected
    {
        get { return previewOb; }
        set 
        {
            if (pending) return;
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = transform.position.z;
            previewOb = Instantiate(value, mousePos, Quaternion.identity);
            PrevItData = previewOb.GetComponent<PreviewItemData>();
            pending = true;
            PrevItData.ChangeMat(Red);
            PrevItData.SetMats(Green, Red, this);
        }
    }
}
