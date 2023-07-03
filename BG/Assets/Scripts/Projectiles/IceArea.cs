using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceArea : IceCyclops
{

    private void Hit()
    {
        Player.HealthPoint -= 10;
        Player.playerFreeze += 1f;
    }

}
