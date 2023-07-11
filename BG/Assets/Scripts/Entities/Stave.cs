using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stave : IceCyclops
{
    private IceCyclops cyclopsController;

    private void Start()
    {
        cyclopsController = GetComponentInParent<IceCyclops>();
    }

    private void Update()
    {
        Attack();
    }
}       