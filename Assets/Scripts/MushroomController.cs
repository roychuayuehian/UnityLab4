using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    private float originalX;
    public float maxOffset = 5.0f;
    public float enemyPatroltime = 2.0f;
    private int moveRight = 1;
    private Vector2 velocity;
    private bool hit = false;
    public SpriteRenderer spriteRenderer;
    public Sprite usedMush;
    bool collected;

    private Rigidbody2D mushBody;

    void Start()
    {
        mushBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
        mushBody.AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        collected = false;
    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }
    void MoveMush()
    {
        mushBody.MovePosition(mushBody.position + velocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        if ((Mathf.Abs(mushBody.position.x - originalX) < maxOffset) && !hit)
        {// move gomba
            MoveMush();
        }
        else if (!hit)
        {
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            MoveMush();
        }
        else
        {

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pipe") && !hit)
        {
            moveRight *= -1;
            ComputeVelocity();
            MoveMush();
        }
        if (col.gameObject.CompareTag("Player"))
        {
            if (!hit)
            {
                mushBody.AddForce(Vector2.up * 50, ForceMode2D.Impulse);
                spriteRenderer.sprite = usedMush;
            }
            collected = true;
            mushBody.mass = 0.01f;
            Debug.Log("hit mush");
            //mushBody.velocity = Vector2D.zero;
            hit = true;
            //mushBody.MovePosition(mushBody.position);
            
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
