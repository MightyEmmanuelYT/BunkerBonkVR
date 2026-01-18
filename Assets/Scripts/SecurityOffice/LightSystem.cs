using UnityEngine;

public class LightSystem : MonoBehaviour
{
    [SerializeField] private GameObject lightObject;
    [SerializeField] private PowerSystem power;

    private bool isOn;

    void Start()
    {
        SetLight(false);
    }

    public void ToggleLight()
    {
        SetLight(!isOn);
    }

    private void SetLight(bool state)
    {
        if (isOn == state) return;

        isOn = state;
        lightObject.SetActive(state);

        if (state)
            power.SystemsOn++;
        else
            power.SystemsOn--;
    }
}