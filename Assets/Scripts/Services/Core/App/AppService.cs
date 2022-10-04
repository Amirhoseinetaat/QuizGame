using Services.Abstraction;

namespace Services.Core.App
{
    public class AppService : IAppService
    {
        private int _score;
        private int _wronganswers;
        public int Score { get => _score;} 
        public int Wronganswers { get => _wronganswers; }
        public void CheckAnswer(bool answerIsRight)
        {
            if (answerIsRight) _score++; else _wronganswers++; 
        } 
    }
}