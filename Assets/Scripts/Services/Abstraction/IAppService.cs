
namespace Services.Abstraction
{
    public interface IAppService
    {
        int Score { get; }
        int Wronganswers { get; }
        void CheckAnswer(bool answerIsRight);
    }
}