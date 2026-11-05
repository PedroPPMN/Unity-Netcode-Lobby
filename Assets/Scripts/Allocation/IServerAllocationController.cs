using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Lobby.Allocation
{
    public sealed class AllocationResult
    {
        public string JoinCode;
        public string AllocationId;
        public string Host;
        public ushort Port;
    }

    public interface IServerAllocationController
    {
        Task<AllocationResult> CreateAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default);
        Task<AllocationResult> JoinAsync(string joinCode, CancellationToken cancellationToken = default);
    }
}