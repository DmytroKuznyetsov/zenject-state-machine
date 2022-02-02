namespace States.Game.Services
{
    public interface ILocalGameProgressService
    {
        void SaveProgress(GameProgress progress);
        GameProgress LoadProgress();
    }
}