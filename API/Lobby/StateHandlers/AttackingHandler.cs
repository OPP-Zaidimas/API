namespace API.Lobby.StateHandlers
{
    public class AttackingHandler : IPlayerStateHandler
    {
        public void Handle(Player player)
        {
            player.State = States.Attacking;
        }
    }
}
