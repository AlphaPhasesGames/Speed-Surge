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
        public bool hasScrolled;
        public Stage2VehicleSelectScript vehSelectMan;
        public NewCarController newCarCont;
        public GameObject currentTextSection;

        public GameObject sphereParent;
      //  public GameObject resetPosition;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 1;

        public bool answerCorrect;

        public GameObject[] modelArray;

        public GameObject textPanal;
        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;

        public GameObject forwardParent;
        public Button forwardButton;
        public Button backwardsButton;

        public GameObject text1;

        public bool restrictionBool1;
        public bool restrictionBool2;
        public bool restrictionBool3;
        public bool restrictionBool4;
        public bool restrictionBool5;

        public bool textBool1;
        public bool textBool2;
        public bool textBool3;
        public bool textBool4;
        public bool textBool5;
        public bool textBool6;
        public bool textBool7;
        public bool textBool8;
        public bool textBool9;
        public bool textBool10;
        public bool textBool11;
        public bool textBool12;
        public bool textBool13;

        public Button textButton1;
        public Button textButton2;
        public Button textButton3;
        public Button textButton4;
        public Button textButton5;
        public Button textButton6;
        public Button textButton7;
        public Button textButton8;
        public Button textButton9;
        public Button textButton10;
        public Button textButton11;
        public Button textButton12;
        public Button textButton13;


        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);
            textButton1.onClick.AddListener(IntroTTSSpeak1);
            textButton2.onClick.AddListener(IntroTTSSpeak2);
            textButton3.onClick.AddListener(IntroTTSSpeak3);
            textButton4.onClick.AddListener(IntroTTSSpeak4);
            textButton5.onClick.AddListener(IntroTTSSpeak5);
            textButton6.onClick.AddListener(IntroTTSSpeak6);
            textButton7.onClick.AddListener(IntroTTSSpeak7);
            textButton8.onClick.AddListener(IntroTTSSpeak8);
            textButton9.onClick.AddListener(IntroTTSSpeak9);
            textButton10.onClick.AddListener(IntroTTSSpeak10);
            textButton11.onClick.AddListener(IntroTTSSpeak11);
            textButton12.onClick.AddListener(IntroTTSSpeak12);
            textButton13.onClick.AddListener(IntroTTSSpeak13);
            StartCoroutine(StartLevelText());
        }
        // Start is called before the first frame update

        void Start()
        {
            //arrayPos = 0; // on start set array pos to 0
            currentTextSection = modelArray[arrayPos]; // the current object we have selected is the building brick assigned by the arrayPos
            maxLengthArray = modelArray.Length; // max length of array is the length of the buildingBricks array

        }

        void Update()
        {
            if (!hasScrolled)
            {
                for (int i = 0; i < 13; i++)
                {
                    modelArray[i].SetActive(i == arrayPos);
                    Debug.Log("Do We SCroll Forever");
                    // StartCoroutine(DelayTextButton());
                    hasScrolled = true;

                }
            }

        
            if (!textBool1)
            {
                if (arrayPos == 0)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText1");
                    // hasScrolled = false;
                    textBool1 = true;
                }
            }

            if (!textBool2)
            {
                if (arrayPos == 1)
                {
                    HideButton();
                    vehSelectMan.panalOpen = true;
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    LOLSDK.Instance.SpeakText("stage2MissionText1ChooseCar");

                    textBool2 = true;
                }
            }

            if (!textBool3)
            {
                if (arrayPos == 2)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText2");
                    textBool3 = true;
                }
            }

            if (!textBool4)
            {
                if (arrayPos == 3)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText3");

                    textBool4 = true;
                }
            }

            if (!textBool5)
            {
                if (arrayPos == 4)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText4");
                    // hasScrolled = false;
                    textBool5 = true;
                }
            }

            if (!textBool6)
            {
                if (arrayPos == 5)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText5");

                    textBool6 = true;
                }
            }

            if (!textBool7)
            {
                if (arrayPos == 6)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText6");
                    textBool7 = true;
                }
            }

            if (!textBool8)
            {
                if (arrayPos == 7)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText7");
                    
                    textBool8 = true;
                }
            }

            if (!textBool9)
            {
                if (arrayPos == 8)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText8");
                   
                    // hasScrolled = false;
                    textBool9 = true;
                }
            }

            if (!textBool10)
            {
                if (arrayPos == 9)
                {
                    HideButton();
                    newCarCont.isCarActive = true;
                    newCarCont.engineIsIdle = true;
                    LOLSDK.Instance.SpeakText("stage2MissionText9Asses");

                    textBool10 = true;
                }
            }

            if (!textBool11)
            {
                if (arrayPos == 10)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText10Correct");
                    textBool11 = true;
                }
            }

            if (!textBool12)
            {
                if (arrayPos == 11)
                {
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());

                    LOLSDK.Instance.SpeakText("stage2MissionText10Correct2");
                    textBool12 = true;
                }
            }

            if (!textBool13)
            {
                if (arrayPos == 12)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText11Wrong");
                    // StartCoroutine(DelayTextButton());
                    forwardParent.gameObject.SetActive(true);
                    hasScrolled = false;
                    textBool13 = true;
                }
            }

            if (restrictionBool1)
            {
                if (answerCorrect)
                {

                    //arrayPos = 18;
                    textPanal.gameObject.SetActive(true);
                    forwardParent.gameObject.SetActive(true);
                    //  StartCoroutine(CorrectAnswerCoRoutine());
                    restrictionBool1 = false;
                    newCarCont.isCarActive = false;
                }

            }
            if (restrictionBool2)
            {
                if (!answerCorrect)
                {

                 //   arrayPos = 19;
                   // sphereParent.transform.position = resetPosition.transform.position;
                    newCarCont.isCarActive = false;
                    forwardParent.gameObject.SetActive(true);
                    restrictionBool2 = false;
                    //textBool20 = false;
                }
            }

            if (panalOpen)
            {
                if (!runOnce)
                {

                    textPanal.gameObject.SetActive(true);
                    runOnce = true;
                    runOnce2 = false;
                    forwardButton.gameObject.SetActive(false);
                    Debug.Log("Running Once");
                }
            }

            else if (!panalOpen)
            {
                if (!runOnce2)
                {
                    textPanal.gameObject.SetActive(false);
                    runOnce2 = true;
                    Debug.Log("Running Once 2");
                }

            }
        }

        public void ProgressTextForward()
        {
            arrayPos++;
            StopCoroutine(DelayTextButton());
            StartCoroutine(DelayTextButton());
            hasScrolled = false;
            forwardButton.gameObject.SetActive(false);
            //  panalOpen = false;

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
            text1.gameObject.SetActive(true);
            arrayPos = 0;
            Debug.Log("This start coRoutine Runs");

        }

        public IEnumerator MoveToBlankInvislbePanal()
        {
            //forwardButton.gameObject.SetActive(false);
            yield return new WaitForSeconds(5);
            textPanal.gameObject.SetActive(false);
            arrayPos = 24;
            Debug.Log("This start coRoutine Runs");

        }

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


        public void IntroTTSSpeak1()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText1");
            Debug.Log(" introText1 Button is pressed");
        }

        public void IntroTTSSpeak2()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText1ChooseCar");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak3()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText2");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak4()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText3");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak5()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText4");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak6()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText5");
            Debug.Log(" introText1 Button is pressed");
        }

        public void IntroTTSSpeak7()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText6");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak8()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText7");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak9()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText8");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak10()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText9Asses");
            Debug.Log("introText3 Button is pressed");
        }


        public void IntroTTSSpeak11()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText10Correct");
            Debug.Log(" introText1 Button is pressed");
        }

        public void IntroTTSSpeak12()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText10Correct2");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak13()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText11Wrong");
            Debug.Log("introText3 Button is pressed");
        }

        public IEnumerator ChangeScene()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Stage 2 Energy");
        }
    }
}
