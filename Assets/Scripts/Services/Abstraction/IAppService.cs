
namespace Services.Abstraction
{
    public interface IAppService
    {
        int Score { set; get; }
        void CheckAnswer(bool answerIsRight);
    }
}