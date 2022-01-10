//othelloBoard
using System;

namespace Othello
{
	/// <summary>
	/// Η τάξη αυτή ενθυλακώνει όλες τις μεταβλητές και μεθόδους που χρειάζονται
	/// για μία σκακέρα (δηλ. ένα σύνολο 8x8 τετραγώνων) του Othello.
	/// </summary>
	public class OthelloBoard
	{
		/// <summary>
		/// Μεταβλητή - μέλος που αποθηκεύει ως πίνακα τα τετράγωνα (αντικείμενα)
		/// της σκακιέρας
		/// </summary>
		IOthelloSquare[][] theBoard;

		/// <summary>
		/// Κατασκευαστής.
		/// </summary>
		/// <param name="Board">Ο πίνακας με τα στοιχεία που θα χρησιμοποιηθούν
		/// (αναφορικά) για τη σκακιέρα.</param>
		public OthelloBoard(IOthelloSquare[][] Board)
		{
			theBoard = Board;
		}

		/// <summary>
		/// Κατασκευαστής αντιγραφής.
		/// </summary>
		/// <param name="original">H σκακιέρα με τα στοιχεία που θα αντιγραφούν.</param>
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
		/// Μέθοδος προσπέλασης των τετραγώνων της σκακιέρας.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου.</param>
		/// <param name="col">Η στήλη του τετραγώνου.</param>
		/// <returns>Αναφορά προς το τετράγωνο.</returns>
		public IOthelloSquare Square (int row, int col)
		{
			return theBoard[row][col];
		}

		/// <summary>
		/// Αλλαγή των άδειων τετραγώνων της σκακιέρας σε "πιθανών"
		/// για κίνηση του τρέχοντος παίκτη.
		/// </summary>
		/// <param name="IsWhitesTurn">Λογική τιμή για το εάν είναι τώρα
		/// η σειρά των Λευκών.</param>
		public void MarkPossibleMoves(bool IsWhitesTurn)
		{
			foreach(IOthelloSquare[] row in theBoard)
			{
				foreach(IOthelloSquare square in row)
				{
					// έλεγχος αν το τετράγωνο είναι άδειο ή πιθανό (για τον προηγούμενο παίκτη)
					if(square.IsEmpty)
					{
						// έλεγχος αν είναι έγκυρη κίνηση
						if(IsValidMove(square.Row, square.Column, IsWhitesTurn))
						{
							// είναι έκγυρη κίνηση, ορισμός ως πιθανό
							square.CurrentStatus = SquareStatus.Possible;
						}
						else
						{
							// δεν είναι έκγυρη κίνηση, ορισμός ως άδειο
							square.CurrentStatus = SquareStatus.Empty;
						}
					}
				}
			}
		}

		/// <summary>
		/// Ελέγχει αν υπάρχει έστω και μία έγκυρη κίνηση στη σκακιέρα
		/// για έναν δοσμένο παίκτη.
		/// </summary>
		/// <param name="IsWhitesTurn">Λογική τιμή για το εάν είναι τώρα
		/// η σειρά των Λευκών.</param>
		/// <returns>Επιστρέφεται true αν υπάρχει έστω και μία έγκυρη κίνηση
		/// στη σκακιέρα, και false αν δεν υπάρχει καμία.</returns>
		public bool ValidMovesExist(bool IsWhitesTurn)
		{
			foreach(IOthelloSquare[] row in theBoard)
				foreach(IOthelloSquare square in row)
					// Έλεγχος αν είναι έγκυρη η κίνηση σε αυτό το τετράγωνο
					if(square.IsEmpty && IsValidMove(square.Row, square.Column, IsWhitesTurn))
							return true;
			return false;
		}

