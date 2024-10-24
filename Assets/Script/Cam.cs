using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform lookAt;
    public bool lookAtEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void  FixedUpdate()
    {
        if (lookAtEnabled)
        {
            Vector3 dir = lookAt.position - transform.position;
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, 1-Mathf.Pow(0.01f, Time.deltaTime));
        }
    }
}
