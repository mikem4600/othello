using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Othello
{
	/// <summary>
	/// Η τάξη αυτή περιέχει την κυρίως φόρμα και το 
	/// σημείο εκκίνησης (entry point) της εφαρμογής.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{

		#region Στοιχεία ελέγχου

		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuHelpAbout;
		private System.Windows.Forms.MenuItem mnuNewGame;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem mnuExit;
		private Othello.OthelloSquareControl SquareControl11;
		private Othello.OthelloSquareControl SquareControl12;
		private Othello.OthelloSquareControl SquareControl13;
		private Othello.OthelloSquareControl SquareControl14;
		private Othello.OthelloSquareControl SquareControl15;
		private Othello.OthelloSquareControl SquareControl16;
		private Othello.OthelloSquareControl SquareControl17;
		private Othello.OthelloSquareControl SquareControl18;
		private Othello.OthelloSquareControl SquareControl21;
		private Othello.OthelloSquareControl SquareControl22;
		private Othello.OthelloSquareControl SquareControl23;
		private Othello.OthelloSquareControl SquareControl24;
		private Othello.OthelloSquareControl SquareControl25;
		private Othello.OthelloSquareControl SquareControl26;
		private Othello.OthelloSquareControl SquareControl27;
		private Othello.OthelloSquareControl SquareControl28;
		private Othello.OthelloSquareControl SquareControl31;
		private Othello.OthelloSquareControl SquareControl32;
		private Othello.OthelloSquareControl SquareControl33;
		private Othello.OthelloSquareControl SquareControl34;
		private Othello.OthelloSquareControl SquareControl35;
		private Othello.OthelloSquareControl SquareControl36;
		private Othello.OthelloSquareControl SquareControl37;
		private Othello.OthelloSquareControl SquareControl38;
		private Othello.OthelloSquareControl SquareControl41;
		private Othello.OthelloSquareControl SquareControl42;
		private Othello.OthelloSquareControl SquareControl43;
		private Othello.OthelloSquareControl SquareControl44;
		private Othello.OthelloSquareControl SquareControl45;
		private Othello.OthelloSquareControl SquareControl46;
		private Othello.OthelloSquareControl SquareControl47;
		private Othello.OthelloSquareControl SquareControl48;
		private Othello.OthelloSquareControl SquareControl51;
		private Othello.OthelloSquareControl SquareControl52;
		private Othello.OthelloSquareControl SquareControl53;
		private Othello.OthelloSquareControl SquareControl54;
		private Othello.OthelloSquareControl SquareControl55;
		private Othello.OthelloSquareControl SquareControl56;
		private Othello.OthelloSquareControl SquareControl57;
		private Othello.OthelloSquareControl SquareControl58;
		private Othello.OthelloSquareControl SquareControl61;
		private Othello.OthelloSquareControl SquareControl62;
		private Othello.OthelloSquareControl SquareControl63;
		private Othello.OthelloSquareControl SquareControl64;
		private Othello.OthelloSquareControl SquareControl65;
		private Othello.OthelloSquareControl SquareControl66;
		private Othello.OthelloSquareControl SquareControl67;
		private Othello.OthelloSquareControl SquareControl68;
		private Othello.OthelloSquareControl SquareControl71;
		private Othello.OthelloSquareControl SquareControl72;
		private Othello.OthelloSquareControl SquareControl73;
		private Othello.OthelloSquareControl SquareControl74;
		private Othello.OthelloSquareControl SquareControl75;
		private Othello.OthelloSquareControl SquareControl76;
		private Othello.OthelloSquareControl SquareControl77;
		private Othello.OthelloSquareControl SquareControl78;
		private Othello.OthelloSquareControl SquareControl81;
		private Othello.OthelloSquareControl SquareControl82;
		private Othello.OthelloSquareControl SquareControl83;
		private Othello.OthelloSquareControl SquareControl84;
		private Othello.OthelloSquareControl SquareControl85;
		private Othello.OthelloSquareControl SquareControl86;
		private Othello.OthelloSquareControl SquareControl87;
		private Othello.OthelloSquareControl SquareControl88;
		private System.Windows.Forms.Label lblA;
		private System.Windows.Forms.Label lblB;
		private System.Windows.Forms.Label lblC;
		private System.Windows.Forms.Label lblD;
		private System.Windows.Forms.Label lblE;
		private System.Windows.Forms.Label lblF;
		private System.Windows.Forms.Label lblG;
		private System.Windows.Forms.Label lblH;
		private System.Windows.Forms.Label lbl1;
		private System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.Label lbl3;
		private System.Windows.Forms.Label lbl4;
		private System.Windows.Forms.Label lbl5;
		private System.Windows.Forms.Label lbl6;
		private System.Windows.Forms.Label lbl7;
		private System.Windows.Forms.Label lbl8;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.Label lblNextMove;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.GroupBox groupScore;
		private System.Windows.Forms.Label lblBlackScore;
		private System.Windows.Forms.Label lblWhiteScore;
		private System.Windows.Forms.Label lblBlack;
		private System.Windows.Forms.Label lblWhite;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList SquareImages;
		private System.Windows.Forms.GroupBox grpTurn;
		private Othello.OthelloSquareControl turnPiece;
		private System.Windows.Forms.Label lblTurn;

#endregion

		/// <summary>
		/// Πίνακας-μέλος της τάξης με αναφορές προς τα αντικείμενα - τετράγωνα της σκακιέρας (user controls).
		/// </summary>
		IOthelloSquare[][] Squares;
		/// <summary>
		/// Συμβολοσειρά - μέλος της τάξης που περιέχει το τρέχον κείμενο της Status Bar 
		/// αν δεν εμφανίζεται κάποια προειδοποίηση.
		/// </summary>
		String FormStatus;
		/// <summary>
		/// Μέλος της τάξης που ενθυλακώνει το τρέχον παιχνίδι.
		/// </summary>
		OthelloGame theGame;


		/// <summary>
		/// Ο κατασκευαστής της τάξης.
		/// </summary>
		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// Add any constructor code after InitializeComponent call
			//

			// Ορισμός της αρχικής τιμής του κειμένου της Status Bar
			SetStatus("Επιλέξτε Αρχείο -> Νέο παιχνίδι");

			// Δημιουργία του πίνακα με αναφορές προς τα αντικέμενα - τετράγωνα της σκακιέρας
			Squares = new IOthelloSquare[8][];
			Squares[0] = new IOthelloSquare[8] {SquareControl11, SquareControl21, SquareControl31, SquareControl41, SquareControl51, SquareControl61, SquareControl71, SquareControl81};
			Squares[1] = new IOthelloSquare[8] {SquareControl12, SquareControl22, SquareControl32, SquareControl42, SquareControl52, SquareControl62, SquareControl72, SquareControl82};
			Squares[2] = new IOthelloSquare[8] {SquareControl13, SquareControl23, SquareControl33, SquareControl43, SquareControl53, SquareControl63, SquareControl73, SquareControl83};
			Squares[3] = new IOthelloSquare[8] {SquareControl14, SquareControl24, SquareControl34, SquareControl44, SquareControl54, SquareControl64, SquareControl74, SquareControl84};
			Squares[4] = new IOthelloSquare[8] {SquareControl15, SquareControl25, SquareControl35, SquareControl45, SquareControl55, SquareControl65, SquareControl75, SquareControl85};
			Squares[5] = new IOthelloSquare[8] {SquareControl16, SquareControl26, SquareControl36, SquareControl46, SquareControl56, SquareControl66, SquareControl76, SquareControl86};
			Squares[6] = new IOthelloSquare[8] {SquareControl17, SquareControl27, SquareControl37, SquareControl47, SquareControl57, SquareControl67, SquareControl77, SquareControl87};
			Squares[7] = new IOthelloSquare[8] {SquareControl18, SquareControl28, SquareControl38, SquareControl48, SquareControl58, SquareControl68, SquareControl78, SquareControl88};
		}

		/// <summary>
		/// Απελευθέρωση των πόρων που χρησιμοποιούνται.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.mnuMain = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuNewGame = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
			this.SquareImages = new System.Windows.Forms.ImageList(this.components);
			this.SquareControl11 = new Othello.OthelloSquareControl();
			this.SquareControl12 = new Othello.OthelloSquareControl();
			this.SquareControl13 = new Othello.OthelloSquareControl();
			this.SquareControl14 = new Othello.OthelloSquareControl();
			this.SquareControl15 = new Othello.OthelloSquareControl();
			this.SquareControl16 = new Othello.OthelloSquareControl();
			this.SquareControl17 = new Othello.OthelloSquareControl();
			this.SquareControl18 = new Othello.OthelloSquareControl();
			this.SquareControl21 = new Othello.OthelloSquareControl();
			this.SquareControl22 = new Othello.OthelloSquareControl();
			this.SquareControl23 = new Othello.OthelloSquareControl();
			this.SquareControl24 = new Othello.OthelloSquareControl();
			this.SquareControl25 = new Othello.OthelloSquareControl();
			this.SquareControl26 = new Othello.OthelloSquareControl();
			this.SquareControl27 = new Othello.OthelloSquareControl();
			this.SquareControl28 = new Othello.OthelloSquareControl();
			this.SquareControl31 = new Othello.OthelloSquareControl();
			this.SquareControl32 = new Othello.OthelloSquareControl();
			this.SquareControl33 = new Othello.OthelloSquareControl();
			this.SquareControl34 = new Othello.OthelloSquareControl();
			this.SquareControl35 = new Othello.OthelloSquareControl();
			this.SquareControl36 = new Othello.OthelloSquareControl();
			this.SquareControl37 = new Othello.OthelloSquareControl();
			this.SquareControl38 = new Othello.OthelloSquareControl();
			this.SquareControl41 = new Othello.OthelloSquareControl();
			this.SquareControl42 = new Othello.OthelloSquareControl();
			this.SquareControl43 = new Othello.OthelloSquareControl();
			this.SquareControl44 = new Othello.OthelloSquareControl();
			this.SquareControl45 = new Othello.OthelloSquareControl();
			this.SquareControl46 = new Othello.OthelloSquareControl();
			this.SquareControl47 = new Othello.OthelloSquareControl();
			this.SquareControl48 = new Othello.OthelloSquareControl();
			this.SquareControl51 = new Othello.OthelloSquareControl();
			this.SquareControl52 = new Othello.OthelloSquareControl();
			this.SquareControl53 = new Othello.OthelloSquareControl();
			this.SquareControl54 = new Othello.OthelloSquareControl();
			this.SquareControl55 = new Othello.OthelloSquareControl();
			this.SquareControl56 = new Othello.OthelloSquareControl();
			this.SquareControl57 = new Othello.OthelloSquareControl();
			this.SquareControl58 = new Othello.OthelloSquareControl();
			this.SquareControl61 = new Othello.OthelloSquareControl();
			this.SquareControl62 = new Othello.OthelloSquareControl();
			this.SquareControl63 = new Othello.OthelloSquareControl();
			this.SquareControl64 = new Othello.OthelloSquareControl();
			this.SquareControl65 = new Othello.OthelloSquareControl();
			this.SquareControl66 = new Othello.OthelloSquareControl();
			this.SquareControl67 = new Othello.OthelloSquareControl();
			this.SquareControl68 = new Othello.OthelloSquareControl();
			this.SquareControl71 = new Othello.OthelloSquareControl();
			this.SquareControl72 = new Othello.OthelloSquareControl();
			this.SquareControl73 = new Othello.OthelloSquareControl();
			this.SquareControl74 = new Othello.OthelloSquareControl();
			this.SquareControl75 = new Othello.OthelloSquareControl();
			this.SquareControl76 = new Othello.OthelloSquareControl();
			this.SquareControl77 = new Othello.OthelloSquareControl();
			this.SquareControl78 = new Othello.OthelloSquareControl();
			this.SquareControl81 = new Othello.OthelloSquareControl();
			this.SquareControl82 = new Othello.OthelloSquareControl();
			this.SquareControl83 = new Othello.OthelloSquareControl();
			this.SquareControl84 = new Othello.OthelloSquareControl();
			this.SquareControl85 = new Othello.OthelloSquareControl();
			this.SquareControl86 = new Othello.OthelloSquareControl();
			this.SquareControl87 = new Othello.OthelloSquareControl();
			this.SquareControl88 = new Othello.OthelloSquareControl();
			this.lblA = new System.Windows.Forms.Label();
			this.lblB = new System.Windows.Forms.Label();
			this.lblC = new System.Windows.Forms.Label();
			this.lblD = new System.Windows.Forms.Label();
			this.lblE = new System.Windows.Forms.Label();
			this.lblF = new System.Windows.Forms.Label();
			this.lblG = new System.Windows.Forms.Label();
			this.lblH = new System.Windows.Forms.Label();
			this.lbl1 = new System.Windows.Forms.Label();
			this.lbl2 = new System.Windows.Forms.Label();
			this.lbl3 = new System.Windows.Forms.Label();
			this.lbl4 = new System.Windows.Forms.Label();
			this.lbl5 = new System.Windows.Forms.Label();
			this.lbl6 = new System.Windows.Forms.Label();
			this.lbl7 = new System.Windows.Forms.Label();
			this.lbl8 = new System.Windows.Forms.Label();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.lblNextMove = new System.Windows.Forms.Label();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.btnGo = new System.Windows.Forms.Button();
			this.groupScore = new System.Windows.Forms.GroupBox();
			this.lblBlack = new System.Windows.Forms.Label();
			this.lblWhite = new System.Windows.Forms.Label();
			this.lblBlackScore = new System.Windows.Forms.Label();
			this.lblWhiteScore = new System.Windows.Forms.Label();
			this.grpTurn = new System.Windows.Forms.GroupBox();
			this.lblTurn = new System.Windows.Forms.Label();
			this.turnPiece = new Othello.OthelloSquareControl();
			this.groupScore.SuspendLayout();
			this.grpTurn.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuFile,
																					this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuNewGame,
																					this.menuItem5,
																					this.mnuExit});
			this.mnuFile.Text = "&Αρχείο";
			// 
			// mnuNewGame
			// 
			this.mnuNewGame.Index = 0;
			this.mnuNewGame.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.mnuNewGame.Text = "&Νέο Παιχνίδι...";
			this.mnuNewGame.Click += new System.EventHandler(this.mnuNewGame_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "-";
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 2;
			this.mnuExit.Text = "&Έξοδος";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 1;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuHelpAbout});
			this.mnuHelp.Text = "&Βοήθεια";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Index = 0;
			this.mnuHelpAbout.Text = "&Περί...";
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			// 
			// SquareImages
			// 
			this.SquareImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.SquareImages.ImageSize = new System.Drawing.Size(24, 24);
			this.SquareImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SquareImages.ImageStream")));
			this.SquareImages.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// SquareControl11
			// 
			this.SquareControl11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl11.BackgroundImage")));
			this.SquareControl11.Column = ((short)(0));
			this.SquareControl11.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl11.ImagesList = this.SquareImages;
			this.SquareControl11.IsBlack = false;
			this.SquareControl11.IsPossible = false;
			this.SquareControl11.IsWhite = false;
			this.SquareControl11.Location = new System.Drawing.Point(40, 184);
			this.SquareControl11.Name = "SquareControl11";
			this.SquareControl11.Row = ((short)(0));
			this.SquareControl11.Size = new System.Drawing.Size(24, 24);
			this.SquareControl11.TabIndex = 90;
			this.SquareControl11.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl12
			// 
			this.SquareControl12.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl12.BackgroundImage")));
			this.SquareControl12.Column = ((short)(0));
			this.SquareControl12.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl12.ImagesList = this.SquareImages;
			this.SquareControl12.IsBlack = false;
			this.SquareControl12.IsPossible = false;
			this.SquareControl12.IsWhite = false;
			this.SquareControl12.Location = new System.Drawing.Point(40, 160);
			this.SquareControl12.Name = "SquareControl12";
			this.SquareControl12.Row = ((short)(1));
			this.SquareControl12.Size = new System.Drawing.Size(24, 24);
			this.SquareControl12.TabIndex = 1;
			this.SquareControl12.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl13
			// 
			this.SquareControl13.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl13.BackgroundImage")));
			this.SquareControl13.Column = ((short)(0));
			this.SquareControl13.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl13.ImagesList = this.SquareImages;
			this.SquareControl13.IsBlack = false;
			this.SquareControl13.IsPossible = false;
			this.SquareControl13.IsWhite = false;
			this.SquareControl13.Location = new System.Drawing.Point(40, 136);
			this.SquareControl13.Name = "SquareControl13";
			this.SquareControl13.Row = ((short)(2));
			this.SquareControl13.Size = new System.Drawing.Size(24, 24);
			this.SquareControl13.TabIndex = 2;
			this.SquareControl13.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl14
			// 
			this.SquareControl14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl14.BackgroundImage")));
			this.SquareControl14.Column = ((short)(0));
			this.SquareControl14.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl14.ImagesList = this.SquareImages;
			this.SquareControl14.IsBlack = false;
			this.SquareControl14.IsPossible = false;
			this.SquareControl14.IsWhite = false;
			this.SquareControl14.Location = new System.Drawing.Point(40, 112);
			this.SquareControl14.Name = "SquareControl14";
			this.SquareControl14.Row = ((short)(3));
			this.SquareControl14.Size = new System.Drawing.Size(24, 24);
			this.SquareControl14.TabIndex = 3;
			this.SquareControl14.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl15
			// 
			this.SquareControl15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl15.BackgroundImage")));
			this.SquareControl15.Column = ((short)(0));
			this.SquareControl15.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl15.ImagesList = this.SquareImages;
			this.SquareControl15.IsBlack = false;
			this.SquareControl15.IsPossible = false;
			this.SquareControl15.IsWhite = false;
			this.SquareControl15.Location = new System.Drawing.Point(40, 88);
			this.SquareControl15.Name = "SquareControl15";
			this.SquareControl15.Row = ((short)(4));
			this.SquareControl15.Size = new System.Drawing.Size(24, 24);
			this.SquareControl15.TabIndex = 4;
			this.SquareControl15.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl16
			// 
			this.SquareControl16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl16.BackgroundImage")));
			this.SquareControl16.Column = ((short)(0));
			this.SquareControl16.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl16.ImagesList = this.SquareImages;
			this.SquareControl16.IsBlack = false;
			this.SquareControl16.IsPossible = false;
			this.SquareControl16.IsWhite = false;
			this.SquareControl16.Location = new System.Drawing.Point(40, 64);
			this.SquareControl16.Name = "SquareControl16";
			this.SquareControl16.Row = ((short)(5));
			this.SquareControl16.Size = new System.Drawing.Size(24, 24);
			this.SquareControl16.TabIndex = 5;
			this.SquareControl16.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl17
			// 
			this.SquareControl17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl17.BackgroundImage")));
			this.SquareControl17.Column = ((short)(0));
			this.SquareControl17.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl17.ImagesList = this.SquareImages;
			this.SquareControl17.IsBlack = false;
			this.SquareControl17.IsPossible = false;
			this.SquareControl17.IsWhite = false;
			this.SquareControl17.Location = new System.Drawing.Point(40, 40);
			this.SquareControl17.Name = "SquareControl17";
			this.SquareControl17.Row = ((short)(6));
			this.SquareControl17.Size = new System.Drawing.Size(24, 24);
			this.SquareControl17.TabIndex = 6;
			this.SquareControl17.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl18
			// 
			this.SquareControl18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl18.BackgroundImage")));
			this.SquareControl18.Column = ((short)(0));
			this.SquareControl18.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl18.ImagesList = this.SquareImages;
			this.SquareControl18.IsBlack = false;
			this.SquareControl18.IsPossible = false;
			this.SquareControl18.IsWhite = false;
			this.SquareControl18.Location = new System.Drawing.Point(40, 16);
			this.SquareControl18.Name = "SquareControl18";
			this.SquareControl18.Row = ((short)(7));
			this.SquareControl18.Size = new System.Drawing.Size(24, 24);
			this.SquareControl18.TabIndex = 7;
			this.SquareControl18.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl21
			// 
			this.SquareControl21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl21.BackgroundImage")));
			this.SquareControl21.Column = ((short)(1));
			this.SquareControl21.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl21.ImagesList = this.SquareImages;
			this.SquareControl21.IsBlack = false;
			this.SquareControl21.IsPossible = false;
			this.SquareControl21.IsWhite = false;
			this.SquareControl21.Location = new System.Drawing.Point(64, 184);
			this.SquareControl21.Name = "SquareControl21";
			this.SquareControl21.Row = ((short)(0));
			this.SquareControl21.Size = new System.Drawing.Size(24, 24);
			this.SquareControl21.TabIndex = 15;
			this.SquareControl21.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl22
			// 
			this.SquareControl22.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl22.BackgroundImage")));
			this.SquareControl22.Column = ((short)(1));
			this.SquareControl22.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl22.ImagesList = this.SquareImages;
			this.SquareControl22.IsBlack = false;
			this.SquareControl22.IsPossible = false;
			this.SquareControl22.IsWhite = false;
			this.SquareControl22.Location = new System.Drawing.Point(64, 160);
			this.SquareControl22.Name = "SquareControl22";
			this.SquareControl22.Row = ((short)(1));
			this.SquareControl22.Size = new System.Drawing.Size(24, 24);
			this.SquareControl22.TabIndex = 14;
			this.SquareControl22.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl23
			// 
			this.SquareControl23.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl23.BackgroundImage")));
			this.SquareControl23.Column = ((short)(1));
			this.SquareControl23.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl23.ImagesList = this.SquareImages;
			this.SquareControl23.IsBlack = false;
			this.SquareControl23.IsPossible = false;
			this.SquareControl23.IsWhite = false;
			this.SquareControl23.Location = new System.Drawing.Point(64, 136);
			this.SquareControl23.Name = "SquareControl23";
			this.SquareControl23.Row = ((short)(2));
			this.SquareControl23.Size = new System.Drawing.Size(24, 24);
			this.SquareControl23.TabIndex = 13;
			this.SquareControl23.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl24
			// 
			this.SquareControl24.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl24.BackgroundImage")));
			this.SquareControl24.Column = ((short)(1));
			this.SquareControl24.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl24.ImagesList = this.SquareImages;
			this.SquareControl24.IsBlack = false;
			this.SquareControl24.IsPossible = false;
			this.SquareControl24.IsWhite = false;
			this.SquareControl24.Location = new System.Drawing.Point(64, 112);
			this.SquareControl24.Name = "SquareControl24";
			this.SquareControl24.Row = ((short)(3));
			this.SquareControl24.Size = new System.Drawing.Size(24, 24);
			this.SquareControl24.TabIndex = 12;
			this.SquareControl24.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl25
			// 
			this.SquareControl25.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl25.BackgroundImage")));
			this.SquareControl25.Column = ((short)(1));
			this.SquareControl25.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl25.ImagesList = this.SquareImages;
			this.SquareControl25.IsBlack = false;
			this.SquareControl25.IsPossible = false;
			this.SquareControl25.IsWhite = false;
			this.SquareControl25.Location = new System.Drawing.Point(64, 88);
			this.SquareControl25.Name = "SquareControl25";
			this.SquareControl25.Row = ((short)(4));
			this.SquareControl25.Size = new System.Drawing.Size(24, 24);
			this.SquareControl25.TabIndex = 11;
			this.SquareControl25.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl26
			// 
			this.SquareControl26.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl26.BackgroundImage")));
			this.SquareControl26.Column = ((short)(1));
			this.SquareControl26.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl26.ImagesList = this.SquareImages;
			this.SquareControl26.IsBlack = false;
			this.SquareControl26.IsPossible = false;
			this.SquareControl26.IsWhite = false;
			this.SquareControl26.Location = new System.Drawing.Point(64, 64);
			this.SquareControl26.Name = "SquareControl26";
			this.SquareControl26.Row = ((short)(5));
			this.SquareControl26.Size = new System.Drawing.Size(24, 24);
			this.SquareControl26.TabIndex = 10;
			this.SquareControl26.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl27
			// 
			this.SquareControl27.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl27.BackgroundImage")));
			this.SquareControl27.Column = ((short)(1));
			this.SquareControl27.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl27.ImagesList = this.SquareImages;
			this.SquareControl27.IsBlack = false;
			this.SquareControl27.IsPossible = false;
			this.SquareControl27.IsWhite = false;
			this.SquareControl27.Location = new System.Drawing.Point(64, 40);
			this.SquareControl27.Name = "SquareControl27";
			this.SquareControl27.Row = ((short)(6));
			this.SquareControl27.Size = new System.Drawing.Size(24, 24);
			this.SquareControl27.TabIndex = 9;
			this.SquareControl27.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl28
			// 
			this.SquareControl28.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl28.BackgroundImage")));
			this.SquareControl28.Column = ((short)(1));
			this.SquareControl28.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl28.ImagesList = this.SquareImages;
			this.SquareControl28.IsBlack = false;
			this.SquareControl28.IsPossible = false;
			this.SquareControl28.IsWhite = false;
			this.SquareControl28.Location = new System.Drawing.Point(64, 16);
			this.SquareControl28.Name = "SquareControl28";
			this.SquareControl28.Row = ((short)(7));
			this.SquareControl28.Size = new System.Drawing.Size(24, 24);
			this.SquareControl28.TabIndex = 8;
			this.SquareControl28.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl31
			// 
			this.SquareControl31.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl31.BackgroundImage")));
			this.SquareControl31.Column = ((short)(2));
			this.SquareControl31.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl31.ImagesList = this.SquareImages;
			this.SquareControl31.IsBlack = false;
			this.SquareControl31.IsPossible = false;
			this.SquareControl31.IsWhite = false;
			this.SquareControl31.Location = new System.Drawing.Point(88, 184);
			this.SquareControl31.Name = "SquareControl31";
			this.SquareControl31.Row = ((short)(0));
			this.SquareControl31.Size = new System.Drawing.Size(24, 24);
			this.SquareControl31.TabIndex = 23;
			this.SquareControl31.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl32
			// 
			this.SquareControl32.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl32.BackgroundImage")));
			this.SquareControl32.Column = ((short)(2));
			this.SquareControl32.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl32.ImagesList = this.SquareImages;
			this.SquareControl32.IsBlack = false;
			this.SquareControl32.IsPossible = false;
			this.SquareControl32.IsWhite = false;
			this.SquareControl32.Location = new System.Drawing.Point(88, 160);
			this.SquareControl32.Name = "SquareControl32";
			this.SquareControl32.Row = ((short)(1));
			this.SquareControl32.Size = new System.Drawing.Size(24, 24);
			this.SquareControl32.TabIndex = 22;
			this.SquareControl32.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl33
			// 
			this.SquareControl33.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl33.BackgroundImage")));
			this.SquareControl33.Column = ((short)(2));
			this.SquareControl33.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl33.ImagesList = this.SquareImages;
			this.SquareControl33.IsBlack = false;
			this.SquareControl33.IsPossible = false;
			this.SquareControl33.IsWhite = false;
			this.SquareControl33.Location = new System.Drawing.Point(88, 136);
			this.SquareControl33.Name = "SquareControl33";
			this.SquareControl33.Row = ((short)(2));
			this.SquareControl33.Size = new System.Drawing.Size(24, 24);
			this.SquareControl33.TabIndex = 21;
			this.SquareControl33.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl34
			// 
			this.SquareControl34.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl34.BackgroundImage")));
			this.SquareControl34.Column = ((short)(2));
			this.SquareControl34.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl34.ImagesList = this.SquareImages;
			this.SquareControl34.IsBlack = false;
			this.SquareControl34.IsPossible = false;
			this.SquareControl34.IsWhite = false;
			this.SquareControl34.Location = new System.Drawing.Point(88, 112);
			this.SquareControl34.Name = "SquareControl34";
			this.SquareControl34.Row = ((short)(3));
			this.SquareControl34.Size = new System.Drawing.Size(24, 24);
			this.SquareControl34.TabIndex = 20;
			this.SquareControl34.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl35
			// 
			this.SquareControl35.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl35.BackgroundImage")));
			this.SquareControl35.Column = ((short)(2));
			this.SquareControl35.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl35.ImagesList = this.SquareImages;
			this.SquareControl35.IsBlack = false;
			this.SquareControl35.IsPossible = false;
			this.SquareControl35.IsWhite = false;
			this.SquareControl35.Location = new System.Drawing.Point(88, 88);
			this.SquareControl35.Name = "SquareControl35";
			this.SquareControl35.Row = ((short)(4));
			this.SquareControl35.Size = new System.Drawing.Size(24, 24);
			this.SquareControl35.TabIndex = 91;
			this.SquareControl35.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl36
			// 
			this.SquareControl36.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl36.BackgroundImage")));
			this.SquareControl36.Column = ((short)(2));
			this.SquareControl36.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl36.ImagesList = this.SquareImages;
			this.SquareControl36.IsBlack = false;
			this.SquareControl36.IsPossible = false;
			this.SquareControl36.IsWhite = false;
			this.SquareControl36.Location = new System.Drawing.Point(88, 64);
			this.SquareControl36.Name = "SquareControl36";
			this.SquareControl36.Row = ((short)(5));
			this.SquareControl36.Size = new System.Drawing.Size(24, 24);
			this.SquareControl36.TabIndex = 18;
			this.SquareControl36.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl37
			// 
			this.SquareControl37.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl37.BackgroundImage")));
			this.SquareControl37.Column = ((short)(2));
			this.SquareControl37.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl37.ImagesList = this.SquareImages;
			this.SquareControl37.IsBlack = false;
			this.SquareControl37.IsPossible = false;
			this.SquareControl37.IsWhite = false;
			this.SquareControl37.Location = new System.Drawing.Point(88, 40);
			this.SquareControl37.Name = "SquareControl37";
			this.SquareControl37.Row = ((short)(6));
			this.SquareControl37.Size = new System.Drawing.Size(24, 24);
			this.SquareControl37.TabIndex = 17;
			this.SquareControl37.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl38
			// 
			this.SquareControl38.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl38.BackgroundImage")));
			this.SquareControl38.Column = ((short)(2));
			this.SquareControl38.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl38.ImagesList = this.SquareImages;
			this.SquareControl38.IsBlack = false;
			this.SquareControl38.IsPossible = false;
			this.SquareControl38.IsWhite = false;
			this.SquareControl38.Location = new System.Drawing.Point(88, 16);
			this.SquareControl38.Name = "SquareControl38";
			this.SquareControl38.Row = ((short)(7));
			this.SquareControl38.Size = new System.Drawing.Size(24, 24);
			this.SquareControl38.TabIndex = 16;
			this.SquareControl38.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl41
			// 
			this.SquareControl41.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl41.BackgroundImage")));
			this.SquareControl41.Column = ((short)(3));
			this.SquareControl41.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl41.ImagesList = this.SquareImages;
			this.SquareControl41.IsBlack = false;
			this.SquareControl41.IsPossible = false;
			this.SquareControl41.IsWhite = false;
			this.SquareControl41.Location = new System.Drawing.Point(112, 184);
			this.SquareControl41.Name = "SquareControl41";
			this.SquareControl41.Row = ((short)(0));
			this.SquareControl41.Size = new System.Drawing.Size(24, 24);
			this.SquareControl41.TabIndex = 31;
			this.SquareControl41.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl42
			// 
			this.SquareControl42.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl42.BackgroundImage")));
			this.SquareControl42.Column = ((short)(3));
			this.SquareControl42.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl42.ImagesList = this.SquareImages;
			this.SquareControl42.IsBlack = false;
			this.SquareControl42.IsPossible = false;
			this.SquareControl42.IsWhite = false;
			this.SquareControl42.Location = new System.Drawing.Point(112, 160);
			this.SquareControl42.Name = "SquareControl42";
			this.SquareControl42.Row = ((short)(1));
			this.SquareControl42.Size = new System.Drawing.Size(24, 24);
			this.SquareControl42.TabIndex = 30;
			this.SquareControl42.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl43
			// 
			this.SquareControl43.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl43.BackgroundImage")));
			this.SquareControl43.Column = ((short)(3));
			this.SquareControl43.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl43.ImagesList = this.SquareImages;
			this.SquareControl43.IsBlack = false;
			this.SquareControl43.IsPossible = false;
			this.SquareControl43.IsWhite = false;
			this.SquareControl43.Location = new System.Drawing.Point(112, 136);
			this.SquareControl43.Name = "SquareControl43";
			this.SquareControl43.Row = ((short)(2));
			this.SquareControl43.Size = new System.Drawing.Size(24, 24);
			this.SquareControl43.TabIndex = 29;
			this.SquareControl43.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl44
			// 
			this.SquareControl44.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl44.BackgroundImage")));
			this.SquareControl44.Column = ((short)(3));
			this.SquareControl44.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl44.ImagesList = this.SquareImages;
			this.SquareControl44.IsBlack = false;
			this.SquareControl44.IsPossible = false;
			this.SquareControl44.IsWhite = false;
			this.SquareControl44.Location = new System.Drawing.Point(112, 112);
			this.SquareControl44.Name = "SquareControl44";
			this.SquareControl44.Row = ((short)(3));
			this.SquareControl44.Size = new System.Drawing.Size(24, 24);
			this.SquareControl44.TabIndex = 28;
			this.SquareControl44.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl45
			// 
			this.SquareControl45.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl45.BackgroundImage")));
			this.SquareControl45.Column = ((short)(3));
			this.SquareControl45.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl45.ImagesList = this.SquareImages;
			this.SquareControl45.IsBlack = false;
			this.SquareControl45.IsPossible = false;
			this.SquareControl45.IsWhite = false;
			this.SquareControl45.Location = new System.Drawing.Point(112, 88);
			this.SquareControl45.Name = "SquareControl45";
			this.SquareControl45.Row = ((short)(4));
			this.SquareControl45.Size = new System.Drawing.Size(24, 24);
			this.SquareControl45.TabIndex = 27;
			this.SquareControl45.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl46
			// 
			this.SquareControl46.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl46.BackgroundImage")));
			this.SquareControl46.Column = ((short)(3));
			this.SquareControl46.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl46.ImagesList = this.SquareImages;
			this.SquareControl46.IsBlack = false;
			this.SquareControl46.IsPossible = false;
			this.SquareControl46.IsWhite = false;
			this.SquareControl46.Location = new System.Drawing.Point(112, 64);
			this.SquareControl46.Name = "SquareControl46";
			this.SquareControl46.Row = ((short)(5));
			this.SquareControl46.Size = new System.Drawing.Size(24, 24);
			this.SquareControl46.TabIndex = 26;
			this.SquareControl46.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl47
			// 
			this.SquareControl47.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl47.BackgroundImage")));
			this.SquareControl47.Column = ((short)(3));
			this.SquareControl47.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl47.ImagesList = this.SquareImages;
			this.SquareControl47.IsBlack = false;
			this.SquareControl47.IsPossible = false;
			this.SquareControl47.IsWhite = false;
			this.SquareControl47.Location = new System.Drawing.Point(112, 40);
			this.SquareControl47.Name = "SquareControl47";
			this.SquareControl47.Row = ((short)(6));
			this.SquareControl47.Size = new System.Drawing.Size(24, 24);
			this.SquareControl47.TabIndex = 25;
			this.SquareControl47.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl48
			// 
			this.SquareControl48.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl48.BackgroundImage")));
			this.SquareControl48.Column = ((short)(3));
			this.SquareControl48.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl48.ImagesList = this.SquareImages;
			this.SquareControl48.IsBlack = false;
			this.SquareControl48.IsPossible = false;
			this.SquareControl48.IsWhite = false;
			this.SquareControl48.Location = new System.Drawing.Point(112, 16);
			this.SquareControl48.Name = "SquareControl48";
			this.SquareControl48.Row = ((short)(7));
			this.SquareControl48.Size = new System.Drawing.Size(24, 24);
			this.SquareControl48.TabIndex = 24;
			this.SquareControl48.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl51
			// 
			this.SquareControl51.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl51.BackgroundImage")));
			this.SquareControl51.Column = ((short)(4));
			this.SquareControl51.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl51.ImagesList = this.SquareImages;
			this.SquareControl51.IsBlack = false;
			this.SquareControl51.IsPossible = false;
			this.SquareControl51.IsWhite = false;
			this.SquareControl51.Location = new System.Drawing.Point(136, 184);
			this.SquareControl51.Name = "SquareControl51";
			this.SquareControl51.Row = ((short)(0));
			this.SquareControl51.Size = new System.Drawing.Size(24, 24);
			this.SquareControl51.TabIndex = 39;
			this.SquareControl51.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl52
			// 
			this.SquareControl52.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl52.BackgroundImage")));
			this.SquareControl52.Column = ((short)(4));
			this.SquareControl52.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl52.ImagesList = this.SquareImages;
			this.SquareControl52.IsBlack = false;
			this.SquareControl52.IsPossible = false;
			this.SquareControl52.IsWhite = false;
			this.SquareControl52.Location = new System.Drawing.Point(136, 160);
			this.SquareControl52.Name = "SquareControl52";
			this.SquareControl52.Row = ((short)(1));
			this.SquareControl52.Size = new System.Drawing.Size(24, 24);
			this.SquareControl52.TabIndex = 38;
			this.SquareControl52.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl53
			// 
			this.SquareControl53.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl53.BackgroundImage")));
			this.SquareControl53.Column = ((short)(4));
			this.SquareControl53.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl53.ImagesList = this.SquareImages;
			this.SquareControl53.IsBlack = false;
			this.SquareControl53.IsPossible = false;
			this.SquareControl53.IsWhite = false;
			this.SquareControl53.Location = new System.Drawing.Point(136, 136);
			this.SquareControl53.Name = "SquareControl53";
			this.SquareControl53.Row = ((short)(2));
			this.SquareControl53.Size = new System.Drawing.Size(24, 24);
			this.SquareControl53.TabIndex = 37;
			this.SquareControl53.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl54
			// 
			this.SquareControl54.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl54.BackgroundImage")));
			this.SquareControl54.Column = ((short)(4));
			this.SquareControl54.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl54.ImagesList = this.SquareImages;
			this.SquareControl54.IsBlack = false;
			this.SquareControl54.IsPossible = false;
			this.SquareControl54.IsWhite = false;
			this.SquareControl54.Location = new System.Drawing.Point(136, 112);
			this.SquareControl54.Name = "SquareControl54";
			this.SquareControl54.Row = ((short)(3));
			this.SquareControl54.Size = new System.Drawing.Size(24, 24);
			this.SquareControl54.TabIndex = 36;
			this.SquareControl54.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl55
			// 
			this.SquareControl55.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl55.BackgroundImage")));
			this.SquareControl55.Column = ((short)(4));
			this.SquareControl55.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl55.ImagesList = this.SquareImages;
			this.SquareControl55.IsBlack = false;
			this.SquareControl55.IsPossible = false;
			this.SquareControl55.IsWhite = false;
			this.SquareControl55.Location = new System.Drawing.Point(136, 88);
			this.SquareControl55.Name = "SquareControl55";
			this.SquareControl55.Row = ((short)(4));
			this.SquareControl55.Size = new System.Drawing.Size(24, 24);
			this.SquareControl55.TabIndex = 35;
			this.SquareControl55.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl56
			// 
			this.SquareControl56.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl56.BackgroundImage")));
			this.SquareControl56.Column = ((short)(4));
			this.SquareControl56.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl56.ImagesList = this.SquareImages;
			this.SquareControl56.IsBlack = false;
			this.SquareControl56.IsPossible = false;
			this.SquareControl56.IsWhite = false;
			this.SquareControl56.Location = new System.Drawing.Point(136, 64);
			this.SquareControl56.Name = "SquareControl56";
			this.SquareControl56.Row = ((short)(5));
			this.SquareControl56.Size = new System.Drawing.Size(24, 24);
			this.SquareControl56.TabIndex = 34;
			this.SquareControl56.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl57
			// 
			this.SquareControl57.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl57.BackgroundImage")));
			this.SquareControl57.Column = ((short)(4));
			this.SquareControl57.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl57.ImagesList = this.SquareImages;
			this.SquareControl57.IsBlack = false;
			this.SquareControl57.IsPossible = false;
			this.SquareControl57.IsWhite = false;
			this.SquareControl57.Location = new System.Drawing.Point(136, 40);
			this.SquareControl57.Name = "SquareControl57";
			this.SquareControl57.Row = ((short)(6));
			this.SquareControl57.Size = new System.Drawing.Size(24, 24);
			this.SquareControl57.TabIndex = 33;
			this.SquareControl57.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl58
			// 
			this.SquareControl58.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl58.BackgroundImage")));
			this.SquareControl58.Column = ((short)(4));
			this.SquareControl58.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl58.ImagesList = this.SquareImages;
			this.SquareControl58.IsBlack = false;
			this.SquareControl58.IsPossible = false;
			this.SquareControl58.IsWhite = false;
			this.SquareControl58.Location = new System.Drawing.Point(136, 16);
			this.SquareControl58.Name = "SquareControl58";
			this.SquareControl58.Row = ((short)(7));
			this.SquareControl58.Size = new System.Drawing.Size(24, 24);
			this.SquareControl58.TabIndex = 32;
			this.SquareControl58.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl61
			// 
			this.SquareControl61.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl61.BackgroundImage")));
			this.SquareControl61.Column = ((short)(5));
			this.SquareControl61.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl61.ImagesList = this.SquareImages;
			this.SquareControl61.IsBlack = false;
			this.SquareControl61.IsPossible = false;
			this.SquareControl61.IsWhite = false;
			this.SquareControl61.Location = new System.Drawing.Point(160, 184);
			this.SquareControl61.Name = "SquareControl61";
			this.SquareControl61.Row = ((short)(0));
			this.SquareControl61.Size = new System.Drawing.Size(24, 24);
			this.SquareControl61.TabIndex = 47;
			this.SquareControl61.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl62
			// 
			this.SquareControl62.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl62.BackgroundImage")));
			this.SquareControl62.Column = ((short)(5));
			this.SquareControl62.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl62.ImagesList = this.SquareImages;
			this.SquareControl62.IsBlack = false;
			this.SquareControl62.IsPossible = false;
			this.SquareControl62.IsWhite = false;
			this.SquareControl62.Location = new System.Drawing.Point(160, 160);
			this.SquareControl62.Name = "SquareControl62";
			this.SquareControl62.Row = ((short)(1));
			this.SquareControl62.Size = new System.Drawing.Size(24, 24);
			this.SquareControl62.TabIndex = 46;
			this.SquareControl62.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl63
			// 
			this.SquareControl63.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl63.BackgroundImage")));
			this.SquareControl63.Column = ((short)(5));
			this.SquareControl63.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl63.ImagesList = this.SquareImages;
			this.SquareControl63.IsBlack = false;
			this.SquareControl63.IsPossible = false;
			this.SquareControl63.IsWhite = false;
			this.SquareControl63.Location = new System.Drawing.Point(160, 136);
			this.SquareControl63.Name = "SquareControl63";
			this.SquareControl63.Row = ((short)(2));
			this.SquareControl63.Size = new System.Drawing.Size(24, 24);
			this.SquareControl63.TabIndex = 45;
			this.SquareControl63.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl64
			// 
			this.SquareControl64.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl64.BackgroundImage")));
			this.SquareControl64.Column = ((short)(5));
			this.SquareControl64.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl64.ImagesList = this.SquareImages;
			this.SquareControl64.IsBlack = false;
			this.SquareControl64.IsPossible = false;
			this.SquareControl64.IsWhite = false;
			this.SquareControl64.Location = new System.Drawing.Point(160, 112);
			this.SquareControl64.Name = "SquareControl64";
			this.SquareControl64.Row = ((short)(3));
			this.SquareControl64.Size = new System.Drawing.Size(24, 24);
			this.SquareControl64.TabIndex = 44;
			this.SquareControl64.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl65
			// 
			this.SquareControl65.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl65.BackgroundImage")));
			this.SquareControl65.Column = ((short)(5));
			this.SquareControl65.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl65.ImagesList = this.SquareImages;
			this.SquareControl65.IsBlack = false;
			this.SquareControl65.IsPossible = false;
			this.SquareControl65.IsWhite = false;
			this.SquareControl65.Location = new System.Drawing.Point(160, 88);
			this.SquareControl65.Name = "SquareControl65";
			this.SquareControl65.Row = ((short)(4));
			this.SquareControl65.Size = new System.Drawing.Size(24, 24);
			this.SquareControl65.TabIndex = 43;
			this.SquareControl65.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl66
			// 
			this.SquareControl66.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl66.BackgroundImage")));
			this.SquareControl66.Column = ((short)(5));
			this.SquareControl66.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl66.ImagesList = this.SquareImages;
			this.SquareControl66.IsBlack = false;
			this.SquareControl66.IsPossible = false;
			this.SquareControl66.IsWhite = false;
			this.SquareControl66.Location = new System.Drawing.Point(160, 64);
			this.SquareControl66.Name = "SquareControl66";
			this.SquareControl66.Row = ((short)(5));
			this.SquareControl66.Size = new System.Drawing.Size(24, 24);
			this.SquareControl66.TabIndex = 42;
			this.SquareControl66.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl67
			// 
			this.SquareControl67.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl67.BackgroundImage")));
			this.SquareControl67.Column = ((short)(5));
			this.SquareControl67.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl67.ImagesList = this.SquareImages;
			this.SquareControl67.IsBlack = false;
			this.SquareControl67.IsPossible = false;
			this.SquareControl67.IsWhite = false;
			this.SquareControl67.Location = new System.Drawing.Point(160, 40);
			this.SquareControl67.Name = "SquareControl67";
			this.SquareControl67.Row = ((short)(6));
			this.SquareControl67.Size = new System.Drawing.Size(24, 24);
			this.SquareControl67.TabIndex = 41;
			this.SquareControl67.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl68
			// 
			this.SquareControl68.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl68.BackgroundImage")));
			this.SquareControl68.Column = ((short)(5));
			this.SquareControl68.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl68.ImagesList = this.SquareImages;
			this.SquareControl68.IsBlack = false;
			this.SquareControl68.IsPossible = false;
			this.SquareControl68.IsWhite = false;
			this.SquareControl68.Location = new System.Drawing.Point(160, 16);
			this.SquareControl68.Name = "SquareControl68";
			this.SquareControl68.Row = ((short)(7));
			this.SquareControl68.Size = new System.Drawing.Size(24, 24);
			this.SquareControl68.TabIndex = 40;
			this.SquareControl68.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl71
			// 
			this.SquareControl71.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl71.BackgroundImage")));
			this.SquareControl71.Column = ((short)(6));
			this.SquareControl71.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl71.ImagesList = this.SquareImages;
			this.SquareControl71.IsBlack = false;
			this.SquareControl71.IsPossible = false;
			this.SquareControl71.IsWhite = false;
			this.SquareControl71.Location = new System.Drawing.Point(184, 184);
			this.SquareControl71.Name = "SquareControl71";
			this.SquareControl71.Row = ((short)(0));
			this.SquareControl71.Size = new System.Drawing.Size(24, 24);
			this.SquareControl71.TabIndex = 55;
			this.SquareControl71.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl72
			// 
			this.SquareControl72.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl72.BackgroundImage")));
			this.SquareControl72.Column = ((short)(6));
			this.SquareControl72.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl72.ImagesList = this.SquareImages;
			this.SquareControl72.IsBlack = false;
			this.SquareControl72.IsPossible = false;
			this.SquareControl72.IsWhite = false;
			this.SquareControl72.Location = new System.Drawing.Point(184, 160);
			this.SquareControl72.Name = "SquareControl72";
			this.SquareControl72.Row = ((short)(1));
			this.SquareControl72.Size = new System.Drawing.Size(24, 24);
			this.SquareControl72.TabIndex = 54;
			this.SquareControl72.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl73
			// 
			this.SquareControl73.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl73.BackgroundImage")));
			this.SquareControl73.Column = ((short)(6));
			this.SquareControl73.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl73.ImagesList = this.SquareImages;
			this.SquareControl73.IsBlack = false;
			this.SquareControl73.IsPossible = false;
			this.SquareControl73.IsWhite = false;
			this.SquareControl73.Location = new System.Drawing.Point(184, 136);
			this.SquareControl73.Name = "SquareControl73";
			this.SquareControl73.Row = ((short)(2));
			this.SquareControl73.Size = new System.Drawing.Size(24, 24);
			this.SquareControl73.TabIndex = 53;
			this.SquareControl73.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl74
			// 
			this.SquareControl74.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl74.BackgroundImage")));
			this.SquareControl74.Column = ((short)(6));
			this.SquareControl74.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl74.ImagesList = this.SquareImages;
			this.SquareControl74.IsBlack = false;
			this.SquareControl74.IsPossible = false;
			this.SquareControl74.IsWhite = false;
			this.SquareControl74.Location = new System.Drawing.Point(184, 112);
			this.SquareControl74.Name = "SquareControl74";
			this.SquareControl74.Row = ((short)(3));
			this.SquareControl74.Size = new System.Drawing.Size(24, 24);
			this.SquareControl74.TabIndex = 52;
			this.SquareControl74.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl75
			// 
			this.SquareControl75.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl75.BackgroundImage")));
			this.SquareControl75.Column = ((short)(6));
			this.SquareControl75.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl75.ImagesList = this.SquareImages;
			this.SquareControl75.IsBlack = false;
			this.SquareControl75.IsPossible = false;
			this.SquareControl75.IsWhite = false;
			this.SquareControl75.Location = new System.Drawing.Point(184, 88);
			this.SquareControl75.Name = "SquareControl75";
			this.SquareControl75.Row = ((short)(4));
			this.SquareControl75.Size = new System.Drawing.Size(24, 24);
			this.SquareControl75.TabIndex = 51;
			this.SquareControl75.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl76
			// 
			this.SquareControl76.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl76.BackgroundImage")));
			this.SquareControl76.Column = ((short)(6));
			this.SquareControl76.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl76.ImagesList = this.SquareImages;
			this.SquareControl76.IsBlack = false;
			this.SquareControl76.IsPossible = false;
			this.SquareControl76.IsWhite = false;
			this.SquareControl76.Location = new System.Drawing.Point(184, 64);
			this.SquareControl76.Name = "SquareControl76";
			this.SquareControl76.Row = ((short)(5));
			this.SquareControl76.Size = new System.Drawing.Size(24, 24);
			this.SquareControl76.TabIndex = 50;
			this.SquareControl76.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl77
			// 
			this.SquareControl77.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl77.BackgroundImage")));
			this.SquareControl77.Column = ((short)(6));
			this.SquareControl77.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl77.ImagesList = this.SquareImages;
			this.SquareControl77.IsBlack = false;
			this.SquareControl77.IsPossible = false;
			this.SquareControl77.IsWhite = false;
			this.SquareControl77.Location = new System.Drawing.Point(184, 40);
			this.SquareControl77.Name = "SquareControl77";
			this.SquareControl77.Row = ((short)(6));
			this.SquareControl77.Size = new System.Drawing.Size(24, 24);
			this.SquareControl77.TabIndex = 49;
			this.SquareControl77.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl78
			// 
			this.SquareControl78.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl78.BackgroundImage")));
			this.SquareControl78.Column = ((short)(6));
			this.SquareControl78.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl78.ImagesList = this.SquareImages;
			this.SquareControl78.IsBlack = false;
			this.SquareControl78.IsPossible = false;
			this.SquareControl78.IsWhite = false;
			this.SquareControl78.Location = new System.Drawing.Point(184, 16);
			this.SquareControl78.Name = "SquareControl78";
			this.SquareControl78.Row = ((short)(7));
			this.SquareControl78.Size = new System.Drawing.Size(24, 24);
			this.SquareControl78.TabIndex = 48;
			this.SquareControl78.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl81
			// 
			this.SquareControl81.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl81.BackgroundImage")));
			this.SquareControl81.Column = ((short)(7));
			this.SquareControl81.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl81.ImagesList = this.SquareImages;
			this.SquareControl81.IsBlack = false;
			this.SquareControl81.IsPossible = false;
			this.SquareControl81.IsWhite = false;
			this.SquareControl81.Location = new System.Drawing.Point(208, 184);
			this.SquareControl81.Name = "SquareControl81";
			this.SquareControl81.Row = ((short)(0));
			this.SquareControl81.Size = new System.Drawing.Size(24, 24);
			this.SquareControl81.TabIndex = 63;
			this.SquareControl81.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl82
			// 
			this.SquareControl82.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl82.BackgroundImage")));
			this.SquareControl82.Column = ((short)(7));
			this.SquareControl82.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl82.ImagesList = this.SquareImages;
			this.SquareControl82.IsBlack = false;
			this.SquareControl82.IsPossible = false;
			this.SquareControl82.IsWhite = false;
			this.SquareControl82.Location = new System.Drawing.Point(208, 160);
			this.SquareControl82.Name = "SquareControl82";
			this.SquareControl82.Row = ((short)(1));
			this.SquareControl82.Size = new System.Drawing.Size(24, 24);
			this.SquareControl82.TabIndex = 62;
			this.SquareControl82.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl83
			// 
			this.SquareControl83.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl83.BackgroundImage")));
			this.SquareControl83.Column = ((short)(7));
			this.SquareControl83.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl83.ImagesList = this.SquareImages;
			this.SquareControl83.IsBlack = false;
			this.SquareControl83.IsPossible = false;
			this.SquareControl83.IsWhite = false;
			this.SquareControl83.Location = new System.Drawing.Point(208, 136);
			this.SquareControl83.Name = "SquareControl83";
			this.SquareControl83.Row = ((short)(2));
			this.SquareControl83.Size = new System.Drawing.Size(24, 24);
			this.SquareControl83.TabIndex = 61;
			this.SquareControl83.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl84
			// 
			this.SquareControl84.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl84.BackgroundImage")));
			this.SquareControl84.Column = ((short)(7));
			this.SquareControl84.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl84.ImagesList = this.SquareImages;
			this.SquareControl84.IsBlack = false;
			this.SquareControl84.IsPossible = false;
			this.SquareControl84.IsWhite = false;
			this.SquareControl84.Location = new System.Drawing.Point(208, 112);
			this.SquareControl84.Name = "SquareControl84";
			this.SquareControl84.Row = ((short)(3));
			this.SquareControl84.Size = new System.Drawing.Size(24, 24);
			this.SquareControl84.TabIndex = 60;
			this.SquareControl84.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl85
			// 
			this.SquareControl85.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl85.BackgroundImage")));
			this.SquareControl85.Column = ((short)(7));
			this.SquareControl85.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl85.ImagesList = this.SquareImages;
			this.SquareControl85.IsBlack = false;
			this.SquareControl85.IsPossible = false;
			this.SquareControl85.IsWhite = false;
			this.SquareControl85.Location = new System.Drawing.Point(208, 88);
			this.SquareControl85.Name = "SquareControl85";
			this.SquareControl85.Row = ((short)(4));
			this.SquareControl85.Size = new System.Drawing.Size(24, 24);
			this.SquareControl85.TabIndex = 59;
			this.SquareControl85.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl86
			// 
			this.SquareControl86.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl86.BackgroundImage")));
			this.SquareControl86.Column = ((short)(7));
			this.SquareControl86.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl86.ImagesList = this.SquareImages;
			this.SquareControl86.IsBlack = false;
			this.SquareControl86.IsPossible = false;
			this.SquareControl86.IsWhite = false;
			this.SquareControl86.Location = new System.Drawing.Point(208, 64);
			this.SquareControl86.Name = "SquareControl86";
			this.SquareControl86.Row = ((short)(5));
			this.SquareControl86.Size = new System.Drawing.Size(24, 24);
			this.SquareControl86.TabIndex = 58;
			this.SquareControl86.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl87
			// 
			this.SquareControl87.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl87.BackgroundImage")));
			this.SquareControl87.Column = ((short)(7));
			this.SquareControl87.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl87.ImagesList = this.SquareImages;
			this.SquareControl87.IsBlack = false;
			this.SquareControl87.IsPossible = false;
			this.SquareControl87.IsWhite = false;
			this.SquareControl87.Location = new System.Drawing.Point(208, 40);
			this.SquareControl87.Name = "SquareControl87";
			this.SquareControl87.Row = ((short)(6));
			this.SquareControl87.Size = new System.Drawing.Size(24, 24);
			this.SquareControl87.TabIndex = 57;
			this.SquareControl87.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// SquareControl88
			// 
			this.SquareControl88.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SquareControl88.BackgroundImage")));
			this.SquareControl88.Column = ((short)(7));
			this.SquareControl88.CurrentStatus = Othello.SquareStatus.Empty;
			this.SquareControl88.ImagesList = this.SquareImages;
			this.SquareControl88.IsBlack = false;
			this.SquareControl88.IsPossible = false;
			this.SquareControl88.IsWhite = false;
			this.SquareControl88.Location = new System.Drawing.Point(208, 16);
			this.SquareControl88.Name = "SquareControl88";
			this.SquareControl88.Row = ((short)(7));
			this.SquareControl88.Size = new System.Drawing.Size(24, 24);
			this.SquareControl88.TabIndex = 56;
			this.SquareControl88.Click += new System.EventHandler(this.othelloSquare_click);
			// 
			// lblA
			// 
			this.lblA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblA.Location = new System.Drawing.Point(40, 208);
			this.lblA.Name = "lblA";
			this.lblA.Size = new System.Drawing.Size(24, 24);
			this.lblA.TabIndex = 64;
			this.lblA.Text = "A";
			this.lblA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblB
			// 
			this.lblB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblB.Location = new System.Drawing.Point(64, 208);
			this.lblB.Name = "lblB";
			this.lblB.Size = new System.Drawing.Size(24, 24);
			this.lblB.TabIndex = 65;
			this.lblB.Text = "B";
			this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblC
			// 
			this.lblC.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblC.Location = new System.Drawing.Point(88, 208);
			this.lblC.Name = "lblC";
			this.lblC.Size = new System.Drawing.Size(24, 24);
			this.lblC.TabIndex = 66;
			this.lblC.Text = "C";
			this.lblC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblD
			// 
			this.lblD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblD.Location = new System.Drawing.Point(112, 208);
			this.lblD.Name = "lblD";
			this.lblD.Size = new System.Drawing.Size(24, 24);
			this.lblD.TabIndex = 67;
			this.lblD.Text = "D";
			this.lblD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblE
			// 
			this.lblE.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblE.Location = new System.Drawing.Point(136, 208);
			this.lblE.Name = "lblE";
			this.lblE.Size = new System.Drawing.Size(24, 24);
			this.lblE.TabIndex = 68;
			this.lblE.Text = "E";
			this.lblE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblF
			// 
			this.lblF.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblF.Location = new System.Drawing.Point(160, 208);
			this.lblF.Name = "lblF";
			this.lblF.Size = new System.Drawing.Size(24, 24);
			this.lblF.TabIndex = 69;
			this.lblF.Text = "F";
			this.lblF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblG
			// 
			this.lblG.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblG.Location = new System.Drawing.Point(184, 208);
			this.lblG.Name = "lblG";
			this.lblG.Size = new System.Drawing.Size(24, 24);
			this.lblG.TabIndex = 70;
			this.lblG.Text = "G";
			this.lblG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblH
			// 
			this.lblH.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblH.Location = new System.Drawing.Point(208, 208);
			this.lblH.Name = "lblH";
			this.lblH.Size = new System.Drawing.Size(24, 24);
			this.lblH.TabIndex = 71;
			this.lblH.Text = "H";
			this.lblH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl1
			// 
			this.lbl1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lbl1.Location = new System.Drawing.Point(16, 184);
			this.lbl1.Name = "lbl1";
			this.lbl1.Size = new System.Drawing.Size(24, 24);
			this.lbl1.TabIndex = 72;
			this.lbl1.Text = "1";
			this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl2
			// 
			this.lbl2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lbl2.Location = new System.Drawing.Point(16, 160);
			this.lbl2.Name = "lbl2";
			this.lbl2.Size = new System.Drawing.Size(24, 24);
			this.lbl2.TabIndex = 73;
			this.lbl2.Text = "2";
			this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl3
			// 
			this.lbl3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lbl3.Location = new System.Drawing.Point(16, 136);
			this.lbl3.Name = "lbl3";
			this.lbl3.Size = new System.Drawing.Size(24, 24);
			this.lbl3.TabIndex = 74;
			this.lbl3.Text = "3";
			this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl4
			// 
			this.lbl4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lbl4.Location = new System.Drawing.Point(16, 112);
			this.lbl4.Name = "lbl4";
			this.lbl4.Size = new System.Drawing.Size(24, 24);
			this.lbl4.TabIndex = 75;
			this.lbl4.Text = "4";
			this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl5
			// 
			this.lbl5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lbl5.Location = new System.Drawing.Point(16, 88);
			this.lbl5.Name = "lbl5";
			this.lbl5.Size = new System.Drawing.Size(24, 24);
			this.lbl5.TabIndex = 76;
			this.lbl5.Text = "5";
			this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl6
			// 
			this.lbl6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lbl6.Location = new System.Drawing.Point(16, 64);
			this.lbl6.Name = "lbl6";
			this.lbl6.Size = new System.Drawing.Size(24, 24);
			this.lbl6.TabIndex = 77;
			this.lbl6.Text = "6";
			this.lbl6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl7
			// 
			this.lbl7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lbl7.Location = new System.Drawing.Point(16, 40);
			this.lbl7.Name = "lbl7";
			this.lbl7.Size = new System.Drawing.Size(24, 24);
			this.lbl7.TabIndex = 78;
			this.lbl7.Text = "7";
			this.lbl7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbl8
			// 
			this.lbl8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lbl8.Location = new System.Drawing.Point(16, 16);
			this.lbl8.Name = "lbl8";
			this.lbl8.Size = new System.Drawing.Size(24, 24);
			this.lbl8.TabIndex = 79;
			this.lbl8.Text = "8";
			this.lbl8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 233);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(384, 16);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 80;
			this.statusBar.Text = "Έτοιμο";
			// 
			// lblNextMove
			// 
			this.lblNextMove.Location = new System.Drawing.Point(248, 176);
			this.lblNextMove.Name = "lblNextMove";
			this.lblNextMove.Size = new System.Drawing.Size(128, 16);
			this.lblNextMove.TabIndex = 81;
			this.lblNextMove.Text = "Επόμενη κίνηση:";
			// 
			// txtInput
			// 
			this.txtInput.AcceptsReturn = true;
			this.txtInput.Location = new System.Drawing.Point(248, 192);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(80, 20);
			this.txtInput.TabIndex = 82;
			this.txtInput.Text = "";
			this.txtInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInput_KeyPress);
			// 
			// btnGo
			// 
			this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
			this.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGo.Location = new System.Drawing.Point(328, 192);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(48, 20);
			this.btnGo.TabIndex = 84;
			this.btnGo.Text = "OK";
			this.btnGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// groupScore
			// 
			this.groupScore.Controls.Add(this.lblBlack);
			this.groupScore.Controls.Add(this.lblWhite);
			this.groupScore.Controls.Add(this.lblBlackScore);
			this.groupScore.Controls.Add(this.lblWhiteScore);
			this.groupScore.Location = new System.Drawing.Point(248, 16);
			this.groupScore.Name = "groupScore";
			this.groupScore.Size = new System.Drawing.Size(128, 72);
			this.groupScore.TabIndex = 89;
			this.groupScore.TabStop = false;
			this.groupScore.Text = "Βαθμολογία";
			// 
			// lblBlack
			// 
			this.lblBlack.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblBlack.ForeColor = System.Drawing.Color.Navy;
			this.lblBlack.Location = new System.Drawing.Point(72, 24);
			this.lblBlack.Name = "lblBlack";
			this.lblBlack.Size = new System.Drawing.Size(48, 16);
			this.lblBlack.TabIndex = 90;
			this.lblBlack.Text = "Μαύρα";
			this.lblBlack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblWhite
			// 
			this.lblWhite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblWhite.ForeColor = System.Drawing.Color.Navy;
			this.lblWhite.Location = new System.Drawing.Point(8, 24);
			this.lblWhite.Name = "lblWhite";
			this.lblWhite.Size = new System.Drawing.Size(48, 16);
			this.lblWhite.TabIndex = 89;
			this.lblWhite.Text = "Λευκά";
			this.lblWhite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblBlackScore
			// 
			this.lblBlackScore.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblBlackScore.ForeColor = System.Drawing.Color.Navy;
			this.lblBlackScore.Location = new System.Drawing.Point(72, 40);
			this.lblBlackScore.Name = "lblBlackScore";
			this.lblBlackScore.Size = new System.Drawing.Size(48, 16);
			this.lblBlackScore.TabIndex = 92;
			this.lblBlackScore.Text = "00";
			this.lblBlackScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblWhiteScore
			// 
			this.lblWhiteScore.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.lblWhiteScore.ForeColor = System.Drawing.Color.Navy;
			this.lblWhiteScore.Location = new System.Drawing.Point(8, 40);
			this.lblWhiteScore.Name = "lblWhiteScore";
			this.lblWhiteScore.Size = new System.Drawing.Size(48, 16);
			this.lblWhiteScore.TabIndex = 91;
			this.lblWhiteScore.Text = "00";
			this.lblWhiteScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpTurn
			// 
			this.grpTurn.Controls.Add(this.lblTurn);
			this.grpTurn.Controls.Add(this.turnPiece);
			this.grpTurn.Location = new System.Drawing.Point(248, 96);
			this.grpTurn.Name = "grpTurn";
			this.grpTurn.Size = new System.Drawing.Size(128, 48);
			this.grpTurn.TabIndex = 92;
			this.grpTurn.TabStop = false;
			this.grpTurn.Text = "Τρέχουσα σειρά";
			// 
			// lblTurn
			// 
			this.lblTurn.Location = new System.Drawing.Point(8, 16);
			this.lblTurn.Name = "lblTurn";
			this.lblTurn.Size = new System.Drawing.Size(72, 24);
			this.lblTurn.TabIndex = 1;
			this.lblTurn.Text = "(κανείς)";
			this.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// turnPiece
			// 
			this.turnPiece.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("turnPiece.BackgroundImage")));
			this.turnPiece.Column = ((short)(0));
			this.turnPiece.CurrentStatus = Othello.SquareStatus.Empty;
			this.turnPiece.ImagesList = this.SquareImages;
			this.turnPiece.IsBlack = false;
			this.turnPiece.IsPossible = false;
			this.turnPiece.IsWhite = false;
			this.turnPiece.Location = new System.Drawing.Point(88, 16);
			this.turnPiece.Name = "turnPiece";
			this.turnPiece.Row = ((short)(0));
			this.turnPiece.Size = new System.Drawing.Size(24, 24);
			this.turnPiece.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(384, 249);
			this.Controls.Add(this.SquareControl11);
			this.Controls.Add(this.SquareControl18);
			this.Controls.Add(this.SquareControl17);
			this.Controls.Add(this.SquareControl16);
			this.Controls.Add(this.SquareControl15);
			this.Controls.Add(this.SquareControl14);
			this.Controls.Add(this.SquareControl13);
			this.Controls.Add(this.SquareControl12);
			this.Controls.Add(this.SquareControl21);
			this.Controls.Add(this.SquareControl22);
			this.Controls.Add(this.SquareControl23);
			this.Controls.Add(this.SquareControl24);
			this.Controls.Add(this.SquareControl25);
			this.Controls.Add(this.SquareControl26);
			this.Controls.Add(this.SquareControl27);
			this.Controls.Add(this.SquareControl28);
			this.Controls.Add(this.SquareControl31);
			this.Controls.Add(this.SquareControl32);
			this.Controls.Add(this.SquareControl33);
			this.Controls.Add(this.SquareControl34);
			this.Controls.Add(this.SquareControl35);
			this.Controls.Add(this.SquareControl36);
			this.Controls.Add(this.SquareControl37);
			this.Controls.Add(this.SquareControl38);
			this.Controls.Add(this.SquareControl41);
			this.Controls.Add(this.SquareControl42);
			this.Controls.Add(this.SquareControl43);
			this.Controls.Add(this.SquareControl44);
			this.Controls.Add(this.SquareControl45);
			this.Controls.Add(this.SquareControl46);
			this.Controls.Add(this.SquareControl47);
			this.Controls.Add(this.SquareControl48);
			this.Controls.Add(this.SquareControl51);
			this.Controls.Add(this.SquareControl52);
			this.Controls.Add(this.SquareControl53);
			this.Controls.Add(this.SquareControl54);
			this.Controls.Add(this.SquareControl55);
			this.Controls.Add(this.SquareControl56);
			this.Controls.Add(this.SquareControl57);
			this.Controls.Add(this.SquareControl58);
			this.Controls.Add(this.SquareControl61);
			this.Controls.Add(this.SquareControl62);
			this.Controls.Add(this.SquareControl63);
			this.Controls.Add(this.SquareControl64);
			this.Controls.Add(this.SquareControl65);
			this.Controls.Add(this.SquareControl66);
			this.Controls.Add(this.SquareControl67);
			this.Controls.Add(this.SquareControl68);
			this.Controls.Add(this.SquareControl71);
			this.Controls.Add(this.SquareControl72);
			this.Controls.Add(this.SquareControl73);
			this.Controls.Add(this.SquareControl74);
			this.Controls.Add(this.SquareControl75);
			this.Controls.Add(this.SquareControl76);
			this.Controls.Add(this.SquareControl77);
			this.Controls.Add(this.SquareControl78);
			this.Controls.Add(this.SquareControl81);
			this.Controls.Add(this.SquareControl82);
			this.Controls.Add(this.SquareControl83);
			this.Controls.Add(this.SquareControl84);
			this.Controls.Add(this.SquareControl85);
			this.Controls.Add(this.SquareControl86);
			this.Controls.Add(this.SquareControl87);
			this.Controls.Add(this.SquareControl88);
			this.Controls.Add(this.grpTurn);
			this.Controls.Add(this.groupScore);
			this.Controls.Add(this.btnGo);
			this.Controls.Add(this.txtInput);
			this.Controls.Add(this.lblNextMove);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.lbl8);
			this.Controls.Add(this.lbl7);
			this.Controls.Add(this.lbl6);
			this.Controls.Add(this.lbl5);
			this.Controls.Add(this.lbl4);
			this.Controls.Add(this.lbl3);
			this.Controls.Add(this.lbl2);
			this.Controls.Add(this.lbl1);
			this.Controls.Add(this.lblH);
			this.Controls.Add(this.lblG);
			this.Controls.Add(this.lblF);
			this.Controls.Add(this.lblE);
			this.Controls.Add(this.lblD);
			this.Controls.Add(this.lblC);
			this.Controls.Add(this.lblB);
			this.Controls.Add(this.lblA);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mnuMain;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Othello";
			this.groupScore.ResumeLayout(false);
			this.grpTurn.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Το σημείο εκκίνησης (entry point) της εφαρμογής.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			MainForm theMainForm = new MainForm();
			Application.Run(theMainForm);
		}

		/// <summary>
		/// Αλλάζει το κείμενο της Status Bar
		/// </summary>
		/// <param name="text">Το νέο κείμενο που θέλουμε να 
		/// εμφανιστεί στην Status Bar</param>
		void SetStatus(String text)
		{
			FormStatus = text;
			statusBar.Text = text;
		}

		/// <summary>
		/// Εκκινεί την επεξεργασία της κίνησης που επέλεξε ο παίκτης μέσω 
		/// ποντικιού ή πληκτρολογίου.
		/// </summary>
		/// <param name="row">Η γραμμή που επέλεξε ο παίκτης (μετρώντας από το 0).</param>
		/// <param name="col">Η στήλη που επέλεξε ο παίκτης (μετρώντας από το 0).</param>
		void ProcessMove(int row, int col)
		{
			if(theGame == null)		// έλεγχος αν υπάρχει τρέχον παιχνίδι
			{
				MessageBox.Show("Ξεκινήστε ένα νέο παιχνίδι πρώτα, επιλέγοντας Αρχείο -> Νέο παιχνίδι.", "Ξεκινήστε νέο παιχνίδι", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if(!theGame.ProcessMove(row, col))		// έλεγχος εγκυρότητας της κίνησης
				MessageBox.Show("Μη-έγκυρη κίνηση...", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
			{
				if(theGame != null) 
				{
					SetStatus("Περιμένετε...");
					theGame.MakeComputerMove();
					SetStatus("Τοποθετήστε ένα πιόνι...");
				}
			}
			txtInput.Text = "";		// Καθαρισμός του πεδίου εισαγωγής
			txtInput.Focus();		// Τοποθέτηση του focus στο πεδίο εισαγωγής για την επόμενη κίνηση
		}

		/// <summary>
		/// Εμφάνιση της φόρμας των πληροφοριών της εφαρμογής, όταν επιλεγεί η αντίστοιχη
		/// ένδειξη στο μενού.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void mnuHelpAbout_Click(object sender, System.EventArgs e)
		{
			AboutForm aboutForm = new AboutForm();	// δημιουργία νέου αντικειμένου φόρμας
			aboutForm.ShowDialog();					// εμφάνιση της φόρμας
		}

		/// <summary>
		/// Κλείνει την εφαρμογή, όταν επιλεγεί η αντίστοιχη
		/// ένδειξη στο μενού.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			System.Environment.Exit(0);		// επιστροφή 0 στο λειτουργικό σύστημα.
		}

		/// <summary>
		/// Ελέγχει και μεταφράζει την είσοδο του χρήστη, και καλεί την
		/// μέθοδο ProcessMove() για να ξεκινήσει η επεξεργασία της κίνησης του χρήστη
		/// όταν πατηθεί το αντίστοιχο κουμπί.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			if (txtInput.Text.Length != 2)		// έλεγχος μήκους της εισόδου
			{
				MessageBox.Show("Εισάγετε μία έγκυρη κίνηση (ένα γράμμα A-H και έναν αριθμό 1-8)", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if(		// έλεγχος εγκυρότητας της εισόδου (του χαρακτήρα - γράμμα και του χαρ. - αριθμού)
				(txtInput.Text.ToString().ToUpper()[0] >= 'A' && txtInput.Text.ToString().ToUpper()[0] <= 'H') &&
				(txtInput.Text[1] >= '1' && txtInput.Text[1] <= '8')
				)
			{
				// Υπολογισμός της στήλης από τον τακτικό αριθμό του χαρακτήρα
				int col = (int)txtInput.Text.ToString().ToUpper()[0] - (int)'A';
				// Υπολογισμός της γραμμής από τον τακτικό αριθμό του χαρακτήρα
				int row = txtInput.Text[1] - (int)'1';

				// Εκκίνηση της επεξεργασίας της εισόδου
				ProcessMove(row, col);
			}
			else	// μη-έγκυρη είσοδος
			{
				MessageBox.Show("Μη-έγκυρη κίνηση...", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// Ελέγχει κάθε χαρακτήρα που εισάγεται στο πεδίο εισόδου αν είναι το Enter,
		/// και καλεί την μέθοδο btnGo_Click() για έλεγχο εγκυρότητας.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void txtInput_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// Έλεγχος αν ήταν το Enter
			if(e.KeyChar == (char)13)
			{
				// ειδοποίηση ότι ο χαρακτήρας έχει χειριστεί
				e.Handled = true;
				// Κλήση μεθόδου για έλεγχο εγκυρότητας
				btnGo_Click(txtInput, new System.EventArgs());
			}
		}

		/// <summary>
		/// Ξεκινά ένα νέο παιχνίδι, όταν επιλεγεί η αντίστοιχη
		/// ένδειξη στο μενού.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void mnuNewGame_Click(object sender, System.EventArgs e)
		{
			// Δημιουργία ενός νέου αντικειμένου φόρμας για εισαγωγή
			// παραμέτρων για το νέο παιχνίδι
			NewGameForm newGameForm = new NewGameForm();
			
			// Έλεγχος αν στη φόρμα πατήθηκε το πλήκτρο ΟΚ
			if (newGameForm.ShowDialog(this) == DialogResult.OK)
			{
				// Αποσύνδεση από τα γεγονότα του προηγούμενου παιχνιδιού,
				// αν υπήρχε
				if (theGame!= null)
				{
					theGame.TurnChanged -= new TurnChangedEventHandler(TurnChanged);
					theGame.ScoreChanged -= new ScoreChangedEventHandler(ScoreChanged);
					theGame.NoValidMoves -= new NoValidMovesEventHandler(NoValidMovesWarning);
					theGame.GameOver -= new GameOverEventHandler(GameOver);
				}

				// Καθαρισμός της σκακιέρας
				foreach(IOthelloSquare[] row in Squares)
				{
					foreach(IOthelloSquare square in row)
					{
						square.CurrentStatus = SquareStatus.Empty;
					}
				}

				// Τοποθέτηση των αρχικών παιχνιδιών
				Squares[3][3].CurrentStatus = SquareStatus.White;
				Squares[4][4].CurrentStatus = SquareStatus.White;
				Squares[3][4].CurrentStatus = SquareStatus.Black;
				Squares[4][3].CurrentStatus = SquareStatus.Black;

				// Εύρεση αν παίζουν τώρα τα ’σπρα
				bool WhitePlays =(newGameForm.rdbWhite.Checked && newGameForm.rdbHumanFirst.Checked) ||
					(newGameForm.rdbBlack.Checked && newGameForm.rdbComputerFirst.Checked);
				// Δημιουργία νέου παιχνιδιού
				theGame = new OthelloGame(newGameForm.rdbHumanFirst.Checked, WhitePlays, Squares, (int)newGameForm.numDif.Value);
				// Σύνδεση με τα γεγονότα του νέου παιχνιδιού
				theGame.TurnChanged += new TurnChangedEventHandler(TurnChanged);
				theGame.ScoreChanged += new ScoreChangedEventHandler(ScoreChanged);
				theGame.NoValidMoves += new NoValidMovesEventHandler(NoValidMovesWarning);
				theGame.GameOver += new GameOverEventHandler(GameOver);

				// Ανανέωση της ένδειξης της τρέχουσας σειράς
				TurnChanged(this, EventArgs.Empty);
				// Ανανέωση της ένδειξης του σκορ
				ScoreChanged(this, EventArgs.Empty);

				if(newGameForm.rdbComputerFirst.Checked) theGame.MakeComputerMove();
			}

		}

		/// <summary>
		/// Η μέθοδος αυτή καλείται όταν πληρούνται οι συνθήκες
		/// λήξης του παιχνιδιού, και ειδοποιείται ο παίκτης σχετικά
		/// με το νικητή της παρτίδας.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void GameOver(object sender, EventArgs e)
		{
			// Αποσύνδεση από τα γεγονότα του προηγούμενου παιχνιδιού
			if (theGame!= null)
			{
				theGame.TurnChanged -= new TurnChangedEventHandler(TurnChanged);
				theGame.ScoreChanged -= new ScoreChangedEventHandler(ScoreChanged);
				theGame.NoValidMoves -= new NoValidMovesEventHandler(NoValidMovesWarning);
				theGame.GameOver -= new GameOverEventHandler(GameOver);
			}

			// Δημιουργία της συμβολοσειράς για την ενημέρωση του χρήστη
			String s = "Τέλος παιχνιδιού. ";
			if(theGame.BlackScore > theGame.WhiteScore)
				s = s + "Νικητής: Μαύρα";
			else if (theGame.BlackScore < theGame.WhiteScore)
				s = s + "Νικητής: Λευκά";
			else
				s = s + "Ισοπαλία.";

			// Ανανέωση της ένδειξης της σειράς και της Status Bar
			lblTurn.Text = "(κανείς)";
			turnPiece.CurrentStatus = SquareStatus.Empty;
			SetStatus("Επιλέξτε Αρχείο -> Νέο παιχνίδι");

			// Εμφάνιση της ειδοποίησης
			MessageBox.Show(s, "Τέλος παιχνιδιού", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// "Διαγραφή" του παλιού παιχνιδιού
			theGame = null;
		}

		/// <summary>
		/// Η μέθοδος αυτή καλείται όταν δεν υπάρχουν έγκυρες κινήσεις
		/// για τον τρέχοντα παίκτη, οπότε και ειδοποιείται ο χρήστης.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void NoValidMovesWarning(object sender, EventArgs e) 
		{
			// Εμφάνιση ειδοποίησης στην Status Bar
			if(!theGame.WhitesTurn)	// έλεγχος για τη σειρά του τρέχοντα παίκτη
				MessageBox.Show("Δεν υπάρχουν έγκυρες κινήσεις για τα Μαύρα. Τα Λευκά ξαναπαίζουν.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show("Δεν υπάρχουν έγκυρες κινήσεις για τα Λευκά. Τα Μαύρα ξαναπαίζουν.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// Η μέθοδος αυτή καλείται όταν αλλάζει το σκορ, και
		/// ανανεώνει την ένδειξη στη φόρμα.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void ScoreChanged(object sender, EventArgs e)
		{
			// Αλλαγή της ένδειξης στη φόρμα
			lblWhiteScore.Text = theGame.WhiteScore.ToString();
			lblBlackScore.Text = theGame.BlackScore.ToString();
		}

		/// <summary>
		/// Η μέθοδος αυτή καλείται όταν αλλάζει η σειρά,
		/// και ανανεώνεται η αντίστοιχη ένδειξη στη φόρμα.
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void TurnChanged(object sender, EventArgs e) 
		{
			// Αλλαγή της ένδειξης στη φόρμα
			if(theGame.WhitesTurn)	// έλεγχος τρέχουσας σειράς
			{
				// Αλλαγή του κειμένου
				lblTurn.Text = "Λευκά";
				// Αλλαγή της γραφικής ένδειξης
				turnPiece.CurrentStatus = SquareStatus.White;
			}
			else
			{
				// Αλλαγή του κειμένου
				lblTurn.Text = "Μαύρα";
				// Αλλαγή της γραφικής ένδειξης
				turnPiece.CurrentStatus = SquareStatus.Black;
			}
		}

		/// <summary>
		/// Η μέθοδος αυτή καλείται όταν ο χρήστης εισάγει
		/// μία κίνηση κάνοντας κλικ στο αντίστοιχο τετράγωνο.
		/// Ξεκινάει την επεξεργασία της κίνησης καλώντας τη μέθοδο ProcessMove().
		/// </summary>
		/// <param name="sender">Ο αποστολέας του γεγονότος (το αντικείμενο που προκάλεσε το γεγονός).</param>
		/// <param name="e">Ορίσματα του γεγονότος.</param>
		private void othelloSquare_click(object sender, System.EventArgs e)
		{
			OthelloSquareControl piece = (OthelloSquareControl)sender;
			ProcessMove(piece.Row, piece.Column);
		}
	}
}
