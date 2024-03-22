using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] private float moveSpeed = 2.5f;
    
    Vector2 minBound;
    Vector2 maxBound;
    Shooter shooter;
    Health health;
    private void Awake()
    {
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
    }
    private void Start()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        
    
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x+delta.x, minBound.x+(float)0.3, maxBound.x-(float)0.3);
        newPos.y = Mathf.Clamp(transform.position.y+delta.y, minBound.y + (float)0.5, maxBound.y - (float)0.5);
        transform.position = newPos;
    }

    void OnMove(InputValue inputValue)
    {
        rawInput = inputValue.Get<Vector2>();
    }
    void OnFire(InputValue value)
    {
        if(shooter != null) 
        {
            shooter.isFiring = value.isPressed;
        }
    }
    void SetAnim()
    {
        if(health.GetHealth()<0)
        {

        }
    }
}
