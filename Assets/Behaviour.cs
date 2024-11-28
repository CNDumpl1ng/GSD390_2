using UnityEngine;


public class TiltController : MonoBehaviour
{
    // Static variable to count the instances of TiltController
    private static int instanceCount = 0;

    // Property to get or set the tilt speed
    [SerializeField] private float tiltSpeed = 20f;

    // Adjustable tilt limit with an attribute for the Inspector
    [Range(0, 45)]
    [SerializeField] private float tiltLimit = 30f;

    private float currentTiltX = 0f;
    private float currentTiltZ = 0f;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Increment the instance count when an instance is created
        instanceCount++;
        Debug.Log("TiltController instance created. Total instances: " + instanceCount);
    }

    // Update is called once per frame
    private void Update()
    {
        // Get player input for tilting the plane
        float inputVertical = Input.GetAxis("Vertical");   // W/S keys
        float inputHorizontal = Input.GetAxis("Horizontal"); // A/D keys

        // Calculate tilt changes based on input
        float tiltXChange = inputVertical * tiltSpeed * Time.deltaTime;
        float tiltZChange = -inputHorizontal * tiltSpeed * Time.deltaTime;

        // Update cumulative tilt values, ensuring they stay within the tilt limit
        currentTiltX = Mathf.Clamp(currentTiltX + tiltXChange, -tiltLimit, tiltLimit);
        currentTiltZ = Mathf.Clamp(currentTiltZ + tiltZChange, -tiltLimit, tiltLimit);

        // Apply the cumulative tilt to the plane
        transform.rotation = Quaternion.Euler(currentTiltX, 0, currentTiltZ);
    }

    // OnDestroy is called when the object is destroyed
    private void OnDestroy()
    {
        // Decrement the instance count when an instance is destroyed
        instanceCount--;
        Debug.Log("TiltController instance destroyed. Remaining instances: " + instanceCount);
    }
}