namespace Game
{
	/**
	*	Объявляем стейт-машину GameState
	*	ей состояниями будут классы-наследники GameState
	*	состояния переключаются через GameState.Switch<NextStateType>()
	**/
	public class GameState : Fancy.MonoStateMachine<GameState> { }

}
