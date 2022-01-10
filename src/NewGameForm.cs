using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Othello
{
	/// <summary>
	/// Η τάξη αυτή περιέχει την φόρμα εισαγωγής
	/// των παραμέτρων του νέου παιχνιδιού.
	/// </summary>
	public class NewGameForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblFirstPlayer;
		private System.Windows.Forms.Label lblPieceColour;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.RadioButton rdbComputerFirst;
		public System.Windows.Forms.RadioButton rdbHumanFirst;
		private System.Windows.Forms.Panel panel2;
		public System.Windows.Forms.RadioButton rdbBlack;
		public System.Windows.Forms.RadioButton rdbWhite;
		private System.Windows.Forms.PictureBox picIcon;
		private System.Windows.Forms.Label lblDifficulty;
		private System.Windows.Forms.Label lblWarning;
		public System.Windows.Forms.NumericUpDown numDif;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Προεπιλεγμένος κατασκευαστής.
		/// </summary>
		public NewGameForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Απελευθέρωση των πόρων που χρησιμοποιούνται.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(NewGameForm));
			this.lblFirstPlayer = new System.Windows.Forms.Label();
			this.lblPieceColour = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rdbComputerFirst = new System.Windows.Forms.RadioButton();
			this.rdbHumanFirst = new System.Windows.Forms.RadioButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.rdbBlack = new System.Windows.Forms.RadioButton();
			this.rdbWhite = new System.Windows.Forms.RadioButton();
			this.picIcon = new System.Windows.Forms.PictureBox();
			this.lblDifficulty = new System.Windows.Forms.Label();
			this.numDif = new System.Windows.Forms.NumericUpDown();
			this.lblWarning = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numDif)).BeginInit();
			this.SuspendLayout();
			// 
			// lblFirstPlayer
			// 
			this.lblFirstPlayer.Location = new System.Drawing.Point(48, 16);
			this.lblFirstPlayer.Name = "lblFirstPlayer";
			this.lblFirstPlayer.Size = new System.Drawing.Size(248, 16);
			this.lblFirstPlayer.TabIndex = 0;
			this.lblFirstPlayer.Text = "Επιλέξτε ποιος παίκτης θα παίξει πρώτος:";
			// 
			// lblPieceColour
			// 
			this.lblPieceColour.Location = new System.Drawing.Point(48, 88);
			this.lblPieceColour.Name = "lblPieceColour";
			this.lblPieceColour.Size = new System.Drawing.Size(255, 16);
			this.lblPieceColour.TabIndex = 1;
			this.lblPieceColour.Text = "Επιλέξτε το χρώμα των πιονιών σας στο παιχνίδι:";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(240, 240);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(64, 24);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "’κυρο";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(168, 240);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(64, 24);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "ΟΚ";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rdbComputerFirst);
			this.panel1.Controls.Add(this.rdbHumanFirst);
			this.panel1.Location = new System.Drawing.Point(64, 32);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(240, 48);
			this.panel1.TabIndex = 8;
			// 
			// rdbComputerFirst
			// 
			this.rdbComputerFirst.Location = new System.Drawing.Point(8, 24);
			this.rdbComputerFirst.Name = "rdbComputerFirst";
			this.rdbComputerFirst.Size = new System.Drawing.Size(224, 16);
			this.rdbComputerFirst.TabIndex = 1;
			this.rdbComputerFirst.Text = "Να παίξει ο υπολογιστής πρώτος";
			// 
			// rdbHumanFirst
			// 
			this.rdbHumanFirst.Checked = true;
			this.rdbHumanFirst.Location = new System.Drawing.Point(8, 8);
			this.rdbHumanFirst.Name = "rdbHumanFirst";
			this.rdbHumanFirst.Size = new System.Drawing.Size(224, 16);
			this.rdbHumanFirst.TabIndex = 0;
			this.rdbHumanFirst.TabStop = true;
			this.rdbHumanFirst.Text = "Θα παίξω εγώ πρώτος";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.rdbBlack);
			this.panel2.Controls.Add(this.rdbWhite);
			this.panel2.Location = new System.Drawing.Point(64, 104);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(240, 48);
			this.panel2.TabIndex = 9;
			// 
			// rdbBlack
			// 
			this.rdbBlack.Location = new System.Drawing.Point(8, 24);
			this.rdbBlack.Name = "rdbBlack";
			this.rdbBlack.Size = new System.Drawing.Size(224, 16);
			this.rdbBlack.TabIndex = 3;
			this.rdbBlack.Text = "Μαύρα";
			// 
			// rdbWhite
			// 
			this.rdbWhite.Checked = true;
			this.rdbWhite.Location = new System.Drawing.Point(8, 8);
			this.rdbWhite.Name = "rdbWhite";
			this.rdbWhite.Size = new System.Drawing.Size(224, 16);
			this.rdbWhite.TabIndex = 2;
			this.rdbWhite.TabStop = true;
			this.rdbWhite.Text = "Λευκά";
			// 
			// picIcon
			// 
			this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
			this.picIcon.Location = new System.Drawing.Point(8, 16);
			this.picIcon.Name = "picIcon";
			this.picIcon.Size = new System.Drawing.Size(32, 32);
			this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picIcon.TabIndex = 10;
			this.picIcon.TabStop = false;
			// 
			// lblDifficulty
			// 
			this.lblDifficulty.Location = new System.Drawing.Point(48, 162);
			this.lblDifficulty.Name = "lblDifficulty";
			this.lblDifficulty.Size = new System.Drawing.Size(255, 16);
			this.lblDifficulty.TabIndex = 11;
			this.lblDifficulty.Text = "Επιλέξτε επίπεδο δυσκολίας:";
			// 
			// numDif
			// 
			this.numDif.Location = new System.Drawing.Point(224, 160);
			this.numDif.Maximum = new System.Decimal(new int[] {
																   64,
																   0,
																   0,
																   0});
			this.numDif.Minimum = new System.Decimal(new int[] {
																   1,
																   0,
																   0,
																   0});
			this.numDif.Name = "numDif";
			this.numDif.Size = new System.Drawing.Size(80, 20);
			this.numDif.TabIndex = 12;
			this.numDif.Value = new System.Decimal(new int[] {
																 4,
																 0,
																 0,
																 0});
			// 
			// lblWarning
			// 
			this.lblWarning.Location = new System.Drawing.Point(48, 192);
			this.lblWarning.Name = "lblWarning";
			this.lblWarning.Size = new System.Drawing.Size(255, 48);
			this.lblWarning.TabIndex = 13;
			this.lblWarning.Text = "Σημείωση: Όσο μεγαλύτερο το επίπεδο δυσκολίας, τόσο πιο αργός θα είναι ο υπολογισ" +
				"τής σε κάθε κίνησή του.";
			// 
			// NewGameForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(314, 271);
			this.ControlBox = false;
			this.Controls.Add(this.lblWarning);
			this.Controls.Add(this.numDif);
			this.Controls.Add(this.lblDifficulty);
			this.Controls.Add(this.picIcon);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblPieceColour);
			this.Controls.Add(this.lblFirstPlayer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewGameForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Νέο παιχνίδι";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numDif)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

	}
}
