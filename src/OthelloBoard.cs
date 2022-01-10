//othelloBoard
using System;

namespace Othello
{
	/// <summary>
	/// � ���� ���� ����������� ���� ��� ���������� ��� �������� ��� �����������
	/// ��� ��� ������� (���. ��� ������ 8x8 ����������) ��� Othello.
	/// </summary>
	public class OthelloBoard
	{
		/// <summary>
		/// ��������� - ����� ��� ���������� �� ������ �� ��������� (�����������)
		/// ��� ���������
		/// </summary>
		IOthelloSquare[][] theBoard;

		/// <summary>
		/// �������������.
		/// </summary>
		/// <param name="Board">� ������� �� �� �������� ��� �� ���������������
		/// (���������) ��� �� ��������.</param>
		public OthelloBoard(IOthelloSquare[][] Board)
		{
			theBoard = Board;
		}

		/// <summary>
		/// ������������� ����������.
		/// </summary>
		/// <param name="original">H �������� �� �� �������� ��� �� �����������.</param>
		public OthelloBoard(OthelloBoard original)
		{
			theBoard = new OthelloSquare[8][];
			for(int i = 0; i < 8; i++)
			{
				theBoard[i] = new OthelloSquare[8];
			}
			
			for(int i = 0; i < 8; i++)
			{
				for(int j = 0; j < 8; j++)
				{
					theBoard[i][j] = new OthelloSquare(original.Square(i,j));
				}
			}
		}

		/// <summary>
		/// ������� ����������� ��� ���������� ��� ���������.
		/// </summary>
		/// <param name="row">� ������ ��� ����������.</param>
		/// <param name="col">� ����� ��� ����������.</param>
		/// <returns>������� ���� �� ���������.</returns>
		public IOthelloSquare Square (int row, int col)
		{
			return theBoard[row][col];
		}

		/// <summary>
		/// ������ ��� ������ ���������� ��� ��������� �� "�������"
		/// ��� ������ ��� ��������� ������.
		/// </summary>
		/// <param name="IsWhitesTurn">������ ���� ��� �� ��� ����� ����
		/// � ����� ��� ������.</param>
		public void MarkPossibleMoves(bool IsWhitesTurn)
		{
			foreach(IOthelloSquare[] row in theBoard)
			{
				foreach(IOthelloSquare square in row)
				{
					// ������� �� �� ��������� ����� ����� � ������ (��� ��� ����������� ������)
					if(square.IsEmpty)
					{
						// ������� �� ����� ������ ������
						if(IsValidMove(square.Row, square.Column, IsWhitesTurn))
						{
							// ����� ������ ������, ������� �� ������
							square.CurrentStatus = SquareStatus.Possible;
						}
						else
						{
							// ��� ����� ������ ������, ������� �� �����
							square.CurrentStatus = SquareStatus.Empty;
						}
					}
				}
			}
		}

		/// <summary>
		/// ������� �� ������� ���� ��� ��� ������ ������ ��� ��������
		/// ��� ���� ������� ������.
		/// </summary>
		/// <param name="IsWhitesTurn">������ ���� ��� �� ��� ����� ����
		/// � ����� ��� ������.</param>
		/// <returns>������������ true �� ������� ���� ��� ��� ������ ������
		/// ��� ��������, ��� false �� ��� ������� �����.</returns>
		public bool ValidMovesExist(bool IsWhitesTurn)
		{
			foreach(IOthelloSquare[] row in theBoard)
				foreach(IOthelloSquare square in row)
					// ������� �� ����� ������ � ������ �� ���� �� ���������
					if(square.IsEmpty && IsValidMove(square.Row, square.Column, IsWhitesTurn))
							return true;
			return false;
		}

