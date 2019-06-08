using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScaleXY : MonoBehaviour
{
    [SerializeField]
    Vector2 scaleRange;

    private void OnEnable()
    {
        Vector3 scale = transform.localScale;
        float newVal = UnityEngine.Random.Range(scaleRange.x, scaleRange.y);
        Vector3 newScale = new Vector3(newVal, newVal, scale.z);
        transform.localScale = newScale;
    }
}
