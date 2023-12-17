using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAway : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed = 2f;

    private enum MovementState { idle, running }
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float fleeDistance; 

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < fleeDistance)
        {
            anim.SetBool("running", true);

            Vector3 fleeDirection = (transform.position - playerTransform.position).normalized;

            transform.position += fleeDirection * speed * Time.deltaTime;

            if (fleeDirection.x > 0)
                sprite.flipX = true;
            else
                sprite.flipX = false;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