		/// <summary>
		/// ������� � ������ ����� ������ �� ��� ������� ���������,
		/// ��� ������ ������� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="IsWhitesTurn">������ ���� ��� �� ��� ����� ����
		/// � ����� ��� ������.</param>
		/// <returns>������������ true �� � ������ ����� ������,
		/// ��� false �����������.</returns>
		public bool IsValidMove(int row, int col, bool IsWhitesTurn)
		{
			// ������� �� �� ��������� ���� ����� ��������
			if(!theBoard[row][col].IsEmpty)
				return false;

			// ������ ��� "����������" ��� ������ ��� ���������
			// ������ ��� ��� ��������� ��� �� ���� ��� ����������� SquareStatus
			SquareStatus enemyStatus;
			SquareStatus ownStatus;
			if(IsWhitesTurn)
			{
				ownStatus = SquareStatus.White;
				enemyStatus = SquareStatus.Black;
			}
			else
			{
				ownStatus = SquareStatus.Black;
				enemyStatus = SquareStatus.White;
			}

			// ������� ���� ���� ���������� ��� ��������� ��� �������������
			return
				(
				ValidateDownwards(row, col, ownStatus, enemyStatus, false)||
				ValidateUpwards(row, col, ownStatus, enemyStatus, false)||
				ValidateToLeft(row, col, ownStatus, enemyStatus, false)||
				ValidateToRight(row, col, ownStatus, enemyStatus, false)||
				ValidateToDownRight(row, col, ownStatus, enemyStatus, false)||
				ValidateToUpLeft(row, col, ownStatus, enemyStatus, false)||
				ValidateToUpRight(row, col, ownStatus, enemyStatus, false)||
				ValidateToDownLeft(row, col, ownStatus, enemyStatus, false)
				);

		}

		/// <summary>
		/// ������� ��� ������ �� ��� ������� ���������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ���� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="IsWhitesTurn">������ ���� ��� �� ��� ����� ����
		/// � ����� ��� ������.</param>
		/// <returns>������������ true �� � ������ ���������������� ��������,
		/// ��� false �����������.</returns>
		public bool MakeMove(int row, int col, bool IsWhitesTurn)
		{
			// ������� �� �� ��������� ���� ����� ��������
			if(!theBoard[row][col].IsEmpty)
				return false;

			// ������ ��� "����������" ��� ������ ��� ���������
			// ������ ��� ��� ��������� ��� �� ���� ��� ����������� SquareStatus
			SquareStatus enemyStatus;
			SquareStatus ownStatus;
			if(IsWhitesTurn)
			{
				ownStatus = SquareStatus.White;
				enemyStatus = SquareStatus.Black;
			}
			else
			{
				ownStatus = SquareStatus.Black;
				enemyStatus = SquareStatus.White;
			}

			// ���������� ��� ������� ��� ������ ��� ���������
			// ��� �������
			theBoard[row][col].CurrentStatus = ownStatus;

			// ��������� ���� �������� ��� ������ ��� ���������
			// ��� ��������� ��� ������
			ValidateUpwards(row, col, ownStatus, enemyStatus, true);
			ValidateDownwards(row, col, ownStatus, enemyStatus, true);
			ValidateToLeft(row, col, ownStatus, enemyStatus, true);
			ValidateToRight(row, col, ownStatus, enemyStatus, true);
			ValidateToDownRight(row, col, ownStatus, enemyStatus, true);
			ValidateToUpLeft(row, col, ownStatus, enemyStatus, true);
			ValidateToUpRight(row, col, ownStatus, enemyStatus, true);
			ValidateToDownLeft(row, col, ownStatus, enemyStatus, true);
			
			return true;
		}

		#region ������� ������� ������� ������� ���� ���� ��� ������������

