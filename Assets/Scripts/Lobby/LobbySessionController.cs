using System;
using System.Threading;
using System.Threading.Tasks;
using Portfolio.Lobby.Allocation;

namespace Portfolio.Lobby
{
    public sealed class LobbySessionController
    {
        private readonly IServerAllocationController _allocation;

        public AllocationResult Current { get; private set; }
        public event Action<AllocationResult> SessionReady;

        public LobbySessionController(IServerAllocationController allocation)
        {
            _allocation = allocation ?? throw new ArgumentNullException(nameof(allocation));
        }

        public async Task CreateSessionAsync(string name, int maxPlayers, CancellationToken cancellationToken = default)
        {
            Current = await _allocation.CreateAsync(name, maxPlayers, cancellationToken);
            SessionReady?.Invoke(Current);
        }

        public async Task JoinSessionAsync(string joinCode, CancellationToken cancellationToken = default)
        {
            Current = await _allocation.JoinAsync(joinCode, cancellationToken);
            SessionReady?.Invoke(Current);
        }
    }
}