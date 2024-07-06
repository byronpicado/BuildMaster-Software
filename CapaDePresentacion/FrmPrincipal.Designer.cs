using System.Windows.Forms;
using System;
using CapaDeNegocio.CN_CRUD;
using CapaDeDatos;

namespace CapaDePresentacion
{

    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.MenuVertical = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButtonResponsable = new FontAwesome.Sharp.IconButton();
            this.iconButtonProgreso = new FontAwesome.Sharp.IconButton();
            this.iconButtonPersonal = new FontAwesome.Sharp.IconButton();
            this.iconButtonMantenimiento = new FontAwesome.Sharp.IconButton();
            this.iconButtonHabilidad = new FontAwesome.Sharp.IconButton();
            this.iconButtonEquipo = new FontAwesome.Sharp.IconButton();
            this.iconButtonCliente = new FontAwesome.Sharp.IconButton();
            this.btnlogoInicio = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.BarraTitulo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.iconButtonRecurso = new FontAwesome.Sharp.IconButton();
            this.iconButtonTarea = new FontAwesome.Sharp.IconButton();
            this.iconButtonProyecto = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblhora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.DGVProyectoDetalle = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.submenureportecompras = new System.Windows.Forms.ToolStripMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.MenuVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogoInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProyectoDetalle)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuVertical
            // 
            this.MenuVertical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(184)))), ((int)(((byte)(45)))));
            this.MenuVertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MenuVertical.Controls.Add(this.label1);
            this.MenuVertical.Controls.Add(this.iconButtonResponsable);
            this.MenuVertical.Controls.Add(this.iconButtonProgreso);
            this.MenuVertical.Controls.Add(this.iconButtonPersonal);
            this.MenuVertical.Controls.Add(this.iconButtonMantenimiento);
            this.MenuVertical.Controls.Add(this.iconButtonHabilidad);
            this.MenuVertical.Controls.Add(this.iconButtonEquipo);
            this.MenuVertical.Controls.Add(this.iconButtonCliente);
            this.MenuVertical.Controls.Add(this.btnlogoInicio);
            this.MenuVertical.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuVertical.Location = new System.Drawing.Point(0, 0);
            this.MenuVertical.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MenuVertical.Name = "MenuVertical";
            this.MenuVertical.Size = new System.Drawing.Size(315, 1050);
            this.MenuVertical.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 39;
            this.label1.Text = "Catálogos";
            // 
            // iconButtonResponsable
            // 
            this.iconButtonResponsable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonResponsable.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.iconButtonResponsable.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonResponsable.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonResponsable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonResponsable.Location = new System.Drawing.Point(-1, 569);
            this.iconButtonResponsable.Name = "iconButtonResponsable";
            this.iconButtonResponsable.Size = new System.Drawing.Size(315, 60);
            this.iconButtonResponsable.TabIndex = 38;
            this.iconButtonResponsable.Text = "Responsable";
            this.iconButtonResponsable.UseVisualStyleBackColor = false;
            this.iconButtonResponsable.Click += new System.EventHandler(this.iconButtonResponsable_Click);
            // 
            // iconButtonProgreso
            // 
            this.iconButtonProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonProgreso.IconChar = FontAwesome.Sharp.IconChar.ChartGantt;
            this.iconButtonProgreso.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonProgreso.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonProgreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonProgreso.Location = new System.Drawing.Point(-1, 503);
            this.iconButtonProgreso.Name = "iconButtonProgreso";
            this.iconButtonProgreso.Size = new System.Drawing.Size(315, 60);
            this.iconButtonProgreso.TabIndex = 37;
            this.iconButtonProgreso.Text = " Progreso";
            this.iconButtonProgreso.UseVisualStyleBackColor = false;
            this.iconButtonProgreso.Click += new System.EventHandler(this.iconButtonProgreso_Click);
            // 
            // iconButtonPersonal
            // 
            this.iconButtonPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonPersonal.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.iconButtonPersonal.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonPersonal.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonPersonal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonPersonal.Location = new System.Drawing.Point(-1, 437);
            this.iconButtonPersonal.Name = "iconButtonPersonal";
            this.iconButtonPersonal.Size = new System.Drawing.Size(315, 60);
            this.iconButtonPersonal.TabIndex = 36;
            this.iconButtonPersonal.Text = "Personal";
            this.iconButtonPersonal.UseVisualStyleBackColor = false;
            this.iconButtonPersonal.Click += new System.EventHandler(this.iconButtonPersonal_Click);
            // 
            // iconButtonMantenimiento
            // 
            this.iconButtonMantenimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonMantenimiento.IconChar = FontAwesome.Sharp.IconChar.Hammer;
            this.iconButtonMantenimiento.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonMantenimiento.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonMantenimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonMantenimiento.Location = new System.Drawing.Point(-1, 370);
            this.iconButtonMantenimiento.Name = "iconButtonMantenimiento";
            this.iconButtonMantenimiento.Size = new System.Drawing.Size(315, 60);
            this.iconButtonMantenimiento.TabIndex = 35;
            this.iconButtonMantenimiento.Text = "Mantenimiento";
            this.iconButtonMantenimiento.UseVisualStyleBackColor = false;
            this.iconButtonMantenimiento.Click += new System.EventHandler(this.iconButtonMantenimiento_Click);
            // 
            // iconButtonHabilidad
            // 
            this.iconButtonHabilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonHabilidad.IconChar = FontAwesome.Sharp.IconChar.GraduationCap;
            this.iconButtonHabilidad.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonHabilidad.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonHabilidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonHabilidad.Location = new System.Drawing.Point(-1, 304);
            this.iconButtonHabilidad.Name = "iconButtonHabilidad";
            this.iconButtonHabilidad.Size = new System.Drawing.Size(315, 60);
            this.iconButtonHabilidad.TabIndex = 34;
            this.iconButtonHabilidad.Text = "Habilidad";
            this.iconButtonHabilidad.UseVisualStyleBackColor = false;
            this.iconButtonHabilidad.Click += new System.EventHandler(this.iconButtonHabilidad_Click);
            // 
            // iconButtonEquipo
            // 
            this.iconButtonEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonEquipo.IconChar = FontAwesome.Sharp.IconChar.Tractor;
            this.iconButtonEquipo.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonEquipo.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonEquipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonEquipo.Location = new System.Drawing.Point(0, 238);
            this.iconButtonEquipo.Name = "iconButtonEquipo";
            this.iconButtonEquipo.Size = new System.Drawing.Size(315, 60);
            this.iconButtonEquipo.TabIndex = 33;
            this.iconButtonEquipo.Text = "Equipo";
            this.iconButtonEquipo.UseVisualStyleBackColor = false;
            this.iconButtonEquipo.Click += new System.EventHandler(this.iconButtonEquipo_Click);
            // 
            // iconButtonCliente
            // 
            this.iconButtonCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonCliente.IconChar = FontAwesome.Sharp.IconChar.Person;
            this.iconButtonCliente.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonCliente.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonCliente.Location = new System.Drawing.Point(0, 172);
            this.iconButtonCliente.Name = "iconButtonCliente";
            this.iconButtonCliente.Rotation = 1D;
            this.iconButtonCliente.Size = new System.Drawing.Size(315, 60);
            this.iconButtonCliente.TabIndex = 32;
            this.iconButtonCliente.Text = "Cliente";
            this.iconButtonCliente.UseVisualStyleBackColor = false;
            this.iconButtonCliente.Click += new System.EventHandler(this.iconButtonCliente_Click);
            // 
            // btnlogoInicio
            // 
            this.btnlogoInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogoInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnlogoInicio.Image")));
            this.btnlogoInicio.Location = new System.Drawing.Point(0, 0);
            this.btnlogoInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnlogoInicio.Name = "btnlogoInicio";
            this.btnlogoInicio.Size = new System.Drawing.Size(90, 107);
            this.btnlogoInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnlogoInicio.TabIndex = 0;
            this.btnlogoInicio.TabStop = false;
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.Location = new System.Drawing.Point(403, 14);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(52, 54);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 2;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // BarraTitulo
            // 
            this.BarraTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BarraTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BarraTitulo.Controls.Add(this.label2);
            this.BarraTitulo.Controls.Add(this.iconButtonRecurso);
            this.BarraTitulo.Controls.Add(this.iconButtonTarea);
            this.BarraTitulo.Controls.Add(this.iconButtonProyecto);
            this.BarraTitulo.Controls.Add(this.pictureBox1);
            this.BarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraTitulo.Location = new System.Drawing.Point(315, 0);
            this.BarraTitulo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BarraTitulo.Name = "BarraTitulo";
            this.BarraTitulo.Size = new System.Drawing.Size(1609, 138);
            this.BarraTitulo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(106, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "Catálogos";
            // 
            // iconButtonRecurso
            // 
            this.iconButtonRecurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonRecurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonRecurso.IconChar = FontAwesome.Sharp.IconChar.PaintRoller;
            this.iconButtonRecurso.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonRecurso.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonRecurso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonRecurso.Location = new System.Drawing.Point(747, 56);
            this.iconButtonRecurso.Name = "iconButtonRecurso";
            this.iconButtonRecurso.Rotation = 1D;
            this.iconButtonRecurso.Size = new System.Drawing.Size(315, 60);
            this.iconButtonRecurso.TabIndex = 41;
            this.iconButtonRecurso.Text = "Recurso";
            this.iconButtonRecurso.UseVisualStyleBackColor = false;
            this.iconButtonRecurso.Click += new System.EventHandler(this.iconButtonRecurso_Click);
            // 
            // iconButtonTarea
            // 
            this.iconButtonTarea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonTarea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonTarea.IconChar = FontAwesome.Sharp.IconChar.ListCheck;
            this.iconButtonTarea.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonTarea.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonTarea.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonTarea.Location = new System.Drawing.Point(426, 56);
            this.iconButtonTarea.Name = "iconButtonTarea";
            this.iconButtonTarea.Rotation = 1D;
            this.iconButtonTarea.Size = new System.Drawing.Size(315, 60);
            this.iconButtonTarea.TabIndex = 40;
            this.iconButtonTarea.Text = "Tarea";
            this.iconButtonTarea.UseVisualStyleBackColor = false;
            this.iconButtonTarea.Click += new System.EventHandler(this.iconButtonTarea_Click);
            // 
            // iconButtonProyecto
            // 
            this.iconButtonProyecto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButtonProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButtonProyecto.IconChar = FontAwesome.Sharp.IconChar.BuildingUser;
            this.iconButtonProyecto.IconColor = System.Drawing.Color.LightGreen;
            this.iconButtonProyecto.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButtonProyecto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButtonProyecto.Location = new System.Drawing.Point(110, 56);
            this.iconButtonProyecto.Name = "iconButtonProyecto";
            this.iconButtonProyecto.Rotation = 1D;
            this.iconButtonProyecto.Size = new System.Drawing.Size(315, 60);
            this.iconButtonProyecto.TabIndex = 39;
            this.iconButtonProyecto.Text = "Proyecto";
            this.iconButtonProyecto.UseVisualStyleBackColor = false;
            this.iconButtonProyecto.Click += new System.EventHandler(this.iconButtonProyecto_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 56);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // lblhora
            // 
            this.lblhora.AutoSize = true;
            this.lblhora.BackColor = System.Drawing.Color.Transparent;
            this.lblhora.CausesValidation = false;
            this.lblhora.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblhora.Location = new System.Drawing.Point(1374, 868);
            this.lblhora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(419, 115);
            this.lblhora.TabIndex = 30;
            this.lblhora.Text = "10:59:58";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblFecha.Location = new System.Drawing.Point(1286, 967);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(619, 49);
            this.lblFecha.TabIndex = 31;
            this.lblFecha.Text = "Miercoles, 10  noviembre  2017";
            // 
            // DGVProyectoDetalle
            // 
            this.DGVProyectoDetalle.AllowUserToAddRows = false;
            this.DGVProyectoDetalle.AllowUserToDeleteRows = false;
            this.DGVProyectoDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVProyectoDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVProyectoDetalle.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.DGVProyectoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProyectoDetalle.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.DGVProyectoDetalle.Location = new System.Drawing.Point(343, 305);
            this.DGVProyectoDetalle.Name = "DGVProyectoDetalle";
            this.DGVProyectoDetalle.ReadOnly = true;
            this.DGVProyectoDetalle.RowHeadersWidth = 62;
            this.DGVProyectoDetalle.RowTemplate.Height = 28;
            this.DGVProyectoDetalle.Size = new System.Drawing.Size(1003, 390);
            this.DGVProyectoDetalle.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(338, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 29);
            this.label3.TabIndex = 44;
            this.label3.Text = "Proyectos ";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(184)))), ((int)(((byte)(45)))));
            this.iconButton1.ForeColor = System.Drawing.Color.Black;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.PencilAlt;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 29;
            this.iconButton1.Location = new System.Drawing.Point(1285, 253);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(61, 46);
            this.iconButton1.TabIndex = 48;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem1,
            this.menureportes,
            this.menuacercade});
            this.menu.Location = new System.Drawing.Point(315, 138);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1609, 75);
            this.menu.TabIndex = 50;
            this.menu.Text = "menuStrip1";
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.AutoSize = false;
            this.iconMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.iconMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            this.iconMenuItem1.IconColor = System.Drawing.Color.LightGreen;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(182, 69);
            this.iconMenuItem1.Text = "Reportes";
            this.iconMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 34);
            this.toolStripMenuItem1.Text = "Listados";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem2.Text = "Reporte de Cliente";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem3.Text = "Reporte de Responsable";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem4.Text = "Reporte de Personal";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem5.Text = "Reporte de Habilidad";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem6.Text = "Reporte de Tarea";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Checked = true;
            this.toolStripMenuItem7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem7.Text = "Reporte de Recurso";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem8.Text = "Reporte de Equipo";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem9.Text = "Reporte de Mantenimiento";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem10.Text = "Reporte de Progreso";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(394, 34);
            this.toolStripMenuItem11.Text = "Reporte de Proyecto";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenureportecompras});
            this.menureportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.menureportes.IconColor = System.Drawing.Color.LightGreen;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(182, 69);
            this.menureportes.Text = " Operaciones";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenureportecompras
            // 
            this.submenureportecompras.Name = "submenureportecompras";
            this.submenureportecompras.Size = new System.Drawing.Size(394, 34);
            this.submenureportecompras.Text = " Mantenimiento del equipo";
            this.submenureportecompras.Click += new System.EventHandler(this.submenureportecompras_Click);
            // 
            // menuacercade
            // 
            this.menuacercade.AutoSize = false;
            this.menuacercade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuacercade.IconColor = System.Drawing.Color.LightGreen;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.Size = new System.Drawing.Size(182, 69);
            this.menuacercade.Text = "Acerca de";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuacercade.Click += new System.EventHandler(this.menuacercade_Click);
            // 
            // FrmPrincipal
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DGVProyectoDetalle);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.BarraTitulo);
            this.Controls.Add(this.lblhora);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.MenuVertical);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmPrincipal";
            this.Text = "Build Master Construction SoftWare";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.MenuVertical.ResumeLayout(false);
            this.MenuVertical.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnlogoInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.BarraTitulo.ResumeLayout(false);
            this.BarraTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProyectoDetalle)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MostrarProyectosDetalle(); 

        }
   

        private Panel MenuVertical;
        private PictureBox btnlogoInicio;
        private PictureBox btnMenu;
        private Panel BarraTitulo;
        private PictureBox pictureBox1;
        private Timer timer1;
        private FontAwesome.Sharp.IconButton iconButtonCliente;
        private FontAwesome.Sharp.IconButton iconButtonEquipo;
        private FontAwesome.Sharp.IconButton iconButtonHabilidad;
        private FontAwesome.Sharp.IconButton iconButtonMantenimiento;
        private FontAwesome.Sharp.IconButton iconButtonPersonal;
        private FontAwesome.Sharp.IconButton iconButtonResponsable;
        private FontAwesome.Sharp.IconButton iconButtonProgreso;
        private FontAwesome.Sharp.IconButton iconButtonProyecto;
        private FontAwesome.Sharp.IconButton iconButtonRecurso;
        private FontAwesome.Sharp.IconButton iconButtonTarea;
        private Label label1;
        private Label label2;
        private Label lblhora;
        private Label lblFecha;
        private DataGridView DGVProyectoDetalle;
        private Label label3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private MenuStrip menu;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private ToolStripMenuItem submenureportecompras;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
    }
}

