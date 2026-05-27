using UnityEngine;

[CreateAssetMenu(fileName = "EnergySettings", menuName = "Configs/Energy Settings")]
public sealed class EnergySettings : ScriptableObject
{
    [field: SerializeField] public int MaxEnergy { get; private set; } = 100;
    [field: SerializeField] public float RegenSeconds { get; private set; } = 5f;
}