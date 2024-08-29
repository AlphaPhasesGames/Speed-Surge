using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using UnityEngine.SceneManagement;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2TextMan : MonoBehaviour
    {


        public Stage2VehicleSelectScript vehSelectMan;
        public NewCarControllerStage2 newCarCont;
        public GameObject[] modelArray;

        public GameObject sphereParent;
        public GameObject resetPosition;
       // public GameObject buttonsPanal;
        public GameObject textPanal;
        public GameObject forwardParent;
        public GameObject sidePanalBoxes;
        public GameObject textForStep0;
        public GameObject textForStep15;
        public GameObject textForStep16;
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

        }


        private void HandleArrayPosActions()
        {
            switch (arrayPos)
            {
                case 0:
                    textForStep0.gameObject.SetActive(true);
                    textForStep16.gameObject.SetActive(false);
                    SpeakText("stage2MissionText1"); break;
                case 1:
                    HideButton();
                   // vehSelectMan.panalOpen = true;
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    SpeakText("stage2MissionText2ChooseCar"); break;
                case 2:
                    vehSelectMan.selectionPanal.gameObject.SetActive(false); 
                    SpeakText("stage2MissionText3"); break;
                case 3: SpeakText("stage2MissionText4"); break;
                case 4:SpeakText("stage2MissionText5");break;
                case 5:SpeakText("stage2MissionText6");break;
                case 6: SpeakText("stage2MissionText7"); break;
                case 7: SpeakText("stage2MissionText8"); break;
                case 8: SpeakText("stage2MissionText9"); break;
                case 9: SpeakText("stage2MissionText10"); break;
                case 10: SpeakText("stage2MissionText11"); break;
                case 11:
                    LOLSDK.Instance.SpeakText("stage2MissionText12");
                    sidePanalBoxes.gameObject.SetActive(true);
                    SpeakText("stage2MissionText12"); break;
                case 12:SpeakText("stage2MissionText13");break;
                case 13:SpeakText("stage2MissionText14");break;
                case 14:
                    newCarCont.isCarActive = true;
                    newCarCont.engineIsIdle = true;
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    SpeakText("stage2MissionText15");
                    break;
                case 15:
                    textPanal.gameObject.SetActive(true);
                    textForStep16.gameObject.SetActive(false);
                    textForStep15.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(ResetCarArrayMove());
                    //  newCarCont.engineIsIdle = true;
                    SpeakText("stage2MissionText16");
                    break;
                case 16:
                    SpeakText("stage2MissionText17");

                    textPanal.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    hasScrolled = false;
                    break;
                case 17:
                    SpeakText("stage2MissionText18");
                    textPanal.gameObject.SetActive(true);

                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    break;
                case 18:
                    SpeakText("stage2MissionText19");
                    textPanal.gameObject.SetActive(true);
                    newCarCont.isCarActive = false;
                    forwardParent.gameObject.SetActive(true);
                    hasScrolled = false;
                    break;
                case 19:
                    StartCoroutine(ChangeScene());
                    forwardParent.gameObject.SetActive(false);

                    hasScrolled = false;
                    SpeakText("stage2MissionText20");
                    break;
                case 20:
                    textPanal.gameObject.SetActive(true);
                    // StartCoroutine(ChangeScene());
                    forwardParent.gameObject.SetActive(true);
                    hasScrolled = false;
                    SpeakText("stage2MissionText21");
                    break;

                case 21:
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(ResetCarArrayMove());
                    hasScrolled = false;
                    SpeakText("stage2MissionText22");
                    break;

                case 22:
                    textPanal.gameObject.SetActive(false);
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
            arrayPos = 0;
            textPanal.gameObject.SetActive(true);

            Debug.Log("This start coRoutine Runs start text");

        }

        public IEnumerator MoveToBlankInvislbePanal()
        {
            //forwardButton.gameObject.SetActive(false);
            yield return new WaitForSeconds(5);
            hasScrolled = false;
            textPanal.gameObject.SetActive(false);

            //arrayPos = 22;
            Debug.Log("This start coRoutine Runs");

        }


        public IEnumerator ResetCarArrayMove()
        {
            //forwardButton.gameObject.SetActive(false);

            yield return new WaitForSeconds(5);
            //  hasScrolled = false;
            newCarCont.isCarActive = false;
            restrictionBool2 = true;
            textPanal.gameObject.SetActive(false);
           /// arrayPos = 1;
            Debug.Log("This start coRoutine Runs");

        }
        /*
        public IEnumerator CorrectAnswerCoRoutine()
        {
            //forwardButton.gameObject.SetActive(false);
            hasScrolled = false;
            yield return new WaitForSeconds(5);
            textPanal.gameObject.SetActive(true);
            arrayPos = 22;
            Debug.Log("This start coRoutine Runs");

        }

        public IEnumerator ResetCarAndQuestion()
        {
            yield return new WaitForSeconds(5);
            newCarCont.isCarActive = true;
            arrayPos = 18;
        }
        */

        public void IntroTTSSpeak(int textIndex)
        {
            string textKey = $"stage2MissionText{textIndex}";
            LOLSDK.Instance.SpeakText(textKey);
            Debug.Log($"Intro Text {textIndex} Button is pressed");
        }

        private void SpeakText(string textKey)
        {
            LOLSDK.Instance.SpeakText(textKey);
        }


        public IEnumerator ChangeScene()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Stage 3 Increased Energy");
        }
    }
}

