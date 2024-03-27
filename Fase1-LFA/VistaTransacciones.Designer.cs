namespace Fase1_LFA
{
    partial class VistaTransacciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            RTXtext = new RichTextBox();
            TransitionsTable = new DataGridView();
            TreeTable = new DataGridView();
            FollowTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)TransitionsTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TreeTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FollowTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 24);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 0;
            label1.Text = "Tokens";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 256);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 1;
            label2.Text = "Fist, Last, Nullable";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(495, 256);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 2;
            label3.Text = "Follow";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(495, 24);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 3;
            label4.Text = "Transiciones";
            // 
            // RTXtext
            // 
            RTXtext.Location = new Point(42, 47);
            RTXtext.Name = "RTXtext";
            RTXtext.Size = new Size(374, 126);
            RTXtext.TabIndex = 4;
            RTXtext.Text = "";
            // 
            // TransitionsTable
            // 
            TransitionsTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TransitionsTable.Location = new Point(495, 47);
            TransitionsTable.Name = "TransitionsTable";
            TransitionsTable.RowHeadersWidth = 51;
            TransitionsTable.RowTemplate.Height = 29;
            TransitionsTable.Size = new Size(374, 126);
            TransitionsTable.TabIndex = 5;
            // 
            // TreeTable
            // 
            TreeTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TreeTable.Location = new Point(42, 293);
            TreeTable.Name = "TreeTable";
            TreeTable.RowHeadersWidth = 51;
            TreeTable.RowTemplate.Height = 29;
            TreeTable.Size = new Size(374, 126);
            TreeTable.TabIndex = 6;
            // 
            // FollowTable
            // 
            FollowTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            FollowTable.Location = new Point(495, 293);
            FollowTable.Name = "FollowTable";
            FollowTable.RowHeadersWidth = 51;
            FollowTable.RowTemplate.Height = 29;
            FollowTable.Size = new Size(374, 126);
            FollowTable.TabIndex = 7;
            // 
            // VistaTransacciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 450);
            Controls.Add(FollowTable);
            Controls.Add(TreeTable);
            Controls.Add(TransitionsTable);
            Controls.Add(RTXtext);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "VistaTransacciones";
            Text = "VistaTransacciones";
            ((System.ComponentModel.ISupportInitialize)TransitionsTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)TreeTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)FollowTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox RTXtext;
        private DataGridView TransitionsTable;
        private DataGridView TreeTable;
        private DataGridView FollowTable;
    }
}