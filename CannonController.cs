using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : BaseTower
{
    public override void Shoot()
    {
        Instantiate(bullet, bulletSpawnPositions[0].transform.position, transform.rotation);
        Instantiate(flash, bulletSpawnPositions[0].transform.position, transform.rotation);
        src.Play();
        cools = shootSpeed;
        base.Shoot(); 
    }
}
