using UnityEngine;

public class PowerSystemOld : MonoBehaviour
{
    public float maxPower = 100f;
    public float currentPower = 100f;

    public bool HasPower(float amount)
    {
        return currentPower >= amount;
    }

    public void Consume(float amount)
    {
        currentPower = Mathf.Max(0f, currentPower - amount);
    }

    public void Refill(float amount)
    {
        currentPower = Mathf.Min(maxPower, currentPower + amount);
    }
}
