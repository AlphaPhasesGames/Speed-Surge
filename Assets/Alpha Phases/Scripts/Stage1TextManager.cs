using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using UnityEngine.SceneManagement;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1TextManager : MonoBehaviour
    {
        public VehicleSelectScreenMan vehSelectMan;
        public NewCarController newCarCont;
        public GameObject[] modelArray;

        public GameObject sphereParent;
        public GameObject resetPosition;
        public GameObject buttonsPanal;
        public GameObject textPanal;
        public GameObject forwardParent;

        public Button forwardButton;
        public Button backwardsButton;
        public Button[] textButtons;

        public bool showButtonsOnce;

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
                       
        }

        private void HandleArrayPosActions()
        {
            switch (arrayPos)
            {
                case 0:
                    LOLSDK.Instance.SubmitProgress(0, 10, 100);
                    backwardsButton.gameObject.SetActive(false);
                    SpeakText("stage1MissionText1"); break;
                case 1: backwardsButton.gameObject.SetActive(true);

                    SpeakText("stage1MissionText2"); break;
                case 2: SpeakText("stage1MissionText3"); break;
                case 3: SpeakText("stage1MissionText4"); break;
                case 4:
                    HideButton();
                    backwardsButton.gameObject.SetActive(false);
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    SpeakText("stage1MissionText5");
                    break;
                case 5:
                    backwardsButton.gameObject.SetActive(false);
                    SpeakText("stage1MissionText6");
                    vehSelectMan.selectionPanal.gameObject.SetActive(false);
                    break;
                case 6:
                    backwardsButton.gameObject.SetActive(true);
                    SpeakText("stage1MissionText7"); break;
                case 7: SpeakText("stage1MissionText8"); break;
                case 8: SpeakText("stage1MissionText9"); break;
                case 9: SpeakText("stage1MissionText10"); break;
                case 10: SpeakText("stage1MissionText11"); break;
                case 11:
                    forwardParent.gameObject.SetActive(true);
                    SpeakText("stage1MissionText12"); break;
                case 12:
                    SpeakText("stage1MissionText13");
                    if (!showButtonsOnce)
                    {
                        buttonsPanal.gameObject.SetActive(true);
                        showButtonsOnce = true;
                    }
                  

                    forwardParent.gameObject.SetActive(false);
                    break;
                case 13:
                    backwardsButton.gameObject.SetActive(false);
                    buttonsPanal.gameObject.SetActive(false);
                    forwardParent.gameObject.SetActive(true);
                    SpeakText("stage1MissionText14");
                    break;
                case 14:
                    StartCoroutine(MoveToBlankInvislbePanal());
                    newCarCont.PlayIdle();
                    newCarCont.isCarActive = true;
                   // newCarCont.engineIsIdle = true;
                    forwardParent.gameObject.SetActive(false);
                    SpeakText("stage1MissionText15");
                    break;
                case 15:
                    backwardsButton.gameObject.SetActive(false);
                    forwardParent.gameObject.SetActive(true);
                    newCarCont.isCarActive = false;
                    newCarCont.StopIdle();
                    hasScrolled = false;
                    textPanal.gameObject.SetActive(true);
                    //  newCarCont.engineIsIdle = true;
                    SpeakText("stage1MissionText16Correct");
                    break;
                case 16:
                    backwardsButton.gameObject.SetActive(true);
                    SpeakText("stage1MissionText17");
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(ChangeScene());
                    break;
                case 17:
                    SpeakText("stage1MissionText18Incorrect1");
                    StartCoroutine(CorrectAnswerCoRoutine());
                    forwardParent.gameObject.SetActive(true);
                    backwardsButton.gameObject.SetActive(false);
                    break;
                case 18:
                    buttonsPanal.gameObject.SetActive(true);
                    SpeakText("stage1MissionText19Incorrect2");
                   
                    forwardParent.gameObject.SetActive(false);
                    backwardsButton.gameObject.SetActive(true);
                    break;
                case 19:
                    buttonsPanal.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    SpeakText("stage1MissionText20CorrectNMJ");
                    break;
            }

            if (answerCorrect)
            {
                HandleCorrectAnswer();
            }
        }

        private void HandleCorrectAnswer()
        {
            switch (arrayPos)
            {
                case 17:
                    textPanal.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(true);
                   // newCarCont.isCarActive = false;
                    break;
                case 18:
                    arrayPos = 18;
                   // newCarCont.isCarActive = false;
                    sphereParent.transform.position = resetPosition.transform.position;
                    forwardParent.gameObject.SetActive(true);
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
            Array.Fill(textBools, false);
            hasScrolled = false;
        }

        public void HideButton()
        {
            forwardParent.gameObject.SetActive(false);
        }

        public IEnumerator DelayTextButton()
        {
            yield return new WaitForSeconds(1);
            forwardButton.gameObject.SetActive(true);
        }

        public IEnumerator StartLevelText()
        {
            yield return new WaitForSeconds(2);
            textPanal.gameObject.SetActive(true);
            arrayPos = 0;
        }

        public IEnumerator MoveToBlankInvislbePanal()
        {
           // buttonsPanal.gameObject.SetActive(false);
            yield return new WaitForSeconds(5);
            textPanal.gameObject.SetActive(false);
            arrayPos = 20;
        }

        public IEnumerator CorrectAnswerCoRoutine()
        {

            yield return new WaitForSeconds(1);
            newCarCont.isCarActive = false;
            textBools[12] = false;
            //textPanal.gameObject.SetActive(true);
            //  textBools[12] = false;
            //  arrayPos = 12;
        }

        public void IntroTTSSpeak(int textIndex)
        {
            string textKey = $"stage1MissionText{textIndex}";
            LOLSDK.Instance.SpeakText(textKey);
            Debug.Log($"Intro Text {textIndex} Button is pressed");
        }

        private void SpeakText(string textKey)
        {
            LOLSDK.Instance.SpeakText(textKey);
        }

        public IEnumerator ChangeScene()
        {
            LOLSDK.Instance.SubmitProgress(0, 25, 100);
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Stage 2 Energy");
        }

        public void ResetCarPosition()
        {
            sphereParent.transform.position = resetPosition.transform.position;
        }
    }
}