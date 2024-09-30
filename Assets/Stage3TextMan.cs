using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using UnityEngine.SceneManagement;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3TextMan : MonoBehaviour
    {
        public bool hasScrolled;
        public Stage3VehicleSelectScript vehSelectMan;
        public NewCarControllerStage3 newCarCont;
        public GameObject currentTextSection;
        public Transform carRespawner;
        public GameObject sphereParent;
        public GameObject respawnerPos;
        public GameObject respawnerPos2;
        public GameObject respawnerPos3;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 1;

        public bool answerCorrect;

        public GameObject mphUI;
        public GameObject taskUIl;

        public GameObject[] modelArray;
        public GameObject wallPanal;
        public GameObject textScript11;
        public GameObject textScript12;

        public GameObject textScript13;
        public GameObject textScript14;
        public GameObject textScript15;
        public GameObject textScript16;

        public GameObject textPanal;
        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;

        public bool submitOnce;
        public bool submitOnce2;
        public GameObject forwardParent;
        public Button forwardButton;
        public Button backwardsButton;

        public Button[] textButtons;
        public bool[] textBools;


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

           
        }

        private void HandleArrayPosActions()
        {
            switch (arrayPos)
            {
                case 0:
                    if (!submitOnce)
                    {
                        LOLSDK.Instance.SubmitProgress(0, 55, 100);
                        submitOnce = true;
                    }
                   
                    newCarCont.isCarActive = false;
                    backwardsButton.gameObject.SetActive(false);
                    SpeakText("stage3MissionText1"); break;
                case 1:
                    HideButton();
                    backwardsButton.gameObject.SetActive(false);
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    SpeakText("stage3MissionText2ChooseCar"); break;
                case 2:
                    backwardsButton.gameObject.SetActive(false);
                    vehSelectMan.selectionPanal.gameObject.SetActive(false);
                    SpeakText("stage3MissionText3"); break;
                case 3:
                    backwardsButton.gameObject.SetActive(true);
                    SpeakText("stage3MissionText4"); break;
                case 4: SpeakText("stage3MissionText5"); break;
                case 5: SpeakText("stage3MissionText6"); break;
                case 6:
                 
                    SpeakText("stage3MissionText7"); break;
                case 7: SpeakText("stage3MissionText8"); break;
                case 8: SpeakText("stage3MissionText9"); break;
                case 9:
                    taskUIl.gameObject.SetActive(true);
                    wallPanal.gameObject.SetActive(true);
                    SpeakText("stage3MissionText10"); break;
                case 10: SpeakText("stage3MissionText11");
                    mphUI.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    HideButton();
                    newCarCont.isCarActive = true;
                    newCarCont.engineIsIdle = true; break;
                case 11:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    textScript11.gameObject.SetActive(false);
                    textScript13.gameObject.SetActive(false);
                    textScript14.gameObject.SetActive(false);
                    textScript15.gameObject.SetActive(false);
                    textScript12.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    SpeakText("stage3MissionText12"); break;
                case 12:

                    backwardsButton.gameObject.SetActive(false);
                    textScript11.gameObject.SetActive(false);
                    textScript12.gameObject.SetActive(false);
                    textScript14.gameObject.SetActive(false);
                    textScript13.gameObject.SetActive(true);
                    textPanal.gameObject.SetActive(true);
                    // StartCoroutine(DelayTextButton());
                    StartCoroutine(MoveToBlankInvislbePanal());
                    SpeakText("stage3MissionText13"); break;
                case 13:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    textScript12.gameObject.SetActive(false);
                    textScript13.gameObject.SetActive(false);
                    textScript14.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    SpeakText("stage3MissionText14"); break;
                case 14:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    textScript12.gameObject.SetActive(false);
                    textScript13.gameObject.SetActive(false);
                    textScript14.gameObject.SetActive(false);
                    textScript15.gameObject.SetActive(true);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    SpeakText("stage3MissionText15");
                    break;
                case 15:
                    backwardsButton.gameObject.SetActive(false);
                    textPanal.gameObject.SetActive(true);
                    textScript15.gameObject.SetActive(false);
                    textScript16.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(true);
                    newCarCont.isCarActive = false;
                    newCarCont.engineIsIdle = true;
                    //  newCarCont.engineIsIdle = true;
                    SpeakText("stage3MissionText16");
                    break;
                case 16:
                    SpeakText("stage3MissionText17");
                    forwardParent.gameObject.SetActive(false);
                    if (!submitOnce2)
                    {
                        submitOnce2 = true;
                        LOLSDK.Instance.SubmitProgress(0, 75, 100);
                    }
                    LOLSDK.Instance.SubmitProgress(0, 75, 100);
                    textPanal.gameObject.SetActive(true);
                    StartCoroutine(ChangeScene());
                    //hasScrolled = false;
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


        public IEnumerator ChangeScene()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Stage 4 Transfering Energy");
        }
        public IEnumerator RespawnCar()
        {
            //forwardButton.gameObject.SetActive(false);
            //   buttonsPanal.gameObject.SetActive(false);
            newCarCont.enabled = false;
            yield return new WaitForSeconds(5);
            textPanal.gameObject.SetActive(false);
            arrayPos = 17;
            Debug.Log("This start coRoutine Runs");
            sphereParent.transform.position = respawnerPos.transform.position;
            sphereParent.transform.rotation = Quaternion.Euler(0, 70, 0);
            newCarCont.enabled = true;
        }
/*
        public IEnumerator RespawnCar2()
        {
            //forwardButton.gameObject.SetActive(false);
            //   buttonsPanal.gameObject.SetActive(false);
            newCarCont.enabled = false;
            yield return new WaitForSeconds(5);
            textPanal.gameObject.SetActive(false);
            arrayPos = 17;
            Debug.Log("This start coRoutine Runs");
            sphereParent.transform.position = respawnerPos2.transform.position;
            sphereParent.transform.rotation = Quaternion.Euler(0, 70, 0);
            newCarCont.enabled = true;
        }
*/
        public IEnumerator RespawnCar3()
        {
            //forwardButton.gameObject.SetActive(false);
            //   buttonsPanal.gameObject.SetActive(false);
            newCarCont.enabled = false;
            yield return new WaitForSeconds(5);
            textPanal.gameObject.SetActive(false);
            arrayPos = 17;
            Debug.Log("This start coRoutine Runs");
            sphereParent.transform.position = respawnerPos3.transform.position;
            sphereParent.transform.rotation = Quaternion.Euler(0, 70, 0);
            newCarCont.enabled = true;
        }
        public void RespawnFunction()
        {
            //forwardButton.gameObject.SetActive(false);
            //   buttonsPanal.gameObject.SetActive(false);
            newCarCont.enabled = false;
            textPanal.gameObject.SetActive(false);
           // arrayPos = 17;
            Debug.Log("This start coRoutine Runs");
            sphereParent.transform.position = respawnerPos.transform.position;
         //   sphereParent.transform.rotation = Quaternion.Euler(0, 70, 0);
            newCarCont.enabled = true;
        }
    }

}

