using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitware.VTK;
using System.Windows.Forms;

namespace ChemVis
{
    public class Datavis
    {
        public Main form;

        public int current;

        public List<Vissolution> Solutions = new List<Vissolution>();

        private Vis_type Visual_type=Vis_type.pretowy;

        public Datavis(Main main)
        {
            form = main;
        }

        public void LoadModel(List<Vissolution> solutions)
        {
            foreach (Vissolution s in solutions)
            {
                Solutions.Add(s);
            }
        }

        public void ClearSol()
        {
            Solutions.Clear();
        }

        public void SetVistype(Vis_type type)
        {
            Visual_type = type;
            Reload();
        }

        public void DrawModel(int solution_index)
        {
            current = solution_index;
            form.win.RemoveAllViewProps();

            SetCamerOrigin(1.5);

            switch (Visual_type)
            {
                case Vis_type.czasowy: DrawCzasz(Solutions[solution_index]);
                    break;
                case Vis_type.pretowy: DrawPret(Solutions[solution_index]);
                    break;
                case Vis_type.pretowyPE: DrawPretPE(Solutions[solution_index]);
                    break;
                case Vis_type.MO: DrawMO(Solutions[solution_index]);
                    break;
                case Vis_type.translation:DrawTRANS(Solutions[solution_index]);
                    break;
            }

            refreshCamera();
           
        }

        private void DrawCzasz(Vissolution sol_)
        {
            foreach (VisPoint sol in sol_.points)
            {
                if (sol.rep != ELEMENT.None)
                {
                    vtkSphereSource SphereSource = vtkSphereSource.New();
                    SphereSource.SetRadius(sol.radius * 0.005);
                    SphereSource.SetThetaResolution(30);
                    SphereSource.SetPhiResolution(30);


                    SphereSource.SetCenter(sol.position.x, sol.position.y, sol.position.z);

                    // mapper
                    vtkPolyDataMapper SphereMapper = vtkPolyDataMapper.New();
                    SphereMapper.SetInputConnection(SphereSource.GetOutputPort());

                    // actor
                    vtkActor SphereActor = vtkActor.New();
                    SphereActor.GetProperty().SetColor(Convert.ToDouble(sol.color.x) / 255, Convert.ToDouble(sol.color.y) / 255, Convert.ToDouble(sol.color.z) / 255);
                    SphereActor.SetMapper(SphereMapper);
                    form.win.AddViewProp(SphereActor);
                }
            }
        }

        private void DrawPret(Vissolution sol_)
        {
            foreach (VisPoint sol in sol_.points)
            {
                if (sol.rep != ELEMENT.None)
                {
                    vtkSphereSource SphereSource = vtkSphereSource.New();
                    SphereSource.SetRadius(sol.radius * 0.0025);
                    SphereSource.SetThetaResolution(20);
                    SphereSource.SetPhiResolution(20);
                    SphereSource.SetCenter(sol.position.x, sol.position.y, sol.position.z);
                    // mapper
                    vtkPolyDataMapper SphereMapper = vtkPolyDataMapper.New();
                    SphereMapper.SetInputConnection(SphereSource.GetOutputPort());
                    // actor
                    vtkActor SphereActor = vtkActor.New();
                    SphereActor.GetProperty().SetColor(Convert.ToDouble(sol.color.x) / 255, Convert.ToDouble(sol.color.y) / 255, Convert.ToDouble(sol.color.z) / 255);
                    SphereActor.SetMapper(SphereMapper);
                    form.win.AddViewProp(SphereActor);
                }
            }
            foreach (bound sol in sol_.bounds)
            {
                if (sol.handle[1].rep != ELEMENT.None)
                {
                    if (sol.type == bound_type.singleB)
                    {
                        #region SINGLE 
                        vtkCylinderSource CylinderSource = vtkCylinderSource.New();
                        CylinderSource.SetHeight(VSEPR.GetBoundLeght(sol.handle[0].rep, sol.handle[1].rep));
                        CylinderSource.SetRadius(0.04);
                        CylinderSource.SetResolution(20);
                        Vector3 v = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));
                        CylinderSource.SetCenter(v.x, v.y, v.z);
                        // mapper
                        vtkPolyDataMapper CylinderMapper = vtkPolyDataMapper.New();
                        CylinderMapper.SetInputConnection(CylinderSource.GetOutputPort());
                        // actor
                        vtkActor SphereActor = vtkActor.New();
                        SphereActor.GetProperty().SetColor(0.9, 0.9, 0.9);
                        SphereActor.SetMapper(CylinderMapper);
                        SphereActor.SetOrigin(v.x, v.y, v.z);
                        double OZ = 0;
                        double OX = 0;

                        double OZlenght = 0;
                        double OXlenght = 0;

                        OZlenght = Math.Sqrt(Math.Pow(sol.handle[0].position.x - sol.handle[1].position.x, 2) + Math.Pow(sol.handle[0].position.y - sol.handle[1].position.y, 2));
                        OXlenght = (sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1))).lenght();

