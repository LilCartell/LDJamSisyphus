using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBallRotation : MonoBehaviour
{
     Vector3 rotationEuler;

    // Update is called once per frame
    void Update()
    {   
        rotationEuler+= Vector3.forward*-120*Time.deltaTime; //increment 30 degrees every second
        transform.rotation = Quaternion.Euler(rotationEuler);
    }
}
