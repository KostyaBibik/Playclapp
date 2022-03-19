using UnityEngine;

public class CubeController : MonoBehaviour
{
    private float _speed;
    private float _targetDistance;
    private float _traveledDistance;
    private Vector3 _oldPosition; 
    
    public void InitializeCube(float speed, float distance)
    {
        _speed = speed;
        _targetDistance = distance;
    }

    private void Start()
    {
        _oldPosition = transform.position;
    }

    private void Update()
    {
        _traveledDistance += (transform.position - _oldPosition).magnitude;
        _oldPosition = transform.position;
        
        transform.Translate(transform.forward * (_speed * Time.deltaTime));
        
        if (_traveledDistance > _targetDistance)
        {
            Destroy(gameObject);
        }
    }
}
