using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    protected TimeHelper helper;

    [SerializeField]
    protected Vector2 randomSpeed;

    [SerializeField]
    protected Vector2 randomTime;

    [SerializeField]
    protected float speed;

    protected Vector3 movementVector;

    // Update is called once per frame
    protected void Update()
    {
        if (movementVector != Vector3.zero)
        {
            Vector3 pos = transform.position;
            pos += movementVector * speed * Time.deltaTime;
            transform.position = pos;
        }
    }

    protected void OnEnable()
    {
        StartCoroutine(MoveAround());
    }

    protected IEnumerator Wait(float seconds)
    {
        helper.RestartTime();
        while (!helper.HasPassedTime(seconds))
        {
            yield return null;
        }
    }

    protected IEnumerator MoveAround()
    {
        while (true)
        {
            bool stay = UnityEngine.Random.Range(0.0f, 1.0f) < 0.5f;
            float x = UnityEngine.Random.Range(0.0f, 1.0f);
            float y = UnityEngine.Random.Range(0.0f, 1.0f);

            movementVector = stay ? Vector3.zero : new Vector3(x, y, 0);
            speed = UnityEngine.Random.Range(randomSpeed.x, randomSpeed.y);

            float time = UnityEngine.Random.Range(randomTime.x, randomTime.y);

            yield return StartCoroutine(Wait(time));
        }
    }
}
