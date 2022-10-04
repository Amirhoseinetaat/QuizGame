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
    public class ResultShowScreen : UIScreenItem
    {
        public const string SCREEN_NAME = "ResultShowScreen";
        public override string ScreenName => SCREEN_NAME;

        [SerializeField]
        private Text _resultScoreLabel;
        private int _score, _totalQuizes;
        public override bool HasBlackScreen => false;
        public override bool CanCloseByBack => false;

        public override void OnShow(Action onClose = null, bool showAnimation = true)
        {
            base.OnShow(onClose, showAnimation);

        }
        public override void Initialization()
        {
            base.Initialization();
            InitializeTheResult();
        }
        public void InitializeTheResult()
        {
            IAppService appService = ServiceProvider.GetService<IAppService>();
            IPlayAudio playAudioice = ServiceProvider.GetService<IPlayAudio>();
            playAudioice.StopPlayAudioClip();
            _resultScoreLabel.text = "Score : "+ appService.Score + "\n" + "You answered " + appService.Score + " right and " + appService.Wronganswers + " wrong.";
        }
        public void OnNextButtonClicked()
        {
            WelcomeScreen screen = ScreenHandler.ShowScreen<WelcomeScreen>(WelcomeScreen.SCREEN_NAME, ECanvasType.ScreenCanvas, EPreviosScreenAct.Queue);
        }

    }
}