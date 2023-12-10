using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour
{
    public Text messageText;
    public PlayerState playerState;

    void Start()
    {
        // PlayerState'i bul
        playerState = FindObjectOfType<PlayerState>();
        // Metin başlangıçta boş olsun
        UpdateMessage("");
    }

    void Update()
    {
        // Oxygen durumu kontrolü
        if (playerState.currentOxigenPorcent < 50f)
        {
            // Oxigen 50% veya daha az ise mesajı güncelle
            UpdateMessage("Git ve Oxigenini Doldur");
        }
        // Calories durumu kontrolü
        else if (playerState.currentCalories < 250f)
        {
            // Calories 250 veya daha az ise mesajı güncelle
            UpdateMessage("Git ve Yemegini Doldur");
        }
        else
        {
            // Her iki durum da sağlanmıyorsa mesajı temizle
            UpdateMessage("");
        }
    }

    void UpdateMessage(string newMessage)
    {
        // Metin elemanına yeni mesajı yazdır
        messageText.text = newMessage;
    }
}