		/// <summary>
		/// Ελέγχει η κίνηση είναι έγκυρη σε ένα δοσμένο τετράγωνο,
		/// για κάποιο δοσμένο παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="IsWhitesTurn">Λογική τιμή για το εάν είναι τώρα
		/// η σειρά των Λευκών.</param>
		/// <returns>Επιστρέφεται true αν η κίνηση είναι έγκυρη,
		/// και false διαφορετικά.</returns>
		public bool IsValidMove(int row, int col, bool IsWhitesTurn)
		{
			// Έλεγχος αν το τετράγωνο αυτό είναι ελεύθερο
			if(!theBoard[row][col].IsEmpty)
				return false;

			// Εύρεση της "κατάστασης" του παίκτη της τρέχουσας
			// σειράς και του αντιπάλου του ως τιμή της απαρίθμησης SquareStatus
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

			// Έλεγχος προς κάθε κατεύθυνση και επιστροφή του αποτελέσματος
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
		/// Εκτελεί μία κίνηση σε ένα δοσμένο τετράγωνο.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στην οποία θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="IsWhitesTurn">Λογική τιμή για το εάν είναι τώρα
		/// η σειρά των Λευκών.</param>
		/// <returns>Επιστρέφεται true αν η κίνηση πραγματοποιήθηκε επιτυχώς,
		/// και false διαφορετικά.</returns>
		public bool MakeMove(int row, int col, bool IsWhitesTurn)
		{
			// Έλεγχος αν το τετράγωνο αυτό είναι ελεύθερο
			if(!theBoard[row][col].IsEmpty)
				return false;

			// Εύρεση της "κατάστασης" του παίκτη της τρέχουσας
			// σειράς και του αντιπάλου του ως τιμή της απαρίθμησης SquareStatus
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

			// Τοποθέτηση του πιονιού του παίκτη στο τετράγωνο
			// που επέλεξε
			theBoard[row][col].CurrentStatus = ownStatus;

			// Αναζήτηση στην σκακιέρα και αλλαγή των κομμάτιών
			// του αντιπάλου που πρέπει
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

		#region Μέθοδοι εύρεσης έγκυρης κίνησης προς όλες τις κατευθύνσεις

		/// <summary>
		/// Εξετάζει αν το δοσμένο τετράγωνο είναι έγκυρο για κίνηση,
		/// ελέγχοντας τα πούλια προς τα πάνω. Αν της δωθεί ως παράμετρος,
		/// και είναι έγκυρη η κίνηση, τότε αλλάζει τα πούλια του αντιπάλου
		/// προς τη συγκεκριμένη κατεύθυνση σε πούλια με το το χρώμα
		/// του τρέχοντος παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο  οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="ownStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον τρέχοντα παίκτη.</param>
		/// <param name="enemyStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον αντίπαλο του τρέχοντα παίκτη.</param>
		/// <param name="FlipOpponentsPieces">Λογική τιμή που ορίζει αν θα αντικατασταθούν τα πιόνια
		/// του αντιπάλου με αυτά του τρέχοντος παίκτη, προς τη συγκεκριμένη κατεύθυνση, 
		/// και έχοντας ελέγξει αν είναι έγκυρη η κίνηση.</param>
		/// <returns>Επιστρέφεται true αν είναι έγκυρη η κίνηση προς αυτή
		/// την κατεύθυνση (και αλλάχθηκαν επιτυχώς τα πιόνια του αντιπάλου,
		/// αν αυτό ζητήθηκε),διαφορετικά επιστρέφει false.</returns>
		/// <remarks>Τα ορίσματα ownStatus και enemyStatus είναι τιμές
		/// της απαρίθμησης SquareStatus.</remarks>
		bool ValidateUpwards(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// Μετρητής των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			int counter = 0;
			// Μετρητής που περιέχει τη θέση που ελέγχεται τώρα
			int i = 0;

			// Έλεγχος των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			for(i = row-1; i >= 0; i--)
			{
				// Έλεγχος αν ακολουθεί πούλι του αντιπάλου
				if(theBoard[i][col].CurrentStatus == enemyStatus)
				{
					// Έλεγχος αν φτάσαμε στο τελευταίο κομμάτι της σκακιέρας (το ακριανό)
					if (i == 0)
					{
						// Προφανώς, δεν πρόκειται για έγκυρη κίνηση.
						// Μηδενισμός του μετρητή ώστε να επιστραφεί false.
						counter = 0;
						break;
					}
					else
					{
						// Αύξηση του μετρητή
						counter++;
					}
				}
				else
					break;
			}
			// Έλεγχος αν μετά τα πούλια του αντιπάλου ακολουθεί δικό μας
			if(i < 0 || theBoard[i][col].CurrentStatus != ownStatus)
				counter = 0;
			// Έλεγχος αν πρέπει να αντιστρέψουμε τα πούλια του αντιπάλου
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// Έλεγχος αν υπάρχουν πιόνια για αλλαγή
				{
					for(i = row-1; i >= 0; i--)
					{
						// Έλεγχος αν πρόκειται για πούλι του αντιπάλου
						if(theBoard[i][col].CurrentStatus == enemyStatus)
						{
							// Αντιστροφή του πιονιού
							theBoard[i][col].Flip();
						}
						else
							break;
					}
					// Οι αλλαγές ολοκληρώθηκαν.
					return true;
				}
				else
				{
					// Δεν είναι έγκυρη η κίνηση όσον αφορά αυτή την κατεύθυνση
					return false;
				}
			}
			else
			{
				// Επιστροφή του αποτελέσματος
				return (counter > 0);
			}
		}

		/// <summary>
		/// Εξετάζει αν το δοσμένο τετράγωνο είναι έγκυρο για κίνηση,
		/// ελέγχοντας τα πούλια προς τα κάτω. Αν της δωθεί ως παράμετρος,
		/// και είναι έγκυρη η κίνηση, τότε αλλάζει τα πούλια του αντιπάλου
		/// προς τη συγκεκριμένη κατεύθυνση σε πούλια με το το χρώμα
		/// του τρέχοντος παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="ownStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον τρέχοντα παίκτη.</param>
		/// <param name="enemyStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον αντίπαλο του τρέχοντα παίκτη.</param>
		/// <param name="FlipOpponentsPieces">Λογική τιμή που ορίζει αν θα αντικατασταθούν τα πιόνια
		/// του αντιπάλου με αυτά του τρέχοντος παίκτη, προς τη συγκεκριμένη κατεύθυνση, 
		/// και έχοντας ελέγξει αν είναι έγκυρη η κίνηση.</param>
		/// <returns>Επιστρέφεται true αν είναι έγκυρη η κίνηση προς αυτή
		/// την κατεύθυνση (και αλλάχθηκαν επιτυχώς τα πιόνια του αντιπάλου,
		/// αν αυτό ζητήθηκε), και false διαφορετικά.</returns>
		/// <remarks>Τα ορίσματα ownStatus και enemyStatus είναι τιμές
		/// της απαρίθμησης SquareStatus.</remarks>
		bool ValidateDownwards(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// Μετρητής των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			int counter = 0;
			// Μετρητής που περιέχει τη θέση που ελέγχεται τώρα
			int i = 0;

			// Έλεγχος των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			for(i = row+1; i < theBoard.Length; i++)
			{
				// Έλεγχος αν ακολουθεί πούλι του αντιπάλου
				if(theBoard[i][col].CurrentStatus == enemyStatus)
				{
					// Έλεγχος αν φτάσαμε στο τελευταίο κομμάτι της σκακιέρας (το ακριανό)
					if (i == theBoard.Length-1)
					{
						// Προφανώς, δεν πρόκειται για έγκυρη κίνηση.
						// Μηδενισμός του μετρητή ώστε να επιστραφεί false.
						counter = 0;
						break;
					}
					else
					{
						// Αύξηση του μετρητή
						counter++;
					}
				}
				else
					break;
			}
			
			// Έλεγχος αν μετά τα πούλια του αντιπάλου ακολουθεί δικό μας
			if(i >= theBoard[row].Length || theBoard[i][col].CurrentStatus != ownStatus)
				counter = 0;
			
			// Έλεγχος αν πρέπει να αντιστρέψουμε τα πούλια του αντιπάλου
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// Έλεγχος αν υπάρχουν πιόνια για αλλαγή
				{
					for(i = row+1; i < theBoard.Length; i++)
					{
						// Έλεγχος αν πρόκειται για πούλι του αντιπάλου
						if(theBoard[i][col].CurrentStatus == enemyStatus)
						{
							// Αντιστροφή του πιονιού
							theBoard[i][col].Flip();
						}
						else
							break;
					}
					// Οι αλλαγές ολοκληρώθηκαν.
					return true;
				}
				else
				{
					// Δεν είναι έγκυρη η κίνηση όσον αφορά αυτή την κατεύθυνση
					return false;
				}
			}
			else
			{
				// Επιστροφή του αποτελέσματος
				return (counter > 0);
			}
		}

