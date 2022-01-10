using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Othello
{
	/// <summary>
	/// Η τάξη αυτή υλοποιεί ένα τετράγωνο της σκακιέρας του Othello ως ένα στοιχείο
	/// ελέγχου του χρήστη.
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
		/// Μεταβλητή - μέλος που διατηρεί μία αναφορά στην 
		/// ImageList (αν υπάρχει), όπου υπάρχουν αποθηκευμένες οι εικόνες που θα
		/// εμφανίζει το τετράγωνο, ανάλογα με την κατάστασή του.
		/// </summary>
		private ImageList images;
		/// <summary>
		/// Μεταβλητή - μέλος που διατηρεί την τρέχουσα κατάσταση.
		/// </summary>
		SquareStatus status;
		/// <summary>
		/// Μεταβλητή - μέλος που διατηρεί την τρέχουσα γραμμή στη σκακιέρα.
		/// </summary>
		short row;
		/// <summary>
		/// Μεταβλητή - μέλος που διατηρεί την τρέχουσα στήλη στη σκακιέρα.
		/// </summary>
		short column;

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
		/// Επιστρέφει ή θέτει τη γραμμή (στη σκακιέρα) του τετραγώνου.
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
		/// Επιστρέφει ή θέτει τη στήλη (στη σκακιέρα) του τετραγώνου.
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
		/// Επιστρέφει ή θέτει την ImageList η οποία διαθέτει τις εικόνες που θα
		/// εμφανίζει το τετράγωνο, ανάλογα με την κατάστασή του.
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
				UpdateImage();	// Ανανέωση της εικόνας
			}
		}

		/// <summary>
		/// Επιστρέφει αν το τετράγωνο έχει κατάσταση "Empty" (άδειο) ή "Possible" (πιθανό).
		/// </summary>
		public bool IsEmpty
		{
			get
			{
				return status == SquareStatus.Empty || status == SquareStatus.Possible;
			}
		}

		/// <summary>
		/// Επιστρέφει ή θέτει αν το τετράγωνο έχει κατάσταση "White" (Λευκό).
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
					UpdateImage();	// Ανανέωση της εικόνας
				}
			}
		}

		/// <summary>
		/// Επιστρέφει ή θέτει αν το τετράγωνο έχει κατάσταση "Black" (Μαύρο).
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
					UpdateImage();	// Ανανέωση της εικόνας
				}
			}
		}

		/// <summary>
		/// Επιστρέφει ή θέτει αν το τετράγωνο έχει κατάσταση "Possible" (πιθανό).
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
					UpdateImage();	// Ανανέωση της εικόνας
				}
			}
		}

		/// <summary>
		/// Επιστρέφει ή θέτει την τρέχουσα κατάσταση του τετραγώνου και ανανεώνει
		/// την εικόνα του τετραγώνου.
		/// </summary>
		/// <value>
		/// Η τιμή είναι μία από αυτές που επιτρέπονται από την απαρίθμιση SquareStatus.
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
				UpdateImage();	// Ανανέωση της εικόνας
			}
		}

		/// <summary>
		/// Ανανεώνει την εικόνα του τετραγώνου με βάση αυτές που
		/// περιέχονται στο ImageList images και την τρέχουσα
		/// κατάσταση.
		/// </summary>
		private void UpdateImage()
		{
			// Έλεγχος αν υπάρχει το ImageList και έχει τουλάχιστον
			// 4 εικόνες
			if(images != null && images.Images.Count > 3)
			{
				// εμφάνιση της κατάλληλης εικόνας στο παρασκήνιο του στοιχείου ελέγχου
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
				// Καθαρισμός της εικόνας
				this.BackgroundImage = null;
			}
		}

		/// <summary>
		/// Αλλάζει την κατάσταση του τετραγώνου από Λευκό σε Μαύρο και αντίστροφα.
		/// Αν το τετράγωνο είναι άδειο ή "πιθανό" τότε δεν κάνει τίποτα.
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
