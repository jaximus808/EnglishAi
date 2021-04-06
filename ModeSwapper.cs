using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject AgentMode;
    [SerializeField] private GameObject CreatorMode;
    [SerializeField] private GameObject SensorUi;
    [SerializeField] private ItemPreviewer itemPrevScript;

    public ControlProto AgentControl;

    public Text StateText;
    
    bool agentMode;

    void Start()
    {
       
        agentMode = false;
        ChangeState();
    }


    // Update is called once per frame
    public void ChangeState()
    {
        Debug.Log("??");
        if(agentMode)
        {
            AgentMode.SetActive(false);
            CreatorMode.SetActive(true);
            SensorUi.SetActive(true);
            agentMode = false;
            StateText.text = "Mode: ModifyAgentMode";
            AgentControl.SensorAt.HandleMode(true);
            
        }
        else
        {
            AgentMode.SetActive(true);
            CreatorMode.SetActive(false);
            SensorUi.SetActive(false);
            agentMode = true;
            StateText.text = "Mode: AgentPlayMode";
            AgentControl.SensorAt.HandleMode(false);
            itemPrevScript.DefaultSet();
        }
    }
}
