using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShottyController : BaseTower
{
    public override void Shoot()
    {
        for(int j = 0; j < bulletSpawnPositions.Length; j++)
            for(int i = 0; i < 5; i++)
            Instantiate(bullet, bulletSpawnPositions[j].transform.position, transform.rotation * Quaternion.Euler(0,0, (i*5)-15f));
        Instantiate(flash, bulletSpawnPositions[0].transform.position, transform.rotation);
        src.Play();
        cools = shootSpeed;
        base.Shoot();
    }
}
