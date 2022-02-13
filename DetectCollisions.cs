using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public Player playerController;
    public DeathSound dSound;
    public GameObject soundFile;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.Find("Player");
       playerController = player.GetComponent<Player>();
       soundFile = GameObject.Find("Cow Sound");
       dSound = soundFile.GetComponent<DeathSound>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other)
    {

        //Destroy(gameObject);
        if(other.gameObject.tag == "Projectile")
        {
            dSound.deathSoundCow();
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Animal FED !");
            
        }
        if(other.gameObject.tag == "Cow")
        {
            dSound.deathSoundCow();
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Cow death sound played");
        }

        if(other.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            //Destroy(other.gameObject);
            Debug.Log("Animal jumped yo Ass");
            
            playerController.TakeDamage(15);
            /*if(playerController.currentHealth <= 0)
            {
                Destroy(other.gameObject);
            }*/
        }
        
    }

    
}
