using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AjedrezLbenitez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            partida.Crear();
            RenderizarTablero();
        }

        private Partida partida;

        private void Form1_Load(object sender, EventArgs e)
        {
            partida = new Partida();
            RenderizarTablero();
        }

        private void RenderizarTablero()
        {
            int ancho;
            int alto;

            ancho = panel1.Width / 8;
            alto = panel1.Height / 8;

            panel1.Controls.Clear();

            foreach (Celda celda in partida.Tablero.MatrizCasilleros)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(ancho, alto);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Location = new Point((celda.Columna - 1) * ancho, (celda.Fila - 1) * alto);
                pictureBox.Tag = celda;
                pictureBox.Click += PictureBox_Click;

                string nombreArchivo = string.Empty;

                if (celda.Color == EnumJugadorColor.Blanco)
                    nombreArchivo += "CB";
                else
                    nombreArchivo += "CN";

                if (celda.Pieza != null)
                {
                    nombreArchivo += "-";

                    if (celda.Pieza is Peon)
                        nombreArchivo += "P";

                    if (celda.Pieza is Torre)
                        nombreArchivo += "T";



                    if (celda.Pieza.Color == EnumJugadorColor.Blanco)
                        nombreArchivo += "B";
                    else
                        nombreArchivo += "N";
                }

                nombreArchivo += ".png";

                nombreArchivo = "img/" + nombreArchivo;

                pictureBox.Image = Bitmap.FromFile(nombreArchivo);
                panel1.Controls.Add(pictureBox);

            }
        }

        private Celda celdaOrigen;

        private Celda celdaDestino;

        private void PictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                PictureBox pictureBox = (PictureBox)sender;

                if (celdaOrigen == null)
                {
                    celdaOrigen = (Celda)pictureBox.Tag;
                }
                else
                {
                    if (celdaDestino == null)
                    {
                        celdaDestino = (Celda)pictureBox.Tag;

                        partida.Validar(celdaOrigen, celdaDestino);

                        partida.Mover(celdaOrigen, celdaDestino);

                        celdaOrigen = null;
                        celdaDestino = null;

                        RenderizarTablero();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                celdaOrigen = null;
                celdaDestino = null;

            }
        }
    }
}
