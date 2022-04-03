using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour
{   
     List<GameObject> otherPortals = new List<GameObject>();
     private Vector3 destinationPosition;

    void OnTriggerEnter(Collider collider){
        foreach (GameObject go in GameObject.FindGameObjectsWithTag ("Portal")) {
            if (go.Equals(this.gameObject))
                continue;
            otherPortals.Add(go);
        }   
        if(otherPortals.Count>0){
            int portalId = Random.Range(0, otherPortals.Count);
            destinationPosition = otherPortals[portalId].transform.position;            
            otherPortals[portalId].GetComponent<ItemAutoDestruct>().BallCollision();
            destinationPosition = new Vector3(destinationPosition.x, destinationPosition.y+0.04f, destinationPosition.z);
            MainScene.Instance.Ball.transform.position = destinationPosition;
        }
    }
}
