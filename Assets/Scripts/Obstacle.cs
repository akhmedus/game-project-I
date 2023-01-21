using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Range(0,200)]
    public List<float> speed;
    [Range(1, 10)]
    public List<float> time;

    private float currentSpeed;
    private float rotateTime, currentTime;

    private void Awake()
    {
        rotateTime = 0f;
        currentSpeed = speed[0] + (speed[1] - speed[0]) * .1f * Random.Range(0, 11);
        rotateTime = time[0] + (time[1] - time[0]) * .1f * Random.Range(0, 11);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > rotateTime)
        {
            currentTime = 0f;
            currentSpeed = speed[0] + (speed[1] - speed[0]) * .1f * Random.Range(0, 11);
            currentTime = time[0] + (time[1] - time[0]) * .1f * Random.Range(0, 11);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, currentSpeed * Time.fixedDeltaTime);
    }
}
