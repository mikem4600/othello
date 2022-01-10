using System;

namespace Othello
{
	// ����� delegate ��� ��� ������� ������������ (���������).
	public delegate void TurnChangedEventHandler(object sender, EventArgs e);
	public delegate void ScoreChangedEventHandler(object sender, EventArgs e);
	public delegate void NoValidMovesEventHandler(object sender, EventArgs e);
	public delegate void GameOverEventHandler(object sender, EventArgs e);

	/// <summary>
	/// ���� ��� ������������ �� �������������� ���� �������
	/// ��� �������� ����������.
	/// </summary>
	struct OthelloMove
	{
		/// <summary>
		/// � ������ ��� �������
		/// </summary>
		public int Row;
		/// <summary>
		/// � ����� ��� �������
		/// </summary>
		public int Column;
		/// <summary>
		/// � ���� ��� �������
		/// </summary>
		public int Value;
	}

	/// <summary>
	/// � ���� ���� ����������� ���� ��� ���������� ��� �������� ��� �����������
	/// ��� ���� �������� (�������) Othello.
	/// </summary>
	public class OthelloGame
	{
		/// <summary>
		/// ��������� - ����� ��� ���������� �� ����� ��� ������ - ��������
		/// (���. �� � �������� ���� �� ����� � ���).
		/// </summary>
		bool HumanIsWhite;
		/// <summary>
		/// ��������� - ����� ��� ���������� ��� �������� �����
		/// (���. �� ����� ����� ����� ���� � ���).
		/// </summary>
		bool IsWhitesTurn;
		/// <summary>
		/// ��������� - ����� ��� ���������� ���� �������� ��������
		/// ��� ����������.
		/// </summary>
		OthelloBoard theBoard;
		///<summ�ry>
		/// ������� ���� ������������ � ���� ��� ���������� ��� ��������� ��� �� 
		/// ��������������� ���� ��������� ���������.
		///</summary>
		private int[,] squareWeight = { 
					{100, -10, 11, 6, 6, 11,-10, 100},
					{-10, -20, 1, 2, 2, 1, -20, -10 },
					{ 10, 1, 5, 4, 4, 5, 1, 10 },
					{ 6, 2, 4, 2, 2, 4, 2, 6 },
					{ 6, 2, 4, 2, 2, 4, 2, 6 },
					{ 10, 1, 5, 4, 4, 5, 1, 10 },
					{-10, -20, 1, 2, 2, 1, -20, -10 },
					{100, -10, 11, 6, 6, 11,-10, 100}
					};
		///<summ�ry>
		/// �� ������� ����� ��� �� ������� ���������
		/// ��� ������ ��� ���������� �-�.
		///</summary>
		int level;
		///<summ�ry>
		/// �������� ��� �� ������ ��� ����� ��� ��������
		/// � ������� �-� ��� ���� ������ ��� ����������.
		/// (debug)
		///</summary>
		int counter;

		/// <summary>
		/// ��� ������� ��� ��������������� ��� ��� ����������
		/// ���� ������� � �����.
		/// </summary>
		public event TurnChangedEventHandler TurnChanged;
		/// <summary>
		/// ��� ������� ��� ��������������� ��� ��� ����������
		/// ���� ������� � ����������.
		/// </summary>
		public event ScoreChangedEventHandler ScoreChanged;
		/// <summary>
		/// ��� ������� ��� ��������������� ��� ��� ����������
		/// ���� ��� �������� ������� �������� ��� ��� �������� ������.
		/// </summary>
		public event NoValidMovesEventHandler NoValidMoves;
		/// <summary>
		/// ��� ������� ��� ��������������� ��� ��� ����������
		/// ���� ������������� �� �������� ����������� ��� ����������.
		/// </summary>
		public event GameOverEventHandler GameOver;

		/// <summary>
		/// � ������������� ��� �����.
		/// </summary>
		/// <param name="IsHumanWhite">������ ���� ��� �� �� � �������� - �������
		/// ���� �� �����.</param>
		/// <param name="WhitesTurn">������ ���� ��� �� �� �� ����� ����� ���� �����.</param>
		/// <param name="Board">������� ���� ��� ������ ������ ��� ���������.</param>
		public OthelloGame(bool IsHumanWhite, bool WhitesTurn, IOthelloSquare[][] Board, int theLevel)
		{
			// ���������� ��� ����������
			HumanIsWhite = IsHumanWhite;
			IsWhitesTurn = WhitesTurn;
			level = theLevel;

			// ���������� ���� ��������� �� ���� ��� ������ ��� ��� ������
			theBoard = new OthelloBoard(Board);
			// �������� ��� ������� �������� ��� ��������� ������
			theBoard.MarkPossibleMoves(IsWhitesTurn);
		}

		/// <summary>
		/// ���������� � ����� �� ���� ������� �� �����.
		/// </summary>
		public bool WhitesTurn
		{
			get
			{
				return IsWhitesTurn;
			}
			set
			{
				IsWhitesTurn = value;
			}
		}

