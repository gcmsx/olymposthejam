// www.stapeliagames.com


using UnityEngine;
using System.Collections;
using System;
namespace StapeliaGames
{
public class JumpScare : MonoBehaviour
{

    public AudioSource soundSource;
    public AudioClip scarySound;
    public GameObject scare1;
    public GameObject scare2;
    
    
    public GameObject delete1;
    public GameObject delete2;

    public GameObject subtitle;
   

    bool isPlayed;

    void Start()
    {
       
        isPlayed = false;
        soundSource.clip = scarySound;
        scare1.SetActive(false);
        scare2.SetActive(false);   
 
    }
    //Duvara girince.
    void OnTriggerStay(Collider Socket)
    {
       
        if(Socket.gameObject.tag == "Player" )
        {
            
            StartCoroutine(scare());
            StartCoroutine(altyazi());
            scare1.SetActive(true);
            scare2.SetActive(true);
        
                      
            delete1.SetActive(false);
            delete2.SetActive(false); 
            
            subtitle.SetActive(true);
                
        }   
       
  
    }
  
     IEnumerator altyazi()
    {        
       
      

        yield return new WaitForSeconds(2f);
        subtitle.SetActive(false);
    }

    

    IEnumerator scare()
    {
      if (!isPlayed) {
      soundSource.Play();
      
        isPlayed = true;            
       }
        yield return new WaitForSeconds(0.5f);
    }


}
}