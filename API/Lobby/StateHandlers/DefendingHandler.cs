namespace API.Lobby.StateHandlers
{
    public class DefendingHandler : IPlayerStateHandler
    {
        public void Handle(Player player)
        {
            player.State = States.Defending;
        }
    }
}
