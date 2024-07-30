using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using SimpleJSON;
using TMPro;
namespace SSGFE.Alpha.Phases.Games
{
    public class Stage2LangMan : MonoBehaviour
    {

        public TextMeshProUGUI introText1;
        public TextMeshProUGUI introText2;
        public TextMeshProUGUI introText3;
        public TextMeshProUGUI introText4;
        public TextMeshProUGUI introText5;
        public TextMeshProUGUI introText6;
        public TextMeshProUGUI introText7;
        public TextMeshProUGUI introText8;
        public TextMeshProUGUI introText9;
        public TextMeshProUGUI introText10;
        public TextMeshProUGUI introText11;
        public TextMeshProUGUI introText12;
        public TextMeshProUGUI introText13;

       // public TextMeshProUGUI stage2AssesEnergy;
       // public TextMeshProUGUI stage2AssesResist;

        public TextMeshProUGUI vehicleTitleText;
        public TextMeshProUGUI carText;
        public TextMeshProUGUI toiletText;
        public TextMeshProUGUI skateboardText;
        public TextMeshProUGUI toyCarText;
        public TextMeshProUGUI bedText;
        public TextMeshProUGUI bathText;


        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;

           // stage2AssesEnergy.text = defs["energyAssTitle"];
            //stage2AssesResist.text = defs["resistanceAssTitle"];

            vehicleTitleText.text = defs["vehicleTitle"];
            carText.text = defs["carName"];
            toiletText.text = defs["toiletName"];
            skateboardText.text = defs["skateBoardName"];
            toyCarText.text = defs["toyCarName"];
            bedText.text = defs["bedName"];
            bathText.text = defs["bathName"];

            introText1.text = defs["stage2MissionText1"];
            introText2.text = defs["stage2MissionText1ChooseCar"];
            introText3.text = defs["stage2MissionText2"];
            introText4.text = defs["stage2MissionText3"];
            introText5.text = defs["stage2MissionText4"];
            introText6.text = defs["stage2MissionText5"];
            introText7.text = defs["stage2MissionText6"];
            introText8.text = defs["stage2MissionText7"];
            introText9.text = defs["stage2MissionText8"];
            introText10.text = defs["stage2MissionText9Asses"];
            introText11.text = defs["stage2MissionText10Correct"];
            introText12.text = defs["stage2MissionText10Correct2"];
            introText13.text = defs["stage2MissionText11Wrong"];
        }
    }
}
