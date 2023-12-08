using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; set; }

    // ---- Player Health ---- //
    public float currentHealth;
    public float maxHealth;

    // ---- Player Calories ---- //
    public float currentCalories;
    public float maxCalories;

    float distanceTravelled = 0;
    Vector3 lastPosition;

    public GameObject playerBody;

    // ---- Player Oxigen ---- //
    public float currentOxigenPorcent;
    public float maxOxigenPorcent;
    public bool isOxigenActive;

    // ---- InventoryItem ---- //

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
  
        currentCalories = maxCalories;
        currentOxigenPorcent = maxOxigenPorcent;

        StartCoroutine(decreaseOxigen());
    }

    IEnumerator decreaseOxigen()
    {
        while (true)
        {
            currentOxigenPorcent -= 1;
            yield return new WaitForSeconds(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
        lastPosition = playerBody.transform.position;

        if (distanceTravelled >= 5)
        {
            distanceTravelled = 0;
            currentCalories -= 1;
        }

    }

    public void TakeDamage(float damage)
    {
        currentOxigenPorcent -= damage;

        if (currentOxigenPorcent <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Oyuncunun ölümü durumunda yapılacak işlemler burada yer alacak.
        // Mesela, oyunu durdurmak, ölüm animasyonunu oynatmak, veya başka bir sahneye geçmek gibi.
        // Aşağıdaki örnekte sadece ölüm mesajını ekrana yazdık.

        Debug.Log("Oyuncu Öldü!");
        // Burada istediğiniz diğer ölüm işlemlerini ekleyebilirsiniz.
    }


    public void setCalories(float calories)
    {
        currentCalories = calories;
    }

    public void setOxigen(float Oxigen)
    {
        currentOxigenPorcent = Oxigen;
    }
}
