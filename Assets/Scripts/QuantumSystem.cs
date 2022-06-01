using Qiskit;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class QuantumSystem : MonoBehaviour {
    // The phase of the quantum system
    public TextMeshProUGUI TargetText;
    private float phase;
    private bool catAwake;

    private QuantumCircuit quantumQircuit;
    private MicroQiskitSimulator simulator;

    public TextMeshProUGUI ZeroText;
    public TextMeshProUGUI OneText;
    public TextMeshProUGUI PhaseValue;

    public Image CatAwake;
    public Image CatSleeping;
    public GameObject LoadingAnimation;
    public GameObject FireFlies;

    public float LoadingDuration = 1f;

    double zeroValue;
    double oneValue;
    double phaseValue;

    bool isMeasuring = false;



    void Start() {
        this.phase = 0.0f;
        
        this.simulator = new MicroQiskitSimulator();

        quantumQircuit = new QuantumCircuit(1, 1, true);


        this.InitCircuit();

        CalculateValues();

        FireFlies.SetActive(false);
        LoadingAnimation.SetActive(false);

        //TargetText.text = "Phase: " + "0";



    }

    private void InitCircuit() {
        this.quantumQircuit.H(0);
        //this.quantumQircuit.Measure(0, 0);
        //this.quantumQircuit.Measure(1, 1);
    }


    void CalculateValues() {
        simulator.SimulateInPlace(quantumQircuit, ref quantumQircuit.Amplitudes);
        quantumQircuit.ResetGates();
        //convert amplitudes to probabilities
        zeroValue = Math.Pow(quantumQircuit.Amplitudes[0].Real, 2) + Math.Pow(quantumQircuit.Amplitudes[0].Complex, 2);
        oneValue = Math.Pow(quantumQircuit.Amplitudes[1].Real, 2) + Math.Pow(quantumQircuit.Amplitudes[1].Complex, 2);

        //double eps = 0.001;

       //////// Note: these will ALWAYS be 0.50 so long as we are only changing the phase

        ZeroText.text = zeroValue.ToString("0.00");
        OneText.text = oneValue.ToString("0.00");
        phaseValue = 0.0;

        phaseValue = Math.Atan2(quantumQircuit.Amplitudes[0].Complex, quantumQircuit.Amplitudes[0].Real);

        phaseValue = -phaseValue / Math.PI;


        Debug.Log(quantumQircuit.Amplitudes[0].Real + " " + quantumQircuit.Amplitudes[0].Complex + " " + phaseValue );


        PhaseValue.text = phaseValue.ToString("0.00");
    }

    public float GetPhase() {
        return this.phase;
    }

    public void ChangePhaseDeg(float change) {
        if (isMeasuring) {
            return;
        }

        this.phase += change / 180.0f * Mathf.PI;
        //TargetText.text = "Phase: " + this.phase;
        ApplyZRotation(change);
    }

    public void MeasureCat() {

        /*
        double[] probabilities = this.simulator.GetProbabilities(this.quantumQircuit);
      
        float randF = Random.value;
        double sum = 0.0;
        int i;
        for (i = 0; i < probabilities.Length; i++) {
            sum += probabilities[i];
            if (randF < sum) {
                break;
            }
        }
        this.catAwake = !(i == 0);
        Debug.Log("Cat is " + (this.catAwake ? "awake." : "asleep."));
        */

        StartCoroutine(measureAnimation());
    }

    IEnumerator measureAnimation() {
        LoadingAnimation.SetActive(true);
        isMeasuring = true;
        yield return null;

        float progress = 0;

        while (progress < 1) {
            progress += Time.deltaTime / LoadingDuration;
            Vector3 rot = LoadingAnimation.transform.localRotation.eulerAngles;
            rot += Time.deltaTime * new Vector3(0, 0, 360);
            LoadingAnimation.transform.localRotation = Quaternion.Euler(rot);
            yield return null;
        }
        float rnd = Random.Range(0.0f, 1.0f);
        if (rnd < zeroValue) {
            CatSleeping.color = new Color(1, 1, 1, 1);
            CatAwake.color = new Color(1, 1, 1, 0);
            FireFlies.SetActive(true);
        } else {
            CatSleeping.color = new Color(1, 1, 1, 0);
            CatAwake.color = new Color(1, 1, 1, 1);
            FireFlies.SetActive(false);
        }

        isMeasuring = false;
        LoadingAnimation.SetActive(false);
    }

    public bool IsCatAwake() {
        return this.catAwake;
    }


    public void ApplyZRotation(float change) {
        if (isMeasuring) {
            return;
        }
        //there was some wrong scaling this should not be needed.
        //change = change * 2;
        quantumQircuit.RZ(0, change / 360 * 2 * Math.PI);

        CalculateValues();
    }

    public void ApplyX() {
        if (isMeasuring) {
            return;
        }
        quantumQircuit.X(0);
        CalculateValues();
    }

    public void ApplyH() {
        if (isMeasuring) {
            return;
        }
        quantumQircuit.H(0);
        CalculateValues();
    }


}
