namespace source.Boundarys
{
    partial class PantallaRegistrarResultado
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
            dataGridEventosSismicos = new DataGridView();
            Fecha = new DataGridViewTextBoxColumn();
            Hipocentro = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).BeginInit();
            SuspendLayout();
            // 
            // dataGridEventosSismicos
            // 
            dataGridEventosSismicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEventosSismicos.Columns.AddRange(new DataGridViewColumn[] { Fecha, Hipocentro });
            dataGridEventosSismicos.Location = new Point(177, 128);
            dataGridEventosSismicos.Name = "dataGridEventosSismicos";
            dataGridEventosSismicos.RowHeadersWidth = 51;
            dataGridEventosSismicos.Size = new Size(627, 327);
            dataGridEventosSismicos.TabIndex = 0;
            // 
            // Fecha
            // 
            Fecha.DataPropertyName = "fechaHoraOcurrencia";
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 6;
            Fecha.Name = "Fecha";
            Fecha.Width = 125;
            // 
            // Hipocentro
            // 
            Hipocentro.HeaderText = "Hipocentro";
            Hipocentro.MinimumWidth = 6;
            Hipocentro.Name = "Hipocentro";
            Hipocentro.Width = 125;
            // 
            // PantallaRegistrarResultado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 648);
            Controls.Add(dataGridEventosSismicos);
            Name = "PantallaRegistrarResultado";
            Text = "PantallaRegistrarResultado";
            Load += PantallaRegistrarResultado_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridEventosSismicos;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Hipocentro;
    }
}