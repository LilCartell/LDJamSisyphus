using UnityEngine;

public class ItemAutoDestruct : MonoBehaviour
{
    public int CollisionsForExplosion = 2;

    private int _remainingCollisions;

    public AudioClip ItemSound;

    public bool Invicible;

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
        SoundManager.Instance.PlayItemSound(ItemSound);
        if(!Invicible){
            _remainingCollisions--;
            if(_remainingCollisions <= 0){
                gameObject.SetActive(false);
                GameObject go = Resources.Load("Prefabs/PlacableItems/ItemExplosion") as GameObject;
                Instantiate(go, transform.position, Quaternion.identity, MainScene.Instance.PlacableItemsRoot);

                // Explosion Sound if not a portal
                if ( gameObject.tag != "Portal" ){
                    SoundManager.Instance.PlayExplosion();
                }
                
            }   
        }
        
    }
}
