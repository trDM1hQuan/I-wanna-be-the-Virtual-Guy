using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatform : MonoBehaviour
{
    private float fallDelay = 0.5f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;

    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("On", true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
            anim.SetBool("On", false);
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
