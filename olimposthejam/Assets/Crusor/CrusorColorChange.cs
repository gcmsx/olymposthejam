using UnityEngine;
using UnityEngine.UI;

public class CanvasColorChange : MonoBehaviour
{
    public Image cursorImage; // Canvas üzerindeki resim
    public Color hoverColor = Color.green; // Üzerine gelindiğindeki renk
    public string targetTag = "Esya"; // Hedef objenin tag'i

    void Update()
{
    // Fare pozisyonundan ray oluştur
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    // Raycast ile nesne kontrolü
    if (Physics.Raycast(ray, out hit))
    {
        // Eğer nesnenin tag'i "Esya" ise
        if (hit.collider.CompareTag(targetTag) && cursorImage != null)
        {
            // Üzerine gelindiğinde rengi değiştir
            cursorImage.color = hoverColor;
        }
        else if (cursorImage != null)
        {
            // Ayrıldığında varsayılan rengi ayarla
            cursorImage.color = Color.white; // veya başka bir varsayılan renk
        }
    }
}

}
