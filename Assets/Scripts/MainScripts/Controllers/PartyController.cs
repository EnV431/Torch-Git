using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
public class PartyController : MonoBehaviour //party moving funcs can be moved into a different script
{
    private PartyController PartyControllerInstance { get; set; }

    public static System.Action<GameObject> movePartyTo;
    public static bool canPartyMove = true;
    public static int currentStageInlevel = 1;

    private bool isPartyMoving = false;

    [SerializeField]private GameObject partyMemberPrefab;

    private List<GameObject> currentPartyGameObjects = new List<GameObject>();
    private List<Character> currentPartyList = new List<Character>();

    public IReadOnlyList<Character> CurrentPartyList => currentPartyList;

    public float partyMoveSpeed;


    private void Awake()
    {
        #region SingletonSetup
        if (PartyControllerInstance != null && PartyControllerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        PartyControllerInstance = this;
        #endregion
        ResetLevelPartyLogic();

    }

    private void OnEnable()
    {
        movePartyTo += StartPartyMovingCoroutine;
    }
    private void OnDisable()
    {
        movePartyTo -= StartPartyMovingCoroutine;
    }
    private void InstantiatePartyMembers()
    {
        foreach (Character character in currentPartyList)
        {
            GameObject newPartyMember = Instantiate(partyMemberPrefab);
            PassPartysVanityInfo(character, newPartyMember);
        }
    }

    private void PassPartysVanityInfo(Character character, GameObject newPartyMember)
    {
        CharacterVanity characterVanity = character.CharacterVanity;
        SetCharactersVanity(newPartyMember, in characterVanity);
    }
    private void SetCharactersVanity(GameObject newPartyMember, in CharacterVanity characterVanity)
    {
        Image image = newPartyMember.GetComponent<Image>();
        image.sprite = characterVanity.sprite;
        Animation animation = newPartyMember.GetComponent<Animation>();
        animation = characterVanity.animation;
    }
    private void StartPartyMovingCoroutine(GameObject targetDestination)
    {
        isPartyMoving = true;
        canPartyMove = false;
        StartCoroutine(MovePartyToPointOfInterest(targetDestination));
    }
    private void EndPartyMovingCoroutine(GameObject targetDestination)
    {
        StopCoroutine(MovePartyToPointOfInterest(targetDestination));
        isPartyMoving = false;
        canPartyMove = true;
    }

    IEnumerator MovePartyToPointOfInterest(GameObject targetDestination)
    {
        while (isPartyMoving == true)
        {
            //Debug.Log("Coroutine is trying to move party");
            //Debug.Log(gameObject.transform.position);
            transform.position = Vector2.MoveTowards(gameObject.transform.position, targetDestination.transform.position, partyMoveSpeed);
            CheckIfPartyAtTarget(targetDestination);
            yield return null;
        }
    }
    private void CheckIfPartyAtTarget(GameObject targetDestination)
    {
        if (gameObject.transform.position == targetDestination.transform.position)
        {
            RunPartyArrivedAtDestinationLogic(targetDestination);
        }
    }

    private void RunPartyArrivedAtDestinationLogic(GameObject targetDestination)
    {
        EndPartyMovingCoroutine(targetDestination);
        currentStageInlevel++;
    }

    private void ResetLevelPartyLogic()
    {
        canPartyMove = true;
        isPartyMoving = false;
        currentStageInlevel = 1;
    
    }
}
