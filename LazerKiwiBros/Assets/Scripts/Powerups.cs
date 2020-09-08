using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public GameObject pickupEffect;

    public int HealthAdd = 25;

    public int ArmorAdd = 25; 

    public int AmmoAdd = 50;

    public float timer = 30f;

    public bool powerupActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
            timer = 10;
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
            StartCoroutine(SpeedTime(10));
        }

        if(gameObject.tag == "Health")
        {
            player.GetComponent<PlayerHealthManager>().currentHealth += HealthAdd;
            Debug.Log("Picked up Health");
        }

        if(gameObject.tag == "Armor")
        {
            player.GetComponent<PlayerHealthManager>().currentArmor += ArmorAdd;
            Debug.Log("Picked up Armor");
        }

        if (gameObject.tag == "Invincibility")
        {
            player.GetComponent<PlayerHealthManager>().enabled = false;
            Debug.Log("Picked up Invincibility");
        }

        if (gameObject.tag == "Ammo")
        {
            player.GetComponentInChildren<GunController>().bulletAmount += AmmoAdd;
            Debug.Log("Picked up Ammo");
        }

        Destroy(gameObject);
    }

    IEnumerator SpeedTime (int duration)
    {
        Debug.Log("Power Up Activated");
        GetComponent<SpeedEffect>().enabled = true;
        yield return new WaitForSeconds(timer);
        GetComponent<SpeedEffect>().enabled = false;
        Debug.Log("Power Up Deactivated");
    }
}
