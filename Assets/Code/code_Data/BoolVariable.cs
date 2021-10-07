using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Bool")]
public class BoolVariable : ScriptableObject
{
    public string developerDescription;
    public bool Value;
    public void SetBoolValue(bool value)
    {
        Value = value;
    }
}