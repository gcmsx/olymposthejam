using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross : MonoBehaviour
{
    public GameObject standardCross;
    public GameObject redCross; 
    public GameObject greenCross; 

    RaycastHit hit;
    void Start ()
    {
    standardCross.gameObject.SetActive(true);
    }
 
 
   void Update()
   {
 
 
    if (Physics.Raycast(transform.position, transform.forward,out hit,100))
    {
      
       if (hit.transform.tag == "Object")
       {
        redCross.gameObject.SetActive(true);
        standardCross.gameObject.SetActive(false);
       }      

       else if (hit.transform.tag == "gen1" || hit.transform.tag == "o2recoil" )
       {
         greenCross.gameObject.SetActive(true);
         standardCross.gameObject.SetActive(false);
       }
       
        else if (hit.transform.tag == "gen2" || hit.transform.tag == "kjrecoil" )
       {
         redCross.gameObject.SetActive(true);
         standardCross.gameObject.SetActive(false);
       }

       else
       {
        redCross.gameObject.SetActive(false);
        greenCross.gameObject.SetActive(false);
        standardCross.gameObject.SetActive(true);
       }
      
    }
   }
}
