using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlProto : MonoBehaviour
{
    public GameObject ModelFrame;

    public SensorAttachor SensorAt;

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody[] rb;
    [SerializeField] private float yOffset;
    [SerializeField] private GameObject EditPos;

    [SerializeField] private GameObject[] Frames;
    [SerializeField] private Vector3[] FramesPos;
    //this will be furthered on later. When the scene loads the level data this will be set. Value rn is place holder
    public Vector3 PlayPos = new Vector3(0f,1f,0f);

    private void Awake()
    {
        SensorAt.AgentControl = this;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!SensorAt.editMode) return;
        ModelFrame.transform.position = rb[0].transform.position + new Vector3(0f, yOffset, 0f);
        //Have Some Check for edit mode from SensorAt idk.


    }
    private void Move(Rigidbody rb)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        ModelFrame.transform.position = rb.transform.position + new Vector3(0f, yOffset, 0f);
        float forwardTranY = rb.transform.forward.y;
        float forwardTranZ = rb.transform.forward.z;
        if (movement == new Vector3(0, 0, 0))
        {
            Vector3.RotateTowards(new Vector3(0f, forwardTranY, 1f), new Vector3(0f, 0f, 0f), 0.5f, 0.0f);
            ModelFrame.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }

        else
        {
            //Later on make smoother rotation for staying still
            //Maybe remove this part so the players can add sensors 


            //Debug.Log(forwardTranY);
            //Vector3 newDirection = Vector3.RotateTowards(new Vector3(movement.x, forwardTranY, movement.z), movement * speed, 2f, 0.0f);

            //Vector3 rotateNew = newDirection + new Vector3(0f, -0.5f, 0f);
            //rotateNew.z = Mathf.Clamp(rotateNew.z, -1, 1);
            //Debug.Log(newDirection);
            //ModelFrame.transform.rotation = Quaternion.LookRotation(rotateNew);
        }
    }
    public void ToggleState(bool edit)
    {
        if(edit)
        {
            transform.position = EditPos.transform.position;
            //make for loop later
            rb[0].isKinematic = false;
            
        }
        else
        {
            transform.position = PlayPos;
            rb[0].isKinematic = true;
            for (int i = 0; i < Frames.Length; i++)
            {
                Debug.Log(FramesPos[i]);
                Frames[i].transform.position = FramesPos[i];
            }
        }
    }
}
