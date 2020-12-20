using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kitware.VTK;

namespace ChemVis
{
    public partial class Main : Form
    {
        public Datavis datavis;
        public vtkRenderer win;
        public vtkCamera cam;
        public VSEPR vsepr;
        public Main()
        {
            InitializeComponent();
            datavis = new Datavis(this);
            vsepr = new VSEPR();
        }

        private void renderWindowControl1_Load(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {
            vsepr.Build(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)

        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            vsepr.Load(datavis);
            checkBox1.Checked = vsepr.settings.ligand_repl;
            checkBox2.Checked = vsepr.settings.stereoisomers;
            checkBox3.Checked = vsepr.settings.generatestruct;
            checkBox4.Checked = !vsepr.settings.quickbuild;
            checkBox5.Checked = vsepr.settings.auto;
            if (vsepr.settings.auto)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
            win.SetBackground(vsepr.settings.backcolor.x, vsepr.settings.backcolor.y, vsepr.settings.backcolor.z);
            datavis.refreshCamera();
            ToolTip t = new ToolTip();
            t.SetToolTip(textBox1, "Tutaj wpisz wzór");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cam.Zoom(10);
            datavis.Reload();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void renderWindowControl1_Load_1(object sender, EventArgs e)
        {
            // get a reference to the renderwindow of our renderWindowControl1
            vtkRenderWindow RenderWindow = renderWindowControl1.RenderWindow;

            // get a reference to the renderer
            vtkRenderer Renderer = RenderWindow.GetRenderers().GetFirstRenderer();
            // set background color
            win = Renderer;
            Renderer.SetBackground(0,0,0);
            Renderer.GetRenderWindow().Render();
            Renderer.Render();
            cam = Renderer.GetActiveCamera();
            datavis.refreshCamera();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            vtkRenderWindow RenderWindow = renderWindowControl1.RenderWindow;
          
            // get a reference to the renderer
            win = RenderWindow.GetRenderers().GetFirstRenderer();
            // set background color
            win.SetBackground(0, 0, 0);
            win.GetRenderWindow().Render();
            win.Render();
            cam = win.GetActiveCamera();
            datavis.refreshCamera();
            datavis.Reload();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            datavis.Zoom(1.5);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            datavis.Zoom(0.66);
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datavis.ClearSol();
            datavis.Reload();
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            win.SetBackground(0.2, 0.3, 0.4);
            datavis.refreshCamera();
        }

        private void białeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            win.SetBackground(0.99, 0.99, 0.99);
            datavis.refreshCamera();
        }

        private void czarneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            win.SetBackground(0, 0, 0);
            datavis.refreshCamera();
        }

        private void szareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            win.SetBackground(0.2, 0.2, 0.2);
            datavis.refreshCamera();
        }

        private void bibliotekaVTKToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void autorzyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Autorzy a = new Autorzy(vsepr);
            a.ShowDialog();
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pomoc p = new pomoc();
            p.ShowDialog();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
         /*   if (e.KeyCode == Keys.Enter)
            {
                vsepr.Build(textBox1.Text);
            }*/
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            vsepr.settings.ligand_repl = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            vsepr.settings.ligand_repl = checkBox1.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            vsepr.settings.ligand_repl = checkBox1.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            vsepr.settings.ligand_repl = checkBox1.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            vsepr.settings.auto = checkBox5.Checked;
            if (checkBox5.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            datavis.NextSol();
        }

        private bool working = false;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !working)
            {
                vsepr.Build(textBox1.Text);
                working = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                working = false;
            }
        }

        private void czaszowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datavis.SetVistype(Vis_type.czasowy);
           
        }

        private void prętowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datavis.SetVistype(Vis_type.pretowy);
        }

        private void siatkaGenerowanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datavis.SetVistype(Vis_type.translation);
        }

        private void prętowyZPEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datavis.SetVistype(Vis_type.pretowyPE);
        }

        private void zrzutEkranuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vtkWindowToImageFilter fil = vtkWindowToImageFilter.New();
            fil.SetInput(renderWindowControl1.RenderWindow);
       
            fil.SetInputBufferTypeToRGBA();
            fil.ReadFrontBufferOff();
            fil.Update();
            vtkPNGWriter wrt = vtkPNGWriter.New();
            Random r = new Random();
            string name = r.Next(100000).ToString();
            wrt.SetFileName("Screenshots/"+name+".png");
            wrt.SetInputConnection(fil.GetOutputPort());
            wrt.Write();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            datavis.PrevSol();
        }
    }
}
