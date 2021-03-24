using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    [Header("Soud")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume;
    [SerializeField] AudioClip flyUpSound;
    [SerializeField] [Range(0, 1)] float flyUPSoundVolume;
    [SerializeField] AudioClip wingsFlappSound;
    [SerializeField] [Range(0, 1)] float wingsFlappSoundVolume;


    [SerializeField] float velocity = 1f;  // [SerializeField] == public
    [SerializeField] Manager manager;
    Rigidbody2D rb;
    private bool isAlreadyTouched = false;
    private bool gameOver = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAlreadyTouched)  // false == !
        {
            isAlreadyTouched = true;
            rb.isKinematic = false;
            FindObjectOfType<PipeSpawner>().StartSpawning();
            manager.DisableStartUI();
            manager.EnableScore();
            PlayeFlyUpSound();
            rb.velocity = Vector2.up * velocity;
        }
        if (Input.GetMouseButtonDown(0) && transform.position.y < 1.1f && gameOver == false) 
        {
            PlayeFlyUpSound();
            rb.velocity = Vector2.up * velocity; 
        }
        if(gameOver == false)
        { 
           transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * 20f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver = true;
        PlayeDeathSound();
        manager.GameOver();
    }

    private void PlayeWingsFlappSound()
    {
        if(wingsFlappSound == null) { return; }
        AudioSource.PlayClipAtPoint(wingsFlappSound, Camera.main.transform.position, wingsFlappSoundVolume);
    }

    private void PlayeFlyUpSound()
    {
        if (flyUpSound == null) { return; }
        AudioSource.PlayClipAtPoint(flyUpSound, Camera.main.transform.position, flyUPSoundVolume);
    }

    private void PlayeDeathSound()
    {
        if (deathSound == null) { return; }
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
