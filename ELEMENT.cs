using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChemVis
{
    public  class ELEMENT
    {

      public string symbol;
        public string name;
        public int index;
        public int wal; 
        public float mass;
        public float en;
        public Vector3 colorpref;
        public float radius;

        public static readonly ELEMENT None = new ELEMENT("###");

        public ELEMENT(string line)
        {
            if (line != "###")
            {
                string[] splt = new string[7];
                //read line form database 
                splt = line.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                if (splt.Length != 7)
                    //throw exception 
                    try
                    {
                        symbol = splt[0];
                        index = Convert.ToInt32(splt[1]);
                        name = splt[2];
                        wal = Convert.ToInt32(splt[3]);
                        en = Convert.ToSingle(splt[4]);
                        mass = Convert.ToSingle(splt[5]);
                        radius = Convert.ToSingle(splt[6]);
                        colorpref = new Vector3(Convert.ToSingle(splt[7].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[0]), Convert.ToSingle(splt[7].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[1]), Convert.ToSingle(splt[7].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries)[2]));
                    }
                    catch
                    {

                    }
            }
        }


    }

    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public static readonly Vector3 zero = new Vector3(0, 0, 0);
        public static readonly Vector3 forward = new Vector3(1, 0, 0);
        public static readonly Vector3 right = new Vector3(0, 1, 0);
        public static readonly Vector3 up = new Vector3(0, 0, 1);

        public Vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vector3 Multiply(float multi)
        {
            return new Vector3(x * multi, y * multi, z * multi);
        }

        public Vector3 Add(Vector3 value)
        {
            return new Vector3(x + value.x, y + value.y, z + value.z);
        }

        public double lenght()
        {
            return Math.Sqrt(Math.Pow(Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2)),2)+Math.Pow(z,2));
        }

        public string Tostring()
        {
            return x.ToString() + " " + y.ToString() + " " + z.ToString();
        }

        public Vector3 GetRealtivePos(Vector3 relativeOrigin)
        {
            return this.Add(relativeOrigin);
        }

        public Vector3 Invert(Axis axis)
        {
            if (axis == Axis.x)
            {
                return new Vector3(-x, y, z);
            }
            else if (axis == Axis.y)
            {
                return new Vector3(x, -y, z);
            }
            else
            {
                return new Vector3(x, y,-z);
            }
        }

    }

    public enum Axis
    {
        x,y,z
    }

    public class Settings
    {
        public bool ligand_repl;
        public bool stereoisomers;
        public bool drawjon;
        public bool chargroups;
        public bool quickbuild;
        public bool generatestruct;
        public bool sextetborowce;
        public Vector3 backcolor;

        public string Version;
        
        public bool auto;

        public Settings(string[] line)
        {
            auto = Convert.ToBoolean(line[0].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            ligand_repl = Convert.ToBoolean(line[1].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            stereoisomers = Convert.ToBoolean(line[2].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            drawjon = Convert.ToBoolean(line[3].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            chargroups = Convert.ToBoolean(line[4].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            quickbuild = Convert.ToBoolean(line[5].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            generatestruct = Convert.ToBoolean(line[6].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            sextetborowce= Convert.ToBoolean(line[7].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]);
            string[] t = line[8].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            backcolor = new Vector3(Convert.ToSingle(t[0]), Convert.ToSingle(t[1]), Convert.ToSingle(t[2]));
            Version = line[9].Trim().Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1];
        }

        public void Save()
        {


        }
    }
}
