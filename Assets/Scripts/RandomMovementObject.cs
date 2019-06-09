using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementObject : RandomMovement
{
    [SerializeField]
    Transform obj;


    // Update is called once per frame
    new void Update()
    {
        if (movementVector != Vector3.zero)
        {
            Vector3 pos = obj.position;
            pos += movementVector * speed * Time.deltaTime;
            obj.position = pos;
        }
    }

    new private void OnEnable()
    {
        base.OnEnable();
    }
}
