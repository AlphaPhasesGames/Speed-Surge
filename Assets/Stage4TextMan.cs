using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using UnityEngine.SceneManagement;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage4TextMan : MonoBehaviour
    {
        public Stage4VehicleSelectScript vehSelectMan;
        public NewCarControllerStage3 newCarCont;
        public GameObject[] modelArray;

        public GameObject sphereParent;
        public GameObject resetPosition;
        // public GameObject buttonsPanal;
        public GameObject textPanal;
        public GameObject forwardParent;
      //  public GameObject sidePanalBoxes;
      //  public GameObject textForStep0;
      //  public GameObject textForStep15;
       // public GameObject textForStep16;
        public Button forwardButton;
        public Button backwardsButton;
        public Button[] textButtons;

        public bool restrictionBool2;
        public bool hasScrolled;
        public bool answerCorrect;
        public int arrayPos;

        public bool[] textBools;
        private int maxLengthArray;



        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);

            for (int i = 0; i < textButtons.Length; i++)
            {
                int index = i + 1;  // Adjust index to match textButton number
                textButtons[i].onClick.AddListener(() => IntroTTSSpeak(index));
            }
            answerCorrect = false;
            StartCoroutine(StartLevelText());
        }
        // Start is called before the first frame update

        void Start()
        {
            arrayPos = 0;
            maxLengthArray = modelArray.Length;
            textBools = new bool[maxLengthArray];
        }


        void Update()
        {
            if (!hasScrolled)
            {
                // Deactivate all previous text objects
                foreach (var obj in modelArray)
                {
                    obj.SetActive(false);
                }

                // Activate the current text object
                if (arrayPos >= 0 && arrayPos < modelArray.Length)
                {
                    modelArray[arrayPos].SetActive(true);
                }

                hasScrolled = true;
            }

            if (!textBools[arrayPos])
            {
                HandleArrayPosActions();
                textBools[arrayPos] = true;
            }


            /*
            if (restrictionBool2)
            {
                //   arrayPos = 19;
                sphereParent.transform.position = resetPosition.transform.position;
                // sphereParent.transform.rotation = resetPosition.transform.rotation;
                newCarCont.isCarActive = false;
                forwardParent.gameObject.SetActive(true);
                restrictionBool2 = false;
                //textBool20 = false;

            }
            */
        }

        private void HandleArrayPosActions()
        {
            switch (arrayPos)
            {
                case 0:
                    SpeakText("stage4MissionText1"); break;
                case 1:
                    SpeakText("stage4MissionText2"); break;
                case 2:
                    SpeakText("stage4MissionText3"); break;
                case 3: SpeakText("stage4MissionText4"); break;
                case 4: SpeakText("stage4MissionText5"); break;
                case 5: SpeakText("stage4MissionText6"); break;
                case 6: SpeakText("stage4MissionText7"); break;
                case 7:
                    HideButton();
                    // vehSelectMan.panalOpen = true;
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    SpeakText("stage4MissionText8ChooseVehicle"); break;
                case 8:
                    vehSelectMan.selectionPanal.gameObject.SetActive(false);
                    SpeakText("stage4MissionText9"); break;
                case 9:
                    SpeakText("stage4MissionText10"); break;
                case 10:
                    newCarCont.isCarActive = true;
                    newCarCont.engineIsIdle = true;
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    SpeakText("stage4MissionText11"); break;
                case 11:                   
                    SpeakText("stage4MissionText12"); break;
                case 12: SpeakText("stage4MissionText13"); break;
                case 13: SpeakText("stage4MissionText14"); break;
                case 14:SpeakText("stage4MissionText15");break;
                case 15:
                    textPanal.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(false);
                   // StartCoroutine(ResetCarArrayMove());
                    //  newCarCont.engineIsIdle = true;
                    SpeakText("stage4MissionText16");
                    break;
                case 16:
                    SpeakText("stage4MissionText17");

                    textPanal.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    hasScrolled = false;
                    break;
             

            }


        }

        public void ProgressTextForward()
        {
            arrayPos++;
            StartCoroutine(DelayTextButton());
            hasScrolled = false;
            forwardButton.gameObject.SetActive(false);
        }


        public void ProgressTextBack()
        {

            arrayPos--;
            hasScrolled = false;
            //  panalOpen = false;
        }

        public void HideButton()
        {
            forwardParent.gameObject.SetActive(false);
        }

        public IEnumerator DelayTextButton()
        {

            yield return new WaitForSeconds(1);
            forwardButton.gameObject.SetActive(true);
            // hasScrolled = false;
            Debug.Log("This coRoutine Runs");

        }



        public IEnumerator StartLevelText()
        {
            //forwardButton.gameObject.SetActive(false);
            yield return new WaitForSeconds(2);
            textPanal.gameObject.SetActive(true);
            arrayPos = 0;
            Debug.Log("This start coRoutine Runs");

        }

        public IEnumerator MoveToBlankInvislbePanal()
        {
            //forwardButton.gameObject.SetActive(false);
            //   buttonsPanal.gameObject.SetActive(false);
            yield return new WaitForSeconds(5);
            textPanal.gameObject.SetActive(false);
            arrayPos = 17;
            Debug.Log("This start coRoutine Runs");

        }


        public void IntroTTSSpeak(int textIndex)
        {
            string textKey = $"stage3MissionText{textIndex}";
            LOLSDK.Instance.SpeakText(textKey);
            Debug.Log($"Intro Text {textIndex} Button is pressed");
        }

        private void SpeakText(string textKey)
        {
            LOLSDK.Instance.SpeakText(textKey);
        }
    }
}
