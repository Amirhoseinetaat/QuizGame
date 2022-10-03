using GameWarriors.UIDomain.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services.Data;
using Services.Abstraction;
using GameWarriors.DependencyInjection.Extensions;

namespace UI.Screens
{
    public class QuestionsScreen : UIScreenItem
    {
        public const string SCREEN_NAME = "QuestionsScreen";
        public override string ScreenName => SCREEN_NAME;

        //[SerializeField]
        //private Button _settingButton;
        //[SerializeField]
        //private Text _coinCountLable; 

        [SerializeField]
        private Text[] _questionslistLabels;
        [SerializeField]
        private Button[] _questionsButtons;
        private int _playlistID;
        public override bool HasBlackScreen => false;
        public override bool CanCloseByBack => false;
        public void SetData(string data)
        {

        }
        public override void OnShow(Action onClose = null, bool showAnimation = true)
        {
            base.OnShow(onClose, showAnimation);
        }
        public override void Initialization()
        {
            base.Initialization();

            IPlaylist playlistInventory = ServiceProvider.GetService<IPlaylist>();
            InitializeThePlayLists(playlistInventory.Playlists[_playlistID].questions);
        }
        private void InitializeThePlayLists(List<Question> questions)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                _questionsButtons[i].gameObject.SetActive(true);
                _questionslistLabels[i].text = "Question "+(i+1);
                _questionsButtons[i].onClick.AddListener(() => OnPlaylistButtonClick(i));
            }
        }
        public void OnPlaylistButtonClick(int number)
        {
            // SettingScreen screen = ScreenHandler.ShowScreen<SettingScreen>(SettingScreen.SCREEN_NAME, ECanvasType.ScreenCanvas, EPreviosScreenAct.Queue);

            // screen.SetData("herrlooooo");
        }

        public void SetPlaylistID(int id)
        {
            _playlistID = id;
        }
    }
}