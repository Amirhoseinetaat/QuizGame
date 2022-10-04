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
        private int _playlistId;
        public override bool HasBlackScreen => false;
        public override bool CanCloseByBack => false;
        
        public override void OnShow(Action onClose = null, bool showAnimation = true)
        {
            base.OnShow(onClose, showAnimation); 
        }
        public override void Initialization()
        {
            base.Initialization(); 
        }
        public void InitializeTheQuestions()
        { 
            IPlaylist playlistInventory = ServiceProvider.GetService<IPlaylist>();
            List<Question> questions = playlistInventory.Playlists[_playlistId].questions;
            for (int i = 0; i < questions.Count; i++)
            {
                _questionsButtons[i].gameObject.SetActive(true);
                _questionslistLabels[i].text = "Question " + (i + 1);
                _questionsButtons[i].onClick.AddListener(() => OnPlaylistButtonClick(i));
            }
        }
        public void OnPlaylistButtonClick(int number)
        {
          
        }
        public void OnStartButtonClicked()
        {
            QuizScreen screen = ScreenHandler.ShowScreen<QuizScreen>(QuizScreen.SCREEN_NAME, ECanvasType.ScreenCanvas, EPreviosScreenAct.Queue);
            screen.SetData(0, _playlistId);
            screen.InitializeTheQuize();
        }

        public void SetPlaylistID(int id)
        {
            _playlistId = id;
        }
    }
}