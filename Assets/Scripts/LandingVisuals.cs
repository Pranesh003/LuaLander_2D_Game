using UnityEngine;

public class LandingVisuals : MonoBehaviour
{
    [SerializeField] private ParticleSystem leftThrusterParticles;
    [SerializeField] private ParticleSystem middleThrusterParticles;
    [SerializeField] private ParticleSystem rightThrusterParticles;

    private Lander lander;

    private void Awake()
    {
        lander = GetComponent<Lander>();
        lander.OnUpForce += Lander_OnUpForce;
        lander.OnLeftForce += Lander_OnLeftForce;
        lander.OnRightForce += Lander_OnRightForce;
        lander.OnBeforeForce += Lander_OnBeforeForce;

        SetEnabledThrusterParticleSystem(leftThrusterParticles, false);
        SetEnabledThrusterParticleSystem(middleThrusterParticles, false);
        SetEnabledThrusterParticleSystem(rightThrusterParticles, false);
    }

    private void Lander_OnBeforeForce(object sender, System.EventArgs e)
    {
        SetEnabledThrusterParticleSystem(leftThrusterParticles, false);
        SetEnabledThrusterParticleSystem(middleThrusterParticles, false);
        SetEnabledThrusterParticleSystem(rightThrusterParticles, false);
    }
    private void Lander_OnUpForce(object sender, System.EventArgs e)
    {
        SetEnabledThrusterParticleSystem(leftThrusterParticles, true);
        SetEnabledThrusterParticleSystem(middleThrusterParticles, true);
        SetEnabledThrusterParticleSystem(rightThrusterParticles, true);
    }

    private void Lander_OnLeftForce(object sender, System.EventArgs e)
    {
       SetEnabledThrusterParticleSystem(leftThrusterParticles, true);

    }

    private void Lander_OnRightForce(object sender, System.EventArgs e)
    {
        SetEnabledThrusterParticleSystem(rightThrusterParticles, true);
    }

    private void SetEnabledThrusterParticleSystem(ParticleSystem  particleSystem, bool enabled)
    {
        ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
        emissionModule.enabled = enabled;
    }
}
