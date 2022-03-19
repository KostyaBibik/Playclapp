using System.Collections;
using UnityEngine;

public class SpawnerCubes : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform spawnPos;

    [SerializeField, Range(0.4f, 1f)] private float minIntervalSpawn;
    [SerializeField, Range(5f, 50f)] private float maxSpeedCubes;
    [SerializeField, Range(5f, 50f)] private float maxDistance;
    
    private float _timeIntervalSpawn = 2f;
    private float _speedCubes = 2f;
    private float _rangeDistance = 5f;

    private void Start()
    {
        StartCoroutine(nameof(SpawnCubes));
    }

    private IEnumerator SpawnCubes()
    {
        do
        {
            var cube = Instantiate(cubePrefab, spawnPos.position, Quaternion.identity);
            cube.GetComponent<CubeController>().InitializeCube(_speedCubes, _rangeDistance);
            yield return new WaitForSeconds(_timeIntervalSpawn);
        } while (true);
    }

    public void SetTimeInterval(float time)
    {
        _timeIntervalSpawn = time > minIntervalSpawn ? time : minIntervalSpawn;
    }

    public void SetSpeed(float speed)
    {
        if(speed > 0)
        {
            _speedCubes = speed < maxSpeedCubes ? speed : maxSpeedCubes;
        }
    }
    
    public void SetDistance(float distance)
    {
        if(distance > 0)
        {
            _rangeDistance = distance < maxDistance ? distance : maxDistance;
        }
    }
}
