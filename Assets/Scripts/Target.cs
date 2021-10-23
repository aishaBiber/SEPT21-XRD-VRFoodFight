using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Target : MonoBehaviour
{
    public float moveSpeed;
    public float moveAmount;
    public float spinUpAmount;

    private float score; 
    public AudioSource audioPlayer;
    public AudioClip foodExplosion; 

    private Vector3 StartPosition;
    private GameManager manager;

    [SerializeField] TMP_Text scoreText;

    public int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        manager = FindObjectOfType<GameManager>();

        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = transform.position;

        newPosition.x = StartPosition.x + Mathf.Sin(Time.time * moveSpeed) * moveAmount;
        newPosition.y = StartPosition.y + Mathf.Sin(Time.time * moveSpeed * 5) * spinUpAmount;
        transform.position = newPosition;



        scoreText.text = currentScore.ToString("f0");
    }

    private void OnCollisionEnter(Collision collision)
    {
        var food = collision.gameObject.GetComponent<ThrowableObject>();


       


        if (food != null)
        {

            currentScore = currentScore + 1; 
            Debug.Log(currentScore);


            audioPlayer.PlayOneShot(foodExplosion);
            Destroy(food.gameObject); 

           

            manager.SpawnTarget();

            Destroy(gameObject);

            //Add score
            //Spawn another chick!
        }
    }
}
