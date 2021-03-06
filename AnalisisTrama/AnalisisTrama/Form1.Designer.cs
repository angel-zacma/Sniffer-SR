﻿namespace AnalisisTrama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BtnAnalizarTrama = new System.Windows.Forms.Button();
            this.DataGridTrama = new System.Windows.Forms.DataGridView();
            this.DirDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Informacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicionesDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NcaracteresDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxAnalisis = new System.Windows.Forms.GroupBox();
            this.groupBoxTramaHexadecimal = new System.Windows.Forms.GroupBox();
            this.TxtHexa = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtTramaBinario = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVdetalles = new System.Windows.Forms.DataGridView();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IniHex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinHex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.analizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.glosarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTécnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTrama)).BeginInit();
            this.groupBoxAnalisis.SuspendLayout();
            this.groupBoxTramaHexadecimal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVdetalles)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAnalizarTrama
            // 
            this.BtnAnalizarTrama.Location = new System.Drawing.Point(1449, 811);
            this.BtnAnalizarTrama.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAnalizarTrama.Name = "BtnAnalizarTrama";
            this.BtnAnalizarTrama.Size = new System.Drawing.Size(140, 37);
            this.BtnAnalizarTrama.TabIndex = 0;
            this.BtnAnalizarTrama.Text = "Analizar";
            this.BtnAnalizarTrama.UseVisualStyleBackColor = true;
            this.BtnAnalizarTrama.Click += new System.EventHandler(this.BtnAnalizarTrama_Click);
            // 
            // DataGridTrama
            // 
            this.DataGridTrama.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridTrama.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DataGridTrama.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DataGridTrama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridTrama.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DirDestino,
            this.DirOrigen,
            this.TipoServicio,
            this.Informacion,
            this.PosicionesDGV,
            this.NcaracteresDGV});
            this.DataGridTrama.Location = new System.Drawing.Point(7, 36);
            this.DataGridTrama.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridTrama.MultiSelect = false;
            this.DataGridTrama.Name = "DataGridTrama";
            this.DataGridTrama.ReadOnly = true;
            this.DataGridTrama.RowHeadersVisible = false;
            this.DataGridTrama.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridTrama.Size = new System.Drawing.Size(1563, 261);
            this.DataGridTrama.TabIndex = 2;
            this.DataGridTrama.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridTrama_CellClick);
            this.DataGridTrama.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridTrama_CellContentClick);
            // 
            // DirDestino
            // 
            this.DirDestino.HeaderText = "Dirección destino";
            this.DirDestino.Name = "DirDestino";
            this.DirDestino.ReadOnly = true;
            // 
            // DirOrigen
            // 
            this.DirOrigen.HeaderText = "Dirección origen";
            this.DirOrigen.Name = "DirOrigen";
            this.DirOrigen.ReadOnly = true;
            // 
            // TipoServicio
            // 
            this.TipoServicio.HeaderText = "Servicio";
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            // 
            // Informacion
            // 
            this.Informacion.HeaderText = "Información";
            this.Informacion.Name = "Informacion";
            this.Informacion.ReadOnly = true;
            this.Informacion.Visible = false;
            // 
            // PosicionesDGV
            // 
            this.PosicionesDGV.HeaderText = "Posiciones";
            this.PosicionesDGV.Name = "PosicionesDGV";
            this.PosicionesDGV.ReadOnly = true;
            this.PosicionesDGV.Visible = false;
            // 
            // NcaracteresDGV
            // 
            this.NcaracteresDGV.HeaderText = "Ncaracteres";
            this.NcaracteresDGV.Name = "NcaracteresDGV";
            this.NcaracteresDGV.ReadOnly = true;
            this.NcaracteresDGV.Visible = false;
            // 
            // groupBoxAnalisis
            // 
            this.groupBoxAnalisis.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxAnalisis.Controls.Add(this.DataGridTrama);
            this.groupBoxAnalisis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAnalisis.Location = new System.Drawing.Point(15, 233);
            this.groupBoxAnalisis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAnalisis.Name = "groupBoxAnalisis";
            this.groupBoxAnalisis.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxAnalisis.Size = new System.Drawing.Size(1577, 266);
            this.groupBoxAnalisis.TabIndex = 4;
            this.groupBoxAnalisis.TabStop = false;
            this.groupBoxAnalisis.Text = "Información del Paquete";
            this.groupBoxAnalisis.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBoxTramaHexadecimal
            // 
            this.groupBoxTramaHexadecimal.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxTramaHexadecimal.Controls.Add(this.TxtHexa);
            this.groupBoxTramaHexadecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxTramaHexadecimal.Location = new System.Drawing.Point(1145, 30);
            this.groupBoxTramaHexadecimal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTramaHexadecimal.Name = "groupBoxTramaHexadecimal";
            this.groupBoxTramaHexadecimal.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTramaHexadecimal.Size = new System.Drawing.Size(437, 198);
            this.groupBoxTramaHexadecimal.TabIndex = 5;
            this.groupBoxTramaHexadecimal.TabStop = false;
            this.groupBoxTramaHexadecimal.Text = "Flujo de Datos en Hexadecimal";
            // 
            // TxtHexa
            // 
            this.TxtHexa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHexa.Location = new System.Drawing.Point(13, 36);
            this.TxtHexa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtHexa.Name = "TxtHexa";
            this.TxtHexa.Size = new System.Drawing.Size(417, 144);
            this.TxtHexa.TabIndex = 0;
            this.TxtHexa.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.TxtTramaBinario);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1127, 198);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flujo de Datos en Binario";
            // 
            // TxtTramaBinario
            // 
            this.TxtTramaBinario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTramaBinario.Location = new System.Drawing.Point(7, 28);
            this.TxtTramaBinario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtTramaBinario.Name = "TxtTramaBinario";
            this.TxtTramaBinario.Size = new System.Drawing.Size(1113, 152);
            this.TxtTramaBinario.TabIndex = 2;
            this.TxtTramaBinario.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 811);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(584, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(505, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Desarrollado por: Julio Antonio Gonzalez Martín y Luis Angel Zacarias Magaña";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.DGVdetalles);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 503);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1577, 306);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles del Paquete";
            // 
            // DGVdetalles
            // 
            this.DGVdetalles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVdetalles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DGVdetalles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGVdetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVdetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descripcion,
            this.IniHex,
            this.FinHex});
            this.DGVdetalles.Location = new System.Drawing.Point(7, 36);
            this.DGVdetalles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DGVdetalles.MultiSelect = false;
            this.DGVdetalles.Name = "DGVdetalles";
            this.DGVdetalles.ReadOnly = true;
            this.DGVdetalles.RowHeadersVisible = false;
            this.DGVdetalles.Size = new System.Drawing.Size(1563, 261);
            this.DGVdetalles.TabIndex = 2;
            this.DGVdetalles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVdetalles_CellClick);
            this.DGVdetalles.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVdetalles_CellEnter);
            this.DGVdetalles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGVdetalles_KeyDown);
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // IniHex
            // 
            this.IniHex.HeaderText = "Inicio Hexa";
            this.IniHex.Name = "IniHex";
            this.IniHex.ReadOnly = true;
            this.IniHex.Visible = false;
            // 
            // FinHex
            // 
            this.FinHex.HeaderText = "Final Hexa";
            this.FinHex.Name = "FinHex";
            this.FinHex.ReadOnly = true;
            this.FinHex.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.analizarToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1683, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // analizarToolStripMenuItem
            // 
            this.analizarToolStripMenuItem.Name = "analizarToolStripMenuItem";
            this.analizarToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.analizarToolStripMenuItem.Text = "Analizar";
            this.analizarToolStripMenuItem.Click += new System.EventHandler(this.analizarToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem,
            this.glosarioToolStripMenuItem,
            this.manualTécnicoToolStripMenuItem,
            this.manualDeUsuarioToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.acercaDeToolStripMenuItem.Text = "Acerca De";
            // 
            // glosarioToolStripMenuItem
            // 
            this.glosarioToolStripMenuItem.Name = "glosarioToolStripMenuItem";
            this.glosarioToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.glosarioToolStripMenuItem.Text = "Glosario";
            // 
            // manualTécnicoToolStripMenuItem
            // 
            this.manualTécnicoToolStripMenuItem.Name = "manualTécnicoToolStripMenuItem";
            this.manualTécnicoToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.manualTécnicoToolStripMenuItem.Text = "Manual Técnico";
            this.manualTécnicoToolStripMenuItem.Click += new System.EventHandler(this.manualTécnicoToolStripMenuItem_Click);
            // 
            // manualDeUsuarioToolStripMenuItem
            // 
            this.manualDeUsuarioToolStripMenuItem.Name = "manualDeUsuarioToolStripMenuItem";
            this.manualDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.manualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1683, 849);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnAnalizarTrama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxTramaHexadecimal);
            this.Controls.Add(this.groupBoxAnalisis);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Análisis de Trama Ethernet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTrama)).EndInit();
            this.groupBoxAnalisis.ResumeLayout(false);
            this.groupBoxTramaHexadecimal.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVdetalles)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAnalizarTrama;
        private System.Windows.Forms.DataGridView DataGridTrama;
        private System.Windows.Forms.GroupBox groupBoxAnalisis;
        private System.Windows.Forms.GroupBox groupBoxTramaHexadecimal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TxtTramaBinario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DGVdetalles;
        private System.Windows.Forms.RichTextBox TxtHexa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IniHex;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinHex;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Informacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicionesDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NcaracteresDGV;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem analizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem glosarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualTécnicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualDeUsuarioToolStripMenuItem;
    }
}

