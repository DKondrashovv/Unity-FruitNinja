using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    [SerializeField] private ParticleSystem Particle;
    private GameManager gameManager;
    [SerializeField] private int pointValue;
    [SerializeField] private float minSpeed = 25;
    [SerializeField] private float maxSpeed = 30;
    [SerializeField] private float maxTorque = 12;
    [SerializeField] private float xRange = 6;
    [SerializeField] private float ySpawnPos = -6;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    private void OnMouseDown()
    {   
        Destroy(gameObject);
        Instantiate(Particle, transform.position, Quaternion.identity);
        gameManager.UpdateScore(pointValue);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
