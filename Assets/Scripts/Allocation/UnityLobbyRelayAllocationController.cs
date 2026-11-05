using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Portfolio.Lobby.Allocation
{
    /// <summary>
    /// Stub showing where Unity Gaming Services Lobby + Relay would plug in.
    /// Intentionally does not reference UGS packages so the project opens without extras.
    /// </summary>
    public sealed class UnityLobbyRelayAllocationController : IServerAllocationController
    {
        public Task<AllocationResult> CreateAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default)
        {
            Debug.LogWarning("UnityLobbyRelayAllocationController is a stub. Add com.unity.services.lobby + relay and implement CreateLobby/JoinAllocation.");
            return Task.FromException<AllocationResult>(new NotImplementedException(
                "Install Unity Lobby & Relay packages and implement this adapter."));
        }

        public Task<AllocationResult> JoinAsync(string joinCode, CancellationToken cancellationToken = default)
        {
            Debug.LogWarning("UnityLobbyRelayAllocationController is a stub.");
            return Task.FromException<AllocationResult>(new NotImplementedException(
                "Install Unity Lobby & Relay packages and implement this adapter."));
        }
    }
}