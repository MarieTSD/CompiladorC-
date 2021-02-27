
namespace ProyectoCompiladores_IDE
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cuadro = new System.Windows.Forms.RichTextBox();
            this.Pestañas = new System.Windows.Forms.TabControl();
            this.tabLexico = new System.Windows.Forms.TabPage();
            this.LexicoTextBox = new System.Windows.Forms.RichTextBox();
            this.tabSintactico = new System.Windows.Forms.TabPage();
            this.tabSemantico = new System.Windows.Forms.TabPage();
            this.tabCod_Intermd = new System.Windows.Forms.TabPage();
            this.Resultados = new System.Windows.Forms.TabControl();
            this.tabErrores = new System.Windows.Forms.TabPage();
            this.ErroresTextBox = new System.Windows.Forms.RichTextBox();
            this.tabResultados = new System.Windows.Forms.TabPage();
            this.ResulTextBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarCtrlXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guardar = new System.Windows.Forms.SaveFileDialog();
            this.Pestañas.SuspendLayout();
            this.tabLexico.SuspendLayout();
            this.tabSintactico.SuspendLayout();
            this.Resultados.SuspendLayout();
            this.tabErrores.SuspendLayout();
            this.tabResultados.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 234);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(331, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Mensaje";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(149, 279);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo a Compilar";
            // 
            // cuadro
            // 
            this.cuadro.Location = new System.Drawing.Point(12, 62);
            this.cuadro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cuadro.Name = "cuadro";
            this.cuadro.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.cuadro.Size = new System.Drawing.Size(593, 358);
            this.cuadro.TabIndex = 3;
            this.cuadro.Text = "";
            this.cuadro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Cambio_Texto);
            // 
            // Pestañas
            // 
            this.Pestañas.Controls.Add(this.tabLexico);
            this.Pestañas.Controls.Add(this.tabSintactico);
            this.Pestañas.Controls.Add(this.tabSemantico);
            this.Pestañas.Controls.Add(this.tabCod_Intermd);
            this.Pestañas.Location = new System.Drawing.Point(620, 62);
            this.Pestañas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pestañas.Name = "Pestañas";
            this.Pestañas.SelectedIndex = 0;
            this.Pestañas.Size = new System.Drawing.Size(400, 359);
            this.Pestañas.TabIndex = 4;
            // 
            // tabLexico
            // 
            this.tabLexico.Controls.Add(this.LexicoTextBox);
            this.tabLexico.Location = new System.Drawing.Point(4, 25);
            this.tabLexico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLexico.Name = "tabLexico";
            this.tabLexico.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLexico.Size = new System.Drawing.Size(392, 330);
            this.tabLexico.TabIndex = 0;
            this.tabLexico.Text = "Lexico";
            this.tabLexico.UseVisualStyleBackColor = true;
            // 
            // LexicoTextBox
            // 
            this.LexicoTextBox.Location = new System.Drawing.Point(0, 0);
            this.LexicoTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LexicoTextBox.Name = "LexicoTextBox";
            this.LexicoTextBox.ReadOnly = true;
            this.LexicoTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.LexicoTextBox.Size = new System.Drawing.Size(392, 330);
            this.LexicoTextBox.TabIndex = 0;
            this.LexicoTextBox.Text = "";
            // 
            // tabSintactico
            // 
            this.tabSintactico.Controls.Add(this.button2);
            this.tabSintactico.Controls.Add(this.button1);
            this.tabSintactico.Location = new System.Drawing.Point(4, 25);
            this.tabSintactico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSintactico.Name = "tabSintactico";
            this.tabSintactico.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSintactico.Size = new System.Drawing.Size(392, 330);
            this.tabSintactico.TabIndex = 1;
            this.tabSintactico.Text = "Sintactico";
            this.tabSintactico.UseVisualStyleBackColor = true;
            // 
            // tabSemantico
            // 
            this.tabSemantico.Location = new System.Drawing.Point(4, 25);
            this.tabSemantico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSemantico.Name = "tabSemantico";
            this.tabSemantico.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSemantico.Size = new System.Drawing.Size(392, 330);
            this.tabSemantico.TabIndex = 2;
            this.tabSemantico.Text = "Semantico";
            this.tabSemantico.UseVisualStyleBackColor = true;
            // 
            // tabCod_Intermd
            // 
            this.tabCod_Intermd.Location = new System.Drawing.Point(4, 25);
            this.tabCod_Intermd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCod_Intermd.Name = "tabCod_Intermd";
            this.tabCod_Intermd.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCod_Intermd.Size = new System.Drawing.Size(392, 330);
            this.tabCod_Intermd.TabIndex = 3;
            this.tabCod_Intermd.Text = "Codigo Intermedio";
            this.tabCod_Intermd.UseVisualStyleBackColor = true;
            // 
            // Resultados
            // 
            this.Resultados.Controls.Add(this.tabErrores);
            this.Resultados.Controls.Add(this.tabResultados);
            this.Resultados.Location = new System.Drawing.Point(12, 439);
            this.Resultados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Resultados.Name = "Resultados";
            this.Resultados.SelectedIndex = 0;
            this.Resultados.Size = new System.Drawing.Size(1008, 142);
            this.Resultados.TabIndex = 5;
            // 
            // tabErrores
            // 
            this.tabErrores.Controls.Add(this.ErroresTextBox);
            this.tabErrores.Location = new System.Drawing.Point(4, 25);
            this.tabErrores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabErrores.Name = "tabErrores";
            this.tabErrores.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabErrores.Size = new System.Drawing.Size(1000, 113);
            this.tabErrores.TabIndex = 0;
            this.tabErrores.Text = "Errores";
            this.tabErrores.UseVisualStyleBackColor = true;
            // 
            // ErroresTextBox
            // 
            this.ErroresTextBox.Location = new System.Drawing.Point(0, 0);
            this.ErroresTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ErroresTextBox.Name = "ErroresTextBox";
            this.ErroresTextBox.ReadOnly = true;
            this.ErroresTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ErroresTextBox.Size = new System.Drawing.Size(997, 114);
            this.ErroresTextBox.TabIndex = 0;
            this.ErroresTextBox.Text = "";
            // 
            // tabResultados
            // 
            this.tabResultados.Controls.Add(this.ResulTextBox);
            this.tabResultados.Location = new System.Drawing.Point(4, 25);
            this.tabResultados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabResultados.Name = "tabResultados";
            this.tabResultados.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabResultados.Size = new System.Drawing.Size(1000, 113);
            this.tabResultados.TabIndex = 1;
            this.tabResultados.Text = "Resultados";
            this.tabResultados.UseVisualStyleBackColor = true;
            // 
            // ResulTextBox
            // 
            this.ResulTextBox.Location = new System.Drawing.Point(0, 0);
            this.ResulTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResulTextBox.Name = "ResulTextBox";
            this.ResulTextBox.ReadOnly = true;
            this.ResulTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.ResulTextBox.Size = new System.Drawing.Size(997, 114);
            this.ResulTextBox.TabIndex = 0;
            this.ResulTextBox.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator4,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1031, 27);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.cerrarCtrlXToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(73, 24);
            this.toolStripDropDownButton1.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.abrirToolStripMenuItem.Text = "Abrir Ctrl + O";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.ClickBoton_ArchivoAbrir);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.guardarToolStripMenuItem.Text = "Guardar Ctrl + S";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.ClickBoton_ArchivoGuardar);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como Ctrl + G";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.ClickBoton_ArchivoCerrar);
            // 
            // cerrarCtrlXToolStripMenuItem
            // 
            this.cerrarCtrlXToolStripMenuItem.Name = "cerrarCtrlXToolStripMenuItem";
            this.cerrarCtrlXToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.cerrarCtrlXToolStripMenuItem.Text = "Cerrar Ctrl + X";
            this.cerrarCtrlXToolStripMenuItem.Click += new System.EventHandler(this.cerrarCtrlXToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 24);
            this.toolStripButton1.Text = "Editar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(69, 24);
            this.toolStripButton2.Text = "Formato";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(74, 24);
            this.toolStripButton3.Text = "Compilar";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(55, 24);
            this.toolStripButton4.Text = "Ayuda";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archivos de texto | *.txt";
            // 
            // guardar
            // 
            this.guardar.Filter = "Archivos de texto | *.txt";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1031, 593);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Resultados);
            this.Controls.Add(this.Pestañas);
            this.Controls.Add(this.cuadro);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Principal";
            this.Text = "Compilador";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Principal_KeyUp);
            this.Pestañas.ResumeLayout(false);
            this.tabLexico.ResumeLayout(false);
            this.tabSintactico.ResumeLayout(false);
            this.Resultados.ResumeLayout(false);
            this.tabErrores.ResumeLayout(false);
            this.tabResultados.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox cuadro;
        private System.Windows.Forms.TabControl Pestañas;
        private System.Windows.Forms.TabPage tabLexico;
        private System.Windows.Forms.TabPage tabSintactico;
        private System.Windows.Forms.TabPage tabSemantico;
        private System.Windows.Forms.TabPage tabCod_Intermd;
        private System.Windows.Forms.TabControl Resultados;
        private System.Windows.Forms.TabPage tabErrores;
        private System.Windows.Forms.TabPage tabResultados;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.RichTextBox LexicoTextBox;
        private System.Windows.Forms.RichTextBox ErroresTextBox;
        private System.Windows.Forms.RichTextBox ResulTextBox;
        private System.Windows.Forms.ToolStripMenuItem cerrarCtrlXToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog guardar;
    }
}

