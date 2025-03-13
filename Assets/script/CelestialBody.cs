using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class CelestialBody : MonoBehaviour
{
    public float bodyMass;
    public float bodyRadius;
    public Vector3 initialVelocity;
    private Rigidbody _body;

    private const float G = 6.67e-2f;
    private const float massOfEarth = 5.97f;
    public Vector3 velocity;
    void Awake()
    {
        _body = gameObject.GetComponent<Rigidbody>();
        _body.mass = bodyMass;
        ChangeRadius(bodyRadius);
        velocity = initialVelocity;
    }

    public void UpdateVelocity(CelestialBody[] otherBodies, float timeStep)
    {
        foreach (CelestialBody otherBody in otherBodies)
        {
            if (otherBody != this)
            {
                var _heading = otherBody.transform.position - _body.position;
                var _sqrDist = _heading.sqrMagnitude;
                var _dir = _heading.normalized;

                var _currentVelocity = G * otherBody.bodyMass / _sqrDist;
                velocity += _currentVelocity * timeStep * _dir;
            }
        }
    }

    public void UpdatePosition(float timeStep)
    {
        _body.position += velocity * timeStep;
    }

    public void ChangeRadius(float radius)
    {
        transform.localScale = Vector3.one * radius;
    }
}
