using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerOneWayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;

    private void Update()
    {   
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentOneWayPlatform != null)
            {   
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        TilemapCollider2D platformCollider = currentOneWayPlatform.GetComponent<TilemapCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}