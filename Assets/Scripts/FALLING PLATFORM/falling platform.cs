using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;

    private Animator anim;
    private enum MovemenState { ON, OFF };
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MovemenState state = MovemenState.OFF;
        if (collision.gameObject.CompareTag("Player"))
        {

            state = MovemenState.OFF;
            StartCoroutine(Fall());

        }
        anim.SetInteger("STATE", (int)state);
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
