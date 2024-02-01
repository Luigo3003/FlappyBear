using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlappyMovement : MonoBehaviour
{
    private Rigidbody2D FBRB2D;
    [SerializeField] private int velocity;
    private FlappyInputs FlappyInputMap;
    public Collider2D FlapCol;
    private SpriteRenderer FlappyRen;
    private bool FlappyIsAlive = true;

    private void Awake()
    {
        FlappyInputMap = new FlappyInputs();
    }
    void Start()
    {
        FlappyInputMap.Enable();
        FBRB2D = GetComponent<Rigidbody2D>();
        FlapCol = GetComponent<Collider2D>();
        FlappyRen = GetComponent<SpriteRenderer>();
        FlappyInputMap.FlappyController.Jump.performed += jump;
    }

    // Update is called once per frame
    void Update()
    {
        if(FlappyIsAlive == false)
        {
            FlappyInputMap.Disable();
            
        }
    }    

    private void jump(InputAction.CallbackContext context)
    {
       FBRB2D.velocity = Vector2.up * velocity;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            FlappyIsAlive = false;
        }
    }


}
