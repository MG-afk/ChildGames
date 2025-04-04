using Dream.Core;
using Dream.XMG;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace XMG.ChildGame.Puzzle
{
	public sealed class PuzzleView : BaseView
	{
		[SerializeField]
		private PuzzleBoardSubView _board;
		[SerializeField]
		private PuzzlePieceSubView _piecePrefab;

		public Sprite _sprite;
		private int _gridSize = 3;
		private PuzzlePieceSubView[,] _grid;
		private PuzzlePieceSubView _draggedPiece;
		private Camera _mainCamera;

		private IInputProvider _inputProvider;

		[Inject, UsedImplicitly]
		private void Construct(IInputProvider inputProvider)
		{
			_inputProvider = inputProvider;
		}

		private void Start()
		{
			_mainCamera = Camera.main;
			InitializeGame();
		}

		private void InitializeGame()
		{
			_grid = new PuzzlePieceSubView[_gridSize, _gridSize];
			var spriteSlicer = new SpriteSlicer(_sprite, _gridSize, _gridSize);
			var sprites = spriteSlicer.SliceSprite();

			for (var x = 0; x < _gridSize; x++)
			{
				for (var y = 0; y < _gridSize; y++)
				{
					var position = new Vector3(x - 1, y - 1, 0);
					var tile = Instantiate(_piecePrefab, position, Quaternion.identity);
					_grid[x, y] = tile;
					tile.GetComponent<SpriteRenderer>().sprite = sprites[x, _gridSize - 1 - y];
					tile.SetNumber(x + y * _gridSize + 1);
				}
			}
			ShufflePuzzle();
		}

		private void ShufflePuzzle()
		{
			for (var i = 0; i < 100; i++)
			{
				var pos1 = new Vector2Int(Random.Range(0, _gridSize), Random.Range(0, _gridSize));
				var pos2 = new Vector2Int(Random.Range(0, _gridSize), Random.Range(0, _gridSize));
				SwapPieces(pos1, pos2);
			}
		}

		private void Update()
		{
			var mousePosition = -_mainCamera.ScreenToWorldPoint(new Vector3(
				_inputProvider.PointerPosition.x,
				_inputProvider.PointerPosition.y,
				_mainCamera.transform.position.z));

			if (Input.GetMouseButtonDown(0) && _draggedPiece == null)
			{
				RaycasterSystem.RaycastFromMainCamera(out _draggedPiece);

				if (_draggedPiece != null)
				{
					_draggedPiece.GetComponent<SpriteRenderer>().sortingOrder = 1;
					_draggedPiece.transform.localScale = Vector3.one * 1.1f;
				}
			}
			else if (Input.GetMouseButtonUp(0) && _draggedPiece != null)
			{
				var gridPosition = WorldToGridPosition(mousePosition);

				if (IsValidGridPosition(gridPosition))
				{
					var originalPosition = GetPiecePosition(_draggedPiece);
					SwapPieces(originalPosition, gridPosition);
				}
				else
				{
					_draggedPiece.transform.position = GridToWorldPosition(GetPiecePosition(_draggedPiece));
				}

				_draggedPiece.GetComponent<SpriteRenderer>().sortingOrder = 0;
				_draggedPiece.transform.localScale = Vector3.one;
				_draggedPiece = null;
				CheckWinCondition();
			}


			if (_draggedPiece != null)
			{
				mousePosition.z = 0;
				_draggedPiece.transform.position = mousePosition;
			}
		}

		private Vector2Int WorldToGridPosition(Vector2 worldPosition)
		{
			return new Vector2Int(
				Mathf.RoundToInt(worldPosition.x + 1),
				Mathf.RoundToInt(worldPosition.y + 1)
			);
		}

		private Vector3 GridToWorldPosition(Vector2Int gridPosition)
		{
			return new Vector3(gridPosition.x - 1, gridPosition.y - 1, 0);
		}

		private bool IsValidGridPosition(Vector2Int pos)
		{
			return pos.x >= 0 && pos.x < _gridSize && pos.y >= 0 && pos.y < _gridSize;
		}

		private Vector2Int GetPiecePosition(PuzzlePieceSubView piece)
		{
			for (var x = 0; x < _gridSize; x++)
			{
				for (var y = 0; y < _gridSize; y++)
				{
					if (_grid[x, y] == piece)
					{
						return new Vector2Int(x, y);
					}
				}
			}
			return new Vector2Int(-1, -1); // Not found
		}

		private void SwapPieces(Vector2Int pos1, Vector2Int pos2)
		{
			var piece1 = _grid[pos1.x, pos1.y];
			var piece2 = _grid[pos2.x, pos2.y];

			// Swap positions
			piece1.transform.position = GridToWorldPosition(pos2);
			piece2.transform.position = GridToWorldPosition(pos1);

			// Update grid
			_grid[pos1.x, pos1.y] = piece2;
			_grid[pos2.x, pos2.y] = piece1;
		}

		void CheckWinCondition()
		{
			for (var x = 0; x < _gridSize; x++)
			{
				for (var y = 0; y < _gridSize; y++)
				{
					var tile = _grid[x, y];
					var correctNumber = x + y * _gridSize + 1;
					if (tile.GetNumber() != correctNumber)
						return;
				}
			}
			Debug.Log("Puzzle solved!");
			// TODO: Add celebration effect or transition to next level
		}
	}
}