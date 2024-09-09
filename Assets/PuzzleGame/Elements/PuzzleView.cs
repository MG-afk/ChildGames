using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame.Puzzle
{
	public sealed class PuzzleView : BaseView<PuzzleController>
	{
		[SerializeField]
		private PuzzleBoardSubView _board;

		[SerializeField]
		private PuzzlePieceSubView _piece;

		public Sprite _sprite;
		private int _gridSize = 3; // 3x3 grid

		private GameObject[,] _grid;
		private Vector2Int _emptySpace;

		[Inject, UsedImplicitly]
		private void Construct()
		{
		}

		void Start()
		{
			InitializeGame();
		}

		void InitializeGame()
		{
			_grid = new GameObject[_gridSize, _gridSize];
			var spriteSlicer = new SpriteSlicer(_sprite, _gridSize, _gridSize);
			var sprites = spriteSlicer.SliceSprite();

			// Create and place tiles
			for (var x = 0; x < _gridSize; x++)
			{
				for (var y = 0; y < _gridSize; y++)
				{
					if (x == _gridSize - 1 && y == _gridSize - 1)
					{
						// Leave last space empty
						_emptySpace = new Vector2Int(x, y);
						continue;
					}

					var position = new Vector3(x - 1, y - 1, 0); // Adjust position as needed
					var tile = Instantiate(_piece, position, Quaternion.identity);
					_grid[x, y] = tile.gameObject;

					// Set tile number or image
					tile.GetComponent<SpriteRenderer>().sprite = sprites[x, y];
					//.SetNumber(x + y * gridSize + 1);
				}
			}

			ShufflePuzzle();
		}

		void ShufflePuzzle()
		{
			// Perform random valid moves to shuffle the puzzle
			for (var i = 0; i < 100; i++) // Adjust number of shuffles as needed
			{
				var validMoves = GetValidMoves();
				if (validMoves.Count > 0)
				{
					int randomIndex = Random.Range(0, validMoves.Count);
					MoveTile(validMoves[randomIndex]);
				}
			}
		}

		List<Vector2Int> GetValidMoves()
		{
			var validMoves = new List<Vector2Int>();
			Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };

			foreach (var dir in directions)
			{
				var newPos = _emptySpace + dir;
				if (IsValidPosition(newPos))
				{
					validMoves.Add(newPos);
				}
			}

			return validMoves;
		}

		bool IsValidPosition(Vector2Int pos)
		{
			return pos.x >= 0 && pos.x < _gridSize && pos.y >= 0 && pos.y < _gridSize;
		}

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				RaycasterSystem.RaycastFromMainCamera<PuzzlePieceSubView>(out var puzzle);

				if (puzzle != null)
				{
					var tilePos = new Vector2Int(
						Mathf.RoundToInt(puzzle.transform.position.x + 1),
						Mathf.RoundToInt(puzzle.transform.position.y + 1)
					);

					if (IsAdjacentToEmptySpace(tilePos))
					{
						MoveTile(tilePos);
						CheckWinCondition();
					}
				}
			}
		}

		bool IsAdjacentToEmptySpace(Vector2Int pos)
		{
			return (Mathf.Abs(pos.x - _emptySpace.x) + Mathf.Abs(pos.y - _emptySpace.y)) == 1;
		}

		void MoveTile(Vector2Int tilePos)
		{
			GameObject tile = _grid[tilePos.x, tilePos.y];
			tile.transform.position = new Vector3(_emptySpace.x - 1, _emptySpace.y - 1, 0);

			_grid[_emptySpace.x, _emptySpace.y] = tile;
			_grid[tilePos.x, tilePos.y] = null;

			_emptySpace = tilePos;
		}

		void CheckWinCondition()
		{
			for (int x = 0; x < _gridSize; x++)
			{
				for (int y = 0; y < _gridSize; y++)
				{
					if (x == _gridSize - 1 && y == _gridSize - 1)
						continue; // Skip empty space

					GameObject tile = _grid[x, y];
					if (tile == null)
						return; // Puzzle not solved

					// Check if tile is in correct position
					// int correctNumber = x + y * gridSize + 1;
					// if (tile.GetComponent<TileScript>().GetNumber() != correctNumber)
					//     return; // Puzzle not solved
				}
			}

			Debug.Log("Puzzle solved!");
		}

		public sealed class Factory : PlaceholderFactory<PuzzleView> { }

	}
}