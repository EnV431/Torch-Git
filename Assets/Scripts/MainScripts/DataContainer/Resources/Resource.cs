using System;
using UnityEngine;

public class Resource
{
    public ResourceData resourceData;

    private int _amount;
    public int Amount => _amount;

    public void ChangeAmount(int amountToChange)
    { 
        _amount += amountToChange;
        ContainAmountWithinBounds();
        CheckAndContainIfCapped();
    }

    public void SetAmount(int amountToSet)
    { 
        _amount = amountToSet;
        ContainAmountWithinBounds();
        CheckAndContainIfCapped();
    }

    private void ContainAmountWithinBounds()
    {
        _amount = Math.Clamp(_amount, 0, 9999);
    }
    private void CheckAndContainIfCapped()
    {
        if (resourceData.isCapped == true)
        {
            _amount = Math.Clamp(_amount, 0, 100);
        }
    }
}
