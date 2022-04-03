using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAutoDestruct : MonoBehaviour
{
    public int CollisionsForExplosion = 2;    

    void OnCollisionEnter(){
       BallCollision();
    }
    void OnTriggerEnter(){
       BallCollision();
    }



    public void BallCollision(){
        CollisionsForExplosion--;
        if(CollisionsForExplosion <=0){
            gameObject.SetActive(false);
            GameObject go = Resources.Load("Prefabs/PlacableItems/ItemExplosion") as GameObject;
            Instantiate(go, transform.position, Quaternion.identity, MainScene.Instance.PlacableItemsRoot);
        }
    }
}
