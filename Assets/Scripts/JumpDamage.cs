using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D coll;
    public Animator anim;
    public SpriteRenderer sprite;
    public GameObject destroy;
    public float jumpForce = 2.5f;
    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LosseLifeAndHit();
            CheckLife();
        }
    }
    public void LosseLifeAndHit()
    {
        lifes--;
        anim.Play("M_HIT");
    }
    public void CheckLife()
    {
        destroy.SetActive(true);
        sprite.enabled = false;
        Invoke("EnemyDie", 0.2f);
    }
    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
