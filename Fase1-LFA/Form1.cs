namespace Fase1_LFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTNUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                AnalizarArchivo(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show(@"Error al leer el archivo.");
            }    
        }

          private void AnalizarArchivo(string file)
 {
    
     TXTPath.Text = file;
     RTBGrammar.Select(0, RTBGrammar.Lines.Length);
     RTBGrammar.SelectionColor = Color.Black;

     try
     {
         int line1 = 0;
         string text = File.ReadAllText(file);
         //Send line
         TResult.Text = FormatoGramatica.AnalyseFile(text, ref line1);
         RTBGrammar.Text = text;

         if (TResult.Text.Contains("Correcto"))
         {
             TResult.BackColor = Color.White;
             TResult.ForeColor = Color.Cyan;
         }
         else
         {
             TResult.BackColor = Color.White;
             TResult.ForeColor = Color.Crimson;

             //Ubicacion del error
             int lineCounter = 0;

             foreach (string line in RTBGrammar.Lines)
             {
                 if (line1 - 1 == lineCounter)
                 {
                     RTBGrammar.Select(RTBGrammar.GetFirstCharIndexFromLine(lineCounter), line.Length);
                     RTBGrammar.SelectionColor = Color.Red;
                 }
                 lineCounter++;
             }
         }

     }
     catch (Exception ex)
     {

         TResult.BackColor = Color.White;
         TResult.ForeColor = Color.Crimson;
         TResult.Text = @"Error en TOKENS";
         MessageBox.Show(ex.Message);

         //Show in red all lines in tokens
         int lineCounter = 0;

         foreach (string line in RTBGrammar.Lines)
         {
             if (line.Contains("TOKEN"))
             {
                 RTBGrammar.Select(RTBGrammar.GetFirstCharIndexFromLine(lineCounter), line.Length);
                 RTBGrammar.SelectionColor = Color.Red;
             }
             lineCounter++;
         }
     }
 }
    }
}
