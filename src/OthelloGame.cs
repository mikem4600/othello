using System;

namespace Othello
{
	// Τύποι delegate για την σύνδεση ειδοποίησεων (γεγονότων).
	public delegate void TurnChangedEventHandler(object sender, EventArgs e);
	public delegate void ScoreChangedEventHandler(object sender, EventArgs e);
	public delegate void NoValidMovesEventHandler(object sender, EventArgs e);
	public delegate void GameOverEventHandler(object sender, EventArgs e);

	/// <summary>
	/// Δομή που περιλαμβάνει τα χαρακτηριστικά μίας κίνησης
	/// της τεχνιτής νοημοσύνης.
	/// </summary>
	struct OthelloMove
	{
		/// <summary>
		/// Η γραμμή της κίνησης
		/// </summary>
		public int Row;
		/// <summary>
		/// Η στήλη της κίνησης
		/// </summary>
		public int Column;
		/// <summary>
		/// Η αξία της κίνησης
		/// </summary>
		public int Value;
	}

	/// <summary>
	/// Η τάξη αυτή ενθυλακώνει όλες τις μεταβλητές και μεθόδους που χρειάζονται
	/// για κάθε παιχνίδι (παρτίδα) Othello.
	/// </summary>
	public class OthelloGame
	{
		/// <summary>
		/// Μεταβλητή - μέλος που αποθηκεύει το χρώμα του παίκτη - ανθρώπου
		/// (δηλ. αν ο άνθρωπος έχει τα Λευκά ή όχι).
		/// </summary>
		bool HumanIsWhite;
		/// <summary>
		/// Μεταβλητή - μέλος που αποθηκεύει την τρέχουσα σειρά
		/// (δηλ. τα Λευκά έχουν σειρά τώρα ή όχι).
		/// </summary>
		bool IsWhitesTurn;
		/// <summary>
		/// Μεταβλητή - μέλος που αναφέρεται στην τρέχουσα σκακιέρα
		/// του παιχνιδιού.
		/// </summary>
		OthelloBoard theBoard;
		///<summαry>
		/// Πίνακας όπου αποθηκεύεται η αξία των τετραγώνων της σκακιέρας για να 
		/// χρησιμοποιηθούν στην ευριστική συνάρτηση.
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
		///<summαry>
		/// Το μέγιστο βάθος που θα γίνεται αναζήτηση
		/// στο δέντρο του αλγορίθμου Α-Β.
		///</summary>
		int level;
		///<summαry>
		/// Μετρητής για το πλήθος των φορών που καλείται
		/// η μέθοδος Α-Β για κάθε κίνηση του υπολογιστή.
		/// (debug)
		///</summary>
		int counter;

		/// <summary>
		/// Ένα γεγονός που χρησιμοποιείται για την ειδοποίηση
		/// όταν αλλάζει η σειρά.
		/// </summary>
		public event TurnChangedEventHandler TurnChanged;
		/// <summary>
		/// Ένα γεγονός που χρησιμοποιείται για την ειδοποίηση
		/// όταν αλλάζει η βαθμολογία.
		/// </summary>
		public event ScoreChangedEventHandler ScoreChanged;
		/// <summary>
		/// Ένα γεγονός που χρησιμοποιείται για την ειδοποίηση
		/// όταν δεν υπάρχουν δυνατές κινήσεις για τον τρέχοντα παίκτη.
		/// </summary>
		public event NoValidMovesEventHandler NoValidMoves;
		/// <summary>
		/// Ένα γεγονός που χρησιμοποιείται για την ειδοποίηση
		/// όταν ικανοποιηθούν τα κριτήρια τερματισμού του παιχνιδιού.
		/// </summary>
		public event GameOverEventHandler GameOver;

		/// <summary>
		/// Ο κατασκευαστής της τάξης.
		/// </summary>
		/// <param name="IsHumanWhite">Λογική τιμή για το αν ο άνθρωπος - παίκτης
		/// έχει τα Λευκά.</param>
		/// <param name="WhitesTurn">Λογική τιμή για το αν τα Λευκά έχουν τώρα σειρά.</param>
		/// <param name="Board">Αναφορά προς τον αρχικό πίνακα της σκακιέρας.</param>
		public OthelloGame(bool IsHumanWhite, bool WhitesTurn, IOthelloSquare[][] Board, int theLevel)
		{
			// Αποθήκευση των μεταβλητών
			HumanIsWhite = IsHumanWhite;
			IsWhitesTurn = WhitesTurn;
			level = theLevel;

			// Δημιουργία νέας σκακιέρας με βάση τον πίνακα που μας δώθηκε
			theBoard = new OthelloBoard(Board);
			// Εμφάνιση των πιθανών κινήσεων του τρέχοντος παίκτη
			theBoard.MarkPossibleMoves(IsWhitesTurn);
		}

		/// <summary>
		/// Επιστρέφει ή θέτει αν τώρα παίζουν τα Λευκά.
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
		/// Επιστρέφει τη βαθμολογία των Μαύρων.
		/// </summary>
		public int BlackScore
		{
			get
			{
				return theBoard.BlackPieces;
			}
		}

		/// <summary>
		/// Επιστρέφει τη βαθμολογία των Λευκών.
		/// </summary>
		public int WhiteScore
		{
			get
			{
				return theBoard.WhitePieces;
			}
		}

		/// <summary>
		/// Επεξεργάζεται μία κίνηση του παίκτη - ανθρώπου.
		/// </summary>
		/// <param name="row">Η γραμμή που επέλεξε ο παίκτης (μετρώντας από το 0).</param>
		/// <param name="col">Η στήλη που επέλεξε ο παίκτης (μετρώντας από το 0).</param>
		/// <returns>Επιστρέφεται true αν η κίνηση ήταν έγκυρη και επιτυχής
		/// και false διαφορετικά.</returns>
		public bool ProcessMove(int row, int col)
		{
			// Έλεγχος εγκυρότητας της κίνησης
			if (!theBoard.IsValidMove(row, col, IsWhitesTurn))
				return false;
			else
				// Εκτέλεση της κίνησης
				theBoard.MakeMove(row, col, IsWhitesTurn);

			// debug
			System.Console.WriteLine("Inserting at " + row + " " + col);
			// Ειδοποίηση για την αλλαγή της βαθμολογίας
			if(ScoreChanged != null) ScoreChanged(this, EventArgs.Empty);
			IsWhitesTurn = !IsWhitesTurn;	// Αλλαγή της σειράς
						

			// Ειδοποίηση για την (πιθανή) αλλαγή της σειράς
			if(TurnChanged != null) TurnChanged(this, EventArgs.Empty);

			// Έλεγχος και ειδοποίηση αν ικανοποιούνται τα κριτήρια λήξης του παιχνιδιού
			if(theBoard.BoardFull || theBoard.WhitePieces == 0 || theBoard.BlackPieces == 0 || (!theBoard.ValidMovesExist(true) &&  !theBoard.ValidMovesExist(false)))
				if(GameOver != null) GameOver(this, EventArgs.Empty);

			return true;
		}

		/// <summary>
		/// Εκτελεί μια ελεγχόμενη από τον υπολογιστή κίνηση, με τα πούλια που του 
		/// αντιστοιχούν τη δεδομένη χρονική στιγμή.
		/// </summary>
		/// <param name="board">Η σκακιέρα πάνω στην οποία παίζει τώρα ο παίκτης.</param>
		public void MakeComputerMove()
		{
			if(!theBoard.BoardFull && !theBoard.ValidMovesExist(IsWhitesTurn))
			{

				// Ειδοποίηση για το γεγονός
				if(NoValidMoves != null) NoValidMoves(this, EventArgs.Empty);
				// Ειδοποίηση για την αλλαγή της βαθμολογίας
				if(ScoreChanged != null) ScoreChanged(this, EventArgs.Empty);
				// Αλλαγή ξανά της σειράς
				IsWhitesTurn = !IsWhitesTurn;
				// Ειδοποίηση για την αλλαγή της σειράς
				if(TurnChanged != null) TurnChanged(this, EventArgs.Empty);

				// Εμφάνιση έγκυρων κινήσεων του νέου παίκτη
				theBoard.MarkPossibleMoves(IsWhitesTurn);

				// Έλεγχος και ειδοποίηση αν ικανοποιούνται τα κριτήρια λήξης του παιχνιδιού
				if(theBoard.BoardFull || theBoard.WhitePieces == 0 || theBoard.BlackPieces == 0 || (!theBoard.ValidMovesExist(true) &&  !theBoard.ValidMovesExist(false)))
					if(GameOver != null) GameOver(this, EventArgs.Empty);

				return;
			}

			// debug
			System.Console.WriteLine("Starting AlphaBeta");
			counter = 0;

			// Εύρεση της καλύτερης δυνατής κίνησης με βάση την
			// ευριστική συνάρτηση και τον αλγόριθμο Α-Β.
			OthelloMove move = AlphaBeta(theBoard, System.Int32.MinValue, System.Int32.MaxValue, level, IsWhitesTurn);

			// debug
			System.Console.WriteLine("Alphabeta: " + counter);
			System.Console.WriteLine("Finished AlphaBeta");

			// Εκτέλεση της κίνησης που βρέθηκε
			ProcessMove(move.Row, move.Column);

			// Έλεγχος αν υπάρχουν κινήσεις για τον νέο παίκτη
			if(!theBoard.BoardFull && !theBoard.ValidMovesExist(IsWhitesTurn))
			{
				// Αλλαγή της σειράς
				IsWhitesTurn = !IsWhitesTurn;
				// Ειδοποίηση για το γεγονός
				if(NoValidMoves != null) NoValidMoves(this, EventArgs.Empty);
				// Παίζει ο επόμενος παίκτης
				MakeComputerMove();
			}
			else
			{
				// Εμφάνιση έγκυρων κινήσεων του νέου παίκτη
				theBoard.MarkPossibleMoves(IsWhitesTurn);
			}

			// Ειδοποίηση για την αλλαγή της βαθμολογίας
			if(ScoreChanged != null) ScoreChanged(this, EventArgs.Empty);
			// Ειδοποίηση για την (πιθανή) αλλαγή της σειράς
			if(TurnChanged != null) TurnChanged(this, EventArgs.Empty);

			// Έλεγχος και ειδοποίηση αν ικανοποιούνται τα κριτήρια λήξης του παιχνιδιού
			if(theBoard.BoardFull || theBoard.WhitePieces == 0 || theBoard.BlackPieces == 0 || (!theBoard.ValidMovesExist(true) &&  !theBoard.ValidMovesExist(false)))
				if(GameOver != null) GameOver(this, EventArgs.Empty);
		}

