using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDecorationMovement : MonoBehaviour
{
 private RectTransform rectTransform;
 private float HorizontalSpeed = 100f;
 public GameObject Brother;
 public bool GoesLeft;
 
 void Start ()
 {
     rectTransform = GetComponent<RectTransform>();     
 }
 
 void Update ()
 {  
    // Fait glisser le motif
     Vector2 position = rectTransform.anchoredPosition;
     if(GoesLeft){
        position.x -= HorizontalSpeed * Time.deltaTime; 
     }
     else{
        position.x += HorizontalSpeed * Time.deltaTime; 
     }
     
     rectTransform.anchoredPosition = position;

     RectTransform rt = GetComponent<RectTransform>();
     float left   =  rt.offsetMin.x;
     
     if(GoesLeft){
        if (-left > gameObject.GetComponent<RectTransform>().rect.width ){        
            Vector2 brotherPosition = Brother.GetComponent<RectTransform>().anchoredPosition;
            brotherPosition.x +=Brother.GetComponent<RectTransform>().rect.width-5;
            rectTransform.anchoredPosition = brotherPosition;
        }
     }
     else{
        if (left>gameObject.GetComponent<RectTransform>().rect.width ){            
            Vector2 brotherPosition = Brother.GetComponent<RectTransform>().anchoredPosition;
            brotherPosition.x -=Brother.GetComponent<RectTransform>().rect.width-1;
            rectTransform.anchoredPosition = brotherPosition;
         }
     }
        
 }
}
