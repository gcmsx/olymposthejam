using UnityEngine;

public class OxygenRefill : MonoBehaviour
{
    public float refillAmount = 100f; // Doldurulacak oksijen miktarı
    private bool isPlayerNear = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerState playerState = FindObjectOfType<PlayerState>();
            if (playerState != null)
            {
                // Oxygen tupu ile etkileşimde bulunulduğunda, oxygen barını doldur
                playerState.RefillOxygen(refillAmount);
                // Tup'ı yok etmek için
                
            }
        }
    }
}