using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schiffe_versenken
{
    public partial class Form1 : Form
    {
        #region Objekte

        static Button bttn_HilfeOeffnen = new Button();
        static Button bttn_SpielfeldOeffnen = new Button();

        static Label lbl_HilfeText = new Label();
        static Button bttn_HilfeClose = new Button();
        
        static Form formHilfe = new Form();
        static Form formSpielfeld = new Form();

        static Button bttn_ZugBeendenSpieler1 = new Button();
        static Button bttn_ZugBeendenSpieler2 = new Button();

        static SpielfeldAlternativ spielfeld1 = new SpielfeldAlternativ();

        static bool spieler1IstAmZug = true;
        #endregion
        
        public Form1()
        {
            InitializeComponent();

            #region form einstellungen
            this.Text = "Schiffe versenken";
            this.MinimumSize = new System.Drawing.Size(750, 650);
            this.MaximumSize = new System.Drawing.Size(750, 650);
            this.BackColor = Color.Black;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            formHilfe.Text = "Hilfe";
            formHilfe.MinimumSize = new System.Drawing.Size(750, 650);
            formHilfe.MaximumSize = new System.Drawing.Size(750, 650);
            formHilfe.BackColor = Color.Black;
            formHilfe.StartPosition = FormStartPosition.CenterScreen;
            formHilfe.ControlBox = false;
            formHilfe.FormBorderStyle = FormBorderStyle.FixedSingle;

            formSpielfeld.Text = "Spielfeld";
            formSpielfeld.MinimumSize = new System.Drawing.Size(750, 650);
            formSpielfeld.MaximumSize = new System.Drawing.Size(750, 650);
            formSpielfeld.BackColor = Color.Black;
            formSpielfeld.StartPosition = FormStartPosition.CenterScreen;
            formSpielfeld.ControlBox = false;
            formSpielfeld.FormBorderStyle = FormBorderStyle.FixedSingle;
            #endregion

            MenueOberflaeche();
            spielfeld1.FormHoV();
            spielfeld1.SpielfeldNullFuellen();
            spielfeld1.TestMethode();

            Ausgeben(spielfeld1.Ausgabe());
        }
        
        public void Ausgeben(PictureBox[,] arrayBuffer)
        {
            int x = 0;
            int y = 0;

            while (y < arrayBuffer.GetLength(1))
            {
                while (x < arrayBuffer.GetLength(0))
                {
                    formSpielfeld.Controls.Add(arrayBuffer[x,y]);
                    x++;
                }
                x = 0;
                y++;
            }

        }
        

        #region Menue
        void MenueOberflaeche()
        {
            bttn_SpielfeldOeffnen.Size = new Size(400, 100);
            bttn_SpielfeldOeffnen.Location = new Point(150, 450);
            bttn_SpielfeldOeffnen.Text = "Spielfeld";
            bttn_SpielfeldOeffnen.BackColor = Color.White;
            bttn_SpielfeldOeffnen.Font = new Font(Font.FontFamily.Name, 25);
            bttn_SpielfeldOeffnen.Click += new EventHandler(SpielfeldOeffnen);
            Controls.Add(bttn_SpielfeldOeffnen);


            bttn_HilfeOeffnen.Size = new Size(400, 100);
            bttn_HilfeOeffnen.Location = new Point(150, 450);
            bttn_HilfeOeffnen.Text = "Hilfe / Optionen";
            bttn_HilfeOeffnen.BackColor = Color.White;
            bttn_HilfeOeffnen.Font = new Font(Font.FontFamily.Name, 25);
            bttn_HilfeOeffnen.Click += new EventHandler(HilfeOeffnen);
            Controls.Add(bttn_HilfeOeffnen);
        }

        void SpielfeldOeffnen(object sender, EventArgs e)
        {
            formSpielfeld.Show();
            this.Hide();
        }

        void HilfeOeffnen(object sender, EventArgs e)
        {
            formHilfe.Show();
            this.Hide();
        }
        #endregion

        #region Hilfe
        void HilfeOberflaeche()
        {
            lbl_HilfeText.Size = new Size(200, 200);
            lbl_HilfeText.Location = new Point(25, 25);
            lbl_HilfeText.Text = "Hilfe-Text bitte einfuegen";
            formHilfe.Controls.Add(lbl_HilfeText);

            bttn_HilfeClose.Size = new Size(400, 100);
            bttn_HilfeClose.Location = new Point(150, 450);
            bttn_HilfeClose.Text = "Schliessen";
            bttn_HilfeClose.Font = new Font(Font.FontFamily.Name, 25);
            bttn_HilfeClose.BackColor = Color.White;
            bttn_HilfeClose.Click += new EventHandler(HilfeSchliessen);
            formHilfe.Controls.Add(bttn_HilfeClose);
        }

        void HilfeSchliessen(object sender, EventArgs e)
        {
            formHilfe.Hide();
            this.Show();
        }
        #endregion
        
    }
}