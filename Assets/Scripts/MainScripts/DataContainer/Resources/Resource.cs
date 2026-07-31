using UnityEngine;

public class Resource
{
    public ResourceData resourceData;

    private int amount;
    public int Amount => amount;

    public void ChangeAmount(int amountToChange)
    { 
        amount += amountToChange;    
    }

    public void SetAmount(int amountToSet)
    { 
        amount = amountToSet;
    }


}
