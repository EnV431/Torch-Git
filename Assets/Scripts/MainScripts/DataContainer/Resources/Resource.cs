using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resource
{

    private void CheckForLoseGame() //DEMO
    {
        if (_amount <= 0)
        {
            GameManager.GameManagerInstance.ResetSceneAfterLose();
        }
    }

    public ResourceData resourceData;

    private int _amount;
    public int Amount => _amount;

    public void ChangeAmount(int amountToChange)
    { 
        _amount += amountToChange;
        CheckForLoseGame(); //DEMO
        ContainAmountWithinBounds();
        CheckAndContainIfCapped();
    }

    public void SetAmount(int amountToSet)
    { 
        _amount = amountToSet;
        CheckForLoseGame(); //DEMO
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