		/// <summary>
		/// �������� �� �� ������� ��������� ����� ������ ��� ������,
		/// ���������� �� ������ ���� �� ����. �� ��� ����� �� ����������,
		/// ��� ����� ������ � ������, ���� ������� �� ������ ��� ���������
		/// ���� �� ������������ ���������� �� ������ �� �� �� �����
		/// ��� ��������� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ���  ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="ownStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ������.</param>
		/// <param name="enemyStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ��� �������� ������.</param>
		/// <param name="FlipOpponentsPieces">������ ���� ��� ������ �� �� ��������������� �� ������
		/// ��� ��������� �� ���� ��� ��������� ������, ���� �� ������������ ����������, 
		/// ��� ������� ������� �� ����� ������ � ������.</param>
		/// <returns>������������ true �� ����� ������ � ������ ���� ����
		/// ��� ���������� (��� ���������� �������� �� ������ ��� ���������,
		/// �� ���� ��������),����������� ���������� false.</returns>
		/// <remarks>�� �������� ownStatus ��� enemyStatus ����� �����
		/// ��� ����������� SquareStatus.</remarks>
		bool ValidateUpwards(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// �������� ��� ������� ��� ��������� ���� ���� ��� ����������
			int counter = 0;
			// �������� ��� �������� �� ���� ��� ��������� ����
			int i = 0;

			// ������� ��� ������� ��� ��������� ���� ���� ��� ����������
			for(i = row-1; i >= 0; i--)
			{
				// ������� �� ��������� ����� ��� ���������
				if(theBoard[i][col].CurrentStatus == enemyStatus)
				{
					// ������� �� ������� ��� ��������� ������� ��� ��������� (�� �������)
					if (i == 0)
					{
						// ��������, ��� ��������� ��� ������ ������.
						// ���������� ��� ������� ���� �� ���������� false.
						counter = 0;
						break;
					}
					else
					{
						// ������ ��� �������
						counter++;
					}
				}
				else
					break;
			}
			// ������� �� ���� �� ������ ��� ��������� ��������� ���� ���
			if(i < 0 || theBoard[i][col].CurrentStatus != ownStatus)
				counter = 0;
			// ������� �� ������ �� ������������� �� ������ ��� ���������
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// ������� �� �������� ������ ��� ������
				{
					for(i = row-1; i >= 0; i--)
					{
						// ������� �� ��������� ��� ����� ��� ���������
						if(theBoard[i][col].CurrentStatus == enemyStatus)
						{
							// ���������� ��� �������
							theBoard[i][col].Flip();
						}
						else
							break;
					}
					// �� ������� �������������.
					return true;
				}
				else
				{
					// ��� ����� ������ � ������ ���� ����� ���� ��� ����������
					return false;
				}
			}
			else
			{
				// ��������� ��� �������������
				return (counter > 0);
			}
		}

