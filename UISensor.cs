using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISensor : MonoBehaviour
{
    [SerializeField] private ItemPreviewer itemPrev;

    [SerializeField] private Text LayerDisplay;

    [SerializeField] private Button UpButtonComp;
    [SerializeField] private Button DownButtonComp;

    [SerializeField] private GameObject[] layers;
    [SerializeField] private GameObject player;

    private int layer = 0;

    private void Awake()
    {
        Color temp = UpButtonComp.image.color;
        temp.a = 0.5f;
        DownButtonComp.image.color = temp;

        LayerDisplay.text = $"Layer: {layer + 1}/{layers.Length}";
        layers[0].SetActive(true);
        for(int i = 1;i < layers.Length;i++)
        {
            layers[i].SetActive(false);
        }
    }

    public void PendingAttach(GameObject Sensor)
    {
        
        itemPrev.Selected = Sensor;
    }

    public void Alternate(int dir)
    {
        int newLay = layer + dir;
        if (newLay < 0 || newLay == layers.Length) return;
        layers[layer].SetActive(false);
        layer = newLay;
        layers[layer].SetActive(true);
        if(newLay == 0)
        {
            Color temp = UpButtonComp.image.color;
            temp.a = 0.5f;
            DownButtonComp.image.color = temp;
        }
        else if(newLay == layers.Length-1)
        {
            Color temp = UpButtonComp.image.color;
            temp.a = 0.5f;
            UpButtonComp.image.color = temp;
        }
        else
        {
            Color temp = UpButtonComp.image.color;
            temp.a = 1f;
            UpButtonComp.image.color = temp;
            DownButtonComp.image.color = temp;
        }
        LayerDisplay.text = $"Layer: {layer + 1}/{layers.Length}";

    }

}