		/// <summary>
		/// Εξετάζει αν το δοσμένο τετράτωνο είναι έγκυρο για κίνηση,
		/// ελέγχοντας τα πούλια προς τα δεξιά.Αν της δωθεί ως παράμετρος,
		/// και είναι έγκυρη η κίνηση, τότε αλλάζει τα πούλια του αντιπάλου
		/// προς τη συγκεκριμένη κατεύθυνση σε πούλια με το το χρώμα
		/// του τρέχοντος παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="ownStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον τρέχοντα παίκτη.</param>
		/// <param name="enemyStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον αντίπαλο του τρέχοντα παίκτη.</param>
		/// <param name="FlipOpponentsPieces">Λογική τιμή που ορίζει αν θα αντικατασταθούν τα πιόνια
		/// του αντιπάλου με αυτά του τρέχοντος παίκτη, προς τη συγκεκριμένη κατεύθυνση, 
		/// και έχοντας ελέγξει αν είναι έγκυρη η κίνηση.</param>
		/// <returns>Επιστρέφεται true αν είναι έγκυρη η κίνηση προς αυτή
		/// την κατεύθυνση (και αλλάχθηκαν επιτυχώς τα πιόνια του αντιπάλου,
		/// αν αυτό ζητήθηκε), και false διαφορετικά.</returns>
		/// <remarks>Τα ορίσματα ownStatus και enemyStatus είναι τιμές
		/// της απαρίθμησης SquareStatus.</remarks>
		bool ValidateToRight(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// Μετρητής των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			int counter = 0;
			// Μετρητής που περιέχει τη θέση που ελέγχεται τώρα
			int i = 0;

			// Έλεγχος των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			for(i = col+1; i < theBoard[row].Length; i++)
			{
				// Έλεγχος αν ακολουθεί πούλι του αντιπάλου
				if(theBoard[row][i].CurrentStatus == enemyStatus)
				{
					// Έλεγχος αν φτάσαμε στο τελευταίο κομμάτι της σκακιέρας (το ακριανό)
					if (i == theBoard[row].Length-1)
					{
						// Προφανώς, δεν πρόκειται για έγκυρη κίνηση.
						// Μηδενισμός του μετρητή ώστε να επιστραφεί false.
						counter = 0;
						break;
					}
					else
					{
						// Αύξηση του μετρητή
						counter++;
					}
				}
				else
					break;
			}
			// Έλεγχος αν μετά τα πούλια του αντιπάλου ακολουθεί δικό μας
			if(i >= theBoard[row].Length || theBoard[row][i].CurrentStatus != ownStatus)
				counter = 0;
			// Έλεγχος αν πρέπει να αντιστρέψουμε τα πούλια του αντιπάλου
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// Έλεγχος αν υπάρχουν πιόνια για αλλαγή
				{
					for(i = col+1; i < theBoard[row].Length; i++)
					{
						// Έλεγχος αν πρόκειται για πούλι του αντιπάλου
						if(theBoard[row][i].CurrentStatus == enemyStatus)
						{
							// Αντιστροφή του πιονιού
							theBoard[row][i].Flip();
						}
						else
							break;
					}
					// Οι αλλαγές ολοκληρώθηκαν.
					return true;
				}
				else
				{
					// Δεν είναι έγκυρη η κίνηση όσον αφορά αυτή την κατεύθυνση
					return false;
				}
			}
			else
			{
				// Επιστροφή του αποτελέσματος
				return (counter > 0);
			}
		}

