using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lid : MonoBehaviour
{
    public Transform lidded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.GetComponent<CoffeeCup>() != null) {
            if (!collision.gameObject.GetComponent<CoffeeCup>().isEmpty)
            {
                Vector3 newCupPos = collision.gameObject.transform.position;
                Quaternion newCupRot = collision.gameObject.transform.rotation;
                Destroy(collision.gameObject);
                Transform newCup = Instantiate(lidded, newCupPos, newCupRot);
                newCup.GetComponent<CoffeeCup>().isEmpty = false;
                newCup.GetComponent<CoffeeCup>().lidded = true;
                Destroy(gameObject);
            }
        }
    }
}
