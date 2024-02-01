using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 0;
    private Rigidbody2D WallRB2D;
    private Collider2D WallCol;
   [SerializeField] private GameObject WallObject;
    public bool GameRunning = true;
    void Start()
    {
        WallRB2D = GetComponent<Rigidbody2D>();
        WallCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
            WallRB2D.velocity = Vector2.left * MoveSpeed;  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            print("Destroyer meet");
            Destroy(WallObject);
        }
    }

}
