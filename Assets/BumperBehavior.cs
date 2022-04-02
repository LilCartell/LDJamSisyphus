using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehavior : MonoBehaviour
{
     void OnTriggerEnter(Collider collider){
        MainScene.Instance.Ball.GetComponent<Rigidbody>().AddForce(0,150f, 100f, ForceMode.Impulse);
     }
}
