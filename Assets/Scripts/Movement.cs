using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Controller MyInputMap;

    private Rigidbody2D rb2D;

    private PoolScript bulletPool;

    public int speed;

    private void Awake()
    {
        MyInputMap = new Controller();
        bulletPool = GameObject.Find("BulletPool").GetComponent<PoolScript>();
    }
    void Start()
    {
        MyInputMap.Enable();
        rb2D = GetComponent<Rigidbody2D>();

        MyInputMap.Keyboard.Shoot.performed += Shoot;
    }

    
    private void FixedUpdate()
    {
        MoveSprite();
    }

    private void MoveSprite()
    {
        Vector2 direction = new Vector2(0, MyInputMap.Keyboard.MovementY.ReadValue<float>());
        rb2D.AddForce(direction * speed);


    }
    private void Shoot(InputAction.CallbackContext context)
    {
        GameObject bullet = bulletPool.RequestObject();
        bullet.SetActive(true);
        bullet.transform.position = transform.position;
    }
}
