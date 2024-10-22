using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSpawner : MonoBehaviour
{
    public Transform coffeeCup;
    Transform spawned;
    // Start is called before the first frame update
    void Start()
    {
        spawned = Instantiate(coffeeCup, transform.position, Quaternion.identity * Quaternion.AngleAxis(-90f, Vector3.right));
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(spawned == null))
        {
            if (Vector3.Distance(spawned.position, transform.position) > 2)
            {
                spawned = Instantiate(coffeeCup, transform.position, Quaternion.identity * Quaternion.AngleAxis(-90f, Vector3.right));
            }
        } else
        {
            spawned = Instantiate(coffeeCup, transform.position, Quaternion.identity * Quaternion.AngleAxis(-90f, Vector3.right));
        }
        print(spawned.GetInstanceID());
    }
}
