using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sell : MonoBehaviour
{
    public int numCustomers = 0;

    public int money = 0;
    float customerTimer = 0;
    public AudioClip coinsound;
    public AudioClip bellsound;

    public TextMeshProUGUI moneyLabel;
    public TextMeshProUGUI customerLabel;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
        customerTimer += Time.deltaTime;
        if (customerTimer > 10)
        {
            customerTimer = 0;
            numCustomers++;
            source.clip = bellsound;
            source.Play();
        }

        moneyLabel.text = "cash: " + money.ToString();
        customerLabel.text = "number of customers: " + numCustomers.ToString();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CoffeeCup>() != null)
        {
            if (other.GetComponent<CoffeeCup>().isEmpty == false && other.GetComponent<CoffeeCup>().lidded && numCustomers > 0 && other.GetComponent<Grab>().isGrabbed == false)
            {
                money += 10;
                numCustomers--;
                source.clip = coinsound;
                source.Play();
                Destroy(other.gameObject);
            }
        }
    }
}
