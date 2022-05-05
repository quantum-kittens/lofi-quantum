using Qiskit;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumSystem : MonoBehaviour
{
    // The phase of the quantum system
    public TextMeshProUGUI TargetText;
    private float phase;
    private bool catAwake;

    private QuantumCircuit quantumQircuit;
    private MicroQiskitSimulator simulator;

    void Start()
    {
        this.phase = 0.0f;
        this.quantumQircuit = new QuantumCircuit(2, 2);
        this.simulator = new MicroQiskitSimulator();
        this.InitCircuit();
	   TargetText.text = "Phase: " + "0";
    }

    private void InitCircuit()
    {
        this.quantumQircuit.H(0);
        this.quantumQircuit.CX(0, 1);
        //this.quantumQircuit.Measure(0, 0);
        //this.quantumQircuit.Measure(1, 1);
    }

    public float GetPhase()
    {
        return this.phase;
    }

    public void ChangePhaseDeg(float change)
    {
        this.phase += change / 180.0f * Mathf.PI;
	   TargetText.text = "Phase: " + this.phase;
    }

    public void MeasureCat()
    {
        double[] probabilities = this.simulator.GetProbabilities(this.quantumQircuit);
        /*foreach (double p in probabilities)
        {
            Debug.Log(p);
        }*/
        float randF = Random.value;
        double sum = 0.0;
        int i;
        for (i = 0; i < probabilities.Length; i++)
        {
            sum += probabilities[i];
            if (randF < sum)
            {
                break;
            }
        }
        this.catAwake = !(i == 0);
        Debug.Log("Cat is " + (this.catAwake ? "awake." : "asleep."));
    }

    public bool IsCatAwake()
    {
        return this.catAwake;
    }
}
