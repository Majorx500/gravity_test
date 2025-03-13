using System;
using UnityEngine;
[ExecuteInEditMode]
public class BodySimulation : MonoBehaviour
{
    private CelestialBody[] allCelestialBodies;
    private const float timeStep = 0.01f;
    public void Awake()
    {
       allCelestialBodies = FindObjectsByType<CelestialBody>(FindObjectsSortMode.None);
        
    }

    public void FixedUpdate()
    {
        foreach (var celestialBody in allCelestialBodies)
        {
            celestialBody.UpdateVelocity(allCelestialBodies, timeStep);
            celestialBody.UpdatePosition(timeStep);
        }
    }
}
