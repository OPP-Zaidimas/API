namespace API.Lobby.StateHandlers
{
    public class WaitingHandler : IPlayerStateHandler
    {
        public void Handle(Player player)
        {
            player.State = States.Waiting;
        }
    }
}
