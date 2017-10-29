using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.IO;

namespace DaleranGames.SquadronLeader
{
    public class MouseSteering : MonoBehaviour
    {
        
        [Header("Steering Settings")]
        [SerializeField]
        [Range(0f,1f)]
        float stopCursorDistance = 0.1f;
        float stopPixels;
        [SerializeField]
        [Range(0f, 1f)]
        float maxSpeedCursorDistance = 0.8f;
        float maxPixels;

        [Header("Steering Information")]
        [ReadOnly]
        [SerializeField]
        float throttle;
        public float Throttle { get { return throttle; } }
        [ReadOnly]
        [SerializeField]
        Vector2 desiredVelocity;
        [ReadOnly]
        [SerializeField]
        Vector2 steering;

        Rect screenSpace;
        Rigidbody2D rb;
        Ship ship;

        private void Awake()
        {
            if (stopCursorDistance >= maxSpeedCursorDistance)
                Debug.Log("Error: Stop Cursor Distance cannot be greater than the max speed cursor distance");

            rb = gameObject.GetRequiredComponent<Rigidbody2D>();
            ship = gameObject.GetRequiredComponent<Ship>();
        }

        // Use this for initialization
        void Start()
        {
            SetUpScreenLimits();
        }

        // Update is called once per frame
        void Update()
        {
            desiredVelocity = CalculateDesiredVelocity();
        }

        private void FixedUpdate()
        {
            steering = CalculateSteeringForce();
            MoveShipTowardsSteering();
            RotateShipTovelocity();
        }

        void SetUpScreenLimits()
        {
            screenSpace = MouseCursor.Instance.ScreenCanvasRect;
            stopPixels = (screenSpace.height * 0.5f) * stopCursorDistance;
            maxPixels = (screenSpace.height * 0.5f) * maxSpeedCursorDistance;
        }

        Vector2 CalculateDesiredVelocity()
        {
            Vector2 targetDirection = MouseCursor.Instance.ScreenPosition - (Vector2)MainCamera.Instance.WorldToScreenPoint(transform.position);
            float targetDistance = targetDirection.magnitude;

            if (targetDistance <= stopPixels)
                throttle = 0f;
            else if (targetDistance > maxPixels)
                throttle = 1f;
            else
                throttle = (targetDistance - stopPixels) / (maxPixels - stopPixels);

            float desiredSpeed = ship.Class.MaxSpeed * throttle;

            return targetDirection.normalized * desiredSpeed;

        }

        Vector2 CalculateSteeringForce()
        {
            Vector2 steer = desiredVelocity - rb.velocity;
            return Vector2.ClampMagnitude(steer, ship.Class.MaxSteeringForce);
        }

        void MoveShipTowardsSteering()
        {
            rb.AddForce(steering);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, ship.Class.MaxSpeed);
        }

        void RotateShipTowardsCursor()
        {
            float angle = Vector2.SignedAngle(transform.up, desiredVelocity);

            if (angle <= ship.Class.RotationSpeed && angle >= -ship.Class.RotationSpeed)
                rb.MoveRotation(rb.rotation + angle * Time.fixedDeltaTime);
            else if (angle < - ship.Class.RotationSpeed)
                rb.MoveRotation(rb.rotation - ship.Class.RotationSpeed * Time.fixedDeltaTime);
            else if (angle > ship.Class.RotationSpeed)
                rb.MoveRotation(rb.rotation + ship.Class.RotationSpeed * Time.fixedDeltaTime);
        }

        void RotateShipTovelocity()
        {
            float angle = Vector2.SignedAngle(transform.up, rb.velocity);

            rb.MoveRotation(rb.rotation + angle);
        }

    }
}
