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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alcanceEditBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)origenEditBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)magnitudEditBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridEventosSismicos
            // 
            dataGridEventosSismicos.AllowUserToAddRows = false;
            dataGridEventosSismicos.AllowUserToDeleteRows = false;
            dataGridEventosSismicos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridEventosSismicos.Columns.AddRange(new DataGridViewColumn[] { Fecha, lat_Epicentro, lng_Epicentro, Lat_Hipocentro, Lng_Hipocentro, Magnitud });
            dataGridEventosSismicos.Location = new Point(142, 71);
            dataGridEventosSismicos.Margin = new Padding(3, 2, 3, 2);
            dataGridEventosSismicos.MultiSelect = false;
            dataGridEventosSismicos.Name = "dataGridEventosSismicos";
            dataGridEventosSismicos.ReadOnly = true;
            dataGridEventosSismicos.RowHeadersWidth = 51;
            dataGridEventosSismicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridEventosSismicos.Size = new Size(704, 245);
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
            seleccionarBtn.Location = new Point(424, 438);
            seleccionarBtn.Margin = new Padding(3, 2, 3, 2);
            seleccionarBtn.Name = "seleccionarBtn";
            seleccionarBtn.Size = new Size(80, 22);
            seleccionarBtn.TabIndex = 1;
            seleccionarBtn.Text = "Seleccionar";
            seleccionarBtn.UseVisualStyleBackColor = true;
            seleccionarBtn.Click += tomarSeleccionEventoSismico;
            // 
            // lblClasificacion
            // 
            lblClasificacion.AutoSize = true;
            lblClasificacion.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClasificacion.Location = new Point(59, 142);
            lblClasificacion.Name = "lblClasificacion";
            lblClasificacion.Size = new Size(112, 20);
            lblClasificacion.TabIndex = 7;
            lblClasificacion.Text = "lblClasificacion";
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOrigen.Location = new Point(59, 236);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(73, 20);
            lblOrigen.TabIndex = 8;
            lblOrigen.Text = "lblOrigen";
            // 
            // lblMagnitud
            // 
            lblMagnitud.AutoSize = true;
            lblMagnitud.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMagnitud.Location = new Point(59, 337);
            lblMagnitud.Name = "lblMagnitud";
            lblMagnitud.Size = new Size(94, 20);
            lblMagnitud.TabIndex = 9;
            lblMagnitud.Text = "lblMagnitud";
            // 
            // lblAlcance
            // 
            lblAlcance.AutoSize = true;
            lblAlcance.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAlcance.Location = new Point(59, 50);
            lblAlcance.Name = "lblAlcance";
            lblAlcance.Size = new Size(80, 20);
            lblAlcance.TabIndex = 10;
            lblAlcance.Text = "lblAlcance";
            // 
            // lblSolicitarVisualizacion
            // 
            lblSolicitarVisualizacion.Location = new Point(447, 368);
            lblSolicitarVisualizacion.Name = "lblSolicitarVisualizacion";
            lblSolicitarVisualizacion.Size = new Size(312, 50);
            lblSolicitarVisualizacion.TabIndex = 12;
            lblSolicitarVisualizacion.Text = "¿Desea visualizar en un mapa el evento sísmico y las estaciones simológicas involucradas?";
            lblSolicitarVisualizacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // noBtn
            // 
            noBtn.Location = new Point(657, 437);
            noBtn.Margin = new Padding(3, 2, 3, 2);
            noBtn.Name = "noBtn";
            noBtn.Size = new Size(80, 22);
            noBtn.TabIndex = 13;
            noBtn.Text = "No";
            noBtn.UseVisualStyleBackColor = true;
            noBtn.Click += tomarSeleccionMapa;
            // 
            // siBtn
            // 
            siBtn.Location = new Point(546, 437);
            siBtn.Margin = new Padding(3, 2, 3, 2);
            siBtn.Name = "siBtn";
            siBtn.Size = new Size(80, 22);
            siBtn.TabIndex = 14;
            siBtn.Text = "Si";
            siBtn.UseVisualStyleBackColor = true;
            // 
            // alcanceEditBtn
            // 
            alcanceEditBtn.Image = (Image)resources.GetObject("alcanceEditBtn.Image");
            alcanceEditBtn.Location = new Point(132, 46);
            alcanceEditBtn.Margin = new Padding(3, 2, 3, 2);
            alcanceEditBtn.Name = "alcanceEditBtn";
            alcanceEditBtn.Size = new Size(24, 24);
            alcanceEditBtn.SizeMode = PictureBoxSizeMode.Zoom;
            alcanceEditBtn.TabIndex = 15;
            alcanceEditBtn.TabStop = false;
            alcanceEditBtn.Visible = false;
            // 
            // origenEditBtn
            // 
            origenEditBtn.Image = (Image)resources.GetObject("origenEditBtn.Image");
            origenEditBtn.Location = new Point(126, 232);
            origenEditBtn.Margin = new Padding(3, 2, 3, 2);
            origenEditBtn.Name = "origenEditBtn";
            origenEditBtn.Size = new Size(24, 24);
            origenEditBtn.SizeMode = PictureBoxSizeMode.Zoom;
            origenEditBtn.TabIndex = 16;
            origenEditBtn.TabStop = false;
            origenEditBtn.Visible = false;
            // 
            // magnitudEditBtn
            // 
            magnitudEditBtn.Image = (Image)resources.GetObject("magnitudEditBtn.Image");
            magnitudEditBtn.Location = new Point(165, 334);
            magnitudEditBtn.Margin = new Padding(3, 2, 3, 2);
            magnitudEditBtn.Name = "magnitudEditBtn";
            magnitudEditBtn.Size = new Size(24, 24);
            magnitudEditBtn.SizeMode = PictureBoxSizeMode.Zoom;
            magnitudEditBtn.TabIndex = 17;
            magnitudEditBtn.TabStop = false;
            magnitudEditBtn.Visible = false;
            // 
            // guardarCambiosBtn
            // 
            guardarCambiosBtn.Location = new Point(474, 437);
            guardarCambiosBtn.Margin = new Padding(3, 2, 3, 2);
            guardarCambiosBtn.Name = "guardarCambiosBtn";
            guardarCambiosBtn.Size = new Size(115, 22);
            guardarCambiosBtn.TabIndex = 18;
            guardarCambiosBtn.Text = "Guardar cambios";
            guardarCambiosBtn.UseVisualStyleBackColor = true;
            guardarCambiosBtn.Visible = false;
            // 
            // continuarSinModificarBtn
            // 
            continuarSinModificarBtn.Location = new Point(608, 437);
            continuarSinModificarBtn.Margin = new Padding(3, 2, 3, 2);
            continuarSinModificarBtn.Name = "continuarSinModificarBtn";
            continuarSinModificarBtn.Size = new Size(154, 22);
            continuarSinModificarBtn.TabIndex = 19;
            continuarSinModificarBtn.Text = "Continuar sin modificar";
            continuarSinModificarBtn.UseVisualStyleBackColor = true;
            continuarSinModificarBtn.Visible = false;
            continuarSinModificarBtn.Click += tomarModificacionDatosES;
            // 
            // confirmarEventoBtn
            // 
            confirmarEventoBtn.Location = new Point(405, 437);
            confirmarEventoBtn.Margin = new Padding(3, 2, 3, 2);
            confirmarEventoBtn.Name = "confirmarEventoBtn";
            confirmarEventoBtn.Size = new Size(117, 22);
            confirmarEventoBtn.TabIndex = 20;
            confirmarEventoBtn.Text = "Confirmar evento";
            confirmarEventoBtn.UseVisualStyleBackColor = true;
            confirmarEventoBtn.Visible = false;
            confirmarEventoBtn.Click += tomarAccionSobreEvento;
            // 
            // rechazarEventoBtn
            // 
            rechazarEventoBtn.Location = new Point(705, 437);
            rechazarEventoBtn.Margin = new Padding(3, 2, 3, 2);
            rechazarEventoBtn.Name = "rechazarEventoBtn";
            rechazarEventoBtn.Size = new Size(118, 22);
            rechazarEventoBtn.TabIndex = 21;
            rechazarEventoBtn.Text = "Rechazar evento";
            rechazarEventoBtn.UseVisualStyleBackColor = true;
            rechazarEventoBtn.Visible = false;
            rechazarEventoBtn.Click += tomarAccionSobreEvento;
            // 
            // solicitarRevisionBtn
            // 
            solicitarRevisionBtn.Location = new Point(529, 437);
            solicitarRevisionBtn.Margin = new Padding(3, 2, 3, 2);
            solicitarRevisionBtn.Name = "solicitarRevisionBtn";
            solicitarRevisionBtn.Size = new Size(169, 22);
            solicitarRevisionBtn.TabIndex = 22;
            solicitarRevisionBtn.Text = "Solicitar revisión a experto";
            solicitarRevisionBtn.UseVisualStyleBackColor = true;
            solicitarRevisionBtn.Visible = false;
            solicitarRevisionBtn.Click += tomarAccionSobreEvento;
            // 
            // lblSolicitarAccionEvento
            // 
            lblSolicitarAccionEvento.Location = new Point(458, 372);
            lblSolicitarAccionEvento.Name = "lblSolicitarAccionEvento";
            lblSolicitarAccionEvento.Size = new Size(312, 46);
            lblSolicitarAccionEvento.TabIndex = 23;
            lblSolicitarAccionEvento.Text = "Seleccione alguna acción sobre el evento";
            lblSolicitarAccionEvento.TextAlign = ContentAlignment.MiddleCenter;
            lblSolicitarAccionEvento.Visible = false;
            // 
            // cancelarCU
            // 
            cancelarCU.Location = new Point(29, 437);
            cancelarCU.Margin = new Padding(3, 2, 3, 2);
            cancelarCU.Name = "cancelarCU";
            cancelarCU.Size = new Size(126, 22);
            cancelarCU.TabIndex = 24;
            cancelarCU.Text = "Cancelar revisión";
            cancelarCU.UseVisualStyleBackColor = true;
            cancelarCU.Click += cancelarRevision;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Sismograma;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(354, 46);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(587, 330);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            richTextBoxSeries.Visible = false;
            // 
            // PantallaRegistrarResultado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(971, 486);
            Controls.Add(pictureBox1);
            ClientSize = new Size(1110, 648);
            Controls.Add(continuarSinModificarBtn);
            Controls.Add(confirmarEventoBtn);
            Controls.Add(siBtn);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "PantallaRegistrarResultado";
            Text = "PantallaRegistrarResultado";
            ((System.ComponentModel.ISupportInitialize)dataGridEventosSismicos).EndInit();
            ((System.ComponentModel.ISupportInitialize)alcanceEditBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)origenEditBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)magnitudEditBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
    }
}