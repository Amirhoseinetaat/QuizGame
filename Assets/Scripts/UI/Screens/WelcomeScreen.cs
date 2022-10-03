using GameWarriors.UIDomain.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services.Data;
using Services.Abstraction;
using GameWarriors.DependencyInjection.Extensions;
using GameWarriors.UIDomain.Abstraction;

namespace UI.Screens
{
    public class WelcomeScreen : UIScreenItem
    {
        public const string SCREEN_NAME = "WelcomeScreen";
        public override string ScreenName => SCREEN_NAME;

        //[SerializeField]
        //private Button _settingButton;
        //[SerializeField]
        //private Text _coinCountLable; 

        [SerializeField]
        private Text[] _playlistLabels;
        [SerializeField]
        private Button[] _playlistButtons;
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
            InitializeThePlayLists(playlistInventory.Playlists);
        }
        private void InitializeThePlayLists(List<Playlists> playlists)
        {
            for (int i = 0; i < playlists.Count; i++)
            {
                _playlistButtons[i].gameObject.SetActive(true);
                _playlistLabels[i].text = playlists[i].playlist;
                _playlistButtons[i].onClick.AddListener(() => OnPlaylistButtonClick(i));
            }
        }
        public void OnPlaylistButtonClick(int number)
        {
              QuestionsScreen screen = ScreenHandler.ShowScreen<QuestionsScreen>(QuestionsScreen.SCREEN_NAME, ECanvasType.ScreenCanvas, EPreviosScreenAct.Queue);
              screen.SetPlaylistID(number);
        }
    }
}