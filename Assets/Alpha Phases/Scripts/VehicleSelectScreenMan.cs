using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SSGFE.Alpha.Phases.Games
{
    public class VehicleSelectScreenMan : MonoBehaviour
    {
        //public SwitchVehicles switchVeh;
        public NewCarController newCarCont;
        public Stage1TextManager stage1TextMan;

        public bool runOnce;
        public bool runOnce2;

        public Button carButton;
        public Button skateBoardButton;
        public Button toiletButton;
        public Button toyCarButton;
        public Button bathButton;
        public Button bedButton;

        public GameObject carCol;
        public GameObject toyCarCol;
        public GameObject toiletCol;
        public GameObject bathCol;
        public GameObject bedCol;
        public GameObject skateCol;

        public GameObject car;
        public GameObject skateBoard;
        public GameObject toilet;
        public GameObject toyCar;
        public GameObject bath;
        public GameObject bed;


        public GameObject selectionPanal;
       // public bool panalOpen;
        // Start is called before the first frame update
        void Start()
        {
            carButton.onClick.AddListener(ChooseCar);
            skateBoardButton.onClick.AddListener(ChooseSkate);
            toiletButton.onClick.AddListener(ChooseToilet);
            toyCarButton.onClick.AddListener(ChooseToyCar);
            bedButton.onClick.AddListener(ChooseBed);
            bathButton.onClick.AddListener(ChooseBath);
        }

        // Update is called once per frame
        void Update()
        {/*
            if (Input.GetKeyDown(KeyCode.P))
            {
                //panalOpen = !panalOpen;
            }
            
            if (!runOnce)
            {
                if (panalOpen)
                {
                    selectionPanal.gameObject.SetActive(true);
                    runOnce = true;
                }
            }

            if (!runOnce2)
            {
                if (!panalOpen)
                {

                    selectionPanal.gameObject.SetActive(false);
                    runOnce2 = true;
                }
            }
          */
        }


        public void ChooseCar()
        {
            //    car.gameObject.SetActive(true);
            //    skateBoard.gameObject.SetActive(false);
            //    toilet.gameObject.SetActive(false);
            //     toilet.gameObject.SetActive(false);
            // NewCarController.
            // newCarCont.isCarActive = true;
            carCol.gameObject.SetActive(true);
            stage1TextMan.hasScrolled = false;
            stage1TextMan.arrayPos = 5;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            car.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
           // panalOpen = false;
            Debug.Log("This runs");

        }

        public void ChooseSkate()
        {
            //     car.gameObject.SetActive(false);
            //     skateBoard.gameObject.SetActive(true);
            //     toilet.gameObject.SetActive(false);
            //      toilet.gameObject.SetActive(false);
            skateCol.gameObject.SetActive(true);
            stage1TextMan.hasScrolled = false;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            stage1TextMan.arrayPos = 5;
            skateBoard.gameObject.SetActive(true);
            // switchVeh.hasScrolled = false;
            //panalOpen = false;
        }

        public void ChooseToilet()
        {
            toiletCol.gameObject.SetActive(true);
            //    toilet.gameObject.SetActive(true);
            stage1TextMan.hasScrolled = false;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            stage1TextMan.arrayPos = 5;
            toilet.gameObject.SetActive(true);
            // switchVeh.hasScrolled = false;
           // panalOpen = false;
        }

        public void ChooseToyCar()
        {
            toyCarCol.gameObject.SetActive(true);
            //    toilet.gameObject.SetActive(true);
            stage1TextMan.hasScrolled = false;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            stage1TextMan.arrayPos = 5;
            toyCar.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
          //  panalOpen = false;
        }

        public void ChooseBed()
        {
            bedCol.gameObject.SetActive(true);
            //    car.gameObject.SetActive(true);
            //    skateBoard.gameObject.SetActive(false);
            //    toilet.gameObject.SetActive(false);
            //     toilet.gameObject.SetActive(false);
            // NewCarController.
            // newCarCont.isCarActive = true;
            stage1TextMan.hasScrolled = false;
            stage1TextMan.arrayPos = 5;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            bed.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
          //  panalOpen = false;
            Debug.Log("This runs");

        }

        public void ChooseBath()
        {
            bathCol.gameObject.SetActive(true);
            stage1TextMan.hasScrolled = false;
            stage1TextMan.arrayPos = 5;
            stage1TextMan.forwardParent.gameObject.SetActive(true);
            bath.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
            //panalOpen = false;
            Debug.Log("This runs");

        }

    }
}
