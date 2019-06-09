using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScaler : MonoBehaviour
{
    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    Vector2 timeRange;

    [SerializeField]
    Vector2 scaleRange;

    [SerializeField]
    Vector2 waitRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        StartCoroutine(Randomize());
    }

    IEnumerator ScaleOverTime(float x, float y, float time)
    {
        helper.RestartTime();

        Vector2 start = new Vector2(transform.localScale.x, transform.localScale.y);
        Vector2 end = new Vector2(x, y);

        while (!helper.HasPassedTime(time))
        {
            float progress = helper.GetProgressTowardsTime(time);
            Vector3 newScale;
            newScale.x = Mathf.Lerp(start.x, end.x, progress);
            newScale.y = Mathf.Lerp(start.y, end.y, progress);
            newScale.z = transform.localScale.z;

            transform.localScale = newScale;
            yield return null;
        }

        transform.localScale = new Vector3(end.x, end.y, transform.localScale.z);
    }

    IEnumerator Wait(float time)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(time))
        {
            yield return null;
        }
    }

    IEnumerator Randomize()
    {
        while (true)
        {
            float x = UnityEngine.Random.Range(scaleRange.x, scaleRange.y);
            float y = UnityEngine.Random.Range(scaleRange.x, scaleRange.y);
            float time = UnityEngine.Random.Range(timeRange.x, timeRange.y);

            yield return StartCoroutine(ScaleOverTime(x, y, time));

            float waitTime = UnityEngine.Random.Range(waitRange.x, waitRange.y);
            yield return Wait(waitTime);

        }
    }
}
