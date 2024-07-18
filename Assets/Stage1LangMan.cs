using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LoLSDK;
using SimpleJSON;
using TMPro;

public class Stage1LangMan : MonoBehaviour
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
    public TextMeshProUGUI introText14;
    public TextMeshProUGUI introText15;
    public TextMeshProUGUI introText16;
    public TextMeshProUGUI introText17;
    public TextMeshProUGUI introText18;
    public TextMeshProUGUI introText19;
    public TextMeshProUGUI introText20;
    public TextMeshProUGUI introText21;
    public TextMeshProUGUI introText22;
    public TextMeshProUGUI introText23;
    private void Awake()
    {
        JSONNode defs = SharedState.LanguageDefs;

        introText1.text = defs["stage1MissionText1"];
        introText2.text = defs["stage1MissionText2"];
        introText3.text = defs["stage1MissionText3"];
        introText4.text = defs["stage1MissionText4"];
        introText5.text = defs["stage1MissionText5"];
        introText6.text = defs["stage1MissionText6"];
        introText7.text = defs["stage1MissionText7"];
        introText8.text = defs["stage1MissionText8"];
        introText9.text = defs["stage1MissionText9"];
        introText10.text = defs["stage1MissionText10"];
        introText11.text = defs["stage1MissionText11"];
        introText12.text = defs["stage1MissionText12"];
        introText13.text = defs["stage1MissionText13"];
        introText14.text = defs["stage1MissionText14"];
        introText15.text = defs["stage1MissionText15"];
        introText16.text = defs["stage1MissionText16"];
        introText17.text = defs["stage1MissionText17Question"];
        introText18.text = defs["stage1MissionText18Correct"];
        introText19.text = defs["stage1MissionText19"];
        introText20.text = defs["stage1MissionText20Incorrect1"];
        introText21.text = defs["stage1MissionText21Incorrect2"];
        introText22.text = defs["stage1MissionText22"];
        introText23.text = defs["stage1MissionText23"];
    }
}