                        OZ = (sol.handle[0].position.y - sol.handle[1].position.y) / OZlenght;
                        OX = (sol.handle[0].position.z - sol.handle[1].position.z) / OXlenght;

                        if (OZlenght != 0)
                        {
                            if ((sol.handle[0].position.Add(sol.handle[1].position).Multiply(-1)).x < 0)
                                SphereActor.RotateZ(Math.Acos(OZ) * (180 / Math.PI));
                            else
                                SphereActor.RotateZ(-Math.Acos(OZ) * (180 / Math.PI));
                        }
                        if (OXlenght != 0)
                            SphereActor.RotateX(Math.Asin(OX) * (180 / Math.PI));

                        form.win.AddViewProp(SphereActor);
                        #endregion
                    }
                    else if (sol.type == bound_type.doubleB)
                    {
                        #region DOUBLE 
                        vtkCylinderSource CylinderSource = vtkCylinderSource.New();
                        CylinderSource.SetHeight(VSEPR.GetBoundLeght(sol.handle[0].rep, sol.handle[1].rep));
                        CylinderSource.SetRadius(0.04);
                        CylinderSource.SetResolution(20);
                        Vector3 v = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));
                        CylinderSource.SetCenter(v.x,v.y, v.z+0.05);
                        // mapper
                        vtkPolyDataMapper CylinderMapper = vtkPolyDataMapper.New();
                        CylinderMapper.SetInputConnection(CylinderSource.GetOutputPort());
                        // actor
                        vtkActor SphereActor = vtkActor.New();
                        SphereActor.GetProperty().SetColor(0.9, 0.9, 0.9);
                        SphereActor.SetMapper(CylinderMapper);
                        SphereActor.SetOrigin(v.x, v.y, v.z + 0.05);

                        vtkCylinderSource CylinderSource2 = vtkCylinderSource.New();
                        CylinderSource2.SetHeight(VSEPR.GetBoundLeght(sol.handle[0].rep, sol.handle[1].rep));
                        CylinderSource2.SetRadius(0.04);
                        CylinderSource2.SetResolution(20);
                        Vector3 v2 = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));
                        CylinderSource2.SetCenter(v.x, v.y, v.z - 0.05);
                        // mapper
                        vtkPolyDataMapper CylinderMapper2 = vtkPolyDataMapper.New();
                        CylinderMapper2.SetInputConnection(CylinderSource2.GetOutputPort());
                        // actor
                        vtkActor SphereActor2 = vtkActor.New();
                        SphereActor2.GetProperty().SetColor(0.9, 0.9, 0.9);
                        SphereActor2.SetMapper(CylinderMapper2);
                        SphereActor2.SetOrigin(v.x, v.y, v.z-0.05);
                        double OZ = 0;
                        double OX = 0;

                        double OZlenght = 0;
                        double OXlenght = 0;

                        OZlenght = Math.Sqrt(Math.Pow(sol.handle[0].position.x - sol.handle[1].position.x, 2) + Math.Pow(sol.handle[0].position.y - sol.handle[1].position.y, 2));
                        OXlenght = (sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1))).lenght();

                        OZ = (sol.handle[0].position.y - sol.handle[1].position.y) / OZlenght;
                        OX = (sol.handle[0].position.z - sol.handle[1].position.z) / OXlenght;

                        if (OZlenght != 0)
                        {
                            if ((sol.handle[0].position.Add(sol.handle[1].position).Multiply(-1)).x < 0)
                            {
                                SphereActor.RotateZ(Math.Acos(OZ) * (180 / Math.PI));
                                SphereActor2.RotateZ(Math.Acos(OZ) * (180 / Math.PI));
                            }
                            else
                            {
                                SphereActor.RotateZ(-Math.Acos(OZ) * (180 / Math.PI));
                                SphereActor2.RotateZ(-Math.Acos(OZ) * (180 / Math.PI));
                            }
                        }
                        if (OXlenght != 0)
                        {
                            SphereActor.RotateX(Math.Asin(OX) * (180 / Math.PI));
                            SphereActor2.RotateX(Math.Asin(OX) * (180 / Math.PI));
                        }
                        form.win.AddViewProp(SphereActor2);
                        form.win.AddViewProp(SphereActor);
                        #endregion
                    }
                    else
                    {
                        #region TRIPLE
                        vtkCylinderSource CylinderSource = vtkCylinderSource.New();
                        CylinderSource.SetHeight(VSEPR.GetBoundLeght(sol.handle[0].rep, sol.handle[1].rep));
                        CylinderSource.SetRadius(0.04);
                        CylinderSource.SetResolution(20);
                        Vector3 v = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));
                        CylinderSource.SetCenter(v.x, v.y, v.z);
                        // mapper
                        vtkPolyDataMapper CylinderMapper = vtkPolyDataMapper.New();
                        CylinderMapper.SetInputConnection(CylinderSource.GetOutputPort());
                        // actor
                        vtkActor SphereActor = vtkActor.New();
                        SphereActor.GetProperty().SetColor(0.9, 0.9, 0.9);
                        SphereActor.SetMapper(CylinderMapper);
                        SphereActor.SetOrigin(v.x, v.y, v.z);

                        vtkCylinderSource CylinderSource3 = vtkCylinderSource.New();
                        CylinderSource3.SetHeight(VSEPR.GetBoundLeght(sol.handle[0].rep, sol.handle[1].rep));
                        CylinderSource3.SetRadius(0.04);
                        CylinderSource3.SetResolution(20);
                        Vector3 v3 = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));
                        CylinderSource3.SetCenter(v.x, v.y, v.z + 0.1);
                        // mapper
                        vtkPolyDataMapper CylinderMapper3 = vtkPolyDataMapper.New();
                        CylinderMapper3.SetInputConnection(CylinderSource3.GetOutputPort());
                        // actor
                        vtkActor SphereActor3 = vtkActor.New();
                        SphereActor3.GetProperty().SetColor(0.9, 0.9, 0.9);
                        SphereActor3.SetMapper(CylinderMapper3);
                        SphereActor3.SetOrigin(v.x, v.y, v.z + 0.1);

                        vtkCylinderSource CylinderSource2 = vtkCylinderSource.New();
                        CylinderSource2.SetHeight(VSEPR.GetBoundLeght(sol.handle[0].rep, sol.handle[1].rep));
                        CylinderSource2.SetRadius(0.04);
                        CylinderSource2.SetResolution(20);
                        Vector3 v2 = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));
                        CylinderSource2.SetCenter(v.x, v.y, v.z - 0.1);
                        // mapper
                        vtkPolyDataMapper CylinderMapper2 = vtkPolyDataMapper.New();
                        CylinderMapper2.SetInputConnection(CylinderSource2.GetOutputPort());
                        // actor
                        vtkActor SphereActor2 = vtkActor.New();
                        SphereActor2.GetProperty().SetColor(0.9, 0.9, 0.9);
                        SphereActor2.SetMapper(CylinderMapper2);
                        SphereActor2.SetOrigin(v.x, v.y, v.z - 0.1);
                        double OZ = 0;
                        double OX = 0;

                        double OZlenght = 0;
                        double OXlenght = 0;

                        OZlenght = Math.Sqrt(Math.Pow(sol.handle[0].position.x - sol.handle[1].position.x, 2) + Math.Pow(sol.handle[0].position.y - sol.handle[1].position.y, 2));
                        OXlenght = (sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1))).lenght();

                        OZ = (sol.handle[0].position.y - sol.handle[1].position.y) / OZlenght;
                        OX = (sol.handle[0].position.z - sol.handle[1].position.z) / OXlenght;

                        if (OZlenght != 0)
                        {
                            if ((sol.handle[0].position.Add(sol.handle[1].position).Multiply(-1)).x < 0)
                            {
                                SphereActor.RotateZ(Math.Acos(OZ) * (180 / Math.PI));
                                SphereActor2.RotateZ(Math.Acos(OZ) * (180 / Math.PI));
                                SphereActor3.RotateZ(Math.Acos(OZ) * (180 / Math.PI));
                            }
                            else
                            {
                                SphereActor.RotateZ(-Math.Acos(OZ) * (180 / Math.PI));
                                SphereActor2.RotateZ(-Math.Acos(OZ) * (180 / Math.PI));
                                SphereActor3.RotateZ(-Math.Acos(OZ) * (180 / Math.PI));
                            }
                        }
                        if (OXlenght != 0)
                        {
                            SphereActor.RotateX(Math.Asin(OX) * (180 / Math.PI));
                            SphereActor2.RotateX(Math.Asin(OX) * (180 / Math.PI));
                            SphereActor3.RotateX(Math.Asin(OX) * (180 / Math.PI));
                        }
                        form.win.AddViewProp(SphereActor);
                        form.win.AddViewProp(SphereActor2);
                        form.win.AddViewProp(SphereActor3);
                        #endregion
                    }
                }
            }
        }

        private void DrawPretPE(Vissolution sol_)
        {
            foreach (VisPoint sol in sol_.points)
            {
                if (sol.rep != ELEMENT.None)
                {
                    vtkSphereSource SphereSource = vtkSphereSource.New();
                    SphereSource.SetRadius(sol.radius * 0.0025);
                    SphereSource.SetThetaResolution(20);
                    SphereSource.SetPhiResolution(20);
                    SphereSource.SetCenter(sol.position.x, sol.position.y, sol.position.z);
                    // mapper
                    vtkPolyDataMapper SphereMapper = vtkPolyDataMapper.New();
                    SphereMapper.SetInputConnection(SphereSource.GetOutputPort());
                    // actor
                    vtkActor SphereActor = vtkActor.New();
                    SphereActor.GetProperty().SetColor(Convert.ToDouble(sol.color.x) / 255, Convert.ToDouble(sol.color.y) / 255, Convert.ToDouble(sol.color.z) / 255);
                    SphereActor.SetMapper(SphereMapper);
                    form.win.AddViewProp(SphereActor);
                }
            }
            foreach (bound sol in sol_.bounds)
            {
                if (sol.handle[1].rep != ELEMENT.None)
                {
                    vtkCylinderSource CylinderSource = vtkCylinderSource.New();
                    CylinderSource.SetHeight(VSEPR.GetBoundLeght(sol.handle[0].rep, sol.handle[1].rep));
                    CylinderSource.SetRadius(0.04);
                    CylinderSource.SetResolution(20);
                    Vector3 v = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));
                    CylinderSource.SetCenter(v.x, v.y, v.z);
                    // mapper
                    vtkPolyDataMapper CylinderMapper = vtkPolyDataMapper.New();
                    CylinderMapper.SetInputConnection(CylinderSource.GetOutputPort());
                    // actor
                    vtkActor SphereActor = vtkActor.New();
                    SphereActor.GetProperty().SetColor(0.9, 0.9, 0.9);
                    SphereActor.SetMapper(CylinderMapper);
                    SphereActor.SetOrigin(v.x, v.y, v.z);
                    double OZ = 0;
                    double OX = 0;

                    double OZlenght = 0;
                    double OXlenght = 0;

                    OZlenght = Math.Sqrt(Math.Pow(sol.handle[0].position.x - sol.handle[1].position.x, 2) + Math.Pow(sol.handle[0].position.y - sol.handle[1].position.y, 2));
                    OXlenght = (sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1))).lenght();

                    OZ = (sol.handle[0].position.y - sol.handle[1].position.y) / OZlenght;
                    OX = (sol.handle[0].position.z - sol.handle[1].position.z) / OXlenght;

                    if (OZlenght != 0)
                    {
                        if ((sol.handle[0].position.Add(sol.handle[1].position).Multiply(-1)).x < 0)
                            SphereActor.RotateZ(Math.Acos(OZ) * (180 / Math.PI));
                        else
                            SphereActor.RotateZ(-Math.Acos(OZ) * (180 / Math.PI));
                    }
                    if (OXlenght != 0)
                        SphereActor.RotateX(Math.Asin(OX) * (180 / Math.PI));

                    form.win.AddViewProp(SphereActor);
                }
                else
                {
                    Vector3 v = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));

                    double OZ = 0;
                    double OX = 0;

                    double OZlenght = 0;
                    double OXlenght = 0;

                    OZlenght = Math.Sqrt(Math.Pow(sol.handle[0].position.x - sol.handle[1].position.x, 2) + Math.Pow(sol.handle[0].position.y - sol.handle[1].position.y, 2));
                    OXlenght = (sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1))).lenght();

                    OZ = (sol.handle[0].position.y - sol.handle[1].position.y) / OZlenght;
                    OX = (sol.handle[0].position.z - sol.handle[1].position.z) / OXlenght;

                    float RZ = 0;
                    float RX = 0;

                    if (OZlenght != 0)
                    {
                        if ((sol.handle[0].position.Add(sol.handle[1].position).Multiply(-1)).x < 0)
                            RZ = Convert.ToSingle(Math.Acos(OZ) * (180 / Math.PI));
                        else
                            RZ = Convert.ToSingle(-Math.Acos(OZ) * (180 / Math.PI));
                    }
                    if (OXlenght != 0)
                        RX = Convert.ToSingle(Math.Asin(OX) * (180 / Math.PI));

                    v = v.Multiply(0.5f);

                    DrawOBJ(v, "Models/PE.obj", new Vector3(0, 0.8f, 1), new Vector3(RX, 0, RZ), new Vector3(0.12f, 0.12f, 0.12f),0.5);
                }
            }
        }

        private void DrawTRANS(Vissolution sol_)
        {
            foreach (bound sol in sol_.bounds)
            {
                if (sol.handle[1].rep != ELEMENT.None)
                {
                    vtkCylinderSource CylinderSource = vtkCylinderSource.New();
                    CylinderSource.SetHeight(VSEPR.GetBoundLeght(sol.handle[0].rep, sol.handle[1].rep));
                    CylinderSource.SetRadius(0.005);
                    CylinderSource.SetResolution(20);
                    Vector3 v = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));
                    CylinderSource.SetCenter(v.x, v.y, v.z);
                    // mapper
                    vtkPolyDataMapper CylinderMapper = vtkPolyDataMapper.New();
                    CylinderMapper.SetInputConnection(CylinderSource.GetOutputPort());
                    // actor
                    vtkActor SphereActor = vtkActor.New();
                    SphereActor.GetProperty().SetColor(1, 0, 0);
                    SphereActor.SetMapper(CylinderMapper);
                    SphereActor.SetOrigin(v.x, v.y, v.z);
                    double OZ = 0;
                    double OX = 0;

                    double OZlenght = 0;
                    double OXlenght = 0;

                    OZlenght = Math.Sqrt(Math.Pow(sol.handle[0].position.x - sol.handle[1].position.x, 2) + Math.Pow(sol.handle[0].position.y - sol.handle[1].position.y, 2));
                    OXlenght = (sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1))).lenght();

                    OZ = (sol.handle[0].position.y - sol.handle[1].position.y) / OZlenght;
                    OX = (sol.handle[0].position.z - sol.handle[1].position.z) / OXlenght;

                    if (OZlenght != 0)
                    {
                        if ((sol.handle[0].position.Add(sol.handle[1].position).Multiply(-1)).x < 0)
                            SphereActor.RotateZ(Math.Acos(OZ) * (180 / Math.PI));
                        else
                            SphereActor.RotateZ(-Math.Acos(OZ) * (180 / Math.PI));
                    }
                    if (OXlenght != 0)
                        SphereActor.RotateX(Math.Asin(OX) * (180 / Math.PI));

                    form.win.AddViewProp(SphereActor);
                }
            }
        }

        private void DrawMO(Vissolution sol_)
        {
            foreach (VisPoint sol in sol_.points)
            {
                if (sol.rep != ELEMENT.None)
                {
                    vtkSphereSource SphereSource = vtkSphereSource.New();
                    SphereSource.SetRadius(sol.radius * 0.001);
                    SphereSource.SetThetaResolution(20);
                    SphereSource.SetPhiResolution(20);
                    SphereSource.SetCenter(sol.position.x, sol.position.y, sol.position.z);
                    // mapper
                    vtkPolyDataMapper SphereMapper = vtkPolyDataMapper.New();
                    SphereMapper.SetInputConnection(SphereSource.GetOutputPort());
                    // actor
                    vtkActor SphereActor = vtkActor.New();
                    SphereActor.GetProperty().SetColor(Convert.ToDouble(sol.color.x) / 255, Convert.ToDouble(sol.color.y) / 255, Convert.ToDouble(sol.color.z) / 255);
                    SphereActor.SetMapper(SphereMapper);
                    form.win.AddViewProp(SphereActor);
                }
            }
            foreach (bound sol in sol_.bounds)
            {
                if (sol.handle[1].rep != ELEMENT.None)
                {
                    Vector3 v = sol.handle[0].position.Add(sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1)).Multiply((float)-0.5));

                    double OZ = 0;
                    double OX = 0;

                    double OZlenght = 0;
                    double OXlenght = 0;

                    OZlenght = Math.Sqrt(Math.Pow(sol.handle[0].position.x - sol.handle[1].position.x, 2) + Math.Pow(sol.handle[0].position.y - sol.handle[1].position.y, 2));
                    OXlenght = (sol.handle[0].position.Add(sol.handle[1].position.Multiply(-1))).lenght();

                    OZ = (sol.handle[0].position.y - sol.handle[1].position.y) / OZlenght;
                    OX = (sol.handle[0].position.z - sol.handle[1].position.z) / OXlenght;

                    float RZ = 0;
                    float RX = 0;

                    if (OZlenght != 0)
                    {
                        if ((sol.handle[0].position.Add(sol.handle[1].position).Multiply(-1)).x < 0)
                            RZ = Convert.ToSingle(Math.Acos(OZ) * (180 / Math.PI));
                        else
                            RZ = Convert.ToSingle(-Math.Acos(OZ) * (180 / Math.PI));
                    }
                    if (OXlenght != 0)
                        RX = Convert.ToSingle(Math.Asin(OX) * (180 / Math.PI));

                    v = v.Multiply(0.5f);
                    DrawOBJ(v, "Models/sigma.obj", new Vector3(0.9f, 0.9f, 0), new Vector3(RX, 0, RZ), new Vector3(0.1f, 0.1f, 0.1f),0.7);
                }
            }
        }

        private void DrawOBJ(Vector3 pos,string target,Vector3 color,Vector3 rotation,Vector3 scale,double op)
        {
            vtkOBJReader rd = vtkOBJReader.New();
            rd.SetFileName(target);
            rd.Update();
            // mapper
            vtkPolyDataMapper SphereMapper = vtkPolyDataMapper.New();
            SphereMapper.SetInputConnection(rd.GetOutputPort());
            // actor
            vtkActor SphereActor = vtkActor.New();
            SphereActor.GetProperty().SetColor(color.x, color.y, color.z);
            SphereActor.GetProperty().SetOpacity(op);
            SphereActor.SetOrigin(pos.x, pos.y, pos.z);
            SphereActor.SetPosition(pos.x, pos.y, pos.z);
            SphereActor.SetScale(scale.x, scale.y, scale.z);
            SphereActor.RotateZ(rotation.z);
            SphereActor.RotateX(rotation.x);
            SphereActor.SetMapper(SphereMapper);
            form.win.AddViewProp(SphereActor);
        }

        private void SetCamerOrigin(double value)
        {
            vtkSphereSource SphereSource = vtkSphereSource.New();
            SphereSource.SetRadius(value);
            SphereSource.SetThetaResolution(20);
            SphereSource.SetPhiResolution(20);
            SphereSource.SetCenter(0, 0, 0);

            // mapper
            vtkPolyDataMapper SphereMapper = vtkPolyDataMapper.New();
            SphereMapper.SetInputConnection(SphereSource.GetOutputPort());

            // actor
            vtkActor SphereActor = vtkActor.New();
            SphereActor.GetProperty().SetOpacity(0.001);
            SphereActor.SetMapper(SphereMapper);
            form.win.AddViewProp(SphereActor);

        }

        public void Zoom(double value)
        {
            form.cam.Zoom(value);
            form.win.GetRenderWindow().Render();
        }

        public void refreshCamera()
        {
            form.cam.SetPosition(0.1, 0.1, 0.1);
            form.cam.SetViewUp(0, 0, 0);
            form.cam.SetWindowCenter(0, 0);
            form.win.Render();
            form.win.ResetCamera();
            form.cam.Zoom(1.75);
            form.win.GetRenderWindow().Render();
        }

        public void Clear()
        {
            form.win.RemoveAllViewProps();
            refreshCamera();
        }

        public void NextSol()
        {         
            if (Solutions.Count-1 > current)
            {
                current++;
                Reload();
            }
        }

        public void PrevSol()
        {
            if (0< current)
            {
                current--;
                Reload();
            }
        }

        public void Reload()
        {       
            DrawModel(current);
        }

    }

    public class Vissolution
    {
        public List<bound> bounds;
        public List<VisPoint> points;

        public Vissolution(List<bound> bounds_, List<VisPoint> points_)
        {
            bounds = bounds_;
            points = points_;
        }

    }

    public class VisPoint
        {
        public Vector3 position;
        public ELEMENT rep;
        public float radius;
        public Vector3 color;

        public VisPoint(Vector3 pos, ELEMENT element_)
        {
            position = pos; 
            rep = element_;
            radius = element_.radius;
            color = element_.colorpref;
        }
        
        }

    public class bound
    {
        public VisPoint[] handle;
        public bound_type type;

        public bound(VisPoint[] elements, bound_type type_)
        {
            type = type_;
            handle = elements;
        }

    }

    public enum bound_type
        {
        singleB,doubleB,tripleB
    }

    public enum Vis_type
    {
        pretowy,czasowy,pretowyPE,MO,AO,AMO,translation
    }
}
