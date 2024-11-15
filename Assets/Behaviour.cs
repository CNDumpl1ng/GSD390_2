using UnityEngine;

public class TiltController : MonoBehaviour
{
    // Static variable to count the instances of TiltController
    private static int instanceCount = 0;

    // Property to manage tilt speed
    [SerializeField] private float tiltSpeed = 20f;
    public float TiltSpeed { get { return tiltSpeed; } set { tiltSpeed = Mathf.Max(0, value); } }

    // Adjustable tilt limit with an attribute for the Inspector
    [Range(0, 45)] // Restricts tilt limit between 0 and 45
    [SerializeField] private float tiltLimit = 30f;

    // Static variable for total ball distance
    private static float totalBallDistance = 0f;
    public static float TotalBallDistance => totalBallDistance;

    private float currentTiltX = 0f;
    private float currentTiltZ = 0f;

    // Ball object reference
    [SerializeField] private GameObject ball;

    // Speed for ball movement
    [SerializeField] private float ballSpeed = 5f;

    private void Awake()
    {
        // Increment the instance count
        instanceCount++;
        Debug.Log($"TiltController instance created. Total instances: {instanceCount}");
    }

    private void Update()
    {
        // Handle plane tilt
        HandleTilt();

        // Handle ball movement
        HandleBallMovement();
    }

    private void HandleTilt()
    {
        // Get player input for tilt
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        // Calculate tilt changes
        float tiltXChange = inputVertical * TiltSpeed * Time.deltaTime;
        float tiltZChange = -inputHorizontal * TiltSpeed * Time.deltaTime;

        // Update tilt angles within limits
        currentTiltX = Mathf.Clamp(currentTiltX + tiltXChange, -tiltLimit, tiltLimit);
        currentTiltZ = Mathf.Clamp(currentTiltZ + tiltZChange, -tiltLimit, tiltLimit);

        // Apply rotation to the plane
        transform.localRotation = Quaternion.Euler(currentTiltX, 0, currentTiltZ);
    }

    private void HandleBallMovement()
    {
        if (ball == null) return;

        // Get player input for ball movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate ball movement
        Vector3 movement = new Vector3(moveX, 0, moveZ) * ballSpeed * Time.deltaTime;

        // Update ball position and accumulate total distance
        ball.transform.Translate(movement, Space.World);
        totalBallDistance += movement.magnitude;

        Debug.Log($"Total ball distance traveled: {TotalBallDistance:F2}");
    }

    private void OnDestroy()
    {
        // Decrement the instance count
        instanceCount--;
        Debug.Log($"TiltController instance destroyed. Remaining instances: {instanceCount}");
    }
}
