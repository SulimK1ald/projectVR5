using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerColor : MonoBehaviour
{
    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void Green()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void Black()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    public void Blue()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
    
    public void Yellow()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void activateRigidbody()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
