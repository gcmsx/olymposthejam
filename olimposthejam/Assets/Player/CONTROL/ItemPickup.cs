using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    bool _inVicinity = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Check inputs as fast as you can
    void Update()
    {
        if (_inVicinity && Input.GetKeyDown("F"))
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            _inVicinity = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            _inVicinity = false;
        }
    }
 
}