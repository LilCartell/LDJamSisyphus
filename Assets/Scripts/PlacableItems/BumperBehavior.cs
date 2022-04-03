using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehavior : MonoBehaviour
{

   public bool isFlipper;
   private float xForce = 0f; 
   private float zForce = 100f; 

     void OnTriggerEnter(Collider collider){
         if(isFlipper){
            xForce =Random.Range(-100.0f, 100f);
            zForce =Random.Range(50f, 200f);
            gameObject.GetComponent<Animator>().SetBool("isBumping", true);
         }
        MainScene.Instance.Ball.GetComponent<Rigidbody>().AddForce(xForce,150f, zForce, ForceMode.Impulse);
     }

     public void EndFlipperBump(){
         gameObject.GetComponent<Animator>().SetBool("isBumping", false);
     }
}
