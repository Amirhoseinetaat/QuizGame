using GameWarriors.UIDomain.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Services.Data;
using Services.Abstraction;
using GameWarriors.DependencyInjection.Extensions;
using Managers.Abstraction;
using GameWarriors.UIDomain.Abstraction;

namespace UI.Screens
{
    public class QuizScreen : UIScreenItem
    {
        public const string SCREEN_NAME = "QuizScreen";
        public override string ScreenName => SCREEN_NAME;

        //[SerializeField]
        //private Button _settingButton;
        //[SerializeField]
        //private Text _coinCountLable; 

        [SerializeField]
        private Text _quizLabel;
        [SerializeField]
        private Text[] _choiceLabels;
        [SerializeField]
        private ToggleGroup _answerToggle;
        [SerializeField]
        private Text _answerResultLabel;
        [SerializeField]
        private Image _answerResultImage;
        private int _questionID, _playlistID, _totalQuizes;
        private string _correctAnswer, _pictureURL, _playsongURL;
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
        public void InitializeTheQuize()
        {
            IPlaylist playlistInventory = ServiceProvider.GetService<IPlaylist>();
            List<Choice> choices = playlistInventory.Playlists[_playlistID].questions[_questionID].choices;
            int answerIndex = playlistInventory.Playlists[_playlistID].questions[_questionID].answerIndex;
            _correctAnswer = playlistInventory.Playlists[_playlistID].questions[_questionID].choices[answerIndex].title;
            _playsongURL = playlistInventory.Playlists[_playlistID].questions[_questionID].song.sample;
            _pictureURL = playlistInventory.Playlists[_playlistID].questions[_questionID].song.picture;
            _totalQuizes = playlistInventory.Playlists[_playlistID].questions.Count-1;
            IPlayAudio playAudio = ServiceProvider.GetService<IPlayAudio>();
            StartCoroutine(playAudio.PlayAudioClip(_playsongURL));
            _answerToggle.SetAllTogglesOff();
            _quizLabel.text = " Quize " + (_questionID + 1).ToString();
            for (int i = 0; i < _choiceLabels.Length; i++)
                _choiceLabels[i].text = choices[i].title;
        }
        public void OnSubmitAnswerClicked()
        {
            var answer = _answerToggle.GetFirstActiveToggle();
            if (answer == null) return;
            IAppService appService = ServiceProvider.GetService<IAppService>();
            bool isAnswerRight = (answer.GetComponentInChildren<Text>().text == _correctAnswer);
            appService.CheckAnswer(isAnswerRight);
            if (isAnswerRight)
            {
                StartCoroutine(DisplayAnswerResult("Your Answer Was Correct!", Color.green));
            }
            else
            {
                StartCoroutine(DisplayAnswerResult("Your Answer Was Wrong!", Color.red));
            }

            if (_totalQuizes <= _questionID)
            {
                ResultShowScreen screen = ScreenHandler.ShowScreen<ResultShowScreen>(ResultShowScreen.SCREEN_NAME, ECanvasType.ScreenCanvas, EPreviosScreenAct.Queue);
            }
            else
            {
                _questionID++;
                InitializeTheQuize();
            }
        }
        private IEnumerator DisplayAnswerResult(string text, Color32 color)
        {
            _answerResultImage.gameObject.SetActive(true);
            _answerResultLabel.text = text;
            _answerResultImage.color = color;
            yield return new WaitForSeconds(1);
            _answerResultImage.gameObject.SetActive(false);
        }
        public void OnPictureClicked()
        {
            Application.OpenURL(_pictureURL);
        }
        public void OnPlaySongClicked()
        {
            Application.OpenURL(_playsongURL);
        }
        public void SetData(int questionId, int playlistId)
        {
            _questionID = questionId;
            _playlistID = playlistId;
        }
    }
}