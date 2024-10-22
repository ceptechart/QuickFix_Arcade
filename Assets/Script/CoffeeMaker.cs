using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : MonoBehaviour
{
    public Transform fullCup;
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CoffeeCup>())
        {
            if (other.GetComponent<CoffeeCup>().isEmpty && !other.GetComponent<Grab>().isGrabbed)
            {
                Vector3 ncPos = spawnPos.position - other.transform.position;
                Quaternion ncRot = other.transform.rotation;
                Destroy(other.gameObject);
                CoffeeCup newCup = Instantiate(fullCup, spawnPos.position - ncPos, ncRot).GetComponent<CoffeeCup>();
                newCup.isEmpty = false;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
