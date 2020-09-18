using System;
using System.IO;
using System.Windows.Forms;
using Wsqm;

namespace wsqEncodeDecode
{
    public partial class Form1 : Form
    {
        private string wsqOrigen = string.Empty;
        private string bmpOrigen = string.Empty;
        private string archivoDestino = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Decode_Click(object sender, EventArgs e)
        {
            if (wsqOrigen != string.Empty && File.Exists(wsqOrigen))
            {
                WSQ dec = new WSQ();
                if (ArchivoGuardado(1))
                {
                    dec.DecoderFile(wsqOrigen, archivoDestino);
                    MessageBox.Show("Response Status : " + "Conversion finalizada", "Conversion Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Response Status : " + "Seleccione el archivo WSQ", "Conversion Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Encode_Click(object sender, EventArgs e)
        {
            if (bmpOrigen != string.Empty && File.Exists(bmpOrigen))
            {
                WSQ dec = new WSQ();
                string[] comentario = new string[2];
                comentario[0] = "comentario1";
                comentario[1] = "comentario2";

                if (ArchivoGuardado(0))
                {
                    dec.EnconderFile(bmpOrigen, archivoDestino, comentario, 0.75f);
                    MessageBox.Show("Response Status : " + "Conversion finalizada", "Conversion Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Response Status : " + "Seleccione el archivo Imagen", "Conversion Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool ArchivoGuardado(int opcion)
        {
            bool correcto = false;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            switch (opcion)
            {
                case 0:
                    saveFileDialog1.Filter = "WSQ file(*.wsq)|*.wsq";
                    saveFileDialog1.Title = "Save a WSQ File";                    
                    break;
                case 1:
                    saveFileDialog1.Filter = "BMP files (*.bmp)|*.bmp";
                    saveFileDialog1.Title = "Save a BMP file";
                    break;
            }
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                archivoDestino = saveFileDialog1.FileName;
                string tipo = (Path.GetFileName(archivoDestino)).Split('.')[1];
                switch (opcion)
                {
                    case 1:
                        switch (tipo)
                        {
                            case "BMP":
                            case "bmp":
                                correcto = true;
                                break;
                            default:
                                MessageBox.Show("Response Status : " + "Extensión incorrecta", "Conversion Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        break;
                    case 0:
                        switch (tipo)
                        {
                            case "wsq":
                            case "WSQ":
                                correcto = true;
                                break;
                            default:
                                MessageBox.Show("Response Status : " + "Extensión incorrecta", "Conversion Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                        break;
                }                
            }
            return correcto;
        }

        private void SeleccionaArchivoWSQ_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "WSQ file(*.wsq)|*.wsq";
            dialog.Title = "Seleciona WSQ File origen";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                wsqOrigen = dialog.FileName;
                pathWSQ.Text = Path.GetFileName(wsqOrigen);
            }
            dialog.Dispose();
        }

        private void SeleccionaArchivoImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "BMP files (*.bmp)|*.bmp|TIFF files (*.tiff)|*.tiff";
            dialog.Title = "Select a BMP file";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                bmpOrigen = dialog.FileName;
                pathImage.Text = Path.GetFileName(bmpOrigen);
            }
            dialog.Dispose();
        }
    }
}
