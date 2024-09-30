using System.Collections;
using System;
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
        public Stage4EndFade endFade;
        public GameObject sphereParent;
        public GameObject resetPosition;
        // public GameObject buttonsPanal;
        public GameObject textPanal;
        public GameObject forwardParent;
        //  public GameObject sidePanalBoxes;/
        public GameObject textForStep11;
        public GameObject textForStep12;
        public GameObject textForStep13;
        public GameObject textForStep13a;
        public GameObject textForStep14;
        public GameObject textForStep15;

        public GameObject mphUI;
        public GameObject task;
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
            newCarCont.isCarActive = false;
            newCarCont.engineIsIdle = false;
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

          
        }

        private void HandleArrayPosActions()
        {
            switch (arrayPos)
            {
                case 0:
                    backwardsButton.gameObject.SetActive(false);
                    SpeakText("stage4MissionText1"); break;
                case 1:
                    backwardsButton.gameObject.SetActive(true);
                    SpeakText("stage4MissionText2"); break;
                case 2:
                    SpeakText("stage4MissionText3"); break;
                case 3: SpeakText("stage4MissionText4"); break;
                case 4: SpeakText("stage4MissionText5"); break;
                case 5: SpeakText("stage4MissionText6"); break;
                case 6: task.gameObject.SetActive(true);
                    SpeakText("stage4MissionText7"); break;
                case 7:
                    backwardsButton.gameObject.SetActive(false);
                    HideButton();
                    // vehSelectMan.panalOpen = true;
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    SpeakText("stage4MissionText8ChooseVehicle"); break;
                case 8:
                    backwardsButton.gameObject.SetActive(false);
                    vehSelectMan.selectionPanal.gameObject.SetActive(false);
                    SpeakText("stage4MissionText9"); break;
                case 9:
                    backwardsButton.gameObject.SetActive(true);
                    SpeakText("stage4MissionText10"); break;
                case 10:
                    newCarCont.isCarActive = true;
                    newCarCont.engineIsIdle = true;
                    forwardParent.gameObject.SetActive(false);
                    mphUI.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    SpeakText("stage4MissionText11"); break;
                case 11:
                    textForStep12.gameObject.SetActive(false);
                    textForStep11.gameObject.SetActive(true);
                    textPanal.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(false);

                    SpeakText("stage4MissionText12"); break;
                case 12:
                    backwardsButton.gameObject.SetActive(false);
                    textForStep12.gameObject.SetActive(false);
                    textForStep13.gameObject.SetActive(true);
                   // textForStep13.gameObject.SetActive(true);
                    newCarCont.isCarActive = false;
                    newCarCont.engineIsIdle = false;
                    textPanal.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    Debug.Log(" The fired Section 12 in the array");
                    SpeakText("stage4MissionText12"); break;
                case 13:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    textForStep12.gameObject.SetActive(false);
                    textForStep13.gameObject.SetActive(false);
                    textForStep13a.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(true);
                    Debug.Log(" The fired Section 13 in the array");
                    SpeakText("stage4MissionText13"); break;
                case 14:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    textForStep12.gameObject.SetActive(false);
                    textForStep13.gameObject.SetActive(false);
                    textForStep13a.gameObject.SetActive(false);
                    textForStep14.gameObject.SetActive(true);
                    textForStep15.gameObject.SetActive(false);
                    forwardParent.gameObject.SetActive(true);
                    Debug.Log(" The fired Section 13 in the array");
                    SpeakText("stage4MissionText14"); break;
                case 15: SpeakText("stage4MissionText16");
                   // textForStep14.gameObject.SetActive(false);
                   // textForStep15.gameObject.SetActive(true);
                    break;
                case 16: SpeakText("stage4MissionText17");
                    //textForStep16.gameObject.SetActive(true);
                    break;
                case 17:SpeakText("stage4MissionText18");
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    hasScrolled = false;
                    backwardsButton.gameObject.SetActive(false);
           
                    EndOfGame(); break;
                case 18:SpeakText("stage4MissionText18");
                    
                    textPanal.gameObject.SetActive(true);
                 
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
            Array.Fill(textBools, false);

        }

        public void HideButton()
        {
            forwardParent.gameObject.SetActive(false);
        }

        public IEnumerator DelayTextButton()
        {

            yield return new WaitForSeconds(3);
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
            arrayPos = 19;
            Debug.Log("This start coRoutine Runs");

        }


        public void IntroTTSSpeak(int textIndex)
        {
            string textKey = $"stage4MissionText{textIndex}";
            LOLSDK.Instance.SpeakText(textKey);
            Debug.Log($"Intro Text {textIndex} Button is pressed");
        }

        private void SpeakText(string textKey)
        {
            LOLSDK.Instance.SpeakText(textKey);
        }



        public IEnumerator ResetCarArrayMove()
        {
            //forwardButton.gameObject.SetActive(false);

            MoveCar();
            yield return new WaitForSeconds(5);
            //  hasScrolled = false;
          //  newCarCont.isCarActive = false;
            restrictionBool2 = true;
            //textPanal.gameObject.SetActive(false);
            /// arrayPos = 1;
            Debug.Log("This start coRoutine Runs");

        }

        public void MoveCar() 
        {
            sphereParent.transform.position = resetPosition.transform.position;

        }

        public void EndOfGame()
        {
            endFade.runEnd = true;
            endFade.FadeBlack();
            LOLSDK.Instance.SubmitProgress(0, 100, 100);
            LOLSDK.Instance.CompleteGame();
        }
    }
}
