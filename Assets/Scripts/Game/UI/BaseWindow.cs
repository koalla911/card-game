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

		/*public override void Open()
		{
			base.Open();
			biomePanel.OnClickPreview += BiomePanel_OnClickPreview;
			bestiaryDataProvider.AppliedCoinsChanged += BestiaryDataProvider_AppliedCoinsChanged;
			foreach (var btn in biomeButtons)
			{
				btn.OnClick += OnClickBiomeBtn;
			}

			ShowBiome(locationsDataProvider.GetCurrentBiomeId());
			sharePanel.Hide();
			MessageUtility.Publish<BestiaryOpenedMessage>();
		}*/

		/*public override void Close()
		{
			base.Close();
			biomePanel.OnClickPreview -= BiomePanel_OnClickPreview;
			foreach (var btn in biomeButtons)
			{
				btn.OnClick -= OnClickBiomeBtn;
			}
			biomePanel.Clear();
		}*/

		/*protected override void OnClickBackButton() => OnClickCloseBtn();

		private void BiomePanel_OnClickPreview(Sprite sprite, Vector2 size)
		{
			sharePanel.Show(sprite, size);
		}

		private void Start()
		{
			closeBtn.onClick.AddListener(OnClickCloseBtn);
		}*/

		/*private void OnClickCloseBtn()
		{
			MessageUtility.Publish<BestiaryClosedMessage>();
			uiService.Close<BaseWindow>();
		}

		private void OnClickBiomeBtn(BestiaryBiomeButton btn) => ShowBiome(btn.BiomeId);

		private void BestiaryDataProvider_AppliedCoinsChanged(string biomeId)
		{
			UpdateBiomeButtons(biomeId);
		}

		private void ShowBiome(string biomeId)
		{
			UpdateBiomeButtons(biomeId);
			biomePanel.Clear();
			biomePanel.Init(biomeId);
			biomeGradesPanel.Init(biomeId);
		}
*/
		/*private void UpdateBiomeButtons(string shownBiomeId)
		{
			foreach (var btn in biomeButtons)
			{
				string biomeId = btn.BiomeId;
				if (!locationsDataProvider.IsAvailableBiome(biomeId))
				{
					btn.SetStatus(BestiaryBiomeButton.Status.Locked);
				}
				else if (biomeId == shownBiomeId)
				{
					btn.SetStatus(BestiaryBiomeButton.Status.Active);
				}
				else
				{
					btn.SetStatus(BestiaryBiomeButton.Status.Inactive);
				}

				bool hasReward = bestiaryDataProvider.HasNonAppliedReward(biomeId);
				btn.SetRewardAvailable(hasReward);

				var gradeData = bestiaryDataProvider.GetBiomeGradeData(biomeId);
				btn.SetCupVisible(gradeData.CurrentProgress >= gradeData.NextGradeProgress);
			}

			LayoutRebuilder.MarkLayoutForRebuild(buttonsLayout);
		}*/
	}
}
