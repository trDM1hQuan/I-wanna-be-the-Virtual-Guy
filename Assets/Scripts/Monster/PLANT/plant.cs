using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    private float waitedTime;
    private float waitTimeToAttack = 2f;
    public Animator anim;
    public GameObject bulletPrefab;
    public Transform launchSpawnPoint;

    private void Start()
    {
        waitedTime = waitTimeToAttack;
    }
    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            anim.Play("P_Attack");
            Invoke("LaunchBullet", 2f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }
    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet=Instantiate(bulletPrefab,launchSpawnPoint.position,launchSpawnPoint.rotation);
    }
}
