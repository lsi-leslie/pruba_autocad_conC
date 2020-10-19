using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace AU.MySoftware
{
    class Initialization : IExtensionApplication
    {
        #region Commands

        [CommandMethod("Proyecto")]
        public void cmdMyFirst()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database db = acDoc.Database;
            Transaction trans = db.TransactionManager.StartTransaction();

          //  acDoc.SendStringToExecute("circle 2,2,0 4 ", true, false, true); para enviar a linea de comandos
            BlockTable blkTbl = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
            BlockTableRecord msBlkRec = trans.GetObject(blkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;


            Point3d pnt1 = new Point3d(10, 10, 0);
            Point3d pnt2 = new Point3d(20, 20, 0);

            Line lineObj = new Line(pnt1, pnt2);
            msBlkRec.AppendEntity(lineObj);
            trans.AddNewlyCreatedDBObject(lineObj, true);
            trans.Commit();

        }

        #endregion

        #region Initialization
        void IExtensionApplication.Initialize()
        {
                
        }
        void IExtensionApplication.Terminate()
        {

        }
        #endregion
    }

}
