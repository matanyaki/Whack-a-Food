using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManger gameManger;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xSpawnPos = 4;
    private float ySpawnPos = -2;

    public ParticleSystem explosionParticle;
    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManger = GameObject.Find("Game Manger").GetComponent<GameManger>();

        targetRb.AddForce(RandomForce() , ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque() , RandomTorque(), RandomTorque()  ,ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(gameManger.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManger.UpdateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManger.GameOver();
        }
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
        return  new Vector3(Random.Range(-xSpawnPos , xSpawnPos), ySpawnPos );
    }

   
}
