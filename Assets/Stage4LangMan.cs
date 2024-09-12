using UnityEngine;
using SimpleJSON;
using TMPro;

namespace SSGFE.Alpha.Phases.Games
{
    public class Stage4LangMan : MonoBehaviour
    {
        public TextMeshProUGUI vehicleTitleText;
        public TextMeshProUGUI carText;
        public TextMeshProUGUI toiletText;
        public TextMeshProUGUI skateboardText;
        public TextMeshProUGUI toyCarText;
        public TextMeshProUGUI bedText;
        public TextMeshProUGUI bathText;

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
        public TextMeshProUGUI introText14;
        public TextMeshProUGUI introText15;
        public TextMeshProUGUI introText16;
        public TextMeshProUGUI introText17;
        public TextMeshProUGUI introText18;

        public TextMeshProUGUI task;
        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;


            vehicleTitleText.text = defs["vehicleTitle"];
            carText.text = defs["carName"];
            toiletText.text = defs["toiletName"];
            skateboardText.text = defs["skateBoardName"];
            toyCarText.text = defs["toyCarName"];
            bedText.text = defs["bedName"];
            bathText.text = defs["bathName"];

            introText1.text = defs["stage4MissionText1"];
            introText2.text = defs["stage4MissionText2"];
            introText3.text = defs["stage4MissionText3"];
            introText4.text = defs["stage4MissionText4"];
            introText5.text = defs["stage4MissionText5"];
            introText6.text = defs["stage4MissionText6"];
            introText7.text = defs["stage4MissionText7"];
            introText8.text = defs["stage4MissionText8ChooseVehicle"];
            introText9.text = defs["stage4MissionText9"];
            introText10.text = defs["stage4MissionText10"];
            introText11.text = defs["stage4MissionText11"];
            introText12.text = defs["stage4MissionText12"];
            introText13.text = defs["stage4MissionText13"];
            introText14.text = defs["stage4MissionText14"];
            introText15.text = defs["stage4MissionText15"];
            introText16.text = defs["stage4MissionText16"];
            introText17.text = defs["stage4MissionText17"];
            introText18.text = defs["stage4MissionText18"];
            task.text = defs["Stage4Task"];
        }
    }
}
