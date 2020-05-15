/**
 * @author  zsq
 * @version 1.0
 */


public class PlayerManager
{
    private long _playerId;

    private long[] _playerEnemy;
    
    public long PlayerId
    {
        get => _playerId;
        set => _playerId = value;
    }

    public long[] PlayerEnemy
    {
        get => _playerEnemy;
        set => _playerEnemy = value;
    }
}
