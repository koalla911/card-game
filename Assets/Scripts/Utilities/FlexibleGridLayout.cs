using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
	public class FlexibleGridLayout : LayoutGroup
	{
		public enum FitType
		{
			Width,
			Height,
			Uniform,
			FixedRows,
			FixedColumns
		}
		public FitType fitType;

		public int rows;
		public int columns;
		public Vector2 cellSize;
		public Vector2 spacing;

		public bool fitX;
		public bool fitY;

		public bool isShiftByRow;
		public bool isShiftByColumn;


		public override void CalculateLayoutInputHorizontal()
		{
			base.CalculateLayoutInputHorizontal();

			if (fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform)
			{
				float squareRoot = Mathf.Sqrt(transform.childCount);
				rows = Mathf.CeilToInt(squareRoot);
				columns = Mathf.CeilToInt(squareRoot);
			}

			float parentWidth = rectTransform.rect.width;
			float parentHeight = rectTransform.rect.height;

			if (fitType == FitType.Width || fitType == FitType.FixedColumns)
			{
				rows = Mathf.CeilToInt(transform.childCount / (float)columns);
			}
			if (fitType == FitType.Height || fitType == FitType.FixedRows)
			{
				columns = Mathf.CeilToInt(transform.childCount / (float)rows);
			}


			float cellWidth = (parentWidth / (float)columns) - ((spacing.x / (float)columns) * 2) -
				(padding.left / (float)columns) - (padding.right / (float)columns);
			float cellHeight = (parentHeight / (float)rows) - ((spacing.y / (float)rows) * 2) -
				(padding.top / (float)rows) - (padding.bottom / (float)rows);

			cellSize.x = fitX ? cellWidth : cellSize.x;
			cellSize.y = fitY ? cellHeight : cellSize.y;

			int column = 0;
			int row = 0;

			float xShift = 0f;
			float yShift = 0f;

			for (int i = 0; i < rectChildren.Count; i++)
			{
				row = i / columns;
				column = i % columns;

				var item = rectChildren[i];

				var xPos = (cellSize.x * column) + (spacing.x * column) + padding.left;
				var yPos = (cellSize.y * row) + (spacing.y * row) + padding.top;

				xShift = isShiftByRow ? 175 * row : 0;
				yShift = isShiftByColumn ? 75 * column : 0;

				SetChildAlongAxis(item, 0, xPos + xShift, cellSize.x);
				SetChildAlongAxis(item, 1, yPos + yShift, cellSize.y);
			}

			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (cellSize.y * rows) + 75);
		}


		public override void CalculateLayoutInputVertical()
		{
		}

		public override void SetLayoutHorizontal()
		{
		}

		public override void SetLayoutVertical()
		{
		}

	}
}