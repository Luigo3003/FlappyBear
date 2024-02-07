using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 0;
    private Rigidbody2D WallRB2D;
    [SerializeField] private GameObject WallObject;
    [SerializeField] private float TimeActive;
    private float despawnTimer = 0;
    void Start()
    {
        WallRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        WallRB2D.velocity = Vector2.left * MoveSpeed;

        despawnTimer += Time.deltaTime;

        if (despawnTimer >= TimeActive)
        {
            transform.parent.GetComponent<PoolScript>().TurnOffObjects(gameObject);
            despawnTimer = 0;
        }
    }



}
