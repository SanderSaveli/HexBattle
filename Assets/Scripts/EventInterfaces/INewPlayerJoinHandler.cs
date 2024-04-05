namespace EventBusSystem
{
    public interface INewPlayerJoinHandler : IGlobalSubscriber
    {
        public void NewPlayerJoin(INetworkPlayer player);
    }

}

