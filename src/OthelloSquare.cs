using System;

namespace Othello
{
	/// <summary>
	/// ������������ ���� ��� ������� ����� ��� ������ ��
	/// ���� � ��������� ���� ���������� ��� Othello.
	/// </summary>
	public enum SquareStatus
	{
		/// <summary>
		/// � ��������� ��� �� ��������� �� ����� �����.
		/// </summary>
		Black = -1,
		/// <summary>
		/// � ��������� ��� �� ����� ���������.
		/// </summary>
		Empty,
		/// <summary>
		/// � ��������� ��� �� ��������� �� ����� �����.
		/// </summary>
		White,
		/// <summary>
		/// � ��������� ��� �� ��������� ��� �������� ������ ������.
		/// </summary>
		Possible
	}

	/// <summary>
	/// � ������� (interface) ���� ������������ ��� ��
	/// �������������� ��� ������ �� �������� ���� ����
	/// ���������� ��� Othello.
	/// </summary>
	public interface IOthelloSquare
	{
		/// <summary>
		/// ���������� �� �� ��������� ���� ��������� "Empty" (�����) � "Possible" (������).
		/// </summary>
		bool IsEmpty
		{
			get;
		}

		/// <summary>
		/// ���������� � ����� �� �� ��������� ���� ��������� "White" (�����).
		/// </summary>
		bool IsWhite
		{
			get;
			set;
		}

		/// <summary>
		/// ���������� � ����� �� �� ��������� ���� ��������� "Black" (�����).
		/// </summary>
		bool IsBlack
		{
			get;
			set;
		}

		/// <summary>
		/// ���������� � ����� �� �� ��������� ���� ��������� "Possible" (������).
		/// </summary>
		bool IsPossible
		{
			get;
			set;
		}

		/// <summary>
		/// ���������� � ����� ��� �������� ��������� ��� ����������.
		/// </summary>
		/// <value>
		/// � ���� ����� ��� ��� ����� ��� ������������ ��� ��� ���������� SquareStatus.
		/// </value>
		SquareStatus CurrentStatus
		{
			get;
			set;
		}

		/// <summary>
		/// ���������� � ����� �� ������ (��� ��������) ��� ����������.
		/// </summary>
		short Row
		{
			get;
			set;
		}

		/// <summary>
		/// ���������� � ����� �� ����� (��� ��������) ��� ����������.
		/// </summary>
		short Column
		{
			get;
			set;
		}

		/// <summary>
		/// ������� ��� ��������� ��� ���������� ��� ����� �� ����� ��� ����������.
		/// �� �� ��������� ����� ����� � "������" ���� ��� ����� ������.
		/// </summary>
		void Flip();
		
	}


	/// <summary>
	/// � ���� ���� �������� ��� ��������� ��� ��������� ��� Othello.
	/// </summary>
	public class OthelloSquare: IOthelloSquare
	{
		/// <summary>
		/// ��������� - ����� ��� �������� ��� �������� ���������.
		/// </summary>
		SquareStatus status;
		/// <summary>
		/// ��������� - ����� ��� �������� ��� �������� ������ ��� ��������.
		/// </summary>
		short row;
		/// <summary>
		/// ��������� - ����� ��� �������� ��� �������� ����� ��� ��������.
		/// </summary>
		short column;

		/// <summary>
		/// �������������� �������������.
		/// </summary>
		/// <remarks>� ������� ���� ��� ����� ������ - 
		/// �� �������������� ������������ ��� ������.
		/// ������� ����� ��� �� ��� ���������� � ��������������
		/// ������������� ��� �������� ��������� �� ��� ������� �����.</remarks>
		public OthelloSquare(){}

		/// <summary>
		/// ������������� ����������.
		/// </summary>
		/// <param name="original">�� ����������� ��� ���� ��� ���������
		/// ��� ������� �� ������� �� ���� ��� �������������� ����.</param>
		/// <remarks>���������� �� ����������� ���� �� ���� �� ����
		/// �������������� �� ��� ����, ��� ��������� ��� ������.</remarks>
		public OthelloSquare(IOthelloSquare original)
		{
			// ��������� ��� ���������������
			this.CurrentStatus = original.CurrentStatus;
			this.Row = original.Row;
			this.Column = original.Column;
		}

		#region IOthelloSquare Members

		/// <summary>
		/// ���������� �� �� ��������� ���� ��������� "Empty" (�����) � "Possible" (������).
		/// </summary>
		public bool IsEmpty
		{
			get
			{
				return status == SquareStatus.Empty || status == SquareStatus.Possible;
			}
		}

		/// <summary>
		/// ���������� � ����� �� �� ��������� ���� ��������� "White" (�����).
		/// </summary>
		public bool IsWhite
		{
			get
			{
				return status == SquareStatus.White;
			}
			set
			{
				status = SquareStatus.White;
			}
		}

		/// <summary>
		/// ���������� � ����� �� �� ��������� ���� ��������� "Black" (�����).
		/// </summary>
		public bool IsBlack
		{
			get
			{
				return status == SquareStatus.Black;
			}
			set
			{
				status = SquareStatus.Black;
			}
		}

		/// <summary>
		/// ���������� � ����� �� �� ��������� ���� ��������� "Possible" (������).
		/// </summary>
		public bool IsPossible
		{
			get
			{
				return status == SquareStatus.Possible;
			}
			set
			{
				status = SquareStatus.Possible;
			}
		}

		/// <summary>
		/// ���������� � ����� ��� �������� ��������� ��� ����������.
		/// </summary>
		/// <value>
		/// � ���� ����� ��� ��� ����� ��� ������������ ��� ��� ���������� SquareStatus.
		/// </value>
		public Othello.SquareStatus CurrentStatus
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}
		}

		/// <summary>
		/// ���������� � ����� �� ������ (��� ��������) ��� ����������.
		/// </summary>
		public short Row
		{
			get
			{
				return row;
			}
			set
			{
				row = value;
			}
		}

		/// <summary>
		/// ���������� � ����� �� ����� (��� ��������) ��� ����������.
		/// </summary>
		public short Column
		{
			get
			{
				return column;
			}
			set
			{
				column = value;
			}
		}

		/// <summary>
		/// ������� ��� ��������� ��� ���������� ��� ����� �� ����� ��� ����������.
		/// �� �� ��������� ����� ����� � "������" ���� ��� ����� ������.
		/// </summary>
		public void Flip()
		{
			if (status == SquareStatus.Black) this.CurrentStatus = SquareStatus.White;
			else if (status == SquareStatus.White) this.CurrentStatus = SquareStatus.Black;
		}

		#endregion

	}

}
