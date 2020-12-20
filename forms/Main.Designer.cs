namespace ChemVis
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.renderWindowControl1 = new Kitware.VTK.RenderWindowControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.prętowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prętowyZPEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.czaszowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.orbitaleAtomoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orbitaleMolekularneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.siatkaGenerowanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.animationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zrzutEkranuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tłoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.białeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czarneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.niestandardowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bibliotekaVTKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wizualizacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vSEPRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorzyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(18, 86);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generuj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.renderWindowControl1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 899);
            this.panel1.TabIndex = 2;
            // 
            // renderWindowControl1
            // 
            this.renderWindowControl1.AddTestActors = false;
            this.renderWindowControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.renderWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.renderWindowControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.renderWindowControl1.Name = "renderWindowControl1";
            this.renderWindowControl1.Size = new System.Drawing.Size(1026, 692);
            this.renderWindowControl1.TabIndex = 4;
            this.renderWindowControl1.TestText = null;
            this.renderWindowControl1.Load += new System.EventHandler(this.renderWindowControl1_Load_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripSeparator4,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 692);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1026, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "<<";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = ">>";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Text = "Odświerz";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton5.Text = "Zoom In";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton4.Text = "Zoom Out";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prętowyToolStripMenuItem,
            this.prętowyZPEToolStripMenuItem,
            this.toolStripSeparator6,
            this.czaszowyToolStripMenuItem,
            this.toolStripSeparator5,
            this.orbitaleAtomoweToolStripMenuItem,
            this.orbitaleMolekularneToolStripMenuItem,
            this.toolStripSeparator7,
            this.siatkaGenerowanaToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(45, 28);
            this.toolStripSplitButton1.Text = "Tryby";
            // 
            // prętowyToolStripMenuItem
            // 
            this.prętowyToolStripMenuItem.Name = "prętowyToolStripMenuItem";
            this.prętowyToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.prętowyToolStripMenuItem.Text = "Prętowy";
            this.prętowyToolStripMenuItem.Click += new System.EventHandler(this.prętowyToolStripMenuItem_Click);
            // 
            // prętowyZPEToolStripMenuItem
            // 
            this.prętowyZPEToolStripMenuItem.Name = "prętowyZPEToolStripMenuItem";
            this.prętowyZPEToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.prętowyZPEToolStripMenuItem.Text = "Prętowy z PE";
            this.prętowyZPEToolStripMenuItem.Click += new System.EventHandler(this.prętowyZPEToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(258, 6);
            // 
            // czaszowyToolStripMenuItem
            // 
            this.czaszowyToolStripMenuItem.Name = "czaszowyToolStripMenuItem";
            this.czaszowyToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.czaszowyToolStripMenuItem.Text = "Czaszowy";
            this.czaszowyToolStripMenuItem.Click += new System.EventHandler(this.czaszowyToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(258, 6);
            // 
            // orbitaleAtomoweToolStripMenuItem
            // 
            this.orbitaleAtomoweToolStripMenuItem.Name = "orbitaleAtomoweToolStripMenuItem";
            this.orbitaleAtomoweToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.orbitaleAtomoweToolStripMenuItem.Text = "Orbitale Atomowe";
            // 
            // orbitaleMolekularneToolStripMenuItem
            // 
            this.orbitaleMolekularneToolStripMenuItem.Name = "orbitaleMolekularneToolStripMenuItem";
            this.orbitaleMolekularneToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.orbitaleMolekularneToolStripMenuItem.Text = "Orbitale Molekularne";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(258, 6);
            // 
            // siatkaGenerowanaToolStripMenuItem
            // 
            this.siatkaGenerowanaToolStripMenuItem.Name = "siatkaGenerowanaToolStripMenuItem";
            this.siatkaGenerowanaToolStripMenuItem.Size = new System.Drawing.Size(261, 30);
            this.siatkaGenerowanaToolStripMenuItem.Text = "Siatka Generowana";
            this.siatkaGenerowanaToolStripMenuItem.Click += new System.EventHandler(this.siatkaGenerowanaToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Location = new System.Drawing.Point(0, 723);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1026, 176);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1026, 35);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // animationToolStripMenuItem
            // 
            this.animationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.zrzutEkranuToolStripMenuItem,
            this.tłoToolStripMenuItem,
            this.toolStripSeparator2,
            this.bibliotekaVTKToolStripMenuItem});
            this.animationToolStripMenuItem.Name = "animationToolStripMenuItem";
            this.animationToolStripMenuItem.Size = new System.Drawing.Size(118, 29);
            this.animationToolStripMenuItem.Text = "Wizualizacja";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // zrzutEkranuToolStripMenuItem
            // 
            this.zrzutEkranuToolStripMenuItem.Name = "zrzutEkranuToolStripMenuItem";
            this.zrzutEkranuToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.zrzutEkranuToolStripMenuItem.Text = "Zrzut ekranu";
            this.zrzutEkranuToolStripMenuItem.Click += new System.EventHandler(this.zrzutEkranuToolStripMenuItem_Click);
            // 
            // tłoToolStripMenuItem
            // 
            this.tłoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.białeToolStripMenuItem,
            this.czarneToolStripMenuItem,
            this.szareToolStripMenuItem,
            this.toolStripSeparator1,
            this.niestandardowyToolStripMenuItem});
            this.tłoToolStripMenuItem.Name = "tłoToolStripMenuItem";
            this.tłoToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.tłoToolStripMenuItem.Text = "Tło";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.standardToolStripMenuItem.Text = "Standard";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
            // 
            // białeToolStripMenuItem
            // 
            this.białeToolStripMenuItem.Name = "białeToolStripMenuItem";
            this.białeToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.białeToolStripMenuItem.Text = "Białe";
            this.białeToolStripMenuItem.Click += new System.EventHandler(this.białeToolStripMenuItem_Click);
            // 
            // czarneToolStripMenuItem
            // 
            this.czarneToolStripMenuItem.Name = "czarneToolStripMenuItem";
            this.czarneToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.czarneToolStripMenuItem.Text = "Czarne";
            this.czarneToolStripMenuItem.Click += new System.EventHandler(this.czarneToolStripMenuItem_Click);
            // 
            // szareToolStripMenuItem
            // 
            this.szareToolStripMenuItem.Name = "szareToolStripMenuItem";
            this.szareToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.szareToolStripMenuItem.Text = "Szare";
            this.szareToolStripMenuItem.Click += new System.EventHandler(this.szareToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // niestandardowyToolStripMenuItem
            // 
            this.niestandardowyToolStripMenuItem.Name = "niestandardowyToolStripMenuItem";
            this.niestandardowyToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.niestandardowyToolStripMenuItem.Text = "Niestandardowe";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // bibliotekaVTKToolStripMenuItem
            // 
            this.bibliotekaVTKToolStripMenuItem.Name = "bibliotekaVTKToolStripMenuItem";
            this.bibliotekaVTKToolStripMenuItem.Size = new System.Drawing.Size(208, 30);
            this.bibliotekaVTKToolStripMenuItem.Text = "Biblioteka VTK";
            this.bibliotekaVTKToolStripMenuItem.Click += new System.EventHandler(this.bibliotekaVTKToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wizualizacjaToolStripMenuItem,
            this.vSEPRToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(108, 29);
            this.settingsToolStripMenuItem.Text = "Ustawienia";
            // 
            // wizualizacjaToolStripMenuItem
            // 
            this.wizualizacjaToolStripMenuItem.Name = "wizualizacjaToolStripMenuItem";
            this.wizualizacjaToolStripMenuItem.Size = new System.Drawing.Size(196, 30);
            this.wizualizacjaToolStripMenuItem.Text = "Baza Danych";
            // 
            // vSEPRToolStripMenuItem
            // 
            this.vSEPRToolStripMenuItem.Name = "vSEPRToolStripMenuItem";
            this.vSEPRToolStripMenuItem.Size = new System.Drawing.Size(196, 30);
            this.vSEPRToolStripMenuItem.Text = "VSEPR";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorzyToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(56, 29);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // autorzyToolStripMenuItem
            // 
            this.autorzyToolStripMenuItem.Name = "autorzyToolStripMenuItem";
            this.autorzyToolStripMenuItem.Size = new System.Drawing.Size(158, 30);
            this.autorzyToolStripMenuItem.Text = "Autorzy";
            this.autorzyToolStripMenuItem.Click += new System.EventHandler(this.autorzyToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(158, 30);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            this.pomocToolStripMenuItem.Click += new System.EventHandler(this.pomocToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.checkBox5);
            this.panel2.Controls.Add(this.checkBox4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.checkBox3);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 354);
            this.panel2.TabIndex = 4;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox5.Location = new System.Drawing.Point(208, 98);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(79, 29);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Text = "Auto";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox4.Location = new System.Drawing.Point(18, 245);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(273, 29);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "Wykryj związek organiczny";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Control;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 339);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(396, 15);
            this.panel5.TabIndex = 6;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox3.Location = new System.Drawing.Point(18, 286);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(187, 29);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Generuj strukture";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox2.Location = new System.Drawing.Point(18, 203);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(164, 29);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Stereoizomery";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBox1.Location = new System.Drawing.Point(18, 162);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(190, 29);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Ligand zastępczy";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(18, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 53);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel3.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1026, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(15, 15, 15, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 934);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.listBox2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 354);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(396, 580);
            this.panel4.TabIndex = 5;
            // 
            // listBox2
            // 
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(0, 29);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(396, 551);
            this.listBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Szczegóły";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 934);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(739, 431);
            this.Name = "Main";
            this.Text = "ChemVis";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem animationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tłoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem białeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czarneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem niestandardowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem bibliotekaVTKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wizualizacjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vSEPRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autorzyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem czaszowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prętowyToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox4;
        public Kitware.VTK.RenderWindowControl renderWindowControl1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.ToolStripMenuItem prętowyZPEToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem orbitaleAtomoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orbitaleMolekularneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem siatkaGenerowanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zrzutEkranuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

