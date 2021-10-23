using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float moveSpeed;
    public float moveAmount;
    public float spinUpAmount;

    public AudioSource audioPlayer;
    public AudioClip foodExplosion; 

    private Vector3 StartPosition;
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = transform.position;

        newPosition.x = StartPosition.x + Mathf.Sin(Time.time * moveSpeed) * moveAmount;
        newPosition.y = StartPosition.y + Mathf.Sin(Time.time * moveSpeed * 5) * spinUpAmount;
        transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var food = collision.gameObject.GetComponent<ThrowableObject>();


       


        if (food != null)
        {

            audioPlayer.PlayOneShot(foodExplosion);
            Destroy(food.gameObject, 1.5f); 

           

            manager.SpawnTarget();

            Destroy(gameObject);

            //Add score
            //Spawn another chick!
        }
    }
}
