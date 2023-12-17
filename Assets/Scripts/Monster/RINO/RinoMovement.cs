using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float hucForce = 1000f;
    public float hucCooldown = 2f;
    public float chaseDistance = 10f;
    private bool isChasing = false;
    private bool canHuc = true;
    private enum MovemenState { idle, running }
    private Animator anim;
    private Rigidbody2D rb;
    private bool facingRight = true;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (canHuc && !isChasing && Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
        {
            anim.SetBool("running", true);
            HucTowardsPlayer();
        }
    }

    void HucTowardsPlayer()
    {
        isChasing = true;
        canHuc = false;

        Vector2 hucDirection = new Vector2(playerTransform.position.x - transform.position.x, 0f).normalized;

   
        rb.AddForce(hucDirection * hucForce, ForceMode2D.Impulse);

        if ((hucDirection.x > 0 && !facingRight) || (hucDirection.x < 0 && facingRight))
        {
            Flip();
        }

        Invoke("ResetHucCooldown", hucCooldown);
        CheckWallHit();
    }
    void CheckWallHit()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

        if (hit.collider != null)
        {
            anim.SetBool("hitwall", true);
        }
    }
    void ResetHucCooldown()
    {
        canHuc = true;
        isChasing = false;
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
}