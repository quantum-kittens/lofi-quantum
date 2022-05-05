using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraController : MonoBehaviour
{
    [SerializeField]
    private float maxOffset;
    private float offset;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float phaseSpeed;
    private ParticleSystem auroraEmitter;
    private float phase;
    private float targetPhase;
    private float hue;
    [SerializeField]
    private QuantumSystem quantumSystem;

    private void Start()
    {
        this.auroraEmitter = this.GetComponentInChildren<ParticleSystem>();
        this.hue = 0;
        this.phase = 0;
        this.targetPhase = 0;
        this.UpdateColor();
        // Get particle system's color over lifetime module
        ParticleSystem.ColorOverLifetimeModule col = this.auroraEmitter.colorOverLifetime;
        col.enabled = true;
        // Set up particle system gradient
        Gradient grad = new Gradient();
        grad.SetKeys(
            new GradientColorKey[] { },
            new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(0.6f, 0.15f), new GradientAlphaKey(0.6f, 0.85f), new GradientAlphaKey(0.0f, 1.0f) }
        );
        // Update particle system color over lifetime
        col.color = grad;
    }

    private void UpdatePhase()
    {
        this.targetPhase = this.quantumSystem.GetPhase();
        if (Mathf.Abs(this.targetPhase - this.phase) <= this.phaseSpeed)
        {
            this.phase = this.targetPhase;
        }
        else
        {
            this.phase += (this.phase < this.targetPhase ? 1 : -1) * this.phaseSpeed;
        }
    }

    private void UpdateColor()
    {
        // Convert phase to hue
        this.hue = this.phase % (2 * Mathf.PI) / (2 * Mathf.PI);
        if (this.hue < 0)
        {
            this.hue += 1.0f;
        }
        // Get particle system main module
        ParticleSystem.MainModule mainModule = this.auroraEmitter.main;
        // Get new color and update particle system
        Color newColor = Color.HSVToRGB(this.hue, 1.0f, 1.0f);
        mainModule.startColor = newColor;
    }

    private void Update()
    {
        this.transform.position += new Vector3(0, this.moveSpeed, 0);
        this.offset += this.moveSpeed;
        if (Mathf.Abs(this.offset) > this.maxOffset || Random.Range(0.0f, 1.0f) < 0.005f)
        {
            this.moveSpeed *= -1;
        }
        this.UpdatePhase();
        // Check if hue should be updated
        if (this.hue != this.phase % Mathf.PI / (2 * Mathf.PI))
        {
            this.UpdateColor();
        }
    }
}
