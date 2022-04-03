using UnityEngine;

public class ItemAutoDestruct : MonoBehaviour
{
    public int CollisionsForExplosion = 2;

    private int _remainingCollisions;

    private void OnEnable()
    {
        ResetCollisions();
    }

    public void ResetCollisions()
    {
        _remainingCollisions = CollisionsForExplosion;
    }

    void OnCollisionEnter(){
       BallCollision();
    }
    void OnTriggerEnter(){
       BallCollision();
    }



    public void BallCollision(){
        _remainingCollisions--;
        if(_remainingCollisions <= 0){
            gameObject.SetActive(false);
            GameObject go = Resources.Load("Prefabs/PlacableItems/ItemExplosion") as GameObject;
            Instantiate(go, transform.position, Quaternion.identity, MainScene.Instance.PlacableItemsRoot);
        }
    }
}
