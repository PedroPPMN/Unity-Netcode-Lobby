using Portfolio.Lobby;
using Portfolio.Lobby.Allocation;
using UnityEngine;
using UnityEngine.UI;

namespace Portfolio.Lobby.Demo
{
    public sealed class LobbyDemoBootstrap : MonoBehaviour
    {
        [SerializeField] private AllocationBackend backend = AllocationBackend.LocalRelay;
        [SerializeField] private InputField sessionNameInput;
        [SerializeField] private InputField joinCodeInput;
        [SerializeField] private Text statusText;
        [SerializeField] private Button createButton;
        [SerializeField] private Button joinButton;

        private LobbySessionController _lobby;

        private void Start()
        {
            _lobby = new LobbySessionController(ServerAllocationControllerFactory.Create(backend));
            _lobby.SessionReady += result =>
            {
                if (statusText != null)
                {
                    statusText.text = $"Ready\nCode: {result.JoinCode}\n{result.Host}:{result.Port}";
                }
            };

            if (createButton != null) createButton.onClick.AddListener(async () =>
            {
                var name = sessionNameInput != null ? sessionNameInput.text : "Demo";
                await _lobby.CreateSessionAsync(name, 4);
            });

            if (joinButton != null) joinButton.onClick.AddListener(async () =>
            {
                var code = joinCodeInput != null ? joinCodeInput.text : string.Empty;
                await _lobby.JoinSessionAsync(code);
            });
        }
    }
}