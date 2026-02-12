using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour

{
    public static Lander Instance { get; private set; }

    public event EventHandler OnUpForce;
    public event EventHandler OnLeftForce;
    public event EventHandler OnRightForce;
    public event EventHandler OnBeforeForce;
    public event EventHandler OnCoinPickUp;
    public event EventHandler<onLandedEventArgs> OnLanded;
    public class onLandedEventArgs : EventArgs
    {
        public int Score;
    }

    private Rigidbody2D landerRigidbody2D;
    private float fuelAmount = 10f;

    private void Awake()
    {
        Instance= this;
        landerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        OnBeforeForce?.Invoke(this, EventArgs.Empty);

       
        if (fuelAmount <= 0f)
        {
            return;
        }

        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed 
            || Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed
            || Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            consumeFuel();
        }
        // Move up
        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            float force = 700f;
            landerRigidbody2D.AddForce(
                transform.up * force * Time.deltaTime
            );
            consumeFuel();
            OnUpForce?.Invoke(this, EventArgs.Empty);
        }

        // Rotate left
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            float turnSpeed = 100f;
            landerRigidbody2D.AddTorque(
                turnSpeed * Time.deltaTime
            );
            consumeFuel();
            OnLeftForce?.Invoke(this, EventArgs.Empty);
        }

        // Rotate right
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            float turnSpeed = -100f;
            landerRigidbody2D.AddTorque(
                turnSpeed * Time.deltaTime
            );
            consumeFuel();
            OnRightForce?.Invoke(this, EventArgs.Empty);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(!collision2D.gameObject.TryGetComponent(out LandingPad landingPad))
        {
            Debug.Log("Crashed on the Terrain!");
            return;
        }

        float softLandingVelocityMagnitude = 4f;
        float relativeVelocityMagnitude = collision2D.relativeVelocity.magnitude;
        if (relativeVelocityMagnitude>softLandingVelocityMagnitude)
        {
            Debug.Log("Landed too Hard!");
            return;
        }

        float dotVector=Vector2.Dot(Vector2.up, transform.up);
        float minDotVector = .90f;
        if (dotVector < minDotVector)
        {
            Debug.Log("Landed at a too steep");
            return;
        }
        Debug.Log("Landed successfully!");

        float maxScoreAmountLandingAngle = 100f;
        float scoreDotVectorMulipler = 10f;
        float LandingAngleScore = maxScoreAmountLandingAngle - Mathf.Abs(dotVector-1f)* scoreDotVectorMulipler*maxScoreAmountLandingAngle;

        float maxScoreAmountLandingSpeed = 100f;
        float landingSpeedScore = (softLandingVelocityMagnitude - relativeVelocityMagnitude)*maxScoreAmountLandingSpeed;

        Debug.Log($"LandingAngleScore: {LandingAngleScore}");
        Debug.Log($"LandingSpeedScore: {landingSpeedScore}");

        int score = Mathf.RoundToInt(LandingAngleScore + landingSpeedScore)* landingPad.GetScoreMultiplier();
        Debug.Log($"Score: {score}");
        OnLanded?.Invoke(this, new onLandedEventArgs { 
            Score = score 
        });

    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.TryGetComponent(out FuelPickUp fuelPickUp))
        {
            float addFuelAmount = 10f;
            fuelAmount += addFuelAmount;
            fuelPickUp.DestroySelf();
        }

        if (collider2D.gameObject.TryGetComponent(out CoinPickUp coinPickUp))
        {
            OnCoinPickUp?.Invoke(this, EventArgs.Empty);
            coinPickUp.DestroySelf();
        }

    }

    private void consumeFuel()
    {
        float fuelConsumptionRate = 1f;
        fuelAmount -= fuelConsumptionRate * Time.deltaTime;
    }
    public float GetFuelAmount()
    {
        return fuelAmount;
    }

    public float GetSpeedX()
    {
        return landerRigidbody2D.linearVelocity.x;
    }

    public float GetSpeedY() {
        return landerRigidbody2D.linearVelocity.y;
    }
}