		/// <summary>
		/// ���������� �� ���������� ��� ������.
		/// </summary>
		public int BlackScore
		{
			get
			{
				return theBoard.BlackPieces;
			}
		}

		/// <summary>
		/// ���������� �� ���������� ��� ������.
		/// </summary>
		public int WhiteScore
		{
			get
			{
				return theBoard.WhitePieces;
			}
		}

		/// <summary>
		/// ������������� ��� ������ ��� ������ - ��������.
		/// </summary>
		/// <param name="row">� ������ ��� ������� � ������� (��������� ��� �� 0).</param>
		/// <param name="col">� ����� ��� ������� � ������� (��������� ��� �� 0).</param>
		/// <returns>������������ true �� � ������ ���� ������ ��� ��������
		/// ��� false �����������.</returns>
		public bool ProcessMove(int row, int col)
		{
			// ������� ����������� ��� �������
			if (!theBoard.IsValidMove(row, col, IsWhitesTurn))
				return false;
			else
				// �������� ��� �������
				theBoard.MakeMove(row, col, IsWhitesTurn);

			// debug
			System.Console.WriteLine("Inserting at " + row + " " + col);
			// ���������� ��� ��� ������ ��� �����������
			if(ScoreChanged != null) ScoreChanged(this, EventArgs.Empty);
			IsWhitesTurn = !IsWhitesTurn;	// ������ ��� ������
						

			// ���������� ��� ��� (������) ������ ��� ������
			if(TurnChanged != null) TurnChanged(this, EventArgs.Empty);

			// ������� ��� ���������� �� �������������� �� �������� ����� ��� ����������
			if(theBoard.BoardFull || theBoard.WhitePieces == 0 || theBoard.BlackPieces == 0 || (!theBoard.ValidMovesExist(true) &&  !theBoard.ValidMovesExist(false)))
				if(GameOver != null) GameOver(this, EventArgs.Empty);

			return true;
		}

		/// <summary>
		/// ������� ��� ���������� ��� ��� ���������� ������, �� �� ������ ��� ��� 
		/// ������������ �� �������� ������� ������.
		/// </summary>
		/// <param name="board">� �������� ���� ���� ����� ������ ���� � �������.</param>
		public void MakeComputerMove()
		{
			if(!theBoard.BoardFull && !theBoard.ValidMovesExist(IsWhitesTurn))
			{

				// ���������� ��� �� �������
				if(NoValidMoves != null) NoValidMoves(this, EventArgs.Empty);
				// ���������� ��� ��� ������ ��� �����������
				if(ScoreChanged != null) ScoreChanged(this, EventArgs.Empty);
				// ������ ���� ��� ������
				IsWhitesTurn = !IsWhitesTurn;
				// ���������� ��� ��� ������ ��� ������
				if(TurnChanged != null) TurnChanged(this, EventArgs.Empty);

				// �������� ������� �������� ��� ���� ������
				theBoard.MarkPossibleMoves(IsWhitesTurn);

				// ������� ��� ���������� �� �������������� �� �������� ����� ��� ����������
				if(theBoard.BoardFull || theBoard.WhitePieces == 0 || theBoard.BlackPieces == 0 || (!theBoard.ValidMovesExist(true) &&  !theBoard.ValidMovesExist(false)))
					if(GameOver != null) GameOver(this, EventArgs.Empty);

				return;
			}

			// debug
			System.Console.WriteLine("Starting AlphaBeta");
			counter = 0;

			// ������ ��� ��������� ������� ������� �� ���� ���
			// ��������� ��������� ��� ��� ��������� �-�.
			OthelloMove move = AlphaBeta(theBoard, System.Int32.MinValue, System.Int32.MaxValue, level, IsWhitesTurn);

			// debug
			System.Console.WriteLine("Alphabeta: " + counter);
			System.Console.WriteLine("Finished AlphaBeta");

			// �������� ��� ������� ��� �������
			ProcessMove(move.Row, move.Column);

			// ������� �� �������� �������� ��� ��� ��� ������
			if(!theBoard.BoardFull && !theBoard.ValidMovesExist(IsWhitesTurn))
			{
				// ������ ��� ������
				IsWhitesTurn = !IsWhitesTurn;
				// ���������� ��� �� �������
				if(NoValidMoves != null) NoValidMoves(this, EventArgs.Empty);
				// ������ � �������� �������
				MakeComputerMove();
			}
			else
			{
				// �������� ������� �������� ��� ���� ������
				theBoard.MarkPossibleMoves(IsWhitesTurn);
			}

			// ���������� ��� ��� ������ ��� �����������
			if(ScoreChanged != null) ScoreChanged(this, EventArgs.Empty);
			// ���������� ��� ��� (������) ������ ��� ������
			if(TurnChanged != null) TurnChanged(this, EventArgs.Empty);

			// ������� ��� ���������� �� �������������� �� �������� ����� ��� ����������
			if(theBoard.BoardFull || theBoard.WhitePieces == 0 || theBoard.BlackPieces == 0 || (!theBoard.ValidMovesExist(true) &&  !theBoard.ValidMovesExist(false)))
				if(GameOver != null) GameOver(this, EventArgs.Empty);
		}

