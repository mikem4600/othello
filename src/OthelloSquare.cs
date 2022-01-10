using System;

namespace Othello
{
	/// <summary>
	/// Περιλαμβάνει όλες τις δυνατές τιμές που μπορεί να
	/// έχει η κατάσταση ενός τετραγώνου του Othello.
	/// </summary>
	public enum SquareStatus
	{
		/// <summary>
		/// Η κατάσταση για το τετράγωνο με μαύρο πούλι.
		/// </summary>
		Black = -1,
		/// <summary>
		/// Η κατάσταση για το άδειο τετράγωνο.
		/// </summary>
		Empty,
		/// <summary>
		/// Η κατάσταση για το τετράγωνο με άσπρο πούλι.
		/// </summary>
		White,
		/// <summary>
		/// Η κατάσταση για το τετράγωνο που αποτελεί πιθανή κίνηση.
		/// </summary>
		Possible
	}

	/// <summary>
	/// Η διεπαφή (interface) αυτή περιλαμβάνει όλα τα
	/// χαρακτηριστικά που πρέπει να υλοποιεί κάθε τάξη
	/// τετραγώνου του Othello.
	/// </summary>
	public interface IOthelloSquare
	{
		/// <summary>
		/// Επιστρέφει αν το τετράγωνο έχει κατάσταση "Empty" (άδειο) ή "Possible" (πιθανό).
		/// </summary>
		bool IsEmpty
		{
			get;
		}

		/// <summary>
		/// Επιστρέφει ή θέτει αν το τετράγωνο έχει κατάσταση "White" (Λευκό).
		/// </summary>
		bool IsWhite
		{
			get;
			set;
		}

		/// <summary>
		/// Επιστρέφει ή θέτει αν το τετράγωνο έχει κατάσταση "Black" (Μαύρο).
		/// </summary>
		bool IsBlack
		{
			get;
			set;
		}

		/// <summary>
		/// Επιστρέφει ή θέτει αν το τετράγωνο έχει κατάσταση "Possible" (πιθανό).
		/// </summary>
		bool IsPossible
		{
			get;
			set;
		}

		/// <summary>
		/// Επιστρέφει ή θέτει την τρέχουσα κατάσταση του τετραγώνου.
		/// </summary>
		/// <value>
		/// Η τιμή είναι μία από αυτές που επιτρέπονται από την απαρίθμιση SquareStatus.
		/// </value>
		SquareStatus CurrentStatus
		{
			get;
			set;
		}

		/// <summary>
		/// Επιστρέφει ή θέτει τη γραμμή (στη σκακιέρα) του τετραγώνου.
		/// </summary>
		short Row
		{
			get;
			set;
		}

		/// <summary>
		/// Επιστρέφει ή θέτει τη στήλη (στη σκακιέρα) του τετραγώνου.
		/// </summary>
		short Column
		{
			get;
			set;
		}

		/// <summary>
		/// Αλλάζει την κατάσταση του τετραγώνου από Λευκό σε Μαύρο και αντίστροφα.
		/// Αν το τετράγωνο είναι άδειο ή "πιθανό" τότε δεν κάνει τίποτα.
		/// </summary>
		void Flip();
		
	}


	/// <summary>
	/// Η τάξη αυτή υλοποιεί ένα τετράγωνο της σκακιέρας του Othello.
	/// </summary>
	public class OthelloSquare: IOthelloSquare
	{
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
		/// Προεπιλεγμένος κατασκευαστής.
		/// </summary>
		/// <remarks>Η μέθοδος αυτή δεν κάνει τίποτα - 
		/// οι προεπιλεγμένες προτεροτιμές μας αρκούν.
		/// Υπάρχει απλώς για να μην καταργηθεί ο προεπιλεγμένος
		/// κατασκευαστής που κανονικά παρέχεται αν δεν υπάρχει άλλος.</remarks>
		public OthelloSquare(){}

		/// <summary>
		/// Κατασκευαστής αντιγραφής.
		/// </summary>
		/// <param name="original">Το αντικείμενο που έχει τις ιδιότητες
		/// που θέλουμε να δώσουμε σε αυτό που κατασκευάζεται τώρα.</param>
		/// <remarks>Δημιουργεί το αντικείμενο ώστε να έχει τα ίδια
		/// χαρακτηριστικά με ένα άλλο, που περνιέται σαν όρισμα.</remarks>
		public OthelloSquare(IOthelloSquare original)
		{
			// Αντιγραφή των χαρακτηριστικών
			this.CurrentStatus = original.CurrentStatus;
			this.Row = original.Row;
			this.Column = original.Column;
		}

		#region IOthelloSquare Members

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
				status = SquareStatus.White;
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
				status = SquareStatus.Black;
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
				status = SquareStatus.Possible;
			}
		}

		/// <summary>
		/// Επιστρέφει ή θέτει την τρέχουσα κατάσταση του τετραγώνου.
		/// </summary>
		/// <value>
		/// Η τιμή είναι μία από αυτές που επιτρέπονται από την απαρίθμιση SquareStatus.
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
		/// Αλλάζει την κατάσταση του τετραγώνου από Λευκό σε Μαύρο και αντίστροφα.
		/// Αν το τετράγωνο είναι άδειο ή "πιθανό" τότε δεν κάνει τίποτα.
		/// </summary>
		public void Flip()
		{
			if (status == SquareStatus.Black) this.CurrentStatus = SquareStatus.White;
			else if (status == SquareStatus.White) this.CurrentStatus = SquareStatus.Black;
		}

		#endregion

	}

}