		/// <summary>
		/// Εξετάζει αν το δοσμένο τετράγωνο είναι έγκυρο για κίνηση,
		/// ελέγχοντας τα πούλια προς τα αριστερά. Αν της δωθεί ως παράμετρος,
		/// και είναι έγκυρη η κίνηση, τότε αλλάζει τα πούλια του αντιπάλου
		/// προς τη συγκεκριμένη κατεύθυνση σε πούλια με το το χρώμα
		/// του τρέχοντος παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="ownStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον τρέχοντα παίκτη.</param>
		/// <param name="enemyStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον αντίπαλο του τρέχοντα παίκτη.</param>
		/// <param name="FlipOpponentsPieces">Λογική τιμή που ορίζει αν θα αντικατασταθούν τα πιόνια
		/// του αντιπάλου με αυτά του τρέχοντος παίκτη, προς τη συγκεκριμένη κατεύθυνση, 
		/// και έχοντας ελέγξει αν είναι έγκυρη η κίνηση.</param>
		/// <returns>Επιστρέφεται true αν είναι έγκυρη η κίνηση προς αυτή
		/// την κατεύθυνση (και αλλάχθηκαν επιτυχώς τα πιόνια του αντιπάλου,
		/// αν αυτό ζητήθηκε), και false διαφορετικά.</returns>
		/// <remarks>Τα ορίσματα ownStatus και enemyStatus είναι τιμές
		/// της απαρίθμησης SquareStatus.</remarks>
		bool ValidateToLeft(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// Μετρητής των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			int counter = 0;
			// Μετρητής που περιέχει τη θέση που ελέγχεται τώρα
			int i = 0;

			// Έλεγχος των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			for(i = col-1; i >= 0; i--)
			{
				// Έλεγχος αν ακολουθεί πούλι του αντιπάλου
				if(theBoard[row][i].CurrentStatus == enemyStatus)
				{
					// Έλεγχος αν φτάσαμε στο τελευταίο κομμάτι της σκακιέρας (το ακριανό)
					if (i == 0)
					{
						// Προφανώς, δεν πρόκειται για έγκυρη κίνηση.
						// Μηδενισμός του μετρητή ώστε να επιστραφεί false.
						counter = 0;
						break;
					}
					else
					{
						// Αύξηση του μετρητή
						counter++;
					}
				}
				else
					break;
			}
			// Έλεγχος αν μετά τα πούλια του αντιπάλου ακολουθεί δικό μας
			if(i < 0 || theBoard[row][i].CurrentStatus != ownStatus)
				counter = 0;
			// Έλεγχος αν πρέπει να αντιστρέψουμε τα πούλια του αντιπάλου
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// Έλεγχος αν υπάρχουν πιόνια για αλλαγή
				{
					for(i = col -1; i >=0 ; i--)
					{
						// Έλεγχος αν πρόκειται για πούλι του αντιπάλου
						if(theBoard[row][i].CurrentStatus == enemyStatus)
						{
							// Αντιστροφή του πιονιού
							theBoard[row][i].Flip();
						}
						else
							break;
					}
					// Οι αλλαγές ολοκληρώθηκαν.
					return true;
				}
				else
				{
					// Δεν είναι έγκυρη η κίνηση όσον αφορά αυτή την κατεύθυνση
					return false;
				}
			}
			else
			{
				// Επιστροφή του αποτελέσματος
				return (counter > 0);
			}
		}

		/// <summary>
		/// Εξετάζει αν το δοσμένο τετράγωνο είναι έγκυρο για κίνηση,
		/// ελέγχοντας τα πούλια προς τα κάτω-δεξιά (διαγώνια). 
		/// Αν της δωθεί ως παράμετρος, και είναι έγκυρη η κίνηση, 
		/// αλλάζει τα πούλια του αντιπάλου προς την κατεύθυνση
		/// αυτή σε αυτά του παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="ownStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον τρέχοντα παίκτη.</param>
		/// <param name="enemyStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον αντίπαλο του τρέχοντα παίκτη.</param>
		/// <param name="FlipOpponentsPieces">Λογική τιμή που ορίζει αν θα αντικατασταθούν τα πιόνια
		/// του αντιπάλου με αυτά του τρέχοντος παίκτη, προς τη συγκεκριμένη κατεύθυνση, 
		/// και έχοντας ελέγξει αν είναι έγκυρη η κίνηση.</param>
		/// <returns>Επιστρέφεται true αν είναι έγκυρη η κίνηση προς αυτή
		/// την κατεύθυνση (και αλλάχθηκαν επιτυχώς τα πιόνια του αντιπάλου,
		/// αν αυτό ζητήθηκε), και false διαφορετικά.</returns>
		/// <remarks>Τα ορίσματα ownStatus και enemyStatus είναι τιμές
		/// της απαρίθμησης SquareStatus.</remarks>
		bool ValidateToDownRight(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// Μετρητής των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			int counter = 0;
			// Μετρητές που περιέχουν τη θέση που ελέγχεται τώρα
			int i = 0;
			int j = 0;

			// Έλεγχος των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			for(i = row+1, j = col+1; i < theBoard.Length && j < theBoard[i].Length; i++, j++)
			{
				// Έλεγχος αν ακολουθεί πούλι του αντιπάλου
				if(theBoard[i][j].CurrentStatus == enemyStatus)
				{
					// Έλεγχος αν φτάσαμε στο τελευταίο κομμάτι της σκακιέρας (το ακριανό)
					if (i == theBoard.Length-1 || j == theBoard[i].Length-1)
					{
						// Προφανώς, δεν πρόκειται για έγκυρη κίνηση.
						// Μηδενισμός του μετρητή ώστε να επιστραφεί false.
						counter = 0;
						break;
					}
					else
					{
						// Αύξηση του μετρητή
						counter++;
					}
				}
				else
					break;
			}
			// Έλεγχος αν μετά τα πούλια του αντιπάλου ακολουθεί δικό μας
			if(i >= theBoard.Length || j >= theBoard[i].Length || theBoard[i][j].CurrentStatus != ownStatus)
				counter = 0;
			// Έλεγχος αν πρέπει να αντιστρέψουμε τα πούλια του αντιπάλου
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// Έλεγχος αν υπάρχουν πιόνια για αλλαγή
				{
					for(i = row+1, j = col+1; i < theBoard.Length && j < theBoard[i].Length; i++, j++)
					{
						// Έλεγχος αν πρόκειται για πούλι του αντιπάλου
						if(theBoard[i][j].CurrentStatus == enemyStatus)
						{
							// Αντιστροφή του πιονιού
							theBoard[i][j].Flip();
						}
						else
							break;
					}
					// Οι αλλαγές ολοκληρώθηκαν.
					return true;
				}
				else
				{
					// Δεν είναι έγκυρη η κίνηση όσον αφορά αυτή την κατεύθυνση
					return false;
				}
			}
			else
			{
				// Επιστροφή του αποτελέσματος
				return (counter > 0);
			}
		}

		/// <summary>
		/// Εξετάζει αν το δοσμένο τετράγωνο είναι έγκυρο για κίνηση,
		/// ελέγχοντας τα πούλια προς τα πάνω-αριστερά (διαγώνια). 
		/// Αν της δωθεί ως παράμετρος, και είναι έγκυρη η κίνηση, 
		/// αλλάζει τα πούλια του αντιπάλου προς την κατεύθυνση
		/// αυτή σε αυτά του παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="ownStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον τρέχοντα παίκτη.</param>
		/// <param name="enemyStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον αντίπαλο του τρέχοντα παίκτη.</param>
		/// <param name="FlipOpponentsPieces">Λογική τιμή που ορίζει αν θα αντικατασταθούν τα πιόνια
		/// του αντιπάλου με αυτά του τρέχοντος παίκτη, προς τη συγκεκριμένη κατεύθυνση, 
		/// και έχοντας ελέγξει αν είναι έγκυρη η κίνηση.</param>
		/// <returns>Επιστρέφεται true αν είναι έγκυρη η κίνηση προς αυτή
		/// την κατεύθυνση (και αλλάχθηκαν επιτυχώς τα πιόνια του αντιπάλου,
		/// αν αυτό ζητήθηκε), και false διαφορετικά.</returns>
		/// <remarks>Τα ορίσματα ownStatus και enemyStatus είναι τιμές
		/// της απαρίθμησης SquareStatus.</remarks>
		bool ValidateToUpLeft(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// Μετρητής των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			int counter = 0;
			// Μετρητές που περιέχουν τη θέση που ελέγχεται τώρα
			int i = 0;
			int j = 0;

			// Έλεγχος των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			for(i = row-1, j = col-1; i >= 0 && j >= 0; i--, j--)
			{
				// Έλεγχος αν ακολουθεί πούλι του αντιπάλου
				if(theBoard[i][j].CurrentStatus == enemyStatus)
				{
					// Έλεγχος αν φτάσαμε στο τελευταίο κομμάτι της σκακιέρας (το ακριανό)
					if (i == 0 || j == 0)
					{
						// Προφανώς, δεν πρόκειται για έγκυρη κίνηση.
						// Μηδενισμός του μετρητή ώστε να επιστραφεί false.
						counter = 0;
						break;
					}
					else
					{
						// Αύξηση του μετρητή
						counter++;
					}
				}
				else
					break;
			}
			// Έλεγχος αν μετά τα πούλια του αντιπάλου ακολουθεί δικό μας
			if(i < 0 || j < 0 || theBoard[i][j].CurrentStatus != ownStatus)
				counter = 0;
			// Έλεγχος αν πρέπει να αντιστρέψουμε τα πούλια του αντιπάλου
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// Έλεγχος αν υπάρχουν πιόνια για αλλαγή
				{
					for(i = row-1, j = col-1; i >=0 && j >=0; i--, j--)
					{
						// Έλεγχος αν πρόκειται για πούλι του αντιπάλου
						if(theBoard[i][j].CurrentStatus == enemyStatus)
						{
							// Αντιστροφή του πιονιού
							theBoard[i][j].Flip();
						}
						else
							break;
					}
					// Οι αλλαγές ολοκληρώθηκαν.
					return true;
				}
				else
				{
					// Δεν είναι έγκυρη η κίνηση όσον αφορά αυτή την κατεύθυνση
					return false;
				}
			}
			else
			{
				// Επιστροφή του αποτελέσματος
				return (counter > 0);
			}
		}

		/// <summary>
		/// Εξετάζει αν το δοσμένο τετράγωνο είναι έγκυρο για κίνηση,
		/// ελέγχοντας τα πούλια προς τα πάνω-δεξιά (διαγώνια). 
		/// Αν της δωθεί ως παράμετρος, και είναι έγκυρη η κίνηση, 
		/// αλλάζει τα πούλια του αντιπάλου προς την κατεύθυνση
		/// αυτή σε αυτά του παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="ownStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον τρέχοντα παίκτη.</param>
		/// <param name="enemyStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον αντίπαλο του τρέχοντα παίκτη.</param>
		/// <param name="FlipOpponentsPieces">Λογική τιμή που ορίζει αν θα αντικατασταθούν τα πιόνια
		/// του αντιπάλου με αυτά του τρέχοντος παίκτη, προς τη συγκεκριμένη κατεύθυνση, 
		/// και έχοντας ελέγξει αν είναι έγκυρη η κίνηση.</param>
		/// <returns>Επιστρέφεται true αν είναι έγκυρη η κίνηση προς αυτή
		/// την κατεύθυνση (και αλλάχθηκαν επιτυχώς τα πιόνια του αντιπάλου,
		/// αν αυτό ζητήθηκε), και false διαφορετικά.</returns>
		/// <remarks>Τα ορίσματα ownStatus και enemyStatus είναι τιμές
		/// της απαρίθμησης SquareStatus.</remarks>
		bool ValidateToUpRight(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// Μετρητής των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			int counter = 0;
			// Μετρητές που περιέχουν τη θέση που ελέγχεται τώρα
			int i = 0;
			int j = 0;

			// Έλεγχος των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			for(i = row-1, j = col+1; i >=0 && j < theBoard[i].Length; i--, j++)
			{
				// Έλεγχος αν ακολουθεί πούλι του αντιπάλου
				if(theBoard[i][j].CurrentStatus == enemyStatus)
				{
					// Έλεγχος αν φτάσαμε στο τελευταίο κομμάτι της σκακιέρας (το ακριανό)
					if (i == 0 || j == theBoard[i].Length-1)
					{
						// Προφανώς, δεν πρόκειται για έγκυρη κίνηση.
						// Μηδενισμός του μετρητή ώστε να επιστραφεί false.
						counter = 0;
						break;
					}
					else
					{
						// Αύξηση του μετρητή
						counter++;
					}
				}
				else
					break;
			}
			// Έλεγχος αν μετά τα πούλια του αντιπάλου ακολουθεί δικό μας
			if(i < 0 || j >= theBoard[i].Length || theBoard[i][j].CurrentStatus != ownStatus)
				counter = 0;
			// Έλεγχος αν πρέπει να αντιστρέψουμε τα πούλια του αντιπάλου
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// Έλεγχος αν υπάρχουν πιόνια για αλλαγή
				{
					for(i = row-1, j = col+1; i >=0 && j < theBoard[i].Length; i--, j++)
					{
						// Έλεγχος αν πρόκειται για πούλι του αντιπάλου
						if(theBoard[i][j].CurrentStatus == enemyStatus)
						{
							// Αντιστροφή του πιονιού
							theBoard[i][j].Flip();
						}
						else
							break;
					}
					// Οι αλλαγές ολοκληρώθηκαν.
					return true;
				}
				else
				{
					// Δεν είναι έγκυρη η κίνηση όσον αφορά αυτή την κατεύθυνση
					return false;
				}
			}
			else
			{
				// Επιστροφή του αποτελέσματος
				return (counter > 0);
			}
		}

		/// <summary>
		/// Εξετάζει αν το δοσμένο τετράωνο είναι έγκυρο για κίνηση,
		/// ελέγχοντας τα πούλια προς τα κάτω-αριστερά (διαγώνια). 
		/// Αν της δωθεί ως παράμετρος, και είναι έγκυρη η κίνηση, 
		/// αλλάζει τα πούλια του αντιπάλου προς την κατεύθυνση
		/// αυτή σε αυτά του παίκτη.
		/// </summary>
		/// <param name="row">Η γραμμή του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="col">Η στήλη του τετραγώνου στο οποίο θέλει
		/// να εκτελέσει την κίνησή του ο παίκτης.</param>
		/// <param name="ownStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον τρέχοντα παίκτη.</param>
		/// <param name="enemyStatus">Η τιμή της SquareStatus που αντιστοιχεί
		/// στον αντίπαλο του τρέχοντα παίκτη.</param>
		/// <param name="FlipOpponentsPieces">Λογική τιμή που ορίζει αν θα αντικατασταθούν τα πιόνια
		/// του αντιπάλου με αυτά του τρέχοντος παίκτη, προς τη συγκεκριμένη κατεύθυνση, 
		/// και έχοντας ελέγξει αν είναι έγκυρη η κίνηση.</param>
		/// <returns>Επιστρέφεται true αν είναι έγκυρη η κίνηση προς αυτή
		/// την κατεύθυνση (και αλλάχθηκαν επιτυχώς τα πιόνια του αντιπάλου,
		/// αν αυτό ζητήθηκε), και false διαφορετικά.</returns>
		/// <remarks>Τα ορίσματα ownStatus και enemyStatus είναι τιμές
		/// της απαρίθμησης SquareStatus.</remarks>
		bool ValidateToDownLeft(int row, int col, SquareStatus ownStatus, SquareStatus enemyStatus, bool FlipOpponentsPieces)
		{
			// Μετρητής των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			int counter = 0;
			// Μετρητές που περιέχουν τη θέση που ελέγχεται τώρα
			int i = 0;
			int j = 0;

			// Έλεγχος των πιονιών του αντιπάλου προς αυτή την κατεύθυνση
			for(i = row+1, j = col-1; i < theBoard.Length && j >=0; i++, j--)
			{
				// Έλεγχος αν ακολουθεί πούλι του αντιπάλου
				if(theBoard[i][j].CurrentStatus == enemyStatus)
				{
					// Έλεγχος αν φτάσαμε στο τελευταίο κομμάτι της σκακιέρας (το ακριανό)
					if (i == theBoard.Length-1 || j == 0)
					{
						// Προφανώς, δεν πρόκειται για έγκυρη κίνηση.
						// Μηδενισμός του μετρητή ώστε να επιστραφεί false.
						counter = 0;
						break;
					}
					else
					{
						// Αύξηση του μετρητή
						counter++;
					}
				}
				else
					break;
			}
			// Έλεγχος αν μετά τα πούλια του αντιπάλου ακολουθεί δικό μας
			if(i >=  theBoard.Length || j < 0 || theBoard[i][j].CurrentStatus != ownStatus)
				counter = 0;
			// Έλεγχος αν πρέπει να αντιστρέψουμε τα πούλια του αντιπάλου
			if(FlipOpponentsPieces)
			{
				if(counter > 0)	// Έλεγχος αν υπάρχουν πιόνια για αλλαγή
				{
					for(i = row+1, j = col-1; i < theBoard.Length && j >=0; i++, j--)
					{
						// Έλεγχος αν πρόκειται για πούλι του αντιπάλου
						if(theBoard[i][j].CurrentStatus == enemyStatus)
						{
							// Αντιστροφή του πιονιού
							theBoard[i][j].Flip();
						}
						else
							break;
					}
					// Οι αλλαγές ολοκληρώθηκαν.
					return true;
				}
				else
				{
					// Δεν είναι έγκυρη η κίνηση όσον αφορά αυτή την κατεύθυνση
					return false;
				}
			}
			else
			{
				// Επιστροφή του αποτελέσματος
				return (counter > 0);
			}
		}

		#endregion

		/// <summary>
		/// Επιστρέφει το πλήθος των κομματιών των Μαύρων.
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
		/// Επιστρέφει το πλήθος των κομματιών των Λευκών.
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
		/// Ελέγχει αν η σκακιέρα είναι γεμάτη (δηλ. δεν υπάρχει
		/// κανένα άδειο ή "πιθανό" τετράγωνο) ή όχι.
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
