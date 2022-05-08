namespace Application.Interfaces
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase useCase, IApplicationActor applicationActor, object useCaseData);
    }
}
