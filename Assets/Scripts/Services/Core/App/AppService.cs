using Services.Abstraction;

namespace Services.Core.App
{
    public class AppService : IAppService
    {
        private int _score;
        public int Score { 
            get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void CheckAnswer(bool answerIsRight)
        {
            if (answerIsRight)
            {
                _score++;
            }
            else
            {

            }
        }
         
    }
}