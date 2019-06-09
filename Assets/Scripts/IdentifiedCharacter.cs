using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IdentifiedCharacter : MonoBehaviour
{
    protected string id = "";

    public string Id
    {
        get
        {
            return id;
        }
    }
    protected void GenerateIdentifier()
    {
        id = System.Guid.NewGuid().ToString();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        GenerateIdentifier();
    }
}
