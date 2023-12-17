using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovenment : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    //private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private enum MovemenState { idle,running }
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private bool isChasing;
    [SerializeField] private float chaseDistance;

    // Start is called before the first frame update
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {


        if (isChasing)
        {
            anim.SetBool("running", true);
            if (transform.position.x > playerTransform.position.x)
            {
                sprite.flipX = true;
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (transform.position.x < playerTransform.position.x)
            {
               sprite.flipX = false;
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
            }           
            transform.position = transform.position;        }
    }
}
