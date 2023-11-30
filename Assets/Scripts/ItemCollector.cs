using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int orbs = 0;

    [SerializeField] TMPro.TextMeshProUGUI orbsText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Orb"))
        {
            Destroy(other.gameObject);
            orbs++;
            orbsText.text = "Orb Frags: " + orbs;
        }
    }
}
