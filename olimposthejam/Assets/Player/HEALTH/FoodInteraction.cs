using UnityEngine;

public class FoodInteraction : MonoBehaviour
{
    public float caloriesAmount = 50f; // Doldurulacak kalori miktarı
    private bool isPlayerNear = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerState playerState = FindObjectOfType<PlayerState>();
            if (playerState != null)
            {
                // Yemek ile etkileşimde bulunulduğunda, kalori barını doldur
                playerState.RefillCalories(caloriesAmount);
                // Yemeği yok etmek için
                
            }
        }
    }
}
