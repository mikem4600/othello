using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Othello
{
	/// <summary>
	/// � ���� ���� �������� ��� ��������� ��� ��������� ��� Othello �� ��� ��������
	/// ������� ��� ������.
	/// </summary>
	public class OthelloSquareControl : System.Windows.Forms.UserControl, IOthelloSquare
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OthelloSquareControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent call

		}

		/// <summary>
		/// ��������� - ����� ��� �������� ��� ������� ���� 
		/// ImageList (�� �������), ���� �������� ������������� �� ������� ��� ��
		/// ��������� �� ���������, ������� �� ��� ��������� ���.
		/// </summary>
		private ImageList images;
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
		/// ������������ ��� ����� ��� ����������������.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// OthelloSquareControl
			// 
			this.Name = "OthelloSquareControl";
			this.Size = new System.Drawing.Size(24, 24);
			this.Load += new System.EventHandler(this.OthelloSquareControl_Load);

		}
		#endregion

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
		/// ���������� � ����� ��� ImageList � ����� �������� ��� ������� ��� ��
		/// ��������� �� ���������, ������� �� ��� ��������� ���.
		/// </summary>
		public ImageList ImagesList 
		{
			get
			{
				return images;
			}
			set
			{
				images = value;
				UpdateImage();	// �������� ��� �������
			}
		}

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
				if (value == true)
				{
					status = SquareStatus.White;
					UpdateImage();	// �������� ��� �������
				}
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
				if (value == true)
				{
					status = SquareStatus.Black;
					UpdateImage();	// �������� ��� �������
				}
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
				if (value == true)
				{
					status = SquareStatus.Possible;
					UpdateImage();	// �������� ��� �������
				}
			}
		}

		/// <summary>
		/// ���������� � ����� ��� �������� ��������� ��� ���������� ��� ���������
		/// ��� ������ ��� ����������.
		/// </summary>
		/// <value>
		/// � ���� ����� ��� ��� ����� ��� ������������ ��� ��� ���������� SquareStatus.
		/// </value>
		public SquareStatus CurrentStatus
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
				UpdateImage();	// �������� ��� �������
			}
		}

		/// <summary>
		/// ��������� ��� ������ ��� ���������� �� ���� ����� ���
		/// ����������� ��� ImageList images ��� ��� ��������
		/// ���������.
		/// </summary>
		private void UpdateImage()
		{
			// ������� �� ������� �� ImageList ��� ���� �����������
			// 4 �������
			if(images != null && images.Images.Count > 3)
			{
				// �������� ��� ���������� ������� ��� ���������� ��� ��������� �������
				switch(status)
				{
					case SquareStatus.Empty:
						this.BackgroundImage = images.Images[0];
						break;

					case SquareStatus.White:
						this.BackgroundImage = images.Images[1];
						break;

					case SquareStatus.Black:
						this.BackgroundImage = images.Images[2];
						break;

					case SquareStatus.Possible:
						this.BackgroundImage = images.Images[3];
						break;
				}
			}
			else
			{
				// ���������� ��� �������
				this.BackgroundImage = null;
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

			//debug
			System.Console.WriteLine("Flipping (OthelloPiece)" + this.Row + " " + this.Column);
		}

		private void OthelloSquareControl_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