		/// <summary>
		/// Υλοποιεί τη μέθοδο μεσω της οποίας θα επιλέγει ο υπολογιστής την επόμενη
		/// κίνηση του με βάση τον αλγόριθμο Α-Β.
		/// </summary>
		/// <param name="board">Η σκακιέρα στην οποία θα ψάχνει την επόμενη κίνηση.</param>
		/// <param name="alpha">Η μέγιστη αξία που μπορεί να έχει ένα τετράγωνο
		/// της σκακιέρας.</param>
		/// <param name="beta">Η ελάχιστη αξία που μπορεί να έχει ένα τετράγωνο
		/// της σκακιέρας.</param>
		/// <param name="depth">Το επίπεδου του δένδρου μέχρι το οποίο πρέπει
		/// να ψάξει η συνάρτηση.</param>
		/// <param name="maximumPlays">Έλεγχος αν παίζει τώρα ο παίκτης Max.</param>
		/// <returns>Επιστρέφει την καλύτερη κίνηση.</returns>
		OthelloMove AlphaBeta(OthelloBoard board, int alpha, int beta, int depth, bool maximumPlays)
		{
			// Αύξηση του μετρητή (debug)
			counter++;

			// Η καλύτερη κίνηση
			OthelloMove move;
			move.Row = 0;
			move.Column = 0;
			
			// Έλεγχος αν έχουμε φύγει από τα φύλλα
			// ή αν δεν υπάρχουν δυνατές κινήσεις
			if(depth == 0 || !board.ValidMovesExist(maximumPlays))
			{
				// Επιστροφή της τιμής της σκακιέρας
				move.Value = EvaluateBoard(board);
				return move;
			}

			// Έλεγχος κάθε τετραγώνου της σκακιέρας
			for(int row = 0; row < 8; row++)
			{
				for(int col = 0; col < 8; col++)
				{
					// Έλεγχος αν πρόκειται για έγκυρη κίνηση
					if(board.IsValidMove(board.Square(row,col).Row, board.Square(row,col).Column, maximumPlays))
					{
						// Δημιουργία νέας (εικονικής) σκακιέρας
						// και εκτέλεση της κίνησης
						OthelloBoard testBoard = new OthelloBoard(board);
						testBoard.MakeMove(board.Square(row,col).Row, board.Square(row,col).Column, maximumPlays);
						OthelloMove currentMove = AlphaBeta(testBoard, alpha, beta, depth-1, !maximumPlays);

						if(maximumPlays)	// Έλεγχος αν παίζει ο Max
						{
							// Έλεγχος αν η τιμή που βρέθηκε είναι μεγαλύτερη
							// από την τιμή άλφα
							if(currentMove.Value > alpha)
							{
								alpha = currentMove.Value;
								move.Row = board.Square(row,col).Row;
								move.Column = board.Square(row,col).Column;
							}
							// Έλεγχος αν η τιμή άλφα είναι
							// μεγαλύτερη από την τιμή βήτα
							// (οπότε και παρακάμπτουμε κόμβους)
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
							// Έλεγχος αν η τιμή που βρέθηκε είναι μικρότερη
							// από την τιμή βήτα
							if(currentMove.Value < beta)
							{
								beta = currentMove.Value;
								move.Row = board.Square(row,col).Row;
								move.Column = board.Square(row,col).Column;
							}
							// Έλεγχος αν η τιμή άλφα είναι
							// μεγαλύτερη από την τιμή βήτα
							// (οπότε και παρακάμπτουμε κόμβους)
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

			// Επιστροφή της ακραίας τιμής
			if(maximumPlays)
				move.Value = alpha;
			else
				move.Value = beta;
			return move;
		}
		
		/// <summary>
		/// Αποτελεί την ευριστική Συνάρτηση. Βασει του πίνακα squareWeight (όπου έχουμε
		/// δώσει κάποια τιμή σε κάθε τετράγωνο της σκακιέρας)υπολόγίζουμε την αξία των
		/// κινήσεων του Ανθρώπου-παίκτη και του Υπολογιστή-παίκτη.  
		/// </summary>
		/// <param name="theBoard">Η τρέχουσα σκακιέρα.</param>
		/// <returns>Επιστρέφει την αξία της τρέχουσας σκακιέρας.</returns>
		int EvaluateBoard(OthelloBoard theBoard)
		{
			// Η τιμή της σκακιέρας
			int value = 0;
			
			// Έλεγχος κάθε τετραγώνου
			for(int row = 0; row < 8; row++)
			{
				for(int col = 0; col < 8; col++)
				{
					// Έλεγχος των περιεχομένων του τετραγώνου
					// και προσθαφαίρεση της αντίστοιχης τιμής
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