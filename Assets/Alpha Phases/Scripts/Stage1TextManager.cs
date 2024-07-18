using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1TextManager : MonoBehaviour
    {

        public bool hasScrolled;
        public VehicleSelectScreenMan vehSelectMan;
        public NewCarController newCarCont;
        public GameObject currentTextSection;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 1;

        public GameObject[] modelArray;

        public GameObject textPanal;
        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;

        public GameObject forwardParent;
        public Button forwardButton;
        public Button backwardsButton;

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
        public bool textBool24;
        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);
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
                for (int i = 0; i < 23; i++)
                {
                    modelArray[i].SetActive(i == arrayPos);
                    Debug.Log("Do We SCroll Forever");
                   // StartCoroutine(DelayTextButton());
                    hasScrolled = true;
                   
                }
            }

            /*
            if (Input.GetKeyDown(KeyCode.N))
            {
                arrayPos++;
                hasScrolled = false;
            }

         
            
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        hasScrolled = false;
                        arrayPos = 0;
                    }
            
            if (arrayPos == 24)
            {
                hasScrolled = false;
                arrayPos = 0;
            }
             
            if (arrayPos <= -0)
            {
                arrayPos = 0;
                hasScrolled = false;
                Debug.Log("Is this running forever");
            }
            */
            if (!textBool1)
            {
                if (arrayPos == 0)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText1");
                    // hasScrolled = false;
                    textBool1 = false;
                }
            }

            if (!textBool2)
            {
                if (arrayPos == 1) 
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText2");

                    textBool2 = false;
                }
            }

            if (!textBool3)
            {
                if (arrayPos == 2)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText3");
                    textBool3 = false;
                }
            }

            if (!textBool4)
            {
                if (arrayPos == 3)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText4");

                    textBool4 = false;
                }
            }

            if (!textBool5)
            {
                if (arrayPos == 4)
                {
                    HideButton();
                    vehSelectMan.panalOpen = true;
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    LOLSDK.Instance.SpeakText("stage1MissionText5");
                    // hasScrolled = false;
                    textBool5 = false;
                }
            }

            if (!textBool6)
            {
                if (arrayPos == 5)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText6");

                    textBool6 = false;
                }
            }

            if (!textBool7)
            {
                if (arrayPos == 6)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText7");
                    textBool7 = false;
                }
            }

            if (!textBool8)
            {
                if (arrayPos == 7)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText8");

                    textBool8 = false;
                }
            }

            if (!textBool9)
            {
                if (arrayPos == 8)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText9");
                    // hasScrolled = false;
                    textBool9 = false;
                }
            }

            if (!textBool10)
            {
                if (arrayPos == 9)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText10");

                    textBool10 = false;
                }
            }

            if (!textBool11)
            {
                if (arrayPos == 10)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText11");
                    textBool11 = false;
                }
            }

            if (!textBool12)
            {
                if (arrayPos == 11)
                {
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    newCarCont.isCarActive = true;
                    LOLSDK.Instance.SpeakText("stage1MissionText12");
                    textBool12 = false;
                }
            }

            if (!textBool13)
            {
                if (arrayPos == 12)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText13");
                    // StartCoroutine(DelayTextButton());
                    forwardParent.gameObject.SetActive(true);
                    hasScrolled = false;
                    textBool13 = false;
                }
            }

            if (!textBool14)
            {
                if (arrayPos == 13)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText14");

                    textBool14 = false;
                }
            }

            if (!textBool15)
            {
                if (arrayPos == 14)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText15");
                    textBool15 = false;
                }
            }

            if (!textBool16)
            {
                if (arrayPos == 15)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText16");

                    textBool16 = false;
                }
            }

            if (!textBool17)
            {
                if (arrayPos == 16)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText17");

                    textBool17 = false;
                }
            }

            if (!textBool18)
            {
                if (arrayPos == 17)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText18");
                    // hasScrolled = false;
                    textBool18 = false;
                }
            }

            if (!textBool19)
            {
                if (arrayPos == 18)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText19");

                    textBool19 = false;
                }
            }

            if (!textBool20)
            {
                if (arrayPos == 19)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText20");
                    textBool20 = false;
                }
            }

            if (!textBool21)
            {
                if (arrayPos == 20)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText21");

                    textBool21 = false;
                }
            }

            if (!textBool22)
            {
                if (arrayPos == 21)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText20");
                    textBool20 = false;
                }
            }

            if (!textBool23)
            {
                if (arrayPos == 22)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText22");

                    textBool21 = false;
                }
            }

            if (!textBool24)
            {
                if (arrayPos == 23)
                {
                    LOLSDK.Instance.SpeakText("stage1MissionText23");

                    textBool24 = false;
                }
            }
            /*
            if (!restrictionBool1)
            {
                if (arrayPos == 4)
                {
                    HideButton();
                    vehSelectMan.panalOpen = true;
                    vehSelectMan.selectionPanal.gameObject.SetActive(true);
                    restrictionBool1 = true;

                }
            }

            if (!restrictionBool4)
            {
                if (arrayPos == 11)
                {
                    forwardParent.gameObject.SetActive(false);
                    StartCoroutine(MoveToBlankInvislbePanal());
                    newCarCont.isCarActive = true;
                    restrictionBool4 = true;

                }
            }

            if (!restrictionBool5)
            {
                if (arrayPos == 12)
                {
                   StartCoroutine(DelayTextButton());
                    restrictionBool5 = true;

                }
            }
            
            if (!restrictionBool2)
            {
                if (arrayPos == 0)
                {
                    backwardsButton.gameObject.SetActive(false);
                    restrictionBool2 = true;
                }
            }

            if (!restrictionBool3)
            {
                if (arrayPos != 0)
                {
                    backwardsButton.gameObject.SetActive(true);
                    restrictionBool3 = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                panalOpen = !panalOpen;
                runOnce = false;
                runOnce2 = false;
            }
            */
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

            yield return new WaitForSeconds(5);
            forwardButton.gameObject.SetActive(true);
            hasScrolled = false;
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
            yield return new WaitForSeconds(5);
            textPanal.gameObject.SetActive(false);
            arrayPos = 24;
            Debug.Log("This start coRoutine Runs");

        }

        public void TTSTextButton1()
        {

        }

        public void IntroTTSSpeak1()
        {
            LOLSDK.Instance.SpeakText("stage3IntroText1");
            Debug.Log(" introText1 Button is pressed");
        }

        public void IntroTTSSpeak2()
        {
            LOLSDK.Instance.SpeakText("stage3IntroText2");
            Debug.Log("introText2 Button is pressed");
        }

        public void IntroTTSSpeak3()
        {
            LOLSDK.Instance.SpeakText("stage3IntroText3");
            Debug.Log("introText3 Button is pressed");
        }

        public void CarryOnText1()
        {
            LOLSDK.Instance.SpeakText("stage3IntroText15");
            Debug.Log("stage3IntroText15 Button is pressed");
        }

        public void CarryOnText2()
        {
            LOLSDK.Instance.SpeakText("stage3IntroText16");
            Debug.Log("stage3IntroText16 Button is pressed");
        }
    }

}
