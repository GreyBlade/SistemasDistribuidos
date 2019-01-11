namespace ProgramacionAsincrona.NET
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSincrona = new System.Windows.Forms.Button();
            this.btnAsincrona = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(98, 65);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(171, 20);
            this.txtResult.TabIndex = 0;
            // 
            // btnSincrona
            // 
            this.btnSincrona.Location = new System.Drawing.Point(98, 111);
            this.btnSincrona.Name = "btnSincrona";
            this.btnSincrona.Size = new System.Drawing.Size(75, 23);
            this.btnSincrona.TabIndex = 1;
            this.btnSincrona.Text = "Sincrona";
            this.btnSincrona.UseVisualStyleBackColor = true;
            this.btnSincrona.Click += new System.EventHandler(this.btnSincrona_Click);
            // 
            // btnAsincrona
            // 
            this.btnAsincrona.Location = new System.Drawing.Point(194, 111);
            this.btnAsincrona.Name = "btnAsincrona";
            this.btnAsincrona.Size = new System.Drawing.Size(75, 23);
            this.btnAsincrona.TabIndex = 2;
            this.btnAsincrona.Text = "Asincrona";
            this.btnAsincrona.UseVisualStyleBackColor = true;
            this.btnAsincrona.Click += new System.EventHandler(this.btnAsincrona_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAsincrona);
            this.Controls.Add(this.btnSincrona);
            this.Controls.Add(this.txtResult);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSincrona;
        private System.Windows.Forms.Button btnAsincrona;
    }
}

