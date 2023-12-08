using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StapeliaGames
{
    public class PlayerInspect : MonoBehaviour
    {
        public float distance;
        public Transform playersocket;

        public Transform playerbag;

        Vector3 originalPos;
        public static bool onInspect = false;
        GameObject inspected;
        public LookingScript PlayerLookAround ;
        public MovementScript playerscript;
        

        public void Update()
        {
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, fwd, out hit, distance))
            {
                if (hit.transform.tag == "Object" && !onInspect)
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        inspected = hit.transform.gameObject;
                        originalPos = hit.transform.position;

                        onInspect = true;

                        StartCoroutine(pickupItem());
                    
                    }
                }
            }
            
            if (onInspect)
            {
                inspected.transform.position = Vector3.Lerp(inspected.transform.position, playersocket.position, 0.2f);
                playersocket.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 125f);

            }
            else if(inspected != null) 
            {
                inspected.transform.SetParent(null);
                inspected.transform.position = Vector3.Lerp(inspected.transform.position, originalPos, 0.2f);
            }
            if(Input.GetKeyDown(KeyCode.F)&& onInspect==true)
            {
                StartCoroutine(dropItem());
                onInspect = false;
            }       
        }  
        
        IEnumerator pickupItem()
        {
            PlayerLookAround.enabled = false;
            playerscript.enabled = false;
            yield return new WaitForSeconds(0.2f);
            inspected.transform.SetParent(playersocket);
        }
        
        IEnumerator dropItem()
        {
            inspected.transform.rotation = Quaternion.identity;
            yield return new WaitForSeconds(0.2f);
            playerscript.enabled = true;
            PlayerLookAround.enabled = true;
        }
    }
}
