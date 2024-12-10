using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public struct Logar : IJob // Изменено на struct
{
    private int _randomNumber;

    public Logar(int randomNumber)
    {
        _randomNumber = randomNumber;
    }

    public void Execute()
    {
        float logValue = Mathf.Log10(_randomNumber);
        Debug.Log($"Random Number: {_randomNumber}, Log Value: {logValue}");
    }
}