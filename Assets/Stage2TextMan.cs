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
        public NewCarController newCarCont;
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

/*
   public bool hasScrolled;
        public Stage2VehicleSelectScript vehSelectMan;
        public NewCarController newCarCont;
        public GameObject currentTextSection;

        public GameObject sidePanalBoxes;

        public GameObject sphereParent;
        public GameObject resetPosition;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 1;

        public bool answerCorrect;

        public GameObject[] modelArray;

        public GameObject textPanal;
        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;
        public bool runOnce3;

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
        public bool textBool14;
        public bool textBool15;
        public bool textBool16;
        public bool textBool17;
        public bool textBool18;
        public bool textBool19;
        public bool textBool20;
        public bool textBool21;
        public bool textBool22;
        public bool textBool23;

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
        public Button textButton14;
        public Button textButton15;
        public Button textButton16;
        public Button textButton17;
        public Button textButton18;
        public Button textButton19;
        public Button textButton20;
        public Button textButton21;
        public Button textButton22;

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
            textButton14.onClick.AddListener(IntroTTSSpeak14);
            textButton15.onClick.AddListener(IntroTTSSpeak15);
            textButton16.onClick.AddListener(IntroTTSSpeak16);
            textButton17.onClick.AddListener(IntroTTSSpeak17);
            textButton18.onClick.AddListener(IntroTTSSpeak18);
            textButton19.onClick.AddListener(IntroTTSSpeak19);
            textButton20.onClick.AddListener(IntroTTSSpeak20);
            textButton21.onClick.AddListener(IntroTTSSpeak21);
            textButton22.onClick.AddListener(IntroTTSSpeak22);
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
                for (int i = 0; i < 22; i++)
                {
                    modelArray[i].SetActive(i == arrayPos);
                    Debug.Log("Do We SCroll Forever");
                    // StartCoroutine(DelayTextButton());
                    hasScrolled = true;

                }
            }



            if (arrayPos == 0)
            {
                if (!textBool1)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText1");
                    hasScrolled = false;
                    textBool1 = true;
                } 
            }


            if (arrayPos == 1)
            {
                if (!textBool2)
                {
                    HideButton();
                    vehSelectMan.panalOpen = true;
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    LOLSDK.Instance.SpeakText("stage2MissionText2ChooseCar");

                    textBool2 = true;
                } 
            }


            if (arrayPos == 2)
            {
                if (!textBool3)
                {
                    vehSelectMan.selectionPanal.gameObject.SetActive(false);
                    LOLSDK.Instance.SpeakText("stage2MissionText3");
                    textBool3 = true;
                } 
            }


            if (arrayPos == 3)
            {
                if (!textBool4)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText4");

                    textBool4 = true;
                } 
            }


            if (arrayPos == 4)
            {
                if (!textBool5)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText5");
                    // hasScrolled = false;
                    textBool5 = true;
                } 
            }


            if (arrayPos == 5)
            {
                if (!textBool6)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText6");

                    textBool6 = true;
                } 
            }


            if (arrayPos == 6)
            {
                if (!textBool7)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText7");
                    textBool7 = true;
                } 
            }


            if (arrayPos == 7)
            {
                if (!textBool8)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText8");

                    textBool8 = true;
                } 
            }


            if (arrayPos == 8)
            {
                if (!textBool9)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText9");

                    // hasScrolled = false;
                    textBool9 = true;
                } 
            }


            if (arrayPos == 9)
            {
                if (!textBool10)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText10");

                    textBool10 = true;
                } 
            }


            if (arrayPos == 10)
            {
                if (!textBool11)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText11");
                    textBool11 = true;
                } 
            }


            if (arrayPos == 11)
            {
                if (!textBool12)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText12");
                    sidePanalBoxes.gameObject.SetActive(true);
                    textBool12 = true;
                } 
            }


            if (arrayPos == 12)
            {
                if (!textBool13)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText13");
                    // StartCoroutine(DelayTextButton());
                    textBool13 = true;
                } 
            }


            if (arrayPos == 13)
            {
                //  HideButton();
                if (!textBool14)
                {


                    LOLSDK.Instance.SpeakText("stage2MissionText14");
                    textBool14 = true;
                } 
            }


            if (arrayPos == 14)
            {
                if (!textBool15)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText15");
                    // StartCoroutine(DelayTextButton());
                    newCarCont.isCarActive = true;
                    newCarCont.engineIsIdle = true;
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    hasScrolled = false;
                    textBool15 = true;
                } 
            }


            if (arrayPos == 15)
            {
                if (!textBool16)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText16");
                    textPanal.gameObject.SetActive(true);

                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(ResetCarArrayMove());
                    hasScrolled = false;
                    textBool16 = true;
                } 
            }

            if (arrayPos == 16)
            {
                if (!textBool17)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText17");
                    textPanal.gameObject.SetActive(true);

                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    hasScrolled = false;
                    textBool17 = true;
                } 
            }



            if (arrayPos == 17)
            {
                if (!textBool18)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText18");
                    textPanal.gameObject.SetActive(true);

                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    hasScrolled = false;
                    textBool18 = true;
                } 
            }


            if (arrayPos == 18)
            {
                if (!textBool19)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText19");
                    textPanal.gameObject.SetActive(true);
                    newCarCont.isCarActive = false;
                    forwardParent.gameObject.SetActive(true);

                    hasScrolled = false;
                    textBool19 = true;
                } 
            }

            if (arrayPos == 19)
            {
                if (!textBool20)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText20");

                    // textPanal.gameObject.SetActive(true);
                    StartCoroutine(ChangeScene());
                    forwardParent.gameObject.SetActive(false);

                    hasScrolled = false;
                    textBool20 = true;
                } 
            }


            if (arrayPos == 20)
            {
                if (!textBool21)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText21");

                    textPanal.gameObject.SetActive(true);
                    // StartCoroutine(ChangeScene());
                    forwardParent.gameObject.SetActive(true);

                    hasScrolled = false;
                    textBool21 = true;
                } 
            }


            if (arrayPos == 21)
            {
                if (!textBool22)
                {
                    LOLSDK.Instance.SpeakText("stage2MissionText22");

                    //textPanal.gameObject.SetActive(true);
                    //StartCoroutine(ChangeScene());
                    forwardParent.gameObject.SetActive(false);

                    StartCoroutine(ResetCarArrayMove());
                    hasScrolled = false;
                    textBool22 = true;
                    restrictionBool2 = true;
                } 
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
            hasScrolled = false;
            textPanal.gameObject.SetActive(false);
            arrayPos = 24;
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
            LOLSDK.Instance.SpeakText("stage2MissionText2ChooseCar");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak3()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText3");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak4()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText4");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak5()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText5");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak6()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText6");
            Debug.Log(" introText1 Button is pressed");
        }

        public void IntroTTSSpeak7()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText7");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak8()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText8");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak9()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText9");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak10()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText10");
            Debug.Log("introText3 Button is pressed");
        }


        public void IntroTTSSpeak11()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText11");
            Debug.Log(" introText1 Button is pressed");
        }

        public void IntroTTSSpeak12()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText12");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak13()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText13");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak14()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText14");
            Debug.Log(" introText1 Button is pressed");
        }

        public void IntroTTSSpeak15()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText15");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak16()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText16");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak17()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText17");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak18()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText18");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak19()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText19");
            Debug.Log(" introText1 Button is pressed");
        }

        public void IntroTTSSpeak20()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText20");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak21()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText21");
            Debug.Log("introText3 Button is pressed");
        }

        public void IntroTTSSpeak22()
        {
            LOLSDK.Instance.SpeakText("stage2MissionText22");
            Debug.Log("introText2 Button is pressed");
        }

        public IEnumerator ChangeScene()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("Stage 3 Increased Energy");
        }
    }*/