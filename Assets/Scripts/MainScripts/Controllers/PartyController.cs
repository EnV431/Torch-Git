using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using System;

namespace SAE.PAX.Torch.Party
{
    public class PartyController : MonoBehaviour //party moving funcs can be moved into a different script
    {
        public Vector2 playerSpawn; //DEMO

        private PartyController PartyControllerInstance { get; set; }

        public static Action<GameObject> movePartyTo;
        public static bool canPartyMove = true;
        public static int currentStageInlevel = 1;

        private bool isPartyMoving = false;

        [SerializeField] private GameObject partyMemberPrefab;

        private List<GameObject> currentPartyGameObjects = new List<GameObject>();
        private List<Character> currentPartyList = new List<Character>();

        public IReadOnlyList<Character> CurrentPartyList => currentPartyList;

        public float partyMoveSpeed;

        [SerializeField]private int _totalPartyMoveChecks = 10;


        private void Awake()
        {
            playerSpawn = transform.position; //DEMO

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
        public void ResetPlayerPosition() //DEMO
        {
            transform.position = playerSpawn; //DEMO
            ResetLevelPartyLogic(); 
        }

        private void OnEnable()
        {
            movePartyTo += StartPartyMovingCoroutine;

            GameManager.ResetPlayer += ResetPlayerPosition; //DEMO
        }
        private void OnDisable()
        {
            movePartyTo -= StartPartyMovingCoroutine;

            GameManager.ResetPlayer -= ResetPlayerPosition; //DEMO
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
            if (GameUIManager.GameUIManagerInstance.IncidentUIGameObject.activeInHierarchy || GameUIManager.GameUIManagerInstance.CharacterUIGameObject.activeInHierarchy)
            {
                return;
            }
            isPartyMoving = true;
            canPartyMove = false;
            //Debug.Log("starting partymove" + isPartyMoving + " " + canPartyMove);
            StartCoroutine(MovePartyToPointOfInterest(targetDestination));
        }

        IEnumerator MovePartyToPointOfInterest(GameObject targetDestination)
        {
            float[] movePointArray = GetDistanceChunks(targetDestination.transform.position);

            while (isPartyMoving == true)
            {
                // Debug.Log("moving party" + isPartyMoving + " " + canPartyMove);
                transform.position = Vector2.MoveTowards(gameObject.transform.position, targetDestination.transform.position, partyMoveSpeed);
                CheckIfPartyAtTarget(targetDestination);
                yield return null;
            }
        }
        #region SimpleCoroutineControls
        private void PauseMovePartyRoutine()
        {
            isPartyMoving = false;        
        }
        private void ResumeMovePartyRoutine()
        {
            isPartyMoving = true;        
        }
        #endregion

        private float[] GetDistanceChunks(Vector2 targetDestination)
        {
            float ogDistance = Vector2.Distance(gameObject.transform.position, targetDestination);
            float distanceChunk = ogDistance / _totalPartyMoveChecks;

            float[] movePointsArray = new float[_totalPartyMoveChecks];

            for (int i = 0; i < _totalPartyMoveChecks; i++)
            {
                movePointsArray[i] = distanceChunk;
                Debug.Log(movePointsArray.Length + " " + distanceChunk);
            }
            return movePointsArray;

        }

        private void CheckIfPartyAtTarget(GameObject targetDestination)
        {
            float distance = Vector2.Distance(gameObject.transform.position, targetDestination.transform.position);
            if (distance <= 0.1f)
            {
                RunPartyArrivedAtDestinationLogic(targetDestination);                
            }
        }

        private void AttemptToTriggerIncidentWhilePartyIsMoving()
        {
            Debug.Log(" the party is being attacked while travelling");     
        }

        private void RunPartyArrivedAtDestinationLogic(GameObject targetDestination)
        {
            EndPartyMovingCoroutine(targetDestination);
            currentStageInlevel++;
            //Debug.Log("PartyArrived At Destination");
        }
        private void EndPartyMovingCoroutine(GameObject targetDestination)
        {
            StopCoroutine(MovePartyToPointOfInterest(targetDestination));
            isPartyMoving = false;
            canPartyMove = true;
            //Debug.Log("ending paryymove" + isPartyMoving + " " + canPartyMove);
        }

        private void ResetLevelPartyLogic()
        {
            canPartyMove = true;
            isPartyMoving = false;
            currentStageInlevel = 1;

        }
    }
}