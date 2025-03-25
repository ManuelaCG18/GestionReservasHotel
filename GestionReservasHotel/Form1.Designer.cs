namespace GestionReservasHotel
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReservaEst = new System.Windows.Forms.Button();
            this.btnReservaVip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReservaEst
            // 
            this.btnReservaEst.Location = new System.Drawing.Point(200, 209);
            this.btnReservaEst.Name = "btnReservaEst";
            this.btnReservaEst.Size = new System.Drawing.Size(327, 170);
            this.btnReservaEst.TabIndex = 5;
            this.btnReservaEst.Text = "Reservar en Habitación Estandar";
            this.btnReservaEst.UseVisualStyleBackColor = true;
            this.btnReservaEst.Click += new System.EventHandler(this.btnReservaEst_Click);
            // 
            // btnReservaVip
            // 
            this.btnReservaVip.Location = new System.Drawing.Point(576, 209);
            this.btnReservaVip.Name = "btnReservaVip";
            this.btnReservaVip.Size = new System.Drawing.Size(327, 170);
            this.btnReservaVip.TabIndex = 6;
            this.btnReservaVip.Text = "Reservar en habitación VIP";
            this.btnReservaVip.UseVisualStyleBackColor = true;
            this.btnReservaVip.Click += new System.EventHandler(this.btnReservaVip_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 598);
            this.Controls.Add(this.btnReservaVip);
            this.Controls.Add(this.btnReservaEst);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReservaEst;
        private System.Windows.Forms.Button btnReservaVip;
    }
}

