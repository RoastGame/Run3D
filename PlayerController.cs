using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField]
    private float pushForce = 200f;

    private float movement;

    [SerializeField]
    private float speed = 5f;
    public Vector3 respawnPoint;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint= this.transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
      movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {

        rb.AddForce(0, 0, pushForce * Time.deltaTime,ForceMode.Force);
        rb.velocity = new Vector3(movement * speed, rb.velocity.y , rb.velocity.z);
        FallDetector();
    }

    private void OnCollisionEnter(Collision other)
    {
        //bariere çarptýðýnda çalýþacak fonksiyon
        if(other.collider.CompareTag("Barier"))
        {
            gameManager.RespawnPlayer();
        }
    }

    private void FallDetector()
    {
        if(rb.position.y < -2f)
        {
            gameManager.RespawnPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndTrigger"))
        { 
             gameManager.LevelUp();
        }
    }

}

