namespace Fase1_LFA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TXTPath = new TextBox();
            TResult = new TextBox();
            RTBGrammar = new RichTextBox();
            BTNUpload = new Button();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // TXTPath
            // 
            TXTPath.Location = new Point(100, 58);
            TXTPath.Name = "TXTPath";
            TXTPath.Size = new Size(250, 27);
            TXTPath.TabIndex = 0;
            // 
            // TResult
            // 
            TResult.Location = new Point(422, 165);
            TResult.Name = "TResult";
            TResult.Size = new Size(125, 27);
            TResult.TabIndex = 1;
            // 
            // RTBGrammar
            // 
            RTBGrammar.Location = new Point(12, 128);
            RTBGrammar.Name = "RTBGrammar";
            RTBGrammar.Size = new Size(404, 301);
            RTBGrammar.TabIndex = 2;
            RTBGrammar.Text = "";
            // 
            // BTNUpload
            // 
            BTNUpload.Location = new Point(100, 91);
            BTNUpload.Name = "BTNUpload";
            BTNUpload.Size = new Size(250, 29);
            BTNUpload.TabIndex = 3;
            BTNUpload.Text = "Cargar Gramática";
            BTNUpload.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(422, 400);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Salir";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(446, 142);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 5;
            label1.Text = "Resultados: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 450);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(BTNUpload);
            Controls.Add(RTBGrammar);
            Controls.Add(TResult);
            Controls.Add(TXTPath);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TXTPath;
        private TextBox TResult;
        private RichTextBox RTBGrammar;
        private Button BTNUpload;
        private Button button2;
        private Label label1;
    }
}