﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAP2000v16;
// interop.COM services for SAP
using System.Runtime.InteropServices;

//DYNAMO
using Autodesk.DesignScript.Geometry;
using Autodesk.DesignScript.Runtime;

namespace SAPConnection
{
    [SupressImportIntoVM]
    public class LoadMapper
    {
        // DEFINE LOAD PATTERN In SAPMODEL METHOD
        public static void AddLoadPattern(ref cSapModel Model, string Name, string Type, double Multiplier)
        {
            eLoadPatternType type = (eLoadPatternType)Enum.Parse(typeof(eLoadPatternType), Type);
            int ret = Model.LoadPatterns.Add(Name, type, Multiplier);  
        }

        // DEFINE LOAD CASE IN SAP
        public static void AddLoadCase(ref cSapModel Model, string Name, int LoadCount, ref string[] Loadtype, ref string[] LoadName, ref double []SF){
            int ret = Model.LoadCases.StaticLinear.SetCase(Name);
            ret = Model.LoadCases.StaticLinear.SetLoads(Name, LoadCount, ref Loadtype, ref LoadName, ref SF);
        }

        //CREATE LOAD METHODS
        public static int CreatePointLoad(ref cSapModel mySapModel, string FrameName, string LoadPat, int MyType, int Dir, double Dist, double Val, string CSys, bool RelDist, bool Replace)
        {
            return mySapModel.FrameObj.SetLoadPoint(FrameName, LoadPat, MyType, Dir, Dist, Val, CSys, RelDist, Replace);
        }
        public static int CreateDistributedLoad(ref cSapModel mySapModel, string FrameName, string LoadPat, int MyType, int Dir, double Dist, double Dist2, double Val, double Val2, string CSys, bool RelDist, bool Replace)
        {
            return mySapModel.FrameObj.SetLoadDistributed(FrameName, LoadPat, MyType, Dir, Dist, Dist2, Val, Val2, CSys, RelDist, Replace);
        }

        
    }
}