		/// <summary>
		/// �������� �� �� ������� ��������� ����� ������ ��� ������,
		/// ���������� �� ������ ���� �� ����. �� ��� ����� �� ����������,
		/// ��� ����� ������ � ������, ���� ������� �� ������ ��� ���������
		/// ���� �� ������������ ���������� �� ������ �� �� �� �����
		/// ��� ��������� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="ownStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ������.</param>
		/// <param name="enemyStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ��� �������� ������.</param>
		/// <param name="FlipOpponentsPieces">������ ���� ��� ������ �� �� ��������������� �� ������
		/// ��� ��������� �� ���� ��� ��������� ������, ���� �� ������������ ����������, 
		/// ��� ������� ������� �� ����� ������ � ������.</param>
		/// <returns>������������ true �� ����� ������ � ������ ���� ����
		/// ��� ���������� (��� ���������� �������� �� ������ ��� ���������,
		/// �� ���� ��������), ��� false �����������.</returns>
		/// <remarks>�� �������� ownStatus ��� enemyStatus ����� �����
		/// ��� ����������� SquareStatus.</remarks>
		bool ValidateDownwards(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// �������� ��� ������� ��� ��������� ���� ���� ��� ����������
			int counter = 0;
			// �������� ��� �������� �� ���� ��� ��������� ����
			int i = 0;

			// ������� ��� ������� ��� ��������� ���� ���� ��� ����������
			for(i = row+1; i < theBoard.Length; i++)
			{
				// ������� �� ��������� ����� ��� ���������
				if(theBoard[i][col].CurrentStatus == enemyStatus)
				{
					// ������� �� ������� ��� ��������� ������� ��� ��������� (�� �������)
					if (i == theBoard.Length-1)
					{
						// ��������, ��� ��������� ��� ������ ������.
						// ���������� ��� ������� ���� �� ���������� false.
						counter = 0;
						break;
					}
					else
					{
						// ������ ��� �������
						counter++;
					}
				}
				else
					break;
			}
			
			// ������� �� ���� �� ������ ��� ��������� ��������� ���� ���
			if(i >= theBoard[row].Length || theBoard[i][col].CurrentStatus != ownStatus)
				counter = 0;
			
			// ������� �� ������ �� ������������� �� ������ ��� ���������
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// ������� �� �������� ������ ��� ������
				{
					for(i = row+1; i < theBoard.Length; i++)
					{
						// ������� �� ��������� ��� ����� ��� ���������
						if(theBoard[i][col].CurrentStatus == enemyStatus)
						{
							// ���������� ��� �������
							theBoard[i][col].Flip();
						}
						else
							break;
					}
					// �� ������� �������������.
					return true;
				}
				else
				{
					// ��� ����� ������ � ������ ���� ����� ���� ��� ����������
					return false;
				}
			}
			else
			{
				// ��������� ��� �������������
				return (counter > 0);
			}
		}

		/// <summary>
		/// �������� �� �� ������� ��������� ����� ������ ��� ������,
		/// ���������� �� ������ ���� �� �����.�� ��� ����� �� ����������,
		/// ��� ����� ������ � ������, ���� ������� �� ������ ��� ���������
		/// ���� �� ������������ ���������� �� ������ �� �� �� �����
		/// ��� ��������� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="ownStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ������.</param>
		/// <param name="enemyStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ��� �������� ������.</param>
		/// <param name="FlipOpponentsPieces">������ ���� ��� ������ �� �� ��������������� �� ������
		/// ��� ��������� �� ���� ��� ��������� ������, ���� �� ������������ ����������, 
		/// ��� ������� ������� �� ����� ������ � ������.</param>
		/// <returns>������������ true �� ����� ������ � ������ ���� ����
		/// ��� ���������� (��� ���������� �������� �� ������ ��� ���������,
		/// �� ���� ��������), ��� false �����������.</returns>
		/// <remarks>�� �������� ownStatus ��� enemyStatus ����� �����
		/// ��� ����������� SquareStatus.</remarks>
		bool ValidateToRight(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// �������� ��� ������� ��� ��������� ���� ���� ��� ����������
			int counter = 0;
			// �������� ��� �������� �� ���� ��� ��������� ����
			int i = 0;

			// ������� ��� ������� ��� ��������� ���� ���� ��� ����������
			for(i = col+1; i < theBoard[row].Length; i++)
			{
				// ������� �� ��������� ����� ��� ���������
				if(theBoard[row][i].CurrentStatus == enemyStatus)
				{
					// ������� �� ������� ��� ��������� ������� ��� ��������� (�� �������)
					if (i == theBoard[row].Length-1)
					{
						// ��������, ��� ��������� ��� ������ ������.
						// ���������� ��� ������� ���� �� ���������� false.
						counter = 0;
						break;
					}
					else
					{
						// ������ ��� �������
						counter++;
					}
				}
				else
					break;
			}
			// ������� �� ���� �� ������ ��� ��������� ��������� ���� ���
			if(i >= theBoard[row].Length || theBoard[row][i].CurrentStatus != ownStatus)
				counter = 0;
			// ������� �� ������ �� ������������� �� ������ ��� ���������
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// ������� �� �������� ������ ��� ������
				{
					for(i = col+1; i < theBoard[row].Length; i++)
					{
						// ������� �� ��������� ��� ����� ��� ���������
						if(theBoard[row][i].CurrentStatus == enemyStatus)
						{
							// ���������� ��� �������
							theBoard[row][i].Flip();
						}
						else
							break;
					}
					// �� ������� �������������.
					return true;
				}
				else
				{
					// ��� ����� ������ � ������ ���� ����� ���� ��� ����������
					return false;
				}
			}
			else
			{
				// ��������� ��� �������������
				return (counter > 0);
			}
		}

		/// <summary>
		/// �������� �� �� ������� ��������� ����� ������ ��� ������,
		/// ���������� �� ������ ���� �� ��������. �� ��� ����� �� ����������,
		/// ��� ����� ������ � ������, ���� ������� �� ������ ��� ���������
		/// ���� �� ������������ ���������� �� ������ �� �� �� �����
		/// ��� ��������� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="ownStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ������.</param>
		/// <param name="enemyStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ��� �������� ������.</param>
		/// <param name="FlipOpponentsPieces">������ ���� ��� ������ �� �� ��������������� �� ������
		/// ��� ��������� �� ���� ��� ��������� ������, ���� �� ������������ ����������, 
		/// ��� ������� ������� �� ����� ������ � ������.</param>
		/// <returns>������������ true �� ����� ������ � ������ ���� ����
		/// ��� ���������� (��� ���������� �������� �� ������ ��� ���������,
		/// �� ���� ��������), ��� false �����������.</returns>
		/// <remarks>�� �������� ownStatus ��� enemyStatus ����� �����
		/// ��� ����������� SquareStatus.</remarks>
		bool ValidateToLeft(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// �������� ��� ������� ��� ��������� ���� ���� ��� ����������
			int counter = 0;
			// �������� ��� �������� �� ���� ��� ��������� ����
			int i = 0;

			// ������� ��� ������� ��� ��������� ���� ���� ��� ����������
			for(i = col-1; i >= 0; i--)
			{
				// ������� �� ��������� ����� ��� ���������
				if(theBoard[row][i].CurrentStatus == enemyStatus)
				{
					// ������� �� ������� ��� ��������� ������� ��� ��������� (�� �������)
					if (i == 0)
					{
						// ��������, ��� ��������� ��� ������ ������.
						// ���������� ��� ������� ���� �� ���������� false.
						counter = 0;
						break;
					}
					else
					{
						// ������ ��� �������
						counter++;
					}
				}
				else
					break;
			}
			// ������� �� ���� �� ������ ��� ��������� ��������� ���� ���
			if(i < 0 || theBoard[row][i].CurrentStatus != ownStatus)
				counter = 0;
			// ������� �� ������ �� ������������� �� ������ ��� ���������
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// ������� �� �������� ������ ��� ������
				{
					for(i = col -1; i >=0 ; i--)
					{
						// ������� �� ��������� ��� ����� ��� ���������
						if(theBoard[row][i].CurrentStatus == enemyStatus)
						{
							// ���������� ��� �������
							theBoard[row][i].Flip();
						}
						else
							break;
					}
					// �� ������� �������������.
					return true;
				}
				else
				{
					// ��� ����� ������ � ������ ���� ����� ���� ��� ����������
					return false;
				}
			}
			else
			{
				// ��������� ��� �������������
				return (counter > 0);
			}
		}

		/// <summary>
		/// �������� �� �� ������� ��������� ����� ������ ��� ������,
		/// ���������� �� ������ ���� �� ����-����� (��������). 
		/// �� ��� ����� �� ����������, ��� ����� ������ � ������, 
		/// ������� �� ������ ��� ��������� ���� ��� ����������
		/// ���� �� ���� ��� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="ownStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ������.</param>
		/// <param name="enemyStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ��� �������� ������.</param>
		/// <param name="FlipOpponentsPieces">������ ���� ��� ������ �� �� ��������������� �� ������
		/// ��� ��������� �� ���� ��� ��������� ������, ���� �� ������������ ����������, 
		/// ��� ������� ������� �� ����� ������ � ������.</param>
		/// <returns>������������ true �� ����� ������ � ������ ���� ����
		/// ��� ���������� (��� ���������� �������� �� ������ ��� ���������,
		/// �� ���� ��������), ��� false �����������.</returns>
		/// <remarks>�� �������� ownStatus ��� enemyStatus ����� �����
		/// ��� ����������� SquareStatus.</remarks>
		bool ValidateToDownRight(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// �������� ��� ������� ��� ��������� ���� ���� ��� ����������
			int counter = 0;
			// �������� ��� ��������� �� ���� ��� ��������� ����
			int i = 0;
			int j = 0;

			// ������� ��� ������� ��� ��������� ���� ���� ��� ����������
			for(i = row+1, j = col+1; i < theBoard.Length && j < theBoard[i].Length; i++, j++)
			{
				// ������� �� ��������� ����� ��� ���������
				if(theBoard[i][j].CurrentStatus == enemyStatus)
				{
					// ������� �� ������� ��� ��������� ������� ��� ��������� (�� �������)
					if (i == theBoard.Length-1 || j == theBoard[i].Length-1)
					{
						// ��������, ��� ��������� ��� ������ ������.
						// ���������� ��� ������� ���� �� ���������� false.
						counter = 0;
						break;
					}
					else
					{
						// ������ ��� �������
						counter++;
					}
				}
				else
					break;
			}
			// ������� �� ���� �� ������ ��� ��������� ��������� ���� ���
			if(i >= theBoard.Length || j >= theBoard[i].Length || theBoard[i][j].CurrentStatus != ownStatus)
				counter = 0;
			// ������� �� ������ �� ������������� �� ������ ��� ���������
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// ������� �� �������� ������ ��� ������
				{
					for(i = row+1, j = col+1; i < theBoard.Length && j < theBoard[i].Length; i++, j++)
					{
						// ������� �� ��������� ��� ����� ��� ���������
						if(theBoard[i][j].CurrentStatus == enemyStatus)
						{
							// ���������� ��� �������
							theBoard[i][j].Flip();
						}
						else
							break;
					}
					// �� ������� �������������.
					return true;
				}
				else
				{
					// ��� ����� ������ � ������ ���� ����� ���� ��� ����������
					return false;
				}
			}
			else
			{
				// ��������� ��� �������������
				return (counter > 0);
			}
		}

		/// <summary>
		/// �������� �� �� ������� ��������� ����� ������ ��� ������,
		/// ���������� �� ������ ���� �� ����-�������� (��������). 
		/// �� ��� ����� �� ����������, ��� ����� ������ � ������, 
		/// ������� �� ������ ��� ��������� ���� ��� ����������
		/// ���� �� ���� ��� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="ownStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ������.</param>
		/// <param name="enemyStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ��� �������� ������.</param>
		/// <param name="FlipOpponentsPieces">������ ���� ��� ������ �� �� ��������������� �� ������
		/// ��� ��������� �� ���� ��� ��������� ������, ���� �� ������������ ����������, 
		/// ��� ������� ������� �� ����� ������ � ������.</param>
		/// <returns>������������ true �� ����� ������ � ������ ���� ����
		/// ��� ���������� (��� ���������� �������� �� ������ ��� ���������,
		/// �� ���� ��������), ��� false �����������.</returns>
		/// <remarks>�� �������� ownStatus ��� enemyStatus ����� �����
		/// ��� ����������� SquareStatus.</remarks>
		bool ValidateToUpLeft(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// �������� ��� ������� ��� ��������� ���� ���� ��� ����������
			int counter = 0;
			// �������� ��� ��������� �� ���� ��� ��������� ����
			int i = 0;
			int j = 0;

			// ������� ��� ������� ��� ��������� ���� ���� ��� ����������
			for(i = row-1, j = col-1; i >= 0 && j >= 0; i--, j--)
			{
				// ������� �� ��������� ����� ��� ���������
				if(theBoard[i][j].CurrentStatus == enemyStatus)
				{
					// ������� �� ������� ��� ��������� ������� ��� ��������� (�� �������)
					if (i == 0 || j == 0)
					{
						// ��������, ��� ��������� ��� ������ ������.
						// ���������� ��� ������� ���� �� ���������� false.
						counter = 0;
						break;
					}
					else
					{
						// ������ ��� �������
						counter++;
					}
				}
				else
					break;
			}
			// ������� �� ���� �� ������ ��� ��������� ��������� ���� ���
			if(i < 0 || j < 0 || theBoard[i][j].CurrentStatus != ownStatus)
				counter = 0;
			// ������� �� ������ �� ������������� �� ������ ��� ���������
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// ������� �� �������� ������ ��� ������
				{
					for(i = row-1, j = col-1; i >=0 && j >=0; i--, j--)
					{
						// ������� �� ��������� ��� ����� ��� ���������
						if(theBoard[i][j].CurrentStatus == enemyStatus)
						{
							// ���������� ��� �������
							theBoard[i][j].Flip();
						}
						else
							break;
					}
					// �� ������� �������������.
					return true;
				}
				else
				{
					// ��� ����� ������ � ������ ���� ����� ���� ��� ����������
					return false;
				}
			}
			else
			{
				// ��������� ��� �������������
				return (counter > 0);
			}
		}

		/// <summary>
		/// �������� �� �� ������� ��������� ����� ������ ��� ������,
		/// ���������� �� ������ ���� �� ����-����� (��������). 
		/// �� ��� ����� �� ����������, ��� ����� ������ � ������, 
		/// ������� �� ������ ��� ��������� ���� ��� ����������
		/// ���� �� ���� ��� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="ownStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ������.</param>
		/// <param name="enemyStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ��� �������� ������.</param>
		/// <param name="FlipOpponentsPieces">������ ���� ��� ������ �� �� ��������������� �� ������
		/// ��� ��������� �� ���� ��� ��������� ������, ���� �� ������������ ����������, 
		/// ��� ������� ������� �� ����� ������ � ������.</param>
		/// <returns>������������ true �� ����� ������ � ������ ���� ����
		/// ��� ���������� (��� ���������� �������� �� ������ ��� ���������,
		/// �� ���� ��������), ��� false �����������.</returns>
		/// <remarks>�� �������� ownStatus ��� enemyStatus ����� �����
		/// ��� ����������� SquareStatus.</remarks>
		bool ValidateToUpRight(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// �������� ��� ������� ��� ��������� ���� ���� ��� ����������
			int counter = 0;
			// �������� ��� ��������� �� ���� ��� ��������� ����
			int i = 0;
			int j = 0;

			// ������� ��� ������� ��� ��������� ���� ���� ��� ����������
			for(i = row-1, j = col+1; i >=0 && j < theBoard[i].Length; i--, j++)
			{
				// ������� �� ��������� ����� ��� ���������
				if(theBoard[i][j].CurrentStatus == enemyStatus)
				{
					// ������� �� ������� ��� ��������� ������� ��� ��������� (�� �������)
					if (i == 0 || j == theBoard[i].Length-1)
					{
						// ��������, ��� ��������� ��� ������ ������.
						// ���������� ��� ������� ���� �� ���������� false.
						counter = 0;
						break;
					}
					else
					{
						// ������ ��� �������
						counter++;
					}
				}
				else
					break;
			}
			// ������� �� ���� �� ������ ��� ��������� ��������� ���� ���
			if(i < 0 || j >= theBoard[i].Length || theBoard[i][j].CurrentStatus != ownStatus)
				counter = 0;
			// ������� �� ������ �� ������������� �� ������ ��� ���������
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// ������� �� �������� ������ ��� ������
				{
					for(i = row-1, j = col+1; i >=0 && j < theBoard[i].Length; i--, j++)
					{
						// ������� �� ��������� ��� ����� ��� ���������
						if(theBoard[i][j].CurrentStatus == enemyStatus)
						{
							// ���������� ��� �������
							theBoard[i][j].Flip();
						}
						else
							break;
					}
					// �� ������� �������������.
					return true;
				}
				else
				{
					// ��� ����� ������ � ������ ���� ����� ���� ��� ����������
					return false;
				}
			}
			else
			{
				// ��������� ��� �������������
				return (counter > 0);
			}
		}

		/// <summary>
		/// �������� �� �� ������� �������� ����� ������ ��� ������,
		/// ���������� �� ������ ���� �� ����-�������� (��������). 
		/// �� ��� ����� �� ����������, ��� ����� ������ � ������, 
		/// ������� �� ������ ��� ��������� ���� ��� ����������
		/// ���� �� ���� ��� ������.
		/// </summary>
		/// <param name="row">� ������ ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="col">� ����� ��� ���������� ��� ����� �����
		/// �� ��������� ��� ������ ��� � �������.</param>
		/// <param name="ownStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ������.</param>
		/// <param name="enemyStatus">� ���� ��� SquareStatus ��� �����������
		/// ���� �������� ��� �������� ������.</param>
		/// <param name="FlipOpponentsPieces">������ ���� ��� ������ �� �� ��������������� �� ������
		/// ��� ��������� �� ���� ��� ��������� ������, ���� �� ������������ ����������, 
		/// ��� ������� ������� �� ����� ������ � ������.</param>
		/// <returns>������������ true �� ����� ������ � ������ ���� ����
		/// ��� ���������� (��� ���������� �������� �� ������ ��� ���������,
		/// �� ���� ��������), ��� false �����������.</returns>
		/// <remarks>�� �������� ownStatus ��� enemyStatus ����� �����
		/// ��� ����������� SquareStatus.</remarks>
		bool ValidateToDownLeft(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// �������� ��� ������� ��� ��������� ���� ���� ��� ����������
			int counter = 0;
			// �������� ��� ��������� �� ���� ��� ��������� ����
			int i = 0;
			int j = 0;

			// ������� ��� ������� ��� ��������� ���� ���� ��� ����������
			for(i = row+1, j = col-1; i < theBoard.Length && j >=0; i++, j--)
			{
				// ������� �� ��������� ����� ��� ���������
				if(theBoard[i][j].CurrentStatus == enemyStatus)
				{
					// ������� �� ������� ��� ��������� ������� ��� ��������� (�� �������)
					if (i == theBoard.Length-1 || j == 0)
					{
						// ��������, ��� ��������� ��� ������ ������.
						// ���������� ��� ������� ���� �� ���������� false.
						counter = 0;
						break;
					}
					else
					{
						// ������ ��� �������
						counter++;
					}
				}
				else
					break;
			}
			// ������� �� ���� �� ������ ��� ��������� ��������� ���� ���
			if(i >=  theBoard.Length || j < 0 || theBoard[i][j].CurrentStatus != ownStatus)
				counter = 0;
			// ������� �� ������ �� ������������� �� ������ ��� ���������
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// ������� �� �������� ������ ��� ������
				{
					for(i = row+1, j = col-1; i < theBoard.Length && j >=0; i++, j--)
					{
						// ������� �� ��������� ��� ����� ��� ���������
						if(theBoard[i][j].CurrentStatus == enemyStatus)
						{
							// ���������� ��� �������
							theBoard[i][j].Flip();
						}
						else
							break;
					}
					// �� ������� �������������.
					return true;
				}
				else
				{
					// ��� ����� ������ � ������ ���� ����� ���� ��� ����������
					return false;
				}
			}
			else
			{
				// ��������� ��� �������������
				return (counter > 0);
			}
		}

		#endregion

		/// <summary>
		/// ���������� �� ������ ��� ��������� ��� ������.
		/// </summary>
		public int BlackPieces
		{
			get
			{
				int counter = 0;
				foreach(IOthelloSquare[] row in theBoard)
					foreach(IOthelloSquare square in row)
						if(square.IsBlack)
							counter++;
				return counter;
			}
		}

		/// <summary>
		/// ���������� �� ������ ��� ��������� ��� ������.
		/// </summary>
		public int WhitePieces
		{
			get
			{
				int counter = 0;
				foreach(IOthelloSquare[] row in theBoard)
					foreach(IOthelloSquare square in row)
						if(square.IsWhite)
							counter++;
				return counter;
			}
		}

		/// <summary>
		/// ������� �� � �������� ����� ������ (���. ��� �������
		/// ������ ����� � "������" ���������) � ���.
		/// </summary>
		public bool BoardFull
		{
			get
			{
				foreach(IOthelloSquare[] row in theBoard)
					foreach(IOthelloSquare square in row)
						if(square.IsEmpty)
							return false;
				return true;
			}
		}
	}
}
