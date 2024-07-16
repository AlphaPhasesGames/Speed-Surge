using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage1TextManager : MonoBehaviour
    {

        public bool hasScrolled;

        public GameObject currentTextSection;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 1;

        public GameObject[] modelArray;

        public GameObject textPanal;
        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;

        public Button forwardButton;
        public Button backwardsButton;

        private void Awake()
        {
            forwardButton.onClick.AddListener(ProgressTextForward);
            backwardsButton.onClick.AddListener(ProgressTextBack);
        }
        // Start is called before the first frame update

        void Start()
        {
            arrayPos = 0; // on start set array pos to 0
            currentTextSection = modelArray[arrayPos]; // the current object we have selected is the building brick assigned by the arrayPos
            maxLengthArray = modelArray.Length; // max length of array is the length of the buildingBricks array
        
        }

        void Update()
        {
            if (!hasScrolled)
            {
                for (int i = 0; i < 10; i++)
                {
                    modelArray[i].SetActive(i == arrayPos);
                    Debug.Log("Do We SCroll Forever");
                    StartCoroutine(DelayTextButton());
                    hasScrolled = true;
                   
                }
            }


            if (Input.GetKeyDown(KeyCode.N))
            {
                arrayPos++;
                hasScrolled = false;
            }
            /*
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                    {
                        hasScrolled = false;
                        arrayPos = 0;
                    }
            */
            if (arrayPos == 10)
            {
                hasScrolled = false;
                arrayPos = 0;
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                panalOpen = !panalOpen;
                runOnce = false;
                runOnce2 = false;
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
            forwardButton.gameObject.SetActive(false);
        }

        public IEnumerator DelayTextButton()
        {
            //forwardButton.gameObject.SetActive(false);
            yield return new WaitForSeconds(5);
            forwardButton.gameObject.SetActive(true);
            Debug.Log("This coRoutine Runs");

        }

        
    }
}
