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
            lat_Epicentro = new DataGridViewTextBoxColumn();
            lng_Epicentro = new DataGridViewTextBoxColumn();
            Lat_Hipocentro = new DataGridViewTextBoxColumn();
            Lng_Hipocentro = new DataGridViewTextBoxColumn();
            Magnitud = new DataGridViewTextBoxColumn();
            seleccionarBtn = new Button();
            lblAlcance = new Label();
            lblClasificacion = new Label();
            lblOrigen = new Label();
            lblMagnitud = new Label();
            dataGridDetalles = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridDetalles).BeginInit();
            SuspendLayout();
            // 
            // dataGridEventosSismicos
            // 
            dataGridEventosSismicos.AllowUserToAddRows = false;
            dataGridEventosSismicos.AllowUserToDeleteRows = false;
            dataGridEventosSismicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEventosSismicos.Columns.AddRange(new DataGridViewColumn[] { Fecha, lat_Epicentro, lng_Epicentro, Lat_Hipocentro, Lng_Hipocentro, Magnitud });
            dataGridEventosSismicos.Location = new Point(162, 95);
            dataGridEventosSismicos.MultiSelect = false;
            dataGridEventosSismicos.Name = "dataGridEventosSismicos";
            dataGridEventosSismicos.ReadOnly = true;
            dataGridEventosSismicos.RowHeadersWidth = 51;
            dataGridEventosSismicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEventosSismicos.Size = new Size(804, 327);
            dataGridEventosSismicos.TabIndex = 0;
            // 
            // Fecha
            // 
            Fecha.DataPropertyName = "fechaHoraOcurrencia";
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 6;
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            Fecha.Width = 125;
            // 
            // lat_Epicentro
            // 
            lat_Epicentro.DataPropertyName = "latitudEpicentro";
            lat_Epicentro.HeaderText = "Lat_Epicentro";
            lat_Epicentro.MinimumWidth = 6;
            lat_Epicentro.Name = "lat_Epicentro";
            lat_Epicentro.ReadOnly = true;
            lat_Epicentro.Width = 125;
            // 
            // lng_Epicentro
            // 
            lng_Epicentro.DataPropertyName = "longitudEpicentro";
            lng_Epicentro.HeaderText = "Lng_Epicentro";
            lng_Epicentro.MinimumWidth = 6;
            lng_Epicentro.Name = "lng_Epicentro";
            lng_Epicentro.ReadOnly = true;
            lng_Epicentro.Width = 125;
            // 
            // Lat_Hipocentro
            // 
            Lat_Hipocentro.DataPropertyName = "latitudHipocentro";
            Lat_Hipocentro.HeaderText = "Lat_Hipocentro";
            Lat_Hipocentro.MinimumWidth = 6;
            Lat_Hipocentro.Name = "Lat_Hipocentro";
            Lat_Hipocentro.ReadOnly = true;
            Lat_Hipocentro.Width = 125;
            // 
            // Lng_Hipocentro
            // 
            Lng_Hipocentro.DataPropertyName = "longitudHipocentro";
            Lng_Hipocentro.HeaderText = "Lng_Hipocentro";
            Lng_Hipocentro.MinimumWidth = 6;
            Lng_Hipocentro.Name = "Lng_Hipocentro";
            Lng_Hipocentro.ReadOnly = true;
            Lng_Hipocentro.Width = 125;
            // 
            // Magnitud
            // 
            Magnitud.DataPropertyName = "valorMagnitud";
            Magnitud.HeaderText = "Magnitud";
            Magnitud.MinimumWidth = 6;
            Magnitud.Name = "Magnitud";
            Magnitud.ReadOnly = true;
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
            // lblAlcance
            // 
            lblAlcance.Location = new Point(0, 0);
            lblAlcance.Name = "lblAlcance";
            lblAlcance.Size = new Size(100, 23);
            lblAlcance.TabIndex = 2;
            // 
            // lblClasificacion
            // 
            lblClasificacion.Location = new Point(0, 0);
            lblClasificacion.Name = "lblClasificacion";
            lblClasificacion.Size = new Size(100, 23);
            lblClasificacion.TabIndex = 3;
            // 
            // lblOrigen
            // 
            lblOrigen.Location = new Point(0, 0);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(100, 23);
            lblOrigen.TabIndex = 4;
            // 
            // lblMagnitud
            // 
            lblMagnitud.Location = new Point(0, 0);
            lblMagnitud.Name = "lblMagnitud";
            lblMagnitud.Size = new Size(100, 23);
            lblMagnitud.TabIndex = 5;
            // 
            // dataGridDetalles
            // 
            dataGridDetalles.ColumnHeadersHeight = 29;
            dataGridDetalles.Location = new Point(0, 0);
            dataGridDetalles.Name = "dataGridDetalles";
            dataGridDetalles.RowHeadersWidth = 51;
            dataGridDetalles.Size = new Size(240, 150);
            dataGridDetalles.TabIndex = 6;
            // 
            // PantallaRegistrarResultado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 648);
            Controls.Add(seleccionarBtn);
            Controls.Add(dataGridEventosSismicos);
            Controls.Add(lblAlcance);
            Controls.Add(lblClasificacion);
            Controls.Add(lblOrigen);
            Controls.Add(lblMagnitud);
            Controls.Add(dataGridDetalles);
            Name = "PantallaRegistrarResultado";
            Text = "PantallaRegistrarResultado";
            Load += PantallaRegistrarResultado_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridDetalles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridEventosSismicos;
        private Button seleccionarBtn;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn lat_Epicentro;
        private DataGridViewTextBoxColumn lng_Epicentro;
        private DataGridViewTextBoxColumn Lat_Hipocentro;
        private DataGridViewTextBoxColumn Lng_Hipocentro;
        private DataGridViewTextBoxColumn Magnitud;

        // Labels para los datos únicos
        Label lblAlcance;
        Label lblClasificacion;
        Label lblOrigen;
        Label lblMagnitud;

        // Nuevo DataGridView para los detalles
        DataGridView dataGridDetalles;
    }
}