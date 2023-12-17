using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounce = 20f;

    private Animator anim;
    private enum MovementState { OFF, ON };

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MovementState state = MovementState.OFF;

        if (collision.gameObject != null)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = collision.gameObject.AddComponent<Rigidbody2D>();
            }
            state = MovementState.ON;
            rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);

        }
        StartCoroutine(TurnOffAfterDelay(1.0f));
        anim.SetInteger("state", (int)state);
    }
    private IEnumerator TurnOffAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MovementState state = MovementState.OFF;
        anim.SetInteger("state", (int)state);
    }
}
