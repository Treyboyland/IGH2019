using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    protected T objectPrefab;

    [SerializeField]
    protected bool canIncrease;

    [SerializeField]
    protected int initialSize;

    protected List<T> objectPool = new List<T>();

    // Start is called before the first frame update
    protected void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        for (int i = 0; i < initialSize; i++)
        {
            AddObjectToPool();
        }
    }

    protected T AddObjectToPool()
    {
        T obj = Instantiate(objectPrefab);
        obj.gameObject.SetActive(false);
        objectPool.Add(obj);
        return obj;
    }

    /// <summary>
    /// Returns an object from the pool, if possible. This object will not be active by default.
    /// </summary>
    /// <returns></returns>
    public T GetObject()
    {
        foreach (T obj in objectPool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                return obj;
            }
        }

        if (canIncrease)
        {
            return AddObjectToPool();
        }

        return null;
    }

    public int GetActiveObjects()
    {
        int count = 0;
        foreach (T obj in objectPool)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                count++;
            }
        }

        return count;
    }
}
