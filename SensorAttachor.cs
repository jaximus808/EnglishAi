using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorAttachor : MonoBehaviour
{
    public GameObject[] Sensors;
    public GameObject[] SensorParents;

    public ControlProto AgentControl;
    public bool editMode = false;

    private void Start()
    {
        
        HandleMode(false);

    }

    public void HandleMode(bool edit)
    {
        if(edit)
        {
            for (int i = 0; i < SensorParents.Length; i++)
            {
                SensorParents[i].SetActive(true);
            }
            AgentControl.ToggleState(false);
            editMode = false;
        }
        else
        {
            for (int i = 0; i < SensorParents.Length; i++)
            {
                SensorParents[i].SetActive(false);
                SensorParents[i].transform.position = AgentControl.transform.position;
            }
            AgentControl.ToggleState(true);
            editMode = true;
        }
    }


}
