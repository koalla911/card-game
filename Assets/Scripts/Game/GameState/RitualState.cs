using Game.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
	public class RitualState : GameState
	{
		[SerializeField] private Button exitButton = default;
		[SerializeField] private ResourcesWidget resourcesWidget = default;
		[SerializeField] private CardView cardPrefab = default;
		[SerializeField] private LayoutGroup cardParent = default;

		private ObjectPool<CardView> cardPool = default;

		public UnityEvent OnClickExitButton => exitButton.onClick;

		private void Awake()
		{

			//cardPool = new ObjectPool<CardView>(cardPrefab, GameController.Instance.ConfigHolder.Researches.MinPackSize, cardParent.gameObject);

		}

		protected override void OnEnable()
		{
			base.OnEnable();
			resourcesWidget.Init(GameController.Instance.ResourcesData);

			//GenerateCards();

			OnClickExitButton.AddListener(OnQuit);
		}

		protected override void OnDisable()
		{
			OnClickExitButton.RemoveListener(OnQuit);
			base.OnDisable();
		}

		private void GenerateCards()
		{
			for (int i = 0; i < GameController.Instance.ConfigHolder.Researches.MinPackSize; i++)
			{
				CardView cardView = cardPool.GetFreeElement();
				cardView.Init(GameController.Instance.ConfigHolder.Cards[i]);
			}
		}

		private void OnQuit()
		{
			GameState.Switch<MainState>();
		}
	}
}
