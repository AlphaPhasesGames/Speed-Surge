using UnityEngine;
using TMPro;
namespace SSGFE.Alpha.Phases.Games
{
    public class RefinedCarController : MonoBehaviour
    {
        public Rigidbody sphereRB; // Rigidbody for the car's movement
        public TextMeshProUGUI speed; // UI text for the car's speed
        public AudioSource engineIdle;
        public AudioSource engine;
        public AudioSource skate;

        public bool engineAudioSelected;
        public bool skateAudioSelected;

        private bool runOnce;
        private bool runTwice;

        public int startingPitch = 1;
        public int timeToIncrease = 5;
        public int timeToDecrease = 1;
        public float pitchLimitMax = 2.2f;
        public float pitchLimitMin = 1;

        public float volumeTracker;
        public float minVolume = 0f;
        public float maxVolume = 1f;

        public float fwdSpeed; // Forward speed of the car (Default value set)
        public float revSpeed = 10f; // Reverse speed of the car (Default value set)
        public float turnSpeed = 50f; // Turn speed of the car (Default value set)
        public LayerMask groundLayer; // LayerMask for the ground

        private float moveInput; // Vertical input
        private float turnInput; // Horizontal input
        private bool isCarGrounded; // Check if the car is grounded

        public bool isCarActive = true; // Ensure the car is active by default

        public float acceleration;
        public float maxSpeed;
        public float minSpeed = 0f;
        public float maxTurn = 75f;
        public float minTurn = 0f;

        public float airDrag = 1f; // Drag in the air (Default value set)
        public float groundDrag = 3f; // Drag on the ground (Default value set)

        public float alignToGroundTime = 0.1f; // Time to align to the ground (Default value set)

        void Start()
        {
            // Detach the sphere Rigidbody from the car object
            sphereRB.transform.parent = null;
        }

        void Update()
        {
           
            HandleAudioSelection();
            HandleMovementInput();
            HandleSpeedLimit();
            HandleRotationAndDrag();

            
        }

        private void HandleAudioSelection()
        {
            if (!runOnce && engineAudioSelected)
            {
                engineIdle = engine;
                runOnce = true;
            }

            if (!runTwice && skateAudioSelected)
            {
                engineIdle = skate;
                runTwice = true;
            }

            skate.volume = volumeTracker;
        }

        private void HandleMovementInput()
        {
            if (!isCarActive) return;

            moveInput = Input.GetAxisRaw("Vertical"); // Forward/Reverse input
            turnInput = Input.GetAxisRaw("Horizontal"); // Turn input
            transform.position = sphereRB.transform.position;

           
            // Update the speed UI text
            speed.text = (sphereRB.velocity.magnitude * 3.6f).ToString("0"); // Convert speed to km/h

            // Adjust pitch and volume based on movement input
            if (moveInput > 0)
            {
              
                fwdSpeed += acceleration;
                AdjustPitch(timeToIncrease, pitchLimitMax);
                AdjustVolume(0.001f, maxVolume);
            }
            else if (moveInput < 0)
            {
                AdjustPitch(timeToDecrease, startingPitch);
                AdjustVolume(-0.001f, minVolume);
            }
            else
            {
                AdjustPitch(timeToDecrease, startingPitch);
                AdjustVolume(-0.005f, minVolume);
            }
        }

        private void AdjustPitch(float timeToAdjust, float limit)
        {
            if (!engineAudioSelected) return;

            engineIdle.pitch += Time.deltaTime * startingPitch / timeToAdjust;
            engineIdle.pitch = Mathf.Clamp(engineIdle.pitch, pitchLimitMin, limit);
        }

        private void AdjustVolume(float adjustment, float limit)
        {
            if (!skateAudioSelected) return;

            volumeTracker += adjustment;
            volumeTracker = Mathf.Clamp(volumeTracker, minVolume, limit);
        }

        private void HandleSpeedLimit()
        {
            if (!isCarActive) return;

            if (moveInput == 0) // if moveinput is 0 --- MAY BE REDUNDNANT SOON
            {
                fwdSpeed -= acceleration; // reduce forward speed by value set by accelleration value
                                          // turnSpeed -= turnAcceleration; // reduce turn speed by value set by turnacceleration value
            
            }

            // Limit the car's speed
            if (fwdSpeed > maxSpeed) // if forward speed is greated than the max speed
            {
                fwdSpeed = maxSpeed; // keep car at full speed until slowing down or stopping
            }

            if (fwdSpeed < minSpeed) // if forward speed is less than minimum speed
            {
                fwdSpeed = minSpeed;// == forward speed is kept at 0
            }
        }

        private void HandleRotationAndDrag()
        {
           

            RaycastHit hit;

            float raycastLength = 1.5f;
            Vector3 raycastOrigin = transform.position + Vector3.up * 0.5f;

            isCarGrounded = Physics.Raycast(raycastOrigin, -transform.up, out hit, raycastLength, groundLayer);

            Debug.DrawRay(raycastOrigin, -transform.up * raycastLength, Color.red); // Visualize the raycast

            if (isCarGrounded)
            {
                Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, alignToGroundTime * Time.deltaTime);
                transform.Rotate(0, turnInput * turnSpeed * Time.deltaTime, 0, Space.World);
                sphereRB.drag = groundDrag;
            }
            else
            {
                sphereRB.drag = airDrag;
            }
        }

       

        private void FixedUpdate()
        {
            if (!isCarActive) return;

            if (isCarGrounded)
            {
                Vector3 forceDirection = transform.forward * moveInput * (moveInput > 0 ? fwdSpeed : revSpeed);
                sphereRB.AddForce(forceDirection, ForceMode.Acceleration);
            }
            else
            {
                sphereRB.AddForce(Vector3.down * 60f); // Simulate gravity when in the air
            }
        }
    }
}

