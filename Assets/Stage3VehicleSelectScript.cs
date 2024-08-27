using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage3VehicleSelectScript : MonoBehaviour
    {
        //public SwitchVehicles switchVeh;
        public NewCarController newCarCont;
        public Stage3TextMan stage2TextMan;
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
        public bool panalOpen;
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



        public void ChooseCar()
        {
            //    car.gameObject.SetActive(true);
            //    skateBoard.gameObject.SetActive(false);
            //    toilet.gameObject.SetActive(false);
            //     toilet.gameObject.SetActive(false);
            // NewCarController.
            // newCarCont.isCarActive = true;
            carCol.gameObject.SetActive(true);
            stage2TextMan.hasScrolled = false;
            stage2TextMan.arrayPos = 2;
            stage2TextMan.forwardParent.gameObject.SetActive(true);
            car.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
            panalOpen = false;
            newCarCont.engineAudioSelected = true;
            Debug.Log("This runs");

        }

        public void ChooseSkate()
        {
            //     car.gameObject.SetActive(false);
            //     skateBoard.gameObject.SetActive(true);
            //     toilet.gameObject.SetActive(false);
            //      toilet.gameObject.SetActive(false);
            skateCol.gameObject.SetActive(true);
            stage2TextMan.hasScrolled = false;
            stage2TextMan.forwardParent.gameObject.SetActive(true);
            stage2TextMan.arrayPos = 2;
            skateBoard.gameObject.SetActive(true);
            newCarCont.skateAudioSelected = true;
            // switchVeh.hasScrolled = false;
            panalOpen = false;
        }

        public void ChooseToilet()
        {
            //    toilet.gameObject.SetActive(true);
            toiletCol.gameObject.SetActive(true);
            stage2TextMan.hasScrolled = false;
            stage2TextMan.forwardParent.gameObject.SetActive(true);
            stage2TextMan.arrayPos = 2;
            toilet.gameObject.SetActive(true);
            // switchVeh.hasScrolled = false;
            newCarCont.skateAudioSelected = true;
            panalOpen = false;
        }

        public void ChooseToyCar()
        {
            //    toilet.gameObject.SetActive(true);
            toyCarCol.gameObject.SetActive(true);
            stage2TextMan.hasScrolled = false;
            stage2TextMan.forwardParent.gameObject.SetActive(true);
            stage2TextMan.arrayPos = 2;
            toyCar.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
            newCarCont.skateAudioSelected = true;
            panalOpen = false;
        }

        public void ChooseBed()
        {
            //    car.gameObject.SetActive(true);
            //    skateBoard.gameObject.SetActive(false);
            //    toilet.gameObject.SetActive(false);
            //     toilet.gameObject.SetActive(false);
            // NewCarController.
            // newCarCont.isCarActive = true;
            bedCol.gameObject.SetActive(true);
            stage2TextMan.hasScrolled = false;
            stage2TextMan.arrayPos = 2;
            stage2TextMan.forwardParent.gameObject.SetActive(true);
            bed.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
            panalOpen = false;
            newCarCont.skateAudioSelected = true;
            Debug.Log("This runs");

        }

        public void ChooseBath()
        {
            bathCol.gameObject.SetActive(true);
            stage2TextMan.hasScrolled = false;
            stage2TextMan.arrayPos = 2;
            stage2TextMan.forwardParent.gameObject.SetActive(true);
            bath.gameObject.SetActive(true);
            //switchVeh.hasScrolled = false;
            panalOpen = false;
            newCarCont.skateAudioSelected = true;
            Debug.Log("This runs");

        }
    }
}
