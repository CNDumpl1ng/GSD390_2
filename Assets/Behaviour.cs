using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Behaviour : MonoBehaviour
{
    //public float Speed { get; private set; } is a property that controls access to the Speed variable. It allows other classes to read the speed but not modify it, ensuring safe access.
    //[Range(0.1f, 10f)] is an attribute applied to speedMultiplier, allowing you to adjust the multiplier within a specified range in the Unity Inspector.
    //private static int instanceCount is a static variable shared across all instances of ExampleBehaviour. It tracks the number of active instances in the scene, useful for counting or global information.
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
