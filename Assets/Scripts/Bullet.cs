using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private int speed;
    [SerializeField] private float pushForce;
    [SerializeField] private int damage;
    [SerializeField] private float timeToDespawn;

    private float despawnTimer;

    void Start()
    {
        despawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        despawnTimer += Time.deltaTime;

        if (despawnTimer >= timeToDespawn)
        {
            transform.parent.GetComponent<PoolScript>().TurnOffObjects(gameObject);
            despawnTimer = 0;
        }
    }

}
