namespace source
{
    partial class MainInterface
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
            registrarResultadoRevisionManualBtn = new Button();
            SuspendLayout();
            // 
            // registrarResultadoRevisionManualBtn
            // 
            registrarResultadoRevisionManualBtn.Location = new Point(325, 199);
            registrarResultadoRevisionManualBtn.Name = "registrarResultadoRevisionManualBtn";
            registrarResultadoRevisionManualBtn.Size = new Size(163, 69);
            registrarResultadoRevisionManualBtn.TabIndex = 0;
            registrarResultadoRevisionManualBtn.Text = "Registrar Resultado Revision Manual";
            registrarResultadoRevisionManualBtn.UseVisualStyleBackColor = true;
            registrarResultadoRevisionManualBtn.Click += opcionRegistrarResultadoManual;
            // 
            // MainInterface
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registrarResultadoRevisionManualBtn);
            Name = "MainInterface";
            Text = "MainInterface";
            ResumeLayout(false);
        }

        #endregion

        private Button registrarResultadoRevisionManualBtn;
    }
}