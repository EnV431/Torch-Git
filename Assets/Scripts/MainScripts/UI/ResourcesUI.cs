using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI foodDisplay;
    [SerializeField] private TextMeshProUGUI waterDisplay;
    [SerializeField] private TextMeshProUGUI moneyDisplay;

    private GlobalDictionary globalDict;

    void Start()
    {
        globalDict = GlobalDictionary.GlobalDictionaryInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
