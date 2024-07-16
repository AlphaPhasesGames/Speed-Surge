using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SSGFE.Alpha.Phases.Games
{
    public class SwitchVehicles : MonoBehaviour
    {
        public bool hasScrolled;
        public NewCarController newCarCont;
        public GameObject currentModel;
        public int arrayPos;
        public int maxLengthArray;
        public int minLengthArray = 1;

        public GameObject[] modelArray;

        public Button carButton;
        public Button skateBoardButton;
        public Button toiletButton;
        public Button toyCarButton;

        public GameObject selectionPanal;
        public bool panalOpen;
        public bool runOnce;
        public bool runOnce2;
        // Start is called before the first frame update
        void Start()
        {
            arrayPos = 4; // on start set array pos to 0
            currentModel = modelArray[arrayPos]; // the current object we have selected is the building brick assigned by the arrayPos
            maxLengthArray = modelArray.Length; // max length of array is the length of the buildingBricks array
            carButton.onClick.AddListener(ChooseCar);
            skateBoardButton.onClick.AddListener(ChooseSkate);
            toiletButton.onClick.AddListener(ChooseToilet);
            toyCarButton.onClick.AddListener(ChooseToyCar);
        }

        // Update is called once per frame
        void Update()
        {

            if (!hasScrolled)
            {
                for (int i = 0; i < 5; i++)
                {
                    modelArray[i].SetActive(i == arrayPos);
                    Debug.Log("Do We SCroll Forever");
                    hasScrolled = true;
                }
            }


            if (Input.GetKeyDown(KeyCode.H))
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
            if (arrayPos == 5)
            {
                hasScrolled = false;
                arrayPos = 0;
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                panalOpen = !panalOpen;
                runOnce = false;
                runOnce2 = false;
            }

            if (panalOpen)
            {
                if (!runOnce)
                {
                    selectionPanal.gameObject.SetActive(true);
                    runOnce = true;
                    runOnce2 = false;
                    Debug.Log("Running Once");
                }
            }

            else if (!panalOpen)
            {
                if (!runOnce2)
                {
                    selectionPanal.gameObject.SetActive(false);
                    runOnce2 = true;
                    Debug.Log("Running Once 2");
                }

            }
        }


        public void ChooseCar()
        {
            arrayPos = 0;
            hasScrolled = false;
            panalOpen = false;
            newCarCont.engineIsIdle = true;
        }

        public void ChooseSkate()
        {

            arrayPos = 2;
            hasScrolled = false;
            panalOpen = false;
        }

        public void ChooseToilet()
        {
            arrayPos = 1;
            hasScrolled = false;
            panalOpen = false;
        }

        public void ChooseToyCar()
        {

            arrayPos = 3;
            hasScrolled = false;
            panalOpen = false;
        }
    }
}
