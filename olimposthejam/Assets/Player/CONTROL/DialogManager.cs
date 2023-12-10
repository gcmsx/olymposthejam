using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public GameObject dialogPanel;
    public DialogTask[] tasks;

    private int currentTaskIndex = 0;

    void Start()
    {
        ShowCurrentTask();
    }

    void Update()
    {
        // Eğer tüm görevler tamamlandıysa dialog panelini kapat
        if (currentTaskIndex >= tasks.Length)
        {
            dialogPanel.SetActive(false);
            return;
        }
    }

    void ShowCurrentTask()
    {
        // Eğer tüm görevler tamamlandıysa dialog panelini kapat
        if (currentTaskIndex >= tasks.Length)
        {
            dialogPanel.SetActive(false);
            return;
        }

        // Şu anki görevin mesajını ekrana yazdır
        dialogText.text = tasks[currentTaskIndex].message;
    }

    public void CompleteTaskByTag(string tag)
    {
        // Şu anki görevin tag'i ile alınan objenin tag'i eşleşiyorsa görevi tamamla
        if (currentTaskIndex < tasks.Length && tasks[currentTaskIndex].isCompleted == false)
        {
            if (GameObject.FindGameObjectWithTag(tag) != null)
            {
                // Görevi tamamlanan olarak işaretle
                tasks[currentTaskIndex].isCompleted = true;

                // Bir sonraki göreve geç
                currentTaskIndex++;

                // Yeni görevi göster
                ShowCurrentTask();
            }
        }
    }
}