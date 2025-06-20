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
            Lat_Hipocentro = new DataGridViewTextBoxColumn();
            Lng_Hipocentro = new DataGridViewTextBoxColumn();
            lat_Epicentro = new DataGridViewTextBoxColumn();
            lng_Epicentro = new DataGridViewTextBoxColumn();
            Magnitud = new DataGridViewTextBoxColumn();
            seleccionarBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).BeginInit();
            SuspendLayout();
            // 
            // dataGridEventosSismicos
            // 
            dataGridEventosSismicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEventosSismicos.Columns.AddRange(new DataGridViewColumn[] { Fecha, Lat_Hipocentro, Lng_Hipocentro, lat_Epicentro, lng_Epicentro, Magnitud });
            dataGridEventosSismicos.Location = new Point(169, 99);
            dataGridEventosSismicos.Name = "dataGridEventosSismicos";
            dataGridEventosSismicos.RowHeadersWidth = 51;
            dataGridEventosSismicos.Size = new Size(804, 327);
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
            // Lat_Hipocentro
            // 
            Lat_Hipocentro.DataPropertyName = "lat_Hipocentro";
            Lat_Hipocentro.HeaderText = "Lat_Hipocentro";
            Lat_Hipocentro.MinimumWidth = 6;
            Lat_Hipocentro.Name = "Lat_Hipocentro";
            Lat_Hipocentro.Width = 125;
            // 
            // Lng_Hipocentro
            // 
            Lng_Hipocentro.DataPropertyName = "lng_Hipocentro";
            Lng_Hipocentro.HeaderText = "Lng_Hipocentro";
            Lng_Hipocentro.MinimumWidth = 6;
            Lng_Hipocentro.Name = "Lng_Hipocentro";
            Lng_Hipocentro.Width = 125;
            // 
            // lat_Epicentro
            // 
            lat_Epicentro.DataPropertyName = "lat_Epicentro";
            lat_Epicentro.HeaderText = "Lat_Epicentro";
            lat_Epicentro.MinimumWidth = 6;
            lat_Epicentro.Name = "lat_Epicentro";
            lat_Epicentro.Width = 125;
            // 
            // lng_Epicentro
            // 
            lng_Epicentro.DataPropertyName = "lng_Epicentro";
            lng_Epicentro.HeaderText = "Lng_Epicentro";
            lng_Epicentro.MinimumWidth = 6;
            lng_Epicentro.Name = "lng_Epicentro";
            lng_Epicentro.Width = 125;
            // 
            // Magnitud
            // 
            Magnitud.DataPropertyName = "magnitud";
            Magnitud.HeaderText = "Magnitud";
            Magnitud.MinimumWidth = 6;
            Magnitud.Name = "Magnitud";
            Magnitud.Width = 125;
            // 
            // seleccionarBtn
            // 
            seleccionarBtn.Location = new Point(507, 499);
            seleccionarBtn.Name = "seleccionarBtn";
            seleccionarBtn.Size = new Size(94, 29);
            seleccionarBtn.TabIndex = 1;
            seleccionarBtn.Text = "Seleccionar";
            seleccionarBtn.UseVisualStyleBackColor = true;
            seleccionarBtn.Click += seleccionarBtn_Click;
            // 
            // PantallaRegistrarResultado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 648);
            Controls.Add(seleccionarBtn);
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
        private DataGridViewTextBoxColumn Lat_Hipocentro;
        private DataGridViewTextBoxColumn Lng_Hipocentro;
        private DataGridViewTextBoxColumn lat_Epicentro;
        private DataGridViewTextBoxColumn lng_Epicentro;
        private DataGridViewTextBoxColumn Magnitud;
        private Button seleccionarBtn;
    }
}