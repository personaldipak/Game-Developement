using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat{

    [SerializeField]
    private int basevalue;

    private List<int> Modifier = new List<int>();

    public int Getvalue()
    {
        int FinalValue = basevalue;
        Modifier.ForEach(value => FinalValue += value);
        return FinalValue;
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
            Modifier.Add(modifier);
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
            Modifier.Remove(modifier);
    }
}
