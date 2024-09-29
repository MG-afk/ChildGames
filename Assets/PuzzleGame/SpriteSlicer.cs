using UnityEngine;

namespace XMG.ChildGame.Puzzle
{
	public class SpriteSlicer
	{
		private readonly Sprite _originalSprite;
		private readonly int _rows;
		private readonly int _columns;
		private readonly float _puzzleWidth = 15f;
		private readonly float _puzzleHeight = 15f;

		public SpriteSlicer(Sprite originalSprite, int rows, int columns)
		{
			_originalSprite = originalSprite;
			_rows = rows;
			_columns = columns;
		}

		public Sprite[,] SliceSprite()
		{
			if (_originalSprite == null)
			{
				Debug.LogError("Nie przypisano oryginalnego sprite'a!");
				return null;
			}

			Sprite[,] slicedSprites = new Sprite[_columns, _rows];

			float originalWidth = _originalSprite.rect.width;
			float originalHeight = _originalSprite.rect.height;
			float sliceWidth = originalWidth / _columns;
			float sliceHeight = originalHeight / _rows;

			for (int y = 0; y < _rows; y++)
			{
				for (int x = 0; x < _columns; x++)
				{
					Rect spriteRect = new Rect(x * sliceWidth, originalHeight - (y + 1) * sliceHeight, sliceWidth, sliceHeight);
					Vector2 pivot = new Vector2(0.5f, 0.5f); // Centrujemy pivot każdego kawałka

					slicedSprites[x, y] = Sprite.Create(_originalSprite.texture,
														spriteRect,
														pivot,
														_originalSprite.pixelsPerUnit,
														0,
														SpriteMeshType.FullRect);
				}
			}

			return slicedSprites;
		}

		public void CreateSlicedGameObjects()
		{
			Sprite[,] slicedSprites = SliceSprite();
			if (slicedSprites == null) return;

			float pieceWidth = _puzzleWidth / _columns;
			float pieceHeight = _puzzleHeight / _rows;

			GameObject puzzleContainer = new GameObject("PuzzleContainer");
			puzzleContainer.transform.position = Vector3.zero; // Centrujemy kontener układanki

			for (int y = 0; y < _rows; y++)
			{
				for (int x = 0; x < _columns; x++)
				{
					GameObject slicedPiece = new GameObject($"Slice_{x}_{y}");
					slicedPiece.transform.SetParent(puzzleContainer.transform);

					SpriteRenderer renderer = slicedPiece.AddComponent<SpriteRenderer>();
					renderer.sprite = slicedSprites[x, y];

					// Obliczamy pozycję, aby wypełnić całą przestrzeń układanki
					float posX = (x + 0.5f) * pieceWidth - _puzzleWidth / 2f;
					float posY = -((y + 0.5f) * pieceHeight - _puzzleHeight / 2f);
					slicedPiece.transform.localPosition = new Vector3(posX, posY, 0);

					// Skalujemy kawałek, aby wypełnił przydzieloną przestrzeń
					float scaleX = pieceWidth / slicedSprites[x, y].bounds.size.x;
					float scaleY = pieceHeight / slicedSprites[x, y].bounds.size.y;
					slicedPiece.transform.localScale = new Vector3(scaleX, scaleY, 1);
				}
			}
		}
	}
}