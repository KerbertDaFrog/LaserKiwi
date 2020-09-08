using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
    public int multiplier = 10;

    void Speed(Collider player)
    {
        player.GetComponent<PlayerMovement>().moveSpeed *= multiplier;
    }
}
