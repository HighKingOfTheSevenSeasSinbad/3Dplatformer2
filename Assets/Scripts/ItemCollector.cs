using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    int orbs = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Orb"))
        {
            Destroy(other.gameObject);
            orbs++;
            Debug.Log("Orbs: " + orbs);
        }
    }
}
