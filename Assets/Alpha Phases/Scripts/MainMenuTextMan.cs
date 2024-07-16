using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using SimpleJSON;
using TMPro;

namespace SSGFE.Alpha.Phases.Games
{
    public class MainMenuTextMan : MonoBehaviour
    {
        public TextMeshProUGUI startGame;
        public TextMeshProUGUI continueGame;

        private void Awake()
        {
            JSONNode defs = SharedState.LanguageDefs;
            startGame.text = defs["newGame"];
            continueGame.text = defs["continue"];
        }
    }
}
