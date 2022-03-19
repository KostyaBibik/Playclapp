using TMPro;
using UnityEngine;

public class UIValidation : MonoBehaviour
{
    [SerializeField] private TMP_InputField timeIntervalSpawn;
    [SerializeField] private TMP_InputField speedInput;
    [SerializeField] private TMP_InputField distanceInput;
    
    private SpawnerCubes _spawnerCubes;

    private void Awake()
    {
        _spawnerCubes = FindObjectOfType<SpawnerCubes>();
    }

    private void Start()
    {
        timeIntervalSpawn.characterValidation = TMP_InputField.CharacterValidation.Decimal;
        speedInput.characterValidation = TMP_InputField.CharacterValidation.Decimal;
        distanceInput.characterValidation = TMP_InputField.CharacterValidation.Decimal;
        
        timeIntervalSpawn.onValueChanged.AddListener(delegate(string time)
        {
            if(float.TryParse(time, out var timeInterval))
            {
                _spawnerCubes.SetTimeInterval(timeInterval);
            }
        });
        
        speedInput.onValueChanged.AddListener(delegate(string speed)
        {
            if(float.TryParse(speed, out var speedCubes))
            {
                _spawnerCubes.SetSpeed(speedCubes);
            }
        });
        
        distanceInput.onValueChanged.AddListener(delegate(string distance)
        {
            if(float.TryParse(distance, out var distanceRange))
            {
                _spawnerCubes.SetDistance(distanceRange);
            }
        });
    }
}
