
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
            this.label1 = new System.Windows.Forms.Label();
            this.cuadro = new System.Windows.Forms.RichTextBox();
            this.Pestañas = new System.Windows.Forms.TabControl();
            this.tabLexico = new System.Windows.Forms.TabPage();
            this.LexicoTextBox = new System.Windows.Forms.RichTextBox();
            this.tabSintactico = new System.Windows.Forms.TabPage();
            this.arbolSintactico = new System.Windows.Forms.TreeView();
            this.tabSemantico = new System.Windows.Forms.TabPage();
            this.arbolSemantico = new System.Windows.Forms.TreeView();
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
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.guardar = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Pestañas.SuspendLayout();
            this.tabLexico.SuspendLayout();
            this.tabSintactico.SuspendLayout();
            this.tabSemantico.SuspendLayout();
            this.Resultados.SuspendLayout();
            this.tabErrores.SuspendLayout();
            this.tabResultados.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Codigo a Compilar";
            // 
            // cuadro
            // 
            this.cuadro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuadro.Location = new System.Drawing.Point(12, 62);
            this.cuadro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cuadro.Name = "cuadro";
            this.cuadro.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.cuadro.Size = new System.Drawing.Size(593, 448);
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
            this.Pestañas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pestañas.ItemSize = new System.Drawing.Size(61, 20);
            this.Pestañas.Location = new System.Drawing.Point(12, 38);
            this.Pestañas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pestañas.Name = "Pestañas";
            this.Pestañas.SelectedIndex = 0;
            this.Pestañas.Size = new System.Drawing.Size(409, 446);
            this.Pestañas.TabIndex = 4;
            // 
            // tabLexico
            // 
            this.tabLexico.Controls.Add(this.LexicoTextBox);
            this.tabLexico.Location = new System.Drawing.Point(4, 24);
            this.tabLexico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLexico.Name = "tabLexico";
            this.tabLexico.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLexico.Size = new System.Drawing.Size(401, 418);
            this.tabLexico.TabIndex = 0;
            this.tabLexico.Text = "Lexico";
            this.tabLexico.UseVisualStyleBackColor = true;
            // 
            // LexicoTextBox
            // 
            this.LexicoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LexicoTextBox.Location = new System.Drawing.Point(0, 0);
            this.LexicoTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LexicoTextBox.Name = "LexicoTextBox";
            this.LexicoTextBox.ReadOnly = true;
            this.LexicoTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.LexicoTextBox.Size = new System.Drawing.Size(392, 434);
            this.LexicoTextBox.TabIndex = 0;
            this.LexicoTextBox.Text = "";
            // 
            // tabSintactico
            // 
            this.tabSintactico.Controls.Add(this.arbolSintactico);
            this.tabSintactico.Location = new System.Drawing.Point(4, 24);
            this.tabSintactico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSintactico.Name = "tabSintactico";
            this.tabSintactico.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSintactico.Size = new System.Drawing.Size(401, 418);
            this.tabSintactico.TabIndex = 1;
            this.tabSintactico.Text = "Sintactico";
            this.tabSintactico.UseVisualStyleBackColor = true;
            this.tabSintactico.Click += new System.EventHandler(this.tabSintactico_Click);
            // 
            // arbolSintactico
            // 
            this.arbolSintactico.Location = new System.Drawing.Point(1, 0);
            this.arbolSintactico.Margin = new System.Windows.Forms.Padding(4);
            this.arbolSintactico.Name = "arbolSintactico";
            this.arbolSintactico.Size = new System.Drawing.Size(400, 418);
            this.arbolSintactico.TabIndex = 0;
            // 
            // tabSemantico
            // 
            this.tabSemantico.Controls.Add(this.arbolSemantico);
            this.tabSemantico.Location = new System.Drawing.Point(4, 24);
            this.tabSemantico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSemantico.Name = "tabSemantico";
            this.tabSemantico.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabSemantico.Size = new System.Drawing.Size(401, 418);
            this.tabSemantico.TabIndex = 2;
            this.tabSemantico.Text = "Semantico";
            this.tabSemantico.UseVisualStyleBackColor = true;
            // 
            // arbolSemantico
            // 
            this.arbolSemantico.Location = new System.Drawing.Point(0, 0);
            this.arbolSemantico.Name = "arbolSemantico";
            this.arbolSemantico.Size = new System.Drawing.Size(398, 415);
            this.arbolSemantico.TabIndex = 0;
            // 
            // tabCod_Intermd
            // 
            this.tabCod_Intermd.Location = new System.Drawing.Point(4, 24);
            this.tabCod_Intermd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCod_Intermd.Name = "tabCod_Intermd";
            this.tabCod_Intermd.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabCod_Intermd.Size = new System.Drawing.Size(401, 418);
            this.tabCod_Intermd.TabIndex = 3;
            this.tabCod_Intermd.Text = "Codigo Intermedio";
            this.tabCod_Intermd.UseVisualStyleBackColor = true;
            // 
            // Resultados
            // 
            this.Resultados.Controls.Add(this.tabErrores);
            this.Resultados.Controls.Add(this.tabResultados);
            this.Resultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resultados.Location = new System.Drawing.Point(13, 12);
            this.Resultados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Resultados.Name = "Resultados";
            this.Resultados.SelectedIndex = 0;
            this.Resultados.Size = new System.Drawing.Size(1008, 142);
            this.Resultados.TabIndex = 5;
            // 
            // tabErrores
            // 
            this.tabErrores.Controls.Add(this.ErroresTextBox);
            this.tabErrores.Location = new System.Drawing.Point(4, 29);
            this.tabErrores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabErrores.Name = "tabErrores";
            this.tabErrores.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabErrores.Size = new System.Drawing.Size(1000, 109);
            this.tabErrores.TabIndex = 0;
            this.tabErrores.Text = "Errores";
            this.tabErrores.UseVisualStyleBackColor = true;
            // 
            // ErroresTextBox
            // 
            this.ErroresTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.tabResultados.Location = new System.Drawing.Point(4, 29);
            this.tabResultados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabResultados.Name = "tabResultados";
            this.tabResultados.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabResultados.Size = new System.Drawing.Size(1000, 109);
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
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripDropDownButton2,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator4,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1035, 30);
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
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(81, 27);
            this.toolStripDropDownButton1.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources._62319;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(273, 28);
            this.abrirToolStripMenuItem.Text = "Abrir Ctrl + O";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.ClickBoton_ArchivoAbrir);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources._140_1408496_png_file_icono_de_guardar_png_clipart;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(273, 28);
            this.guardarToolStripMenuItem.Text = "Guardar Ctrl + S";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.ClickBoton_ArchivoGuardar);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources._62124;
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(273, 28);
            this.guardarComoToolStripMenuItem.Text = "Guardar Como Ctrl + G";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.ClickBoton_ArchivoCerrar);
            // 
            // cerrarCtrlXToolStripMenuItem
            // 
            this.cerrarCtrlXToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources.cerrar_borrar_boton_eliminar_318_9073;
            this.cerrarCtrlXToolStripMenuItem.Name = "cerrarCtrlXToolStripMenuItem";
            this.cerrarCtrlXToolStripMenuItem.Size = new System.Drawing.Size(273, 28);
            this.cerrarCtrlXToolStripMenuItem.Text = "Cerrar Ctrl + X";
            this.cerrarCtrlXToolStripMenuItem.Click += new System.EventHandler(this.cerrarCtrlXToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.cortarToolStripMenuItem,
            this.unToolStripMenuItem,
            this.seleccionarTodoToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(68, 27);
            this.toolStripDropDownButton2.Text = "Editar";
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources._32565;
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(291, 28);
            this.copiarToolStripMenuItem.Text = "Copiar Ctrl + C";
            this.copiarToolStripMenuItem.Click += new System.EventHandler(this.copiarToolStripMenuItem_Click);
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources._84340;
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(291, 28);
            this.pegarToolStripMenuItem.Text = "Pegar Ctrl + V";
            this.pegarToolStripMenuItem.Click += new System.EventHandler(this.pegarToolStripMenuItem_Click);
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources._2129819;
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(291, 28);
            this.cortarToolStripMenuItem.Text = "Cortar Ctrl + D";
            this.cortarToolStripMenuItem.Click += new System.EventHandler(this.cortarToolStripMenuItem_Click);
            // 
            // unToolStripMenuItem
            // 
            this.unToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources.kisspng_computer_icons_icon_design_undo_download_curve_5abbc5b5d0c494_4762120115222552858551;
            this.unToolStripMenuItem.Name = "unToolStripMenuItem";
            this.unToolStripMenuItem.Size = new System.Drawing.Size(291, 28);
            this.unToolStripMenuItem.Text = "Deshacer Ctrl + U";
            this.unToolStripMenuItem.Click += new System.EventHandler(this.unToolStripMenuItem_Click);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Image = global::ProyectoCompiladores_IDE.Properties.Resources._565339;
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(291, 28);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar todo  Ctrl + A";
            this.seleccionarTodoToolStripMenuItem.Click += new System.EventHandler(this.seleccionarTodoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(78, 27);
            this.toolStripButton2.Text = "Formato";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(83, 27);
            this.toolStripButton3.Text = "Compilar";
            this.toolStripButton3.Click += new System.EventHandler(this.Click_compilar);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(62, 27);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.Pestañas);
            this.panel1.Location = new System.Drawing.Point(611, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 498);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.Resultados);
            this.panel2.Location = new System.Drawing.Point(0, 514);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1040, 165);
            this.panel2.TabIndex = 8;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1035, 683);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cuadro);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Principal";
            this.Text = "Compilador";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Principal_KeyUp);
            this.Pestañas.ResumeLayout(false);
            this.tabLexico.ResumeLayout(false);
            this.tabSintactico.ResumeLayout(false);
            this.tabSemantico.ResumeLayout(false);
            this.Resultados.ResumeLayout(false);
            this.tabErrores.ResumeLayout(false);
            this.tabResultados.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox cuadro;
        private System.Windows.Forms.TabControl Pestañas;
        private System.Windows.Forms.TabPage tabLexico;
        private System.Windows.Forms.TabPage tabSintactico;
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
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView arbolSintactico;
        private System.Windows.Forms.TabPage tabSemantico;
        private System.Windows.Forms.TreeView arbolSemantico;
    }
}

