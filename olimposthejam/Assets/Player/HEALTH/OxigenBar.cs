using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxigenBar : MonoBehaviour
{
    private Slider slider;
    public Text oxigenCounter;

    public GameObject playerState;

    private float currentOxigen, maxOxigen;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentOxigen = playerState.GetComponent<PlayerState>().currentOxigenPorcent;
        maxOxigen = playerState.GetComponent<PlayerState>().maxOxigenPorcent;

        float fillValue = currentOxigen / maxOxigen;
        slider.value = fillValue;

        oxigenCounter.text = currentOxigen + "%";
    }
}