# Unity Netcode Lobby (Allocation Ports)

Sanitized lobby/session flow with a swappable allocation port:

- `IServerAllocationController`
- `LocalRelayAllocationController` (works offline for demos)
- `UnityLobbyRelayAllocationController` stub (plug in UGS Lobby + Relay)
- `LobbySessionController` create/join orchestration

No GameLift, no product branding, no secrets.

Optional packages (not required to open the project):

- `com.unity.netcode.gameobjects`
- `com.unity.services.lobby`
- `com.unity.services.relay`

## Author

[Pedro Paulo](https://github.com/PedroPPMN) — MIT