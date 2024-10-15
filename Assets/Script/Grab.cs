using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grab : MonoBehaviour
{
    Transform grabTarget;
    bool isGrabbed = false;

    public bool isHighlight = false;
    float lineAmt = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isHighlight) 
        {
            lineAmt = 1.1f;
        } else
        {
            lineAmt = 0f;
        }
        gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_Amount", lineAmt);

        if (grabTarget != null && isGrabbed)
        {
            transform.position = grabTarget.position;
        }
    }
    public Grab highlight()
    {
        isHighlight = true;
        return this;
    }
    public void unhighlight()
    {
        isHighlight = false;
    }
    public Grab grab(Transform to)
    {
        isGrabbed = true;
        grabTarget = to;
        GetComponent<BoxCollider>().enabled = false;
        return this;
    }
    public void letgo()
    {
        isGrabbed = false;
        grabTarget = null;
        GetComponent<BoxCollider>().enabled = true;
    }
}
