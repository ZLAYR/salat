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
    class SpielfeldAlternativ
    {
        static int[,] spielfeldSpieler1 = new int[10, 10];
        static int[,] spielfeldSpieler2 = new int[10, 10];
        static int[,] spielfeldAktuell = new int[10, 10];
        static bool spieler1istDran = true;
        static bool ersteRundeSpieler1 = true;
        static bool ersteRundeSpieler2 = true;
        static PictureBox[,] pb_Spielfeld = new PictureBox[10, 10];
        static Form HorizontalOderVertikal = new Form();
        static RadioButton rb_Horizontal = new RadioButton();
        static RadioButton rb_Vertikal = new RadioButton();
        static Button bttn_bestaetigen = new Button();
        static Form FormSpielerwechsel = new Form();
        static Button bttn_Weiter = new Button();
        static ComboBox cb_schiffauswahl = new ComboBox();
        static bool xAusrichtung = true;
        static int laenge = 3;// test
        static int z = 0;


        static Button bttn_TEST = new Button();
        //Schiff aktuellesSchiff = new Schiff();

        public void FormHoV()
        {
            HorizontalOderVertikal.Text = "Horizontal oder Vertikal";
            HorizontalOderVertikal.MinimumSize = new Size(500, 300);
            HorizontalOderVertikal.MaximumSize = new Size(500, 300);
            HorizontalOderVertikal.StartPosition = FormStartPosition.CenterScreen;
            HorizontalOderVertikal.ControlBox = false;
            HorizontalOderVertikal.FormBorderStyle = FormBorderStyle.FixedSingle;

            rb_Horizontal.Text = "Horizontal";
            rb_Horizontal.Location = new Point(25, 150);
            rb_Horizontal.Checked = true;
            HorizontalOderVertikal.Controls.Add(rb_Horizontal);

            rb_Vertikal.Text = "Vertikal";
            rb_Vertikal.Location = new Point(175, 150);
            rb_Horizontal.Checked = false;
            HorizontalOderVertikal.Controls.Add(rb_Vertikal);

            bttn_bestaetigen.Text = "Bestaetigen";
            bttn_bestaetigen.Location = new Point(125, 200);
            bttn_bestaetigen.Size = new Size(50, 50);
            bttn_bestaetigen.Click += new EventHandler(Uebergeben);
            HorizontalOderVertikal.Controls.Add(bttn_bestaetigen);
            
            cb_schiffauswahl.Location = new Point(100,100);
            cb_schiffauswahl.Size = new Size(150,50);
            cb_schiffauswahl.Items.Add("Uboot");
            cb_schiffauswahl.Items.Add("Zerstoerer");
            cb_schiffauswahl.Items.Add("Kreuzer");
            cb_schiffauswahl.Items.Add("Flugzeugtraeger");
            cb_schiffauswahl.DropDownStyle = ComboBoxStyle.DropDownList;
            HorizontalOderVertikal.Controls.Add(cb_schiffauswahl);
        }

        public void FormSW()
        {
            FormSpielerwechsel.Text = "Spielerwechsel";
            FormSpielerwechsel.ControlBox = false;
            FormSpielerwechsel.FormBorderStyle = FormBorderStyle.FixedSingle;
            FormSpielerwechsel.MinimumSize = new Size(1000,1000);
            FormSpielerwechsel.MaximumSize = new Size(1000,1000);
            FormSpielerwechsel.StartPosition = FormStartPosition.CenterScreen;

            bttn_bestaetigen.Text = "Bestaetigen";
            bttn_bestaetigen.Location = new Point(100, 400);
            bttn_bestaetigen.Size = new Size(200, 200);
            bttn_bestaetigen.Click += new EventHandler(Bestaetigen);
            FormSpielerwechsel.Controls.Add(bttn_bestaetigen);

        }

        void Bestaetigen(object sender, EventArgs e)
        {
            Spielerwechsel();
            if (spieler1istDran == true)
            {
                spieler1istDran = false;
                spielfeldAktuell = spielfeldSpieler2;
            }
            else if (spieler1istDran == false)
            {
                spieler1istDran = true;
                spielfeldAktuell = spielfeldSpieler1;
            }
            //SpielfeldNullFuellen();
        }

        //in progress
        void Spielerwechsel()
        {
           /* // speichert das aktuelle Feld im Feld des jeweiligen Spielers ab
            if (spieler1istDran == true)
            {
                spielfeldAktuell = spielfeldSpieler1;
            }
            else
            {
                spielfeldAktuell = spielfeldSpieler2;
            }

            for (int y = 0; y < pb_Spielfeld.GetLength(1); y++)
            {
                for (int x = 0; x < pb_Spielfeld.GetLength(0);x++)
                {                                                       //0 (gray): Feld leer, 1 (black): Feld befüllt, 2 (red): kapputes Schiff
                    if (pb_Spielfeld[x, y].BackColor == Color.Gray)
                    {
                        spielfeldAktuell[x, y] = 0;
                    }
                    else if (pb_Spielfeld[x, y].BackColor == Color.Black)
                    {
                        spielfeldAktuell[x, y] = 1;
                    }
                    else if (pb_Spielfeld[x, y].BackColor == Color.Red)
                    {
                        spielfeldAktuell[x, y] = 2;
                    }
                }
            }*/
            //
            if (spieler1istDran == true)
            {
                spielfeldSpieler1 = spielfeldAktuell;
                spielfeldAktuell = spielfeldSpieler2;
            }
            else
            {
                spielfeldSpieler2 = spielfeldAktuell;
                spielfeldAktuell = spielfeldSpieler1;
            }
            



            //funktioniert!!!
            #region fuellt das pb_Spielfeld mit den Farben des aktuellen Spielers
            for(int y = 0; y < pb_Spielfeld.GetLength(1); y++)
            {
                for(int x = 0; x < pb_Spielfeld.GetLength(0); x++)
                {
                    pb_Spielfeld[x, y].BackColor = Farbe(x, y);
                }
            }
            #endregion
            FormSpielerwechsel.Hide();
        }

        void Uebergeben(object sender, EventArgs e)
        {
            if (rb_Horizontal.Checked == true)
            {
                xAusrichtung = true;
            }
            else
            {
                xAusrichtung = false;
            }
            HorizontalOderVertikal.Hide();

        }

        int x = 0;
        int y = 0;
        
        public void SpielfeldNullFuellen()
        {
            x = 0;
            y = 0;
            while (y < spielfeldSpieler1.GetLength(1))
            {
                while (x < spielfeldSpieler1.GetLength(0))
                {
                    spielfeldSpieler1[x, y] = 0;
                    spielfeldSpieler2[x, y] = 0;
                    x++;
                }
                y++;
            }
        }

        //Testwerte
        public void TestMethode()
        {
            spielfeldSpieler1[0, 0] = 1;
            spielfeldSpieler1[0, 1] = 2;

            spielfeldSpieler2[0, 5] = 1;
            spielfeldSpieler2[0, 4] = 2;
        }
        //Testwerte

        public PictureBox[,] Ausgabe()
        {
            int positionX = 20;
            int positionY = 20;
            int verschiebung = 51;
            x = 0;
            y = 0;

            while (y < pb_Spielfeld.GetLength(1))
            {
                while (x < pb_Spielfeld.GetLength(0))
                {
                    pb_Spielfeld[x, y] = new PictureBox();
                    pb_Spielfeld[x, y].Size = new Size(50, 50);
                    pb_Spielfeld[x, y].Location = new Point(positionX, positionY);
                    pb_Spielfeld[x, y].Click += new EventHandler(Druecken);
                    pb_Spielfeld[x, y].BackColor = Farbe(x,y);

                    positionX = positionX + verschiebung;
                    x++;
                }
                positionY = positionY + verschiebung;
                positionX = 20;
                x = 0;
                y++;
            }
            return pb_Spielfeld;
        }

        Color Farbe(int localX, int localY)
        {
            if (spieler1istDran == true)
            {
                spielfeldAktuell = spielfeldSpieler1;
            }
            else
            {
                spielfeldAktuell = spielfeldSpieler2;
            }

            if (spielfeldAktuell[localX, localY] == 0 || spielfeldAktuell[localX, localY] == 1 || spielfeldAktuell[localX, localY] == 2)  //0: Feld leer, 1: Feld befüllt, 2: kapputes Schiff
            {
                if (spielfeldAktuell[localX, localY] == 0)
                {
                    return Color.Gray;
                }
                else if (spielfeldAktuell[localX, localY] == 1)
                {
                    return Color.Black;
                }
                else
                {
                    return Color.Red;
                }
            }
            else
            {
                MessageBox.Show("falscher Wert im Array");
                return Color.DeepPink;
            }
        }

        void Druecken(object sender, EventArgs e)
        {
            int posY = 0;
            int posX = 0;
            bool check = false;
            while (pb_Spielfeld[posX, posY] != ((PictureBox)sender))
            {
                while (posX < 10)
                {
                    if (pb_Spielfeld[posX, posY] == ((PictureBox)sender))
                    {
                        check = true;
                        break;
                    }
                    posX++;

                }
                if (check == true)
                {
                    break;
                }
                posX = 0;
                posY++;
            }

            if (spieler1istDran == true)
            {
                if (ersteRundeSpieler1 == true)
                {
                    
                    setzen(posX, posY);
                    if (z < 11)
                    {
                        ersteRundeSpieler1 = false;
                    }
                    z++;
                }
                else
                {
                    Schuss(posX, posY);
                }
            }
            else
            {
                if (ersteRundeSpieler2 == true)
                {
                    setzen(posX, posY);
                    ersteRundeSpieler2 = false;
                }
                else
                {
                    Schuss(posX, posY);
                }
            }
        }
        //
        public void setzen(int posX, int posY)
        {
            HorizontalOderVertikal.Show();


            if (xAusrichtung == true)
            {
                if (posX + laenge >= 0 && posX + laenge < spielfeldAktuell.GetLength(0))
                {
                    for (int i = 0; i < laenge; i++)
                    {
                        spielfeldAktuell[posX, posY] = 1;
                        posX++;
                    }
                }
            }
            else if (xAusrichtung == false)
            {
                if (xAusrichtung == true)
                    if (posY + laenge >= 0 && posY + laenge < spielfeldAktuell.GetLength(1))
                    {
                        for (int i = 0; i < laenge; i++)
                        {
                            spielfeldAktuell[posX, posY] = 1;
                            posY++;
                        }
                    }
            }
            if (spieler1istDran == true)
            {
                spielfeldSpieler1 = spielfeldAktuell;
            }
            else
            {
                spielfeldSpieler2 = spielfeldAktuell;
            }


        }

        public void Schuss(int posX, int posY)
        {
            int[,] gegnerischesSpielfeld = new int[10, 10];

            if (spieler1istDran == true)
            {
                spielfeldAktuell = spielfeldSpieler1;
                gegnerischesSpielfeld = spielfeldSpieler2;
            }
            else
            {
                spielfeldAktuell = spielfeldSpieler2;
                gegnerischesSpielfeld = spielfeldSpieler1;
            }

            if (gegnerischesSpielfeld[posX, posY] == 1)
            {
                gegnerischesSpielfeld[posX, posY] = 2;
                MessageBox.Show("Treffer");
                FormSW();
                FormSpielerwechsel.Show();
            }
            else
            {
                MessageBox.Show("Kein Treffer");
                FormSW();
                FormSpielerwechsel.Show();
            }

            if (spieler1istDran == true)
            {
                spielfeldSpieler1 = gegnerischesSpielfeld;
            }
            else
            {
                spielfeldSpieler2 = gegnerischesSpielfeld;
            }

        }

        public void Gewinnabfrage()
        {
            int weristdran = 2;
            if (spieler1istDran == true)
            {
                weristdran = 1;
            }
            for (int i = 0; i < spielfeldAktuell.GetLength(0); i++)
            {
                for (int k = 0; k < spielfeldAktuell.GetLength(1); k++)
                {
                    if (spielfeldAktuell[i, k] == 1)
                    {
                        //spiel Geht weiter
                    }
                    else
                    {
                        MessageBox.Show("Spieler" + weristdran + "hat gewonnnen");
                    }
                }
            }
        }
    }
}