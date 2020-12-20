using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ChemVis
{
    public class VSEPR
    {
        public List<ELEMENT> elementbase = new List<ELEMENT>();
        public List<geometry> geometrybase = new List<geometry>();
        public List<fixedelement> current = new List<fixedelement>();

        public Settings settings;

        public Datavis datavis;

        public void Load(Datavis vis)
        {
            datavis = vis;
            elementbase.Clear();
            geometrybase.Clear();
            foreach (string line in File.ReadAllLines("Data/Elements"))
            {
                if(line.Length>7)
                elementbase.Add(new ELEMENT(line));
            }
            foreach (string line in File.ReadAllLines("Data/Geometry"))
            {
                if (line.Length > 7)
                    geometrybase.Add(new geometry(line));
            }
            List<string> lines = new List<string>();
            foreach (string line in File.ReadAllLines("Data/config"))
            {
                lines.Add(line);
            }
            settings = new Settings(lines.ToArray());
        }

        public List<string> grupy_charakterystyczne(string input)
        {
            List<string> ret = new List<string>();

            return ret;
        }

        public bool is_number(string check)
        {
            try
            {
                int i = Convert.ToInt32(check);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Build(string Orginalinput)
        {
            int de = 0;

            #region text_analys
            string input = Orginalinput;
            current.Clear();
            input = input.Trim();
            if (input == "")
            {
                return;
            }

            if (input.Contains("!"))
            {
                MessageBox.Show("Błąd wejścia code:003", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (input[0].ToString() == input[0].ToString().ToLower() && input[0].ToString().ToLower() != input[0].ToString().ToUpper() && input[0].ToString() != "(" && input[0].ToString() != "[" && input[0].ToString() != "{")
            {
                MessageBox.Show("Błąd wejścia code:001", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (input.EndsWith("+"))
            {
                if (is_number(input[input.Length - 2].ToString()))
                {
                    de = -Convert.ToInt32(input[input.Length - 2].ToString());
                    input=input.Remove(input.Length - 2, 2);
                }
                else
                {
                    de = -1;
                    input=input.Remove(input.Length - 1,1);
                }

            }
            else if (input.EndsWith("-"))
            {
                if (is_number(input[input.Length - 2].ToString()))
                {
                    de = Convert.ToInt32(input[input.Length - 2].ToString());
                    input=input.Remove(input.Length - 2, 2);
                }
                else
                {
                    de = 1;
                    input=input.Remove(input.Length - 1, 1);
                }
            }
            input = input.Trim();
            input += "!!!";

            

            for (int h = 0; h < input.Length; h++)
            {
                string symb = input[h].ToString();
                string lenght2 = "";
                int multi = 1;
                if (symb == "!")
                {
                    break;
                }
                else if (symb == "^")
                {
                    break;
                }
                else if (symb == ")")
                {
                   
                }
                else if (symb == "(")
                {

                    int end = input.IndexOf(")");
                    if (end < 0)
                    {
                        MessageBox.Show("Błąd wejścia code:002", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string data = input.Substring(h + 1, end - h - 1);
                    int multip = 1;
                    if (is_number(input[end + 1].ToString()))
                    {
                        multip = Convert.ToInt32(input[end + 1].ToString());
                        
                        if (is_number(input[end + 2].ToString()))
                        {
                            
                            multip += 10 * Convert.ToInt32(input[end + 1]);
                        }
                    }
                    data += "!!!";
                    
                    for (int i = 0; i < data.Length; i++)
                    {
                        string symb2 = data[i].ToString();
                        string lenght = "";
                        int multip2 = 1;
                        if (symb2 == "!")
                        {
                            break;
                        }
                        else if (is_number(symb2))
                        {
                            MessageBox.Show("Błąd wejścia code:004", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (symb2.ToUpper() != symb2.ToLower())
                        {
                            if (symb2.ToUpper() == symb2)
                            {
                                if (is_number(data[i + 1].ToString()))
                                {
                                    if (is_number(data[i + 2].ToString()))
                                    {
                                        multip2 = Convert.ToInt32(data[i + 1].ToString() + data[i + 2].ToString());
                                        i += 2;
                                    }
                                    else
                                    {
                                        multip2 = Convert.ToInt32(data[i + 1].ToString());
                                        i++;
                                    }
                                }
                                else if (data[i + 1].ToString() != data[i + 1].ToString().ToUpper() && data[i + 1].ToString().ToLower() == data[i + 1].ToString())
                                {
                                    lenght = data[i + 1].ToString();
                                    
                                    if (is_number(data[i + 2].ToString()))
                                    {
                                        if (is_number(data[i + 3].ToString()))
                                        {
                                            multip2 = Convert.ToInt32(data[i + 1].ToString() + data[i + 2].ToString());
                                            i += 2;
                                        }
                                        else
                                        {
                                            multip2 = Convert.ToInt32(data[i + 1].ToString());
                                            i++;
                                        }
                                    }
                                    i++;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Błąd wejścia code:005", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }


                        }
                        else
                        {
                            MessageBox.Show("Błąd wejścia code:007", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string elemnet2 = symb2;
                       
                        elemnet2 += lenght;
                        foreach (ELEMENT el in elementbase)
                        {
                            if (el.symbol == elemnet2)
                            {
                                current.Add(new fixedelement(el, multip * multip2));
                            }
                        }
                        h++;
                    }
                }
                else if (is_number(symb))
                {
                  
                }
                else if (symb.ToUpper() != symb.ToLower())
                {
                    if (symb.ToUpper() == symb)
                    {
                        if (is_number(input[h + 1].ToString()))
                        {
                            if (is_number(input[h + 2].ToString()))
                            {
                                multi = Convert.ToInt32(input[h + 1].ToString() + input[h + 2].ToString());
                                h += 2;
                            }
                            else
                            {
                                multi = Convert.ToInt32(input[h + 1].ToString());
                                h++;
                            }
                        }
                        else if (input[h + 1].ToString() != input[h + 1].ToString().ToUpper() && input[h + 1].ToString().ToLower() == input[h + 1].ToString())
                        {

                            lenght2 = input[h + 1].ToString();
                           
                            
                            if (is_number(input[h + 2].ToString()))
                            {
                                if (is_number(input[h + 3].ToString()))
                                {
                                    multi = Convert.ToInt32(input[h + 2].ToString() + input[h + 3].ToString());
                                    h += 2;
                                }
                                else
                                {
                                    multi = Convert.ToInt32(input[h + 2].ToString());
                                    h++;
                                }
                            }
                            h++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Błąd wejścia code:005", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                }
                else
                {
                    
                    MessageBox.Show("Błąd wejścia code:007", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string elemnet = symb;

                elemnet += lenght2;

               

                foreach (ELEMENT el in elementbase)
                {
                    if (el.symbol == elemnet)
                    {
                        current.Add(new fixedelement(el, multi));
                    }
                }
            }
            
            #endregion

            #region Homo
            
            if (current.Count == 1)
            { 
                HOMO(de);   
                return;
            }

            #endregion

            if (!settings.auto)
            {

                #region organic
                if (settings.generatestruct)
                {
                    bool is_organic = false;

                    foreach (fixedelement f in current)
                    {
                        if (f.count > 1 && f.el.symbol == "C")
                            is_organic = true;
                    }

                    if (is_organic)
                    {



                    }
                }
                #endregion

                #region Chargroups

                if (settings.chargroups)
                {
                    //szukaj OH i SH  

                    int ox = 0;
                    int hyd = 0;
                    int s = 0;

                    foreach (fixedelement f in current)
                    {
                        if (f.el.symbol == "O")
                        {
                            ox = f.count;
                        }
                        else if (f.el.symbol == "S")
                        {
                            s = f.count;
                        }
                        else if (f.el.symbol == "H")
                        {
                            hyd = f.count;
                        }
                    }
                    int OH = 0;
                    int SH = 0;

                    if (ox > hyd)
                    {
                        OH = hyd;
                    }
                    else
                    {
                        OH = ox;
                    }
                    if (s > hyd - ox && hyd - ox >= 0)
                    {
                        SH = hyd - ox;
                    }
                    else if (hyd - ox >= 0)
                    {
                        SH = s;
                    }

                    if (Orginalinput.Trim() == "H2O" || Orginalinput.Trim() == "H2S"|| Orginalinput.Trim() == "SH2" || Orginalinput.Trim() == "OH2")
                    {
                        BuildSimple(de, null);
                    }
                    else if (OH + SH > 0)
                    {

                        buildwithOHSH(de, OH, SH);
                    }
                    else
                    {
                        if (settings.quickbuild)
                            BuildSimple(de, null);
                        else
                            Muticore();
                    }
                }
                #endregion

                if (!settings.ligand_repl)
                {
                    datavis.ClearSol();
                    BuildSimple(de, null);
                }
            }
            else
            {

            }
          

        }

        public Vector3 get_geometry(Vector3 me_, geometry to)
        {

             bool can_invert = false;
            foreach (Vector3 c in to.translation)
            {
                if (c == me_.Multiply(-1))
                can_invert = true;
            }
            if (can_invert)
                return me_.Multiply(-1);
            else
            {
                foreach (Vector3 c in to.translation)
                {
                    if (c != me_)
                    {
                        return c;
                    }
                      
                }
            }
            return null;
        }

        private void HOMO(int de_)
        {
            
            int central = 0;
            int ligands = 0;
            int hydrogen = 0;

            bool rodnik = false;

            fixedelement fix = null;

            #region VSEPR_PRE
            //wykrywanie atomu centralnego
            current[0].count--;
            fix = new fixedelement(current[0].el, 0);
            current.Add(fix);
            //liczenie ligandów i potenjalnych atmów centralnych


            foreach (fixedelement f in current)
            {
                if (f == fix)
                {
                    central += f.count;
                }
                else if (f.el.index < 3)
                {
                    hydrogen += f.count;
                }
                else
                {
                    ligands += f.count;
                }
            }
            #endregion

            #region VSEPR

            List<Vissolution> Tempsol = new List<Vissolution>();
            int LP = 0;
            geometry thisgeometry = null;

            int ew = de_;

            foreach (fixedelement e in current)
            {
                if(e.count==0)
                    ew += e.el.wal;

                ew += e.el.wal * e.count;
            }

            float wpe = (Convert.ToSingle(ew) / 2) - (4 * ligands) - hydrogen;

            

            if ((2 * wpe) % 2 != 0 && wpe > 0)
            {
                wpe += (float)0.5;
                rodnik = true;
            }
            if (wpe < 0)
            {
                MessageBox.Show("Indywiduum nie może istnieć code:002", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int sigma = ligands + hydrogen;
            int pi = 0;
            LP = sigma + Convert.ToInt32(wpe);

            if (LP <= 4)
            {
                pi = 4 - LP;
            }
            if (rodnik)
            {

                if (!((8 * ligands) + 8 + (2 * hydrogen) - (2 * sigma) - (2 * pi) == ew + 1))
                {
                    MessageBox.Show("Indywiduum nie może istnieć code:001", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (geometry e in geometrybase)
            {
                if (LP == e.cord)
                {
                    thisgeometry = e;
                }
            }
            List<ELEMENT> all = new List<ELEMENT>();
            foreach (fixedelement e in current)
            {
                if (e != fix)
                {
                    for (int i = 0; i < e.count; i++)
                    {
                        all.Add(e.el);
                    }
                }
            }


            if (pi == 0 || (fix.el.wal < 4 && LP - fix.el.wal == 0))
            {
                List<VisPoint> pnt = new List<VisPoint>();
                List<bound> bnd = new List<bound>();

                pnt.Add(new VisPoint(new Vector3(0, 0, 0), fix.el));
                for (int i = 0; i < sigma; i++)
                {

                    pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                    bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.singleB));
                }
                for (int d = 0; d < wpe; d++)
                {
                    pnt.Add(new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None));
                    bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None) }, bound_type.singleB));

                }
                Tempsol.Add(new Vissolution(bnd, pnt));

            }
            else
            {

                List<int> canhavepi = new List<int>();

                for (int i = 0; i < sigma; i++)
                {

                    bool result = all[i].wal < 7 && all[i].wal > 1 && all[i].index > 3;
                    if (result)
                        canhavepi.Add(i);
                }
                if (canhavepi.Count < 1)
                {
                    MessageBox.Show("Nie można umijescowić wiązań pi", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                switch (pi)
                {
                    case 1:

                        for (int j = 0; j < canhavepi.Count; j++)
                        {
                            List<VisPoint> pnt = new List<VisPoint>();
                            List<bound> bnd = new List<bound>();
                            pnt.Add(new VisPoint(new Vector3(0, 0, 0), fix.el));
                            for (int i = 0; i < sigma; i++)
                            {
                                if (i == canhavepi[j])
                                {
                                    pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                    bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.doubleB));
                                }
                                else
                                {
                                    pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                    bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.singleB));
                                }
                            }
                            for (int d = 0; d < wpe; d++)
                            {
                                pnt.Add(new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None));
                                bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None) }, bound_type.singleB));

                            }
                            Tempsol.Add(new Vissolution(bnd, pnt));
                        }
                        break;
                    case 2:

                        for (int j = 0; j < canhavepi.Count; j++)
                        {

                            for (int l = 0; l < canhavepi.Count; l++)
                            {
                                List<VisPoint> pnt = new List<VisPoint>();
                                List<bound> bnd = new List<bound>();
                                pnt.Add(new VisPoint(new Vector3(0, 0, 0), fix.el));
                                bool break_ = false;
                                for (int i = 0; i < sigma; i++)
                                {
                                    if (i == canhavepi[j] && j == l)
                                    {
                                        if (8 - all[i].wal > 2)
                                        {
                                            pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                            bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.tripleB));
                                        }
                                        else
                                        {
                                            break_ = true;
                                        }
                                    }
                                    else if (i == canhavepi[j])
                                    {
                                        pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.doubleB));
                                    }
                                    else if (i == canhavepi[l])
                                    {
                                        pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.doubleB));
                                    }
                                    else
                                    {
                                        pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.singleB));
                                    }
                                }
                                if (!break_)
                                {


                                    for (int d = 0; d < wpe; d++)
                                    {
                                        pnt.Add(new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None));
                                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None) }, bound_type.singleB));

                                    }
                                    Tempsol.Add(new Vissolution(bnd, pnt));
                                }
                            }

                        }
                        break;
                    default:
                        MessageBox.Show("Nie można określić geometrii", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        break;
                }



            }

            if (Tempsol.Count < 1)
                return;
            datavis.ClearSol();
            datavis.LoadModel(Tempsol);
            datavis.DrawModel(0);

            datavis.form.listBox2.Items.Clear();
            string prod = "Wzór sumaryczny: ";
            float mass = 0;
            foreach (fixedelement f in current)
            {
                mass += f.count * f.el.mass;
                prod += f.el.symbol;
                if (f.count > 1)
                    prod += f.count.ToString();

            }
            datavis.form.listBox2.Items.Add(prod);
            datavis.form.listBox2.Items.Add("Dla tego rozwiązania:");
            if (rodnik)
            {
                datavis.form.listBox2.Items.Add("Rodnik: Tak");
            }
            datavis.form.listBox2.Items.Add("Centralny: " + fix.el.symbol);
            datavis.form.listBox2.Items.Add("Ligandy: " + ligands.ToString());
            datavis.form.listBox2.Items.Add("Wodory: " + hydrogen.ToString());
            datavis.form.listBox2.Items.Add("Liczba przestrzenna: " + LP.ToString());
            datavis.form.listBox2.Items.Add("Geometria: " + thisgeometry.geometry_type);
            datavis.form.listBox2.Items.Add("Hybrydyzacja: " + thisgeometry.hyb);
            datavis.form.listBox2.Items.Add("Dodatkowe dane:");
            datavis.form.listBox2.Items.Add("Masa molowa: " + mass.ToString() + " g*mol^-1");


            #endregion

        }

        private void BuildSimple(int de_, fixedelement centralA)
        {
   

            int central = 0;
            int ligands = 0;
            int hydrogen = 0;

            bool rodnik = false;

            fixedelement fix = null;

            #region VSEPR_PRE
            //wykrywanie atomu centralnego

            if (centralA == null)
            {

                foreach (fixedelement el in current)
                {
                    if (fix != null)
                    {

                        if (el.el.index > 2)
                        {
                            if (fix.el.index < 3) fix = el;
                            if (el.count == fix.count)
                            {
                                if (el.el.wal == 8)
                                    fix = el;
                                else if (el.el.wal < 6 && el.el.wal < fix.el.wal)
                                    fix = el;
                            }
                            else if (el.count < fix.count)
                            {

                                fix = el;
                            }

                        }
                        else if (fix.el.index == 1) fix = el;
                    }
                    else
                    {
                        fix = el;
                    }
                }
            }
            else
            {
                fix = centralA;
            }
            //liczenie ligandów i potenjalnych atmów centralnych


            foreach (fixedelement f in current)
            {
                if (f == fix)
                {
                    central += f.count;
                }
                else if (f.el.index < 3)
                {
                    hydrogen += f.count;
                }
                else
                {
                    ligands += f.count;
                }
            }
            #endregion

            #region error_report

            if (fix == null)
            {
                    MessageBox.Show("Nie określono atomu centralnego", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            if (fix.count != 1)
            {
                MessageBox.Show("Nie określono atomu centralnego", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            #region VSEPR

            List<Vissolution> Tempsol = new List<Vissolution>();
            int LP = 0;
            geometry thisgeometry = null;

            int ew = de_;
           
            foreach (fixedelement e in current)
            {
                
                ew += e.el.wal * e.count;
            }
           
            float wpe = (Convert.ToSingle(ew) / 2) - (4 * ligands) - hydrogen;


            if ((2 * wpe) % 2 != 0 && wpe > 0)
            {
                wpe += (float)0.5;
                rodnik = true;
            }
            if (wpe < 0)
            {
                MessageBox.Show("Indywiduum nie może istnieć code:002", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int sigma = ligands + hydrogen;
            int pi = 0;
            LP = sigma + Convert.ToInt32(wpe);

            if (LP <= 4)
            {
                pi = 4 - LP;
            }
            if (rodnik)
            {
               
                if (!((8 * ligands) + 8 + (2 * hydrogen)-(2*sigma)-(2*pi) == ew + 1))
                {
                    MessageBox.Show("Indywiduum nie może istnieć code:001", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        
            foreach (geometry e in geometrybase)
                {
                    if (LP == e.cord)
                    {
                        thisgeometry = e;
                    }
                }
                List<ELEMENT> all = new List<ELEMENT>();
                foreach (fixedelement e in current)
                {
                    if (e != fix)
                    {
                        for (int i = 0; i < e.count; i++)
                        {
                            all.Add(e.el);
                        }
                    }
                }
            
         
                if (pi == 0||(fix.el.wal<4&&LP-fix.el.wal==0))
                {
                List<VisPoint> pnt = new List<VisPoint>();
                List<bound> bnd = new List<bound>();

                pnt.Add(new VisPoint(new Vector3(0, 0, 0), fix.el));
                    for (int i = 0; i < sigma; i++)
                    {

                        pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.singleB));
                    }
                for (int d = 0; d < wpe; d++)
                {
                    pnt.Add(new VisPoint(thisgeometry.translation[d+sigma],ELEMENT.None));
                    bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma],ELEMENT.None) }, bound_type.singleB));

                }
                Tempsol.Add(new Vissolution(bnd, pnt));

                }
                else
                {

                List<int> canhavepi = new List<int>();

                for (int i = 0; i < sigma; i++)
                {
                    
                    bool result = all[i].wal < 7 && all[i].wal > 1 && all[i].index > 3;               
                    if (result)
                        canhavepi.Add(i);
                }
                if (canhavepi.Count < 1)
                {
                    MessageBox.Show("Nie można umijescowić wiązań pi", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                switch (pi)
                {
                    case 1:
                      
                        for (int j = 0; j < canhavepi.Count; j++)
                        {
                            List<VisPoint> pnt = new List<VisPoint>();
                            List<bound> bnd = new List<bound>();
                            pnt.Add(new VisPoint(new Vector3(0, 0, 0), fix.el));
                            for (int i = 0; i < sigma; i++)
                            {
                                if (i == canhavepi[j])
                                {
                                    pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i],fix.el)), all[i]));
                                    bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.doubleB));
                                }
                                else
                                {
                                pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.singleB));
                            }
                        }
                            for (int d = 0; d < wpe; d++)
                            {
                                pnt.Add(new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None));
                                bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None) }, bound_type.singleB));

                            }
                            Tempsol.Add(new Vissolution(bnd, pnt));
                        }
                        break;
                    case 2:
                       
                        for (int j = 0; j < canhavepi.Count; j++)
                        {

                            for (int l = 0; l < canhavepi.Count; l++)
                            {
                                List<VisPoint> pnt = new List<VisPoint>();
                                List<bound> bnd = new List<bound>();
                                pnt.Add(new VisPoint(new Vector3(0, 0, 0), fix.el));
                                bool break_ = false;
                                for (int i = 0; i < sigma; i++)
                                {
                                    if (i == canhavepi[j] && j == l)
                                    {
                                        if (8 - all[i].wal > 2)
                                        {
                                            pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                            bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.tripleB));
                                        }
                                        else
                                        {
                                            break_ = true;
                                        }
                                    }
                                    else if (i == canhavepi[j])
                                    {
                                        pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.doubleB));
                                    }
                                    else if (i == canhavepi[l])
                                    {
                                        pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.doubleB));
                                    }
                                    else
                                    {
                                        pnt.Add(new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]));
                                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[i].Multiply(GetBoundLeght(all[i], fix.el)), all[i]) }, bound_type.singleB));
                                    }
                                }
                                if (!break_)
                                {


                                    for (int d = 0; d < wpe; d++)
                                    {
                                        pnt.Add(new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None));
                                        bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None) }, bound_type.singleB));

                                    }
                                    Tempsol.Add(new Vissolution(bnd, pnt));
                                }
                            }
                            
                        }
                        break;
                    default:
                        MessageBox.Show("Nie można określić geometrii", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        break;
                }

                

            }
            
            if (Tempsol.Count < 1)
                return;
            datavis.ClearSol();
            datavis.LoadModel(Tempsol);
            datavis.DrawModel(0);

            datavis.form.listBox2.Items.Clear();
            string prod = "Wzór sumaryczny: ";
            float mass = 0;
            foreach (fixedelement f in current)
            {
                mass += f.count * f.el.mass;
                prod += f.el.symbol;
                if (f.count > 1)
                    prod += f.count.ToString();

            }
            datavis.form.listBox2.Items.Add(prod);
            datavis.form.listBox2.Items.Add("Dla tego rozwiązania:");
            if (rodnik)
            {
                datavis.form.listBox2.Items.Add("Rodnik: Tak");
            }
            datavis.form.listBox2.Items.Add("Centralny: " + fix.el.symbol);
            datavis.form.listBox2.Items.Add("Ligandy: " + ligands.ToString());
            datavis.form.listBox2.Items.Add("Wodory: " + hydrogen.ToString());
            datavis.form.listBox2.Items.Add("Liczba przestrzenna: " + LP.ToString());
            datavis.form.listBox2.Items.Add("Geometria: " + thisgeometry.geometry_type);
            datavis.form.listBox2.Items.Add("Hybrydyzacja: " + thisgeometry.hyb);
            datavis.form.listBox2.Items.Add("Dodatkowe dane:");
            datavis.form.listBox2.Items.Add("Masa molowa: " + mass.ToString()+" g*mol^-1");


            #endregion


            return;
        }

        private void buildwithOHSH(int de_,int OH,int SH)
        {
            int central = 0;
            int ligands = 0;
            int hydrogen = 0;

            bool rodnik = false;

            datavis.ClearSol();

            fixedelement fix = null;

            #region VSEPR_PRE
            //wykrywanie atomu centralnego

          

                foreach (fixedelement el in current)
                {
                    if (fix != null)
                    {

                        if (el.el.index > 2)
                        {
                            if (fix.el.index < 3) fix = el;
                            if (el.count == fix.count)
                            {
                                if (el.el.wal == 8)
                                    fix = el;
                                else if (el.el.wal < 6 && el.el.wal < fix.el.wal)
                                    fix = el;
                            }
                            else if (el.count < fix.count)
                            {

                                fix = el;
                            }

                        }
                        else if (fix.el.index == 1) fix = el;
                    }
                    else
                    {
                        fix = el;
                    }
                }

            //liczenie ligandów i potenjalnych atmów centralnych

            if (fix.count > 1)
            {
                Muticore();
            }
            float ligandwal = 0;
            foreach (fixedelement f in current)
            {
                if (f == fix)
                {
                    central += f.count;
                }
                else if (f.el.index < 3)
                {
                    ligandwal += (2 - f.el.wal)*f.count;
                    hydrogen += f.count;
                }
                else
                {
                    if (f.el.wal == 4)
                    {
                        BuildSimple(de_, fix);
                        return;
                    }
                    else if (f.el.wal == 3)
                    {
                        ligandwal += 3 * f.count;
                    }
                    else
                    {
                        ligandwal += (8 - f.el.wal) * f.count;
                    }
                    ligands += f.count;
                }
            }
            
            if (ligandwal <= 8 - fix.el.wal)
            {
                BuildSimple(de_, fix);
                return;
            }
            #endregion

            #region error_report

            if (fix.count != 1)
            {
                MessageBox.Show("Nie określono atomu centralnego", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            #region VSEPR

            List<Vissolution> Tempsol = new List<Vissolution>();
            int LP = 0;
            geometry thisgeometry = null;

            int ew = de_;
            foreach (fixedelement e in current)
            {
                ew += e.el.wal * e.count;
            }

            float wpe = (Convert.ToSingle(ew) / 2) - (4 * ligands) - hydrogen+OH+SH;


            if ((2 * wpe) % 2 != 0 && wpe > 0)
            {
                wpe += (float)0.5;
                rodnik = true;
            }
            if (wpe < 0)
            {
                MessageBox.Show("Indywiduum nie może istnieć code:002", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int sigma = ligands + hydrogen-SH-OH;
            int pi = 0;
            LP = sigma + Convert.ToInt32(wpe);

            if (LP <= 4)
            {
                pi = 4 - LP;
            }
            if (rodnik)
            {
              
                if (!((8 * ligands) + 8 + (2 * hydrogen) - (2 * sigma) - (2 * pi) == ew + 1))
                {
                    MessageBox.Show("Indywiduum nie może istnieć code:001", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (geometry e in geometrybase)
            {
                if (LP == e.cord)
                {
                    thisgeometry = e;
                }
            }
            List<ELEMENT> all = new List<ELEMENT>();
            List<ELEMENT> HYDR = new List<ELEMENT>();
            foreach (fixedelement e in current)
            {
              
                if (e != fix&&e.el.symbol!="H")
                {
                    for (int i = 0; i < e.count; i++)
                    {
                        all.Add(e.el);
                    }
                }
                else if (e != fix)
                {
                    for (int i = 0; i < e.count; i++)
                    {
                        HYDR.Add(e.el);
                    }
                }
            }
           

            int hyd_used = 0;


            int lim = (sigma - HYDR.Count + OH + SH);
            if (pi == 0 || (fix.el.wal < 4 && LP - fix.el.wal == 0))
            {
                #region sigmaonly
                List<VisPoint> pnt = new List<VisPoint>();
                List<bound> bnd = new List<bound>();
                VisPoint centr = new VisPoint(Vector3.zero, fix.el);
                pnt.Add(centr);
                int hOH = OH;
                int hSH = SH;
                
                for (int i = 0; i < lim; i++)
                {
                    ELEMENT f = null;
                    float lgt = GetBoundLeght(fix.el, all[i]);
                    VisPoint vp = new VisPoint(thisgeometry.translation[i].Multiply(lgt), all[i]);

                    if (all[i].symbol == "O" && OH > 0)
                    {
                        OH--;
                        
                        foreach (ELEMENT h in HYDR)
                        {
                            f = h;
                            hyd_used++;
                            break;
                        }
                        float lght = GetBoundLeght(f, all[i]);


                        
                        VisPoint hyd = new VisPoint(vp.position.Add(get_geometry(thisgeometry.translation[i], geometry.Tetraedr).Multiply(lght).Invert(Axis.z)), f);
                        pnt.Add(hyd);
                        bnd.Add(new bound(new VisPoint[] { vp,hyd }, bound_type.singleB));
                    }
                    else if (all[i].symbol == "S" && SH > 0)
                    {
                        SH--;
                        
                        foreach (ELEMENT h in HYDR)
                        {
                            f = h;
                            hyd_used++;
                            break;
                        }
                        
                        float lght = GetBoundLeght(f, all[i]);
                        Vector3 addon = Vector3.up.Multiply(lght);
                        if (thisgeometry.translation[i].z == Vector3.up.z)
                        {
                            addon = thisgeometry.translation[3].Multiply(lght);
                        }
                        VisPoint hyd = new VisPoint(vp.position.Add(addon), f);
                        pnt.Add(hyd);
                        bnd.Add(new bound(new VisPoint[] { vp, hyd }, bound_type.singleB));

                    }
                    
                    pnt.Add(vp);
                    bnd.Add(new bound(new VisPoint[] {centr,vp}, bound_type.singleB));
                }

                for (int g = 0; g < HYDR.Count - hOH - hSH; g++)
                {
                  
                    VisPoint vp = new VisPoint(thisgeometry.translation[lim + g].Multiply(GetBoundLeght(fix.el, HYDR[g])),HYDR[g]);
                    pnt.Add(vp);
                    bnd.Add(new bound(new VisPoint[] { centr,vp }, bound_type.singleB));
                }
                for (int d = 0; d < wpe; d++)
                {
                    pnt.Add(new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None));
                    bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None) }, bound_type.singleB));

                }
                Tempsol.Add(new Vissolution(bnd, pnt));

                #endregion

            }
            else
            {

                List<int> canhavepi = new List<int>();

                for (int i = 0; i < sigma-HYDR.Count; i++)
                {

                    bool result = all[i].wal < 7 && all[i].wal > 1 && all[i].index > 3;
                    if (result)
                        canhavepi.Add(i);
                }
                if (canhavepi.Count < 1)
                {
                    MessageBox.Show("Nie można umijescowić wiązań pi", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int havOH = OH;
                int havSH = SH;
                switch (pi)
                {
                    case 1:
                        #region onepi
                        
                        
                       

                        for (int j = 0; j < canhavepi.Count; j++)
                        {
                            OH = havOH;
                            SH = havSH;
                            List<VisPoint> pnt = new List<VisPoint>();
                            List<bound> bnd = new List<bound>();
                            VisPoint centr = new VisPoint(Vector3.zero, fix.el);
                            pnt.Add(centr);
                            for (int i = 0; i < lim; i++)
                            {
                                float lgt = GetBoundLeght(fix.el, all[i]);
                                VisPoint vp = new VisPoint(thisgeometry.translation[i].Multiply(lgt), all[i]);

                                if (i == canhavepi[j])
                                {
                                    pnt.Add(vp);
                                    bnd.Add(new bound(new VisPoint[] {centr,vp},bound_type.doubleB));
                                        }
                                else
                                {
                                    ELEMENT f = null;
                                    if (all[i].symbol == "O" && OH > 0)
                                    {
                                        OH--;

                                        foreach (ELEMENT h in HYDR)
                                        {
                                            f = h;
                                            hyd_used++;
                                            break;
                                        }

                                        float lght = GetBoundLeght(f, all[i]);
                                        Vector3 addon = Vector3.up.Multiply(lght);
                                        if (thisgeometry.translation[i].z == Vector3.up.z)
                                        {

                                            addon = thisgeometry.translation[3].Multiply(lght);
                                        }
                                        VisPoint hyd = new VisPoint(thisgeometry.translation[i].Multiply(lgt).Add(addon), f);
                                        pnt.Add(hyd);
                                        bnd.Add(new bound(new VisPoint[] { vp, hyd }, bound_type.singleB));
                                    }
                                    else if (all[i].symbol == "S" && SH > 0)
                                    {
                                        SH--;

                                        foreach (ELEMENT h in HYDR)
                                        {
                                            f = h;
                                            hyd_used++;
                                            break;
                                        }

                                        float lght = GetBoundLeght(f, all[i]);
                                        Vector3 addon = Vector3.up.Multiply(lght);
                                        if (thisgeometry.translation[i].z == Vector3.up.z)
                                        {

                                            addon = thisgeometry.translation[3].Multiply(lght);
                                        }
                                        VisPoint hyd = new VisPoint(thisgeometry.translation[i].Multiply(lgt).Add(addon), f);
                                        pnt.Add(hyd);
                                        bnd.Add(new bound(new VisPoint[] { vp, hyd }, bound_type.singleB));
                                    }
                                    pnt.Add(vp);
                                    bnd.Add(new bound(new VisPoint[] { centr,vp }, bound_type.singleB));
                                }
                            }
                            for (int g = 0; g < HYDR.Count - havOH - havSH; g++)
                            {

                                VisPoint vp = new VisPoint(thisgeometry.translation[lim + g].Multiply(GetBoundLeght(fix.el, HYDR[g])), HYDR[g]);
                                pnt.Add(vp);
                                bnd.Add(new bound(new VisPoint[] { centr,vp }, bound_type.singleB));
                            }
                            for (int d = 0; d < wpe; d++)
                            {
                                pnt.Add(new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None));
                                bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None) }, bound_type.singleB));

                            }
                            Tempsol.Add(new Vissolution(bnd, pnt));
                        }
                        #endregion
                        break;
                    case 2:
                        #region twopi                       
             
                        for (int j = 0; j < canhavepi.Count; j++)
                        {
                            OH = havOH;
                            SH = havSH;
                            List<VisPoint> pnt = new List<VisPoint>();
                            List<bound> bnd = new List<bound>();
                            pnt.Clear();
                            bnd.Clear();
                            VisPoint centr = new VisPoint(Vector3.zero, fix.el);
                            pnt.Add(centr);
                            for (int l = 0; l < canhavepi.Count; l++)
                            {

                                for (int i = 0; i < lim; i++)
                                {
                                    float lgt = GetBoundLeght(fix.el, all[i]);
                                    VisPoint vp = new VisPoint(thisgeometry.translation[i].Multiply(lgt), all[i]);
                                    if (i == canhavepi[j] && j == l)
                                    {
                                        pnt.Add(vp);
                                        bnd.Add(new bound(new VisPoint[] { centr,vp }, bound_type.tripleB));
                                    }
                                    else if (i == canhavepi[j])
                                    {
                                        pnt.Add(vp);
                                        bnd.Add(new bound(new VisPoint[] { centr,vp }, bound_type.doubleB));
                                    }
                                    else if (i == canhavepi[l])
                                    {
                                        pnt.Add(vp);
                                        bnd.Add(new bound(new VisPoint[] { centr,vp }, bound_type.doubleB));
                                    }
                                    else
                                    {
                                        ELEMENT f = null;
                                        if (all[i].symbol == "O" && OH > 0)
                                        {
                                            OH--;

                                            foreach (ELEMENT h in HYDR)
                                            {
                                                f = h;
                                                hyd_used++;
                                                break;
                                            }

                                            float lght = GetBoundLeght(f, all[i]);
                                            Vector3 addon = Vector3.up.Multiply(lght);
                                            if (thisgeometry.translation[i].z == Vector3.up.z)
                                            {

                                                addon = thisgeometry.translation[3].Multiply(lght);
                                            }
                                            VisPoint hyd = new VisPoint(thisgeometry.translation[i].Multiply(lgt).Add(addon), f);
                                            pnt.Add(hyd);
                                            bnd.Add(new bound(new VisPoint[] { vp, hyd }, bound_type.singleB));
                                        }
                                        else if (all[i].symbol == "S" && SH > 0)
                                        {
                                            SH--;

                                            foreach (ELEMENT h in HYDR)
                                            {
                                                f = h;
                                                hyd_used++;
                                                break;
                                            }

                                            float lght = GetBoundLeght(f, all[i]);
                                            Vector3 addon = Vector3.up.Multiply(lght);
                                            if (thisgeometry.translation[i].z == Vector3.up.z)
                                            {

                                                addon = thisgeometry.translation[3].Multiply(lght);
                                            }
                                            VisPoint hyd = new VisPoint(thisgeometry.translation[i].Multiply(lgt).Add(addon), f);
                                            pnt.Add(hyd);
                                            bnd.Add(new bound(new VisPoint[] { vp, hyd }, bound_type.singleB));
                                        }
                                        pnt.Add(vp);
                                        bnd.Add(new bound(new VisPoint[] { centr,vp }, bound_type.singleB));
                                    }
                                }
                            }
                            for (int g = 0; g < HYDR.Count - havOH - havSH; g++)
                            {

                                VisPoint vp = new VisPoint(thisgeometry.translation[lim + g].Multiply(GetBoundLeght(fix.el, HYDR[g])), HYDR[g]);
                                pnt.Add(vp);
                                bnd.Add(new bound(new VisPoint[] { vp, centr }, bound_type.singleB));
                            }
                            for (int d = 0; d < wpe; d++)
                            {
                                pnt.Add(new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None));
                                bnd.Add(new bound(new VisPoint[] { new VisPoint(new Vector3(0, 0, 0), fix.el), new VisPoint(thisgeometry.translation[d + sigma], ELEMENT.None) }, bound_type.singleB));

                            }
                            Tempsol.Add(new Vissolution(bnd, pnt));
                        }
                        #endregion
                        break;
                    default:
                        MessageBox.Show("Nie można określić geometrii", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }



            }

            

            if (Tempsol.Count < 1)
                return;

            datavis.ClearSol();
            datavis.LoadModel(Tempsol);
            datavis.DrawModel(0);

            datavis.form.listBox2.Items.Clear();
            string prod = "Wzór sumaryczny: ";
            float mass = 0;
            foreach (fixedelement f in current)
            {
                mass += f.count * f.el.mass;
                prod += f.el.symbol;
                if (f.count > 1)
                    prod += f.count.ToString();

            }
            datavis.form.listBox2.Items.Add(prod);
            datavis.form.listBox2.Items.Add("Dla tego rozwiązania:");
            if (rodnik)
            {
                datavis.form.listBox2.Items.Add("Rodnik: Tak");
            }
            datavis.form.listBox2.Items.Add("Centralny: " + fix.el.symbol);
            datavis.form.listBox2.Items.Add("Ligandy: " + ligands.ToString());
            datavis.form.listBox2.Items.Add("Wodory: " + hydrogen.ToString());
            datavis.form.listBox2.Items.Add("Liczba przestrzenna: " + LP.ToString());
            datavis.form.listBox2.Items.Add("Geometria: " + thisgeometry.geometry_type);
            datavis.form.listBox2.Items.Add("Hybrydyzacja: " + thisgeometry.hyb);
            datavis.form.listBox2.Items.Add("Dodatkowe dane:");
            datavis.form.listBox2.Items.Add("Masa molowa: " + mass.ToString() + " g*mol^-1");

            #endregion
        }

        private void Muticore()
        {

        }

        public static float GetBoundLeght(ELEMENT a, ELEMENT b)
        {
            return (a.radius + b.radius) / 260;
        }
    }

    public class fixedelement
    {
        public ELEMENT el;
            public int count;
        public fixedelement(ELEMENT ele, int c)
        {

            el = ele;
            count = c;
        }
    }

    public class geometry
    {
        public int cord;
        public string hyb;
        public string geometry_type;
        public List<Vector3> translation;

        public static geometry Tetraedr;

        public geometry(string line)
        {
            string[] splt = new string[4];
            //read line form database 
            splt = line.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            if (splt.Length != 7)
                //throw exception 
                try
                {
                    cord = Convert.ToInt32(splt[0]);
                    geometry_type = splt[1];
                    hyb = splt[2];
                    translation = new List<Vector3>();
                    foreach (string l in splt[3].Split(new string[] { "#" },StringSplitOptions.RemoveEmptyEntries))
                    {
                        translation.Add(new Vector3(Convert.ToSingle(l.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]), Convert.ToSingle(l.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[1]), Convert.ToSingle(l.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[2])));
                    }
                   
                }
                catch
                {

                }
            if (cord == 4)
            {
                Tetraedr = this;
            }
        }
    }

    public enum religusage
    {
        must,can,no
    }

}
