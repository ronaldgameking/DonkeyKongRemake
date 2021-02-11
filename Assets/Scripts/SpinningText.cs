using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningText : MonoBehaviour
{
    [SerializeField] [ReadOnly] float timer;

    public float maxSpeed = 4f;
    public float resetTo = 1f;

    void Update()
    {
        transform.Rotate(Vector3.back * timer);
        timer += Time.deltaTime;
        if (timer > maxSpeed)
        {
            timer = resetTo;
        }
    }
}
