using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Portfolio.Lobby.Allocation
{
    /// <summary>
    /// Offline/dev allocator that invents a join code. Replace with Unity Lobby+Relay or your backend.
    /// </summary>
    public sealed class LocalRelayAllocationController : IServerAllocationController
    {
        public Task<AllocationResult> CreateAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default)
        {
            var code = Guid.NewGuid().ToString("N")[..6].ToUpperInvariant();
            Debug.Log($"Created local session '{sessionName}' code={code} max={maxPlayers}");
            return Task.FromResult(new AllocationResult
            {
                JoinCode = code,
                AllocationId = Guid.NewGuid().ToString("N"),
                Host = "127.0.0.1",
                Port = 7777
            });
        }

        public Task<AllocationResult> JoinAsync(string joinCode, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(joinCode)) throw new ArgumentException("Join code required.");
            return Task.FromResult(new AllocationResult
            {
                JoinCode = joinCode.Trim().ToUpperInvariant(),
                AllocationId = Guid.NewGuid().ToString("N"),
                Host = "127.0.0.1",
                Port = 7777
            });
        }
    }
}