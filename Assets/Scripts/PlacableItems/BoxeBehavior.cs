using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxeBehavior : MonoBehaviour
{


   private float xForce = -200f; 
   private float yForce = 0f; 
   private float zForce = 100f; 

   public bool isRightBoxer;

     void OnTriggerEnter(Collider collider){

        if(isRightBoxer){
            xForce = 200f;
        }

        gameObject.GetComponent<Animator>().SetBool("isBoxing", true);
        
        MainScene.Instance.Ball.GetComponent<Rigidbody>().AddForce(xForce, yForce, zForce, ForceMode.Impulse);
        Debug.Log("cc");
     }

     public void EndBoxing(){
         gameObject.GetComponent<Animator>().SetBool("isBoxing", false);
     }
}