		/// <summary>
		/// �������� �� ������ ���� ��� ������ �� �������� � ����������� ��� �������
		/// ������ ��� �� ���� ��� ��������� �-�.
		/// </summary>
		/// <param name="board">� �������� ���� ����� �� ������ ��� ������� ������.</param>
		/// <param name="alpha">� ������� ���� ��� ������ �� ���� ��� ���������
		/// ��� ���������.</param>
		/// <param name="beta">� �������� ���� ��� ������ �� ���� ��� ���������
		/// ��� ���������.</param>
		/// <param name="depth">�� �������� ��� ������� ����� �� ����� ������
		/// �� ����� � ���������.</param>
		/// <param name="maximumPlays">������� �� ������ ���� � ������� Max.</param>
		/// <returns>���������� ��� �������� ������.</returns>
		OthelloMove AlphaBeta(OthelloBoard board, int alpha, int beta, int depth, bool maximumPlays)
		{
			// ������ ��� ������� (debug)
			counter++;

			// � �������� ������
			OthelloMove move;
			move.Row = 0;
			move.Column = 0;
			
			// ������� �� ������ ����� ��� �� �����
			// � �� ��� �������� ������� ��������
			if(depth == 0 || !board.ValidMovesExist(maximumPlays))
			{
				// ��������� ��� ����� ��� ���������
				move.Value = EvaluateBoard(board);
				return move;
			}

			// ������� ���� ���������� ��� ���������
			for(int row = 0; row < 8; row++)
			{
				for(int col = 0; col < 8; col++)
				{
					// ������� �� ��������� ��� ������ ������
					if(board.IsValidMove(board.Square(row,col).Row, board.Square(row,col).Column, maximumPlays))
					{
						// ���������� ���� (���������) ���������
						// ��� �������� ��� �������
						OthelloBoard testBoard = new OthelloBoard(board);
						testBoard.MakeMove(board.Square(row,col).Row, board.Square(row,col).Column, maximumPlays);
						OthelloMove currentMove = AlphaBeta(testBoard, alpha, beta, depth-1, !maximumPlays);

						if(maximumPlays)	// ������� �� ������ � Max
						{
							// ������� �� � ���� ��� ������� ����� ����������
							// ��� ��� ���� ����
							if(currentMove.Value > alpha)
							{
								alpha = currentMove.Value;
								move.Row = board.Square(row,col).Row;
								move.Column = board.Square(row,col).Column;
							}
							// ������� �� � ���� ���� �����
							// ���������� ��� ��� ���� ����
							// (����� ��� ������������� �������)
							if(alpha > beta)
							{
								move.Row = board.Square(row,col).Row;
								move.Column = board.Square(row,col).Column;
								move.Value = beta;
								return move;
							}
						}
						else
						{
							// ������� �� � ���� ��� ������� ����� ���������
							// ��� ��� ���� ����
							if(currentMove.Value < beta)
							{
								beta = currentMove.Value;
								move.Row = board.Square(row,col).Row;
								move.Column = board.Square(row,col).Column;
							}
							// ������� �� � ���� ���� �����
							// ���������� ��� ��� ���� ����
							// (����� ��� ������������� �������)
							if(alpha > beta)
							{
								move.Row = board.Square(row,col).Row;
								move.Column = board.Square(row,col).Column;
								move.Value = alpha;
								return move;
							}
						}
					}
				}
			}

			// ��������� ��� ������� �����
			if(maximumPlays)
				move.Value = alpha;
			else
				move.Value = beta;
			return move;
		}
		
		/// <summary>
		/// �������� ��� ��������� ���������. ����� ��� ������ squareWeight (���� ������
		/// ����� ������ ���� �� ���� ��������� ��� ���������)������������ ��� ���� ���
		/// �������� ��� ��������-������ ��� ��� ����������-������.  
		/// </summary>
		/// <param name="theBoard">� �������� ��������.</param>
		/// <returns>���������� ��� ���� ��� ��������� ���������.</returns>
		int EvaluateBoard(OthelloBoard theBoard)
		{
			// � ���� ��� ���������
			int value = 0;
			
			// ������� ���� ����������
			for(int row = 0; row < 8; row++)
			{
				for(int col = 0; col < 8; col++)
				{
					// ������� ��� ������������ ��� ����������
					// ��� ������������� ��� ����������� �����
					if(theBoard.Square(row,col).IsWhite)
					{
						value = value + squareWeight[theBoard.Square(row,col).Row, theBoard.Square(row,col).Column];
					}
					else if(theBoard.Square(row,col).IsBlack)
					{
						value = value - squareWeight[theBoard.Square(row,col).Row, theBoard.Square(row,col).Column];
					}
				}
			}
		
			return value;
		}
	}
}