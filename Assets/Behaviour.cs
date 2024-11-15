using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Behaviour : MonoBehaviour
{

    private static int instanceCount = 0;
    public float Speed { get; private set; } = 5f;

    [Range(0.1f, 10f)]
    [SerializeField] private float speedMultiplier = 1f;

    private void Awake()
    {
        instanceCount++;
        Debug.Log("ExampleBehaviour instance created. Total instances: " + instanceCount);
    }

    private void Update()
    {
        Speed += Time.deltaTime * speedMultiplier;
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        Debug.Log("Current Speed: " + Speed);
    }
    private void OnDestroy()
    {
        instanceCount--;
        Debug.Log("ExampleBehaviour instance destroyed. Remaining instances: " + instanceCount);
    }
}
