using UnityEngine;

[System.Serializable]
public class Stat
{
    [Range(0, 100)][SerializeField] private int _baseValue;

    private int _currentValue;

    public int BaseValue => _baseValue;
    public int CurrentValue { get => _currentValue; set => _currentValue = Mathf.Clamp(value, 0, 100); }

    public void SetCurrentValueToBaseValue()
    {
        _currentValue = _baseValue;
    }

    public Stat() {}

    public Stat(Stat template)
    {
        _baseValue = template.BaseValue;
        _currentValue = template.CurrentValue;
    }
}
