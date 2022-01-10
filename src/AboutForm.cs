using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Othello
{
	/// <summary>
	/// Η τάξη αυτή περιέχει την φόρμα πληροφοριών της εφαρμογής.
	/// </summary>
	public class AboutForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.LinkLabel lnkAUEB;
		private System.Windows.Forms.LinkLabel lnkCSAUEB;
		private System.Windows.Forms.PictureBox picIcon;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.LinkLabel lnkMike;
		private System.Windows.Forms.LinkLabel lnkZXMail;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblMike;
		private System.Windows.Forms.Label lblZX;
		private System.Windows.Forms.PictureBox picLogo;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Προεπιλεγμένος κατασκευαστής.
		/// </summary>
		public AboutForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutForm));
			this.btnOK = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lnkAUEB = new System.Windows.Forms.LinkLabel();
			this.lnkCSAUEB = new System.Windows.Forms.LinkLabel();
			this.lblDate = new System.Windows.Forms.Label();
			this.picIcon = new System.Windows.Forms.PictureBox();
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lnkMike = new System.Windows.Forms.LinkLabel();
			this.lblMike = new System.Windows.Forms.Label();
			this.lnkZXMail = new System.Windows.Forms.LinkLabel();
			this.lblZX = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(240, 264);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblTitle.Location = new System.Drawing.Point(48, 88);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(280, 16);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Othello";
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(48, 104);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(280, 16);
			this.lblDescription.TabIndex = 2;
			this.lblDescription.Text = "Εργασία για το μάθημα ΕΠΛ-444 Τεχνητή Νοημοσύνη";
			// 
			// lnkAUEB
			// 
			this.lnkAUEB.Location = new System.Drawing.Point(8, 208);
			this.lnkAUEB.Name = "lnkAUEB";
			this.lnkAUEB.Size = new System.Drawing.Size(312, 16);
			this.lnkAUEB.TabIndex = 3;
			this.lnkAUEB.TabStop = true;
			this.lnkAUEB.Text = "Οικονομικό Πανεπιστήμιο Αθηνών";
			this.lnkAUEB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAUEB_LinkClicked);
			// 
			// lnkCSAUEB
			// 
			this.lnkCSAUEB.Location = new System.Drawing.Point(8, 224);
			this.lnkCSAUEB.Name = "lnkCSAUEB";
			this.lnkCSAUEB.Size = new System.Drawing.Size(312, 16);
			this.lnkCSAUEB.TabIndex = 4;
			this.lnkCSAUEB.TabStop = true;
			this.lnkCSAUEB.Text = "Τμήμα Πληροφορικής";
			this.lnkCSAUEB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCSAUEB_LinkClicked);
			// 
			// lblDate
			// 
			this.lblDate.Location = new System.Drawing.Point(8, 240);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(312, 16);
			this.lblDate.TabIndex = 5;
			this.lblDate.Text = "Χειμερινό εξάμηνο ακαδημαϊκού έτους 2003-2004";
			// 
			// picIcon
			// 
			this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
			this.picIcon.Location = new System.Drawing.Point(8, 88);
			this.picIcon.Name = "picIcon";
			this.picIcon.Size = new System.Drawing.Size(32, 32);
			this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picIcon.TabIndex = 6;
			this.picIcon.TabStop = false;
			// 
			// picLogo
			// 
			this.picLogo.BackColor = System.Drawing.Color.Black;
			this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
			this.picLogo.Location = new System.Drawing.Point(0, 0);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(336, 72);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picLogo.TabIndex = 12;
			this.picLogo.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lnkMike);
			this.groupBox1.Controls.Add(this.lblMike);
			this.groupBox1.Controls.Add(this.lnkZXMail);
			this.groupBox1.Controls.Add(this.lblZX);
			this.groupBox1.Location = new System.Drawing.Point(8, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(312, 72);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ανάπτυξη";
			// 
			// lnkMike
			// 
			this.lnkMike.AutoSize = true;
			this.lnkMike.Location = new System.Drawing.Point(8, 40);
			this.lnkMike.Name = "lnkMike";
			this.lnkMike.Size = new System.Drawing.Size(165, 17);
			this.lnkMike.TabIndex = 15;
			this.lnkMike.TabStop = true;
			this.lnkMike.Text = "http://dias.aueb.gr/~p3010094/";
			this.lnkMike.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMike_LinkClicked);
			// 
			// lblMike
			// 
			this.lblMike.AutoSize = true;
			this.lblMike.Location = new System.Drawing.Point(8, 24);
			this.lblMike.Name = "lblMike";
			this.lblMike.Size = new System.Drawing.Size(88, 17);
			this.lblMike.TabIndex = 14;
			this.lblMike.Text = "Μακίδης Μιχάλης";
			// 
			// lnkZXMail
			// 
			this.lnkZXMail.AutoSize = true;
			this.lnkZXMail.Location = new System.Drawing.Point(184, 40);
			this.lnkZXMail.Name = "lnkZXMail";
			this.lnkZXMail.Size = new System.Drawing.Size(126, 17);
			this.lnkZXMail.TabIndex = 13;
			this.lnkZXMail.TabStop = true;
			this.lnkZXMail.Text = "p3010057@dias.aueb.gr";
			this.lnkZXMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkZXMail_LinkClicked);
			// 
			// lblZX
			// 
			this.lblZX.AutoSize = true;
			this.lblZX.Location = new System.Drawing.Point(184, 24);
			this.lblZX.Name = "lblZX";
			this.lblZX.Size = new System.Drawing.Size(112, 17);
			this.lblZX.TabIndex = 12;
			this.lblZX.Text = "Κουβακλή Ζαχαρούλα";
			// 
			// AboutForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(330, 296);
			this.ControlBox = false;
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.picLogo);
			this.Controls.Add(this.picIcon);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lnkCSAUEB);
			this.Controls.Add(this.lnkAUEB);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.btnOK);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Περί της Εφαρμογής";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Μεταβιβάζει τον χρήστη στην τοποθεσία της υπερσύνδεσης
		/// που επιλέχθηκε.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void lnkAUEB_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			// Ορισμός ότι έχει γίνει επίσκεψη στην υπερσύνδεση
			lnkAUEB.LinkVisited = true;
			// ’νοιγμα του προεπιλεγμένου προγράμματος περιήγησης για τη
			// μετάβαση στην τοποθεσία
			System.Diagnostics.Process.Start("http://www.aueb.gr/");
		}

		/// <summary>
		/// Μεταβιβάζει τον χρήστη στην τοποθεσία της υπερσύνδεσης
		/// που επιλέχθηκε.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void lnkCSAUEB_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			// Ορισμός ότι έχει γίνει επίσκεψη στην υπερσύνδεση
			lnkCSAUEB.LinkVisited = true;
			// ’νοιγμα του προεπιλεγμένου προγράμματος περιήγησης για τη
			// μετάβαση στην τοποθεσία
			System.Diagnostics.Process.Start("http://www.cs.aueb.gr/");
		}

		/// <summary>
		/// Μεταβιβάζει τον χρήστη στην τοποθεσία της υπερσύνδεσης
		/// που επιλέχθηκε (αποστολή ηλ. ταχυδρομίου).
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void lnkZXMail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			// Ορισμός ότι έχει γίνει επίσκεψη στην υπερσύνδεση
			lnkZXMail.LinkVisited = true;
			// ’νοιγμα του προεπιλεγμένου προγράμματος περιήγησης για την
			// αποστολή μηνύματος
			System.Diagnostics.Process.Start("mailto:p3010057@dias.aueb.gr");
		}

		/// <summary>
		/// Μεταβιβάζει τον χρήστη στην τοποθεσία της υπερσύνδεσης
		/// που επιλέχθηκε.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void lnkMike_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			// Ορισμός ότι έχει γίνει επίσκεψη στην υπερσύνδεση
			lnkMike.LinkVisited = true;
			// ’νοιγμα του προεπιλεγμένου προγράμματος περιήγησης για τη
			// μετάβαση στην τοποθεσία
			System.Diagnostics.Process.Start("http://dias.aueb.gr/~p3010094/");
		}

		/// <summary>
		/// Η μέθοδος αυτή καλείται όταν ο χρήστης κάνει
		/// κλικ στο πλήκτρο ΟΚ, και εξαφανίζει από την
		/// οθόνη τη φόρμα αυτή.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Hide();
		}
	}
}
