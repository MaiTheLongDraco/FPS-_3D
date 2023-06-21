public interface IEnemyState
{
    void EnterState(Enemy _ctx);
    void UpdateState(Enemy _ctx);
    void ExitState(Enemy _ctx);
}
