﻿namespace NeptunoNet2023.Windows
{
    partial class frmPrincipal
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
            btnPaises = new Button();
            btnSalir = new Button();
            btnCategorias = new Button();
            btnCiudades = new Button();
            buttonCliente = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnPaises
            // 
            btnPaises.Image = Properties.Resources.america_50px;
            btnPaises.Location = new Point(40, 61);
            btnPaises.Name = "btnPaises";
            btnPaises.Size = new Size(134, 70);
            btnPaises.TabIndex = 0;
            btnPaises.Text = "Países";
            btnPaises.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPaises.UseVisualStyleBackColor = true;
            btnPaises.Click += btnPaises_Click;
            // 
            // btnSalir
            // 
            btnSalir.Image = Properties.Resources.shutdown_48px;
            btnSalir.Location = new Point(658, 357);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(118, 70);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnCategorias
            // 
            btnCategorias.Image = Properties.Resources.categorize_50px;
            btnCategorias.Location = new Point(40, 169);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(134, 70);
            btnCategorias.TabIndex = 0;
            btnCategorias.Text = "Categorías";
            btnCategorias.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnCiudades
            // 
            btnCiudades.Image = Properties.Resources.city_50px;
            btnCiudades.Location = new Point(199, 61);
            btnCiudades.Name = "btnCiudades";
            btnCiudades.Size = new Size(134, 70);
            btnCiudades.TabIndex = 0;
            btnCiudades.Text = "Ciudades";
            btnCiudades.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCiudades.UseVisualStyleBackColor = true;
            btnCiudades.Click += btnCiudades_Click;
            // 
            // buttonCliente
            // 
            buttonCliente.Location = new Point(199, 169);
            buttonCliente.Name = "buttonCliente";
            buttonCliente.Size = new Size(134, 70);
            buttonCliente.TabIndex = 1;
            buttonCliente.Text = "Cliente";
            buttonCliente.UseVisualStyleBackColor = true;
            buttonCliente.Click += buttonCliente_Click;
            // 
            // button1
            // 
            button1.Location = new Point(406, 82);
            button1.Name = "button1";
            button1.Size = new Size(115, 86);
            button1.TabIndex = 2;
            button1.Text = "Productos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(buttonCliente);
            Controls.Add(btnSalir);
            Controls.Add(btnCategorias);
            Controls.Add(btnCiudades);
            Controls.Add(btnPaises);
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPaises;
        private Button btnSalir;
        private Button btnCategorias;
        private Button btnCiudades;
        private Button buttonCliente;
        private Button button1;
    }
}