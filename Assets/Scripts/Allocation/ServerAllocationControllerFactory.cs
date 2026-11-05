namespace Portfolio.Lobby.Allocation
{
    public enum AllocationBackend
    {
        LocalRelay = 0,
        UnityLobbyRelay = 1
    }

    public static class ServerAllocationControllerFactory
    {
        public static IServerAllocationController Create(AllocationBackend backend)
        {
            return backend switch
            {
                AllocationBackend.LocalRelay => new LocalRelayAllocationController(),
                AllocationBackend.UnityLobbyRelay => new UnityLobbyRelayAllocationController(),
                _ => new LocalRelayAllocationController()
            };
        }
    }
}