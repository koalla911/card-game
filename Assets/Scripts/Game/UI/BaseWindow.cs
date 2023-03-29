using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public class BaseWindow : ScreenState
	{
		[Inject] private static UiService uiService = default;
		[Inject] protected static CardDataProvider bestiaryDataProvider = default;

		[SerializeField] private Button closeBtn = default;
		[SerializeField] private RectTransform buttonsLayout = default;

		public override void Open()
		{
			base.Open();
		}

		public override void Close()
		{
			base.Close();
		}

		//protected override void OnClickBackButton() => OnClickCloseBtn();

		private void Start()
		{
		}

		private void OnClickCloseBtn()
		{
			uiService.Close<BaseWindow>();
		}
	}
}
