using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Player player;

    // public AnimationClip death;
    //private Animation anim;

    public float horizontalMovement;
    public float verticalMovement;
    public float speed = 20.0f;
    public float xRange = 20.0f;
    public float zUpperBound = 15.0f;
    public float zLowerBound = 0.0f;

    public DeathSound dSound;
    public GameObject soundFile;


    public int maxHealth = 100;
    public int currentHealth;

    public HPBar healthBar;

    public GameObject projectile;
    //bool gameHasEnded = false;

    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        soundFile = GameObject.Find("Cow Sound");
        dSound = soundFile.GetComponent<DeathSound>();
        //anim = GetComponent<Animation>();

    }

    // Update is called once per frame


    public void Update()
    {
       
        
            // Collision for negative value on the X-Axis
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }
            // Collision for Positive value on the X-Axis
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.z > zUpperBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zUpperBound);
            }
            if (transform.position.z < zLowerBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zLowerBound);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Launch projectile
                Instantiate(projectile, transform.position, transform.rotation);
            }
            horizontalMovement = Input.GetAxis("Horizontal");
            verticalMovement = Input.GetAxis("Vertical");

            transform.Translate(Vector3.right * horizontalMovement * Time.deltaTime * speed);
            transform.Translate(Vector3.forward * verticalMovement * Time.deltaTime * speed);
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                TakeDamage(15);
            }*/
    }
        
    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        Debug.Log("-15 HP! in player class - takeDamage method");
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
        if(currentHealth > 15)
        {
       
             dSound.damageSoundPlayer();

        }
        if(currentHealth <= 0)
        {
                
            // game end
                //anim.Play(death.name);
                dSound.deathSoundPlayer();
                Invoke("Restart", 3f);
                
                Debug.Log("GAME OVER!");  
            
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TakeDamage(15);
            Debug.Log("-15 HP fom Player Class - OnTriggerEnter Method");
        }
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    


}
