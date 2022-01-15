using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDie : RoleDie
{
    public override void Die(Transform trans)
    {
        base.Die(trans);

        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
        if (bosses.Length == 1)
        {
            GameMode.Instance.OnDogClear();
        }
    }

}
