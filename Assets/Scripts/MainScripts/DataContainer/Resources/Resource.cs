using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] public ResourceData resourceData;

    private int value;
    public int Value => value;

}
