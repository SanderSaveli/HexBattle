namespace SceneStateSystem
{
    public interface ISceneState
    {
        public SceneStatesNames name { get; }
        public void StateBegin();
        public void StateEnd();
    }
}
