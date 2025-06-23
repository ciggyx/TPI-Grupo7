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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaRegistrarResultado));
            dataGridEventosSismicos = new DataGridView();
            Fecha = new DataGridViewTextBoxColumn();
            lat_Epicentro = new DataGridViewTextBoxColumn();
            lng_Epicentro = new DataGridViewTextBoxColumn();
            Lat_Hipocentro = new DataGridViewTextBoxColumn();
            Lng_Hipocentro = new DataGridViewTextBoxColumn();
            Magnitud = new DataGridViewTextBoxColumn();
            seleccionarBtn = new Button();
            lblClasificacion = new Label();
            lblOrigen = new Label();
            lblMagnitud = new Label();
            lblAlcance = new Label();
            lblSolicitarVisualizacion = new Label();
            noBtn = new Button();
            siBtn = new Button();
            alcanceEditBtn = new PictureBox();
            origenEditBtn = new PictureBox();
            magnitudEditBtn = new PictureBox();
            guardarCambiosBtn = new Button();
            continuarSinModificarBtn = new Button();
            confirmarEventoBtn = new Button();
            rechazarEventoBtn = new Button();
            solicitarRevisionBtn = new Button();
            lblSolicitarAccionEvento = new Label();
            cancelarCU = new Button();
            richTextBoxSeries = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alcanceEditBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)origenEditBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)magnitudEditBtn).BeginInit();
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
            seleccionarBtn.Location = new Point(484, 584);
            seleccionarBtn.Name = "seleccionarBtn";
            seleccionarBtn.Size = new Size(92, 29);
            seleccionarBtn.TabIndex = 1;
            seleccionarBtn.Text = "Seleccionar";
            seleccionarBtn.UseVisualStyleBackColor = true;
            seleccionarBtn.Click += tomarSeleccionEventoSismico;
            // 
            // lblClasificacion
            // 
            lblClasificacion.AutoSize = true;
            lblClasificacion.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClasificacion.Location = new Point(67, 189);
            lblClasificacion.Name = "lblClasificacion";
            lblClasificacion.Size = new Size(139, 25);
            lblClasificacion.TabIndex = 7;
            lblClasificacion.Text = "lblClasificacion";
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrigen.Location = new Point(67, 314);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(91, 25);
            lblOrigen.TabIndex = 8;
            lblOrigen.Text = "lblOrigen";
            // 
            // lblMagnitud
            // 
            lblMagnitud.AutoSize = true;
            lblMagnitud.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMagnitud.Location = new Point(67, 449);
            lblMagnitud.Name = "lblMagnitud";
            lblMagnitud.Size = new Size(116, 25);
            lblMagnitud.TabIndex = 9;
            lblMagnitud.Text = "lblMagnitud";
            // 
            // lblAlcance
            // 
            lblAlcance.AutoSize = true;
            lblAlcance.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAlcance.Location = new Point(67, 67);
            lblAlcance.Name = "lblAlcance";
            lblAlcance.Size = new Size(100, 25);
            lblAlcance.TabIndex = 10;
            lblAlcance.Text = "lblAlcance";
            // 
            // lblSolicitarVisualizacion
            // 
            lblSolicitarVisualizacion.Location = new Point(511, 491);
            lblSolicitarVisualizacion.Name = "lblSolicitarVisualizacion";
            lblSolicitarVisualizacion.Size = new Size(357, 67);
            lblSolicitarVisualizacion.TabIndex = 12;
            lblSolicitarVisualizacion.Text = "¿Desea visualizar en un mapa el evento sísmico y las estaciones simológicas involucradas?";
            lblSolicitarVisualizacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // noBtn
            // 
            noBtn.Location = new Point(751, 583);
            noBtn.Name = "noBtn";
            noBtn.Size = new Size(92, 29);
            noBtn.TabIndex = 13;
            noBtn.Text = "No";
            noBtn.UseVisualStyleBackColor = true;
            noBtn.Click += tomarSeleccionMapa;
            // 
            // siBtn
            // 
            siBtn.Location = new Point(624, 583);
            siBtn.Name = "siBtn";
            siBtn.Size = new Size(92, 29);
            siBtn.TabIndex = 14;
            siBtn.Text = "Si";
            siBtn.UseVisualStyleBackColor = true;
            // 
            // alcanceEditBtn
            // 
            alcanceEditBtn.Image = (Image)resources.GetObject("alcanceEditBtn.Image");
            alcanceEditBtn.Location = new Point(151, 62);
            alcanceEditBtn.Name = "alcanceEditBtn";
            alcanceEditBtn.Size = new Size(27, 32);
            alcanceEditBtn.SizeMode = PictureBoxSizeMode.Zoom;
            alcanceEditBtn.TabIndex = 15;
            alcanceEditBtn.TabStop = false;
            alcanceEditBtn.Visible = false;
            // 
            // origenEditBtn
            // 
            origenEditBtn.Image = (Image)resources.GetObject("origenEditBtn.Image");
            origenEditBtn.Location = new Point(144, 310);
            origenEditBtn.Name = "origenEditBtn";
            origenEditBtn.Size = new Size(27, 32);
            origenEditBtn.SizeMode = PictureBoxSizeMode.Zoom;
            origenEditBtn.TabIndex = 16;
            origenEditBtn.TabStop = false;
            origenEditBtn.Visible = false;
            // 
            // magnitudEditBtn
            // 
            magnitudEditBtn.Image = (Image)resources.GetObject("magnitudEditBtn.Image");
            magnitudEditBtn.Location = new Point(189, 445);
            magnitudEditBtn.Name = "magnitudEditBtn";
            magnitudEditBtn.Size = new Size(27, 32);
            magnitudEditBtn.SizeMode = PictureBoxSizeMode.Zoom;
            magnitudEditBtn.TabIndex = 17;
            magnitudEditBtn.TabStop = false;
            magnitudEditBtn.Visible = false;
            // 
            // guardarCambiosBtn
            // 
            guardarCambiosBtn.Location = new Point(542, 583);
            guardarCambiosBtn.Name = "guardarCambiosBtn";
            guardarCambiosBtn.Size = new Size(131, 29);
            guardarCambiosBtn.TabIndex = 18;
            guardarCambiosBtn.Text = "Guardar cambios";
            guardarCambiosBtn.UseVisualStyleBackColor = true;
            guardarCambiosBtn.Visible = false;
            // 
            // continuarSinModificarBtn
            // 
            continuarSinModificarBtn.Location = new Point(695, 583);
            continuarSinModificarBtn.Name = "continuarSinModificarBtn";
            continuarSinModificarBtn.Size = new Size(176, 29);
            continuarSinModificarBtn.TabIndex = 19;
            continuarSinModificarBtn.Text = "Continuar sin modificar";
            continuarSinModificarBtn.UseVisualStyleBackColor = true;
            continuarSinModificarBtn.Visible = false;
            continuarSinModificarBtn.Click += tomarModificacionDatosES;
            // 
            // confirmarEventoBtn
            // 
            confirmarEventoBtn.Location = new Point(463, 583);
            confirmarEventoBtn.Name = "confirmarEventoBtn";
            confirmarEventoBtn.Size = new Size(134, 29);
            confirmarEventoBtn.TabIndex = 20;
            confirmarEventoBtn.Text = "Confirmar evento";
            confirmarEventoBtn.UseVisualStyleBackColor = true;
            confirmarEventoBtn.Visible = false;
            confirmarEventoBtn.Click += tomarAccionSobreEvento;
            // 
            // rechazarEventoBtn
            // 
            rechazarEventoBtn.Location = new Point(806, 583);
            rechazarEventoBtn.Name = "rechazarEventoBtn";
            rechazarEventoBtn.Size = new Size(135, 29);
            rechazarEventoBtn.TabIndex = 21;
            rechazarEventoBtn.Text = "Rechazar evento";
            rechazarEventoBtn.UseVisualStyleBackColor = true;
            rechazarEventoBtn.Visible = false;
            rechazarEventoBtn.Click += tomarAccionSobreEvento;
            // 
            // solicitarRevisionBtn
            // 
            solicitarRevisionBtn.Location = new Point(605, 583);
            solicitarRevisionBtn.Name = "solicitarRevisionBtn";
            solicitarRevisionBtn.Size = new Size(193, 29);
            solicitarRevisionBtn.TabIndex = 22;
            solicitarRevisionBtn.Text = "Solicitar revisión a experto";
            solicitarRevisionBtn.UseVisualStyleBackColor = true;
            solicitarRevisionBtn.Visible = false;
            solicitarRevisionBtn.Click += tomarAccionSobreEvento;
            // 
            // lblSolicitarAccionEvento
            // 
            lblSolicitarAccionEvento.Location = new Point(523, 496);
            lblSolicitarAccionEvento.Name = "lblSolicitarAccionEvento";
            lblSolicitarAccionEvento.Size = new Size(357, 62);
            lblSolicitarAccionEvento.TabIndex = 23;
            lblSolicitarAccionEvento.Text = "Seleccione alguna acción sobre el evento";
            lblSolicitarAccionEvento.TextAlign = ContentAlignment.MiddleCenter;
            lblSolicitarAccionEvento.Visible = false;
            // 
            // cancelarCU
            // 
            cancelarCU.Location = new Point(33, 583);
            cancelarCU.Name = "cancelarCU";
            cancelarCU.Size = new Size(144, 29);
            cancelarCU.TabIndex = 24;
            cancelarCU.Text = "Cancelar revisión";
            cancelarCU.UseVisualStyleBackColor = true;
            cancelarCU.Click += cancelarRevision;
            // 
            // richTextBoxSeries
            // 
            richTextBoxSeries.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxSeries.Font = new Font("Segoe UI", 11F);
            richTextBoxSeries.Location = new Point(329, 54);
            richTextBoxSeries.Name = "richTextBoxSeries";
            richTextBoxSeries.ReadOnly = true;
            richTextBoxSeries.Size = new Size(743, 434);
            richTextBoxSeries.TabIndex = 25;
            richTextBoxSeries.Text = "";
            richTextBoxSeries.Visible = false;
            // 
            // PantallaRegistrarResultado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 648);
            Controls.Add(continuarSinModificarBtn);
            Controls.Add(confirmarEventoBtn);
            Controls.Add(siBtn);
            Controls.Add(richTextBoxSeries);
            Controls.Add(cancelarCU);
            Controls.Add(magnitudEditBtn);
            Controls.Add(lblMagnitud);
            Controls.Add(origenEditBtn);
            Controls.Add(lblOrigen);
            Controls.Add(lblClasificacion);
            Controls.Add(noBtn);
            Controls.Add(alcanceEditBtn);
            Controls.Add(lblAlcance);
            Controls.Add(dataGridEventosSismicos);
            Controls.Add(rechazarEventoBtn);
            Controls.Add(solicitarRevisionBtn);
            Controls.Add(seleccionarBtn);
            Controls.Add(guardarCambiosBtn);
            Controls.Add(lblSolicitarAccionEvento);
            Controls.Add(lblSolicitarVisualizacion);
            Name = "PantallaRegistrarResultado";
            Text = "PantallaRegistrarResultado";
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)alcanceEditBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)origenEditBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)magnitudEditBtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label lblClasificacion;
        private Label lblOrigen;
        private Label lblMagnitud;
        private Label lblAlcance;
        private Label lblSolicitarVisualizacion;
        private Button noBtn;
        private Button siBtn;
        private PictureBox alcanceEditBtn;
        private PictureBox origenEditBtn;
        private PictureBox magnitudEditBtn;
        private Button guardarCambiosBtn;
        private Button continuarSinModificarBtn;
        private Button confirmarEventoBtn;
        private Button rechazarEventoBtn;
        private Button solicitarRevisionBtn;
        private Label lblSolicitarAccionEvento;
        private Button cancelarCU;
        private RichTextBox richTextBoxSeries;
    }
}