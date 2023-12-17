using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;

    private enum MovemenState { idle, running }
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private bool isChasing;
    [SerializeField] private float chaseDistance;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {


        if (isChasing)
        {
            anim.SetBool("running", true);
            Vector3 direction = new Vector3 (playerTransform.position.x - transform.position.x,0f).normalized;
            sprite.flipX = (direction.x < 0);
            transform.position += direction * speed * Time.deltaTime;

             if (Vector2.Distance(transform.position, playerTransform.position) > chaseDistance)
                {
                isChasing = false;
                anim.SetBool("running", false);
                }
        }
         else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }
        }
    }
}
