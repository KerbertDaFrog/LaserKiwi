using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public GameObject pickupEffect;

    public int HealthAdd = 25;

    public int ArmorAdd = 25;

    private bool immune;

    public int multiplier = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        if(pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
        }
        
        if(gameObject.tag == "Speed")
        {
            player.GetComponent<PlayerMovement>().moveSpeed *= multiplier;
        }

        if(gameObject.tag == "Health")
        {
            player.GetComponent<PlayerHealthManager>().currentHealth += HealthAdd;
        }

        Destroy(gameObject);
    }
}
