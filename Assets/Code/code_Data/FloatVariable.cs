using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Float")]
public class FloatVariable : ScriptableObject
{
    public string developerDescription;
    public float Value;
    public void SetFloatValue(float value)
    {
        Value = value;
        SetDirty();
    }
}