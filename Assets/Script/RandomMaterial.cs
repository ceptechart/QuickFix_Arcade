using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = materials[Random.Range(0,materials.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
