using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Policko[,] sudoku = new Policko[9,9];//pole 9*9 buttonů s hodnota
        private int[,] sudokuVysledek = new int[9, 9];
        private void Form1_Load(object sender, EventArgs e)//při načtení se vytvoří pole
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = new Policko();
                    sudoku[i, j].Location = new Point(40 * j + 200, 40 * i + 70);
                    sudoku[i, j].Size = new Size(43, 43);
                    sudoku[i, j].x = i;
                    sudoku[i, j].y = j;
                    sudoku[i, j].Click += new System.EventHandler(Sudoku_Click);
                    if((((i<3)||(i>5))&&((j < 3) || (j > 5)))|| (i>2&&i<6&&j>2&&j<6))
                    {
                        sudoku[i, j].BackColor = Color.LightGray;
                    }
                    Controls.Add(sudoku[i, j]);
                }
            }
        }

        private void Sudoku_Click(object sender, EventArgs e)//hledá nejbližší číslo, pro které jsou splněny pravidla
        {
            int i = 1;
            while (!((SplnenaPravidla(SudokuDoPole(), ((sender as Policko).cislo + i) % 10, (sender as Policko).x, (sender as Policko).y)) || ((sender as Policko).cislo + i) % 10 == 0))
            {
                i++;
            }
            (sender as Policko).Cislo(((sender as Policko).cislo + i) % 10);

        }

        public int[,] SudokuDoPole()//vloží hodnoty políček do pole
        {
            int[,] pole = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    pole[i, j] = sudoku[i, j].cislo;
                }
            }
            return pole;
        }

        public void PoleDoSudoku(int[,] pole)//přepíše hodnoty pole zpět do sudoku
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j].Cislo(pole[i, j]);
                }
            }
        }

        private bool SplnenaPravidla(int[,] pole, int cislo,int x, int y)//kontroluje jestli jsou splněna pravidla sudoku
        {
            for (int i = 0; i < 9; i++)
            {
                if (pole[i, y] == cislo)
                {
                    return false;
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (pole[x, i] == cislo)
                {
                    return false;
                }
            }
            decimal sloupec = x / 3;
            decimal radek = y / 3;
            for (int i = (int)(Math.Floor(sloupec))*3;i< (int)(Math.Floor(sloupec))*3 + 3; i++)
            {
                for (int j = (int)(Math.Floor(radek))*3; j < (int)(Math.Floor(radek))*3 + 3; j++)
                {
                    if (pole[i, j] == cislo)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool VyresSudoku(int[,] puvodniSudoku)//rekurzivní metoda pro řešení
        {
            int x = 0;
            int y= 0;
            if(!NajdiNulu(out x,out y,puvodniSudoku))//pokud nenajde nulu, tak je sudoku vyřešené
            {
                sudokuVysledek = puvodniSudoku;
                return true;
            }

            for (int i = 1; i <= 9; i++)//zkouší všech devět cifer
            {

                if (SplnenaPravidla(puvodniSudoku,i,x,y))// pokud číslo splňuje pravidla, tak ho doplní do pole a pošle ho do funkce VyresSudoku
                {
                    
                    puvodniSudoku[x, y] = i;
                    if (VyresSudoku(puvodniSudoku))//při nalezení řešení (vrázení true poprvé) začnou všechny funkce automaticky vracet true
                    {
                        return true;
                    }
                    puvodniSudoku[x, y] = 0;
                }
                
            }
            return false;
        }

        private bool NajdiNulu(out int x, out int y, int[,] puvodniSudoku)//hledá nulu v poli, její souřadnice vrací do x,y
        {
            y = 0;//program bez přiřazení y hlási error
            for (x = 0; x < 9; x++)
            {
                for (y = 0; y < 9; y++)
                {
                    if (puvodniSudoku[x, y] == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void vyresit_Click(object sender, EventArgs e)
        {
            
            sudokuVysledek = SudokuDoPole();//hodnoty z políček se vloží do pole
            VyresSudoku(sudokuVysledek);//zavolá metodu na řešení sudoku
            if(RovnostPoli(SudokuDoPole(), sudokuVysledek)!)
            {
                MessageBox.Show("sudoku nemá řešení");
            }
            PoleDoSudoku(sudokuVysledek);//vysledek zapsán do políček
        }
        private bool RovnostPoli(int[,] prvni, int[,] druhe)//zkontroluje, jestli jsou pole stejná
        {
            if(prvni.Length!=druhe.Length)
            {
                return false;
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(prvni[i,j]!=druhe[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void reset_Click(object sender, EventArgs e)//nastaví hodnoty celé hrací plochy na 0 (žádné číslo)
        {
            foreach(Policko pole in sudoku)
            {
                pole.Cislo(0);
            }
        }


    }
    
    public class Policko : Button//button rozšířený o hodnotu a souřadnice v poli
    {
        public int cislo = 0;
        public void Cislo(int value)//cislo upravuji přes funkci, metoda get set nefungovala
        {
            if (value == 0)
            {
                Text = " ";
            }
            else
            {
                Text = $"{value}";
            }
            cislo = value;
        }
        public int x;
        public int y;
    }
}
