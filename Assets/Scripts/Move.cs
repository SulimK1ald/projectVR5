using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject rig;
    public GameObject obj;
    public GameObject handPos;
    public Rigidbody rb;
    bool dropTrue = false;

    public bool activeObj = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void TeleportRig()
    {
        rig.transform.position = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z); 
    }
    public void TeleportObj()
    {
        if (dropTrue == false)
        {
            activeObj = true;
            rb.isKinematic = true;
            rb.MovePosition(handPos.transform.position);
            //dropTrue = true;
            //obj.transform.position = new Vector3(handPos.transform.position.x, handPos.transform.position.y, handPos.transform.position.z);
        }
    }
    public void Drop()
    {
        activeObj = false;
        rb.isKinematic = false;
        dropTrue = false;

        //obj.transform.position = new Vector3(handPos.transform.position.x, handPos.transform.position.y, handPos.transform.position.z);
    }

    public void Update()
    {
        if (activeObj == true)
        {
            TeleportObj();
        }
    }
}
