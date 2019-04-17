﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wt2
{
    public class Y_Value
    {
        public double value, arg1;
        public Y_Value(double value, double arg1){
            this.value = value;
            this.arg1 = arg1;
        }
    }
    public class Session
    {
        public double duration; //占比0-1
        public int BaseFactor;
        public int VariantArg;
    } 
    public class Mod  //分段作用
    {
        public int argModel; //凹凸模式
        public int argK; //斜率
        public double begin;  // 取值范围0-1 
        public double ModDuration; //总持续时长 取值范围0-1 
        public ArrayList sessionList = new ArrayList(); 
    }

    public class AllData //提供全局静态参数
    {
        public static int Concave = -1; //内凹模式
        public static int Convex = 1; //外凸模式
        public static int Smooth = 0;//

        public static int DataLength = 0;
         
        public static ArrayList yArray;
        public static ArrayList ModArray = new ArrayList();

        public static ArrayList SimpleModArray = new ArrayList();
        
    }



    public class Funcs
    {
        public static int ModEND = -1;
        public static int FCpos = 0;
        public static int FCvalue = 1;

        public void InitSimpleMods()
        {
            Session sess;

            Mod mod = new Mod {
                argModel = AllData.Concave,
                argK = 1,
                begin = 0.2,
                ModDuration = 0.3
            };
            mod.sessionList.Add(sess = new Session{
                BaseFactor = 100,
                duration = 0.5,
                VariantArg = 0
            });
            mod.sessionList.Add(sess = new Session
            {
                BaseFactor = 100,
                duration = 0.5,
                VariantArg = 200
            });

            Mod mod1 = new Mod
            {
                argModel = AllData.Convex,
                argK = -1,
                begin = 0.8,
                ModDuration = 0.3
            };
            mod1.sessionList.Add(sess = new Session
            {
                BaseFactor = 100,
                duration = 0.5,
                VariantArg = 0
            });
            mod1.sessionList.Add(sess = new Session
            {
                BaseFactor = 100,
                duration = 0.5,
                VariantArg = 150
            });
            
            AllData.SimpleModArray.Add(mod);
            AllData.SimpleModArray.Add(mod1);
        }
        public bool GenAnalogData(double pre)  //modEnd 或 1 跳出
        {
            int[] yValue = new int[AllData.DataLength];

            foreach (Mod mod in AllData.SimpleModArray)  //迭代每一个mod
            {
                int CurLoc = (int)(mod.begin * AllData.DataLength); 
                int ModLength = (int)(mod.ModDuration * AllData.DataLength);
                foreach(Session sess in mod.sessionList)
                {
                    int SessEndLoc = CurLoc + (int)(sess.duration * ModLength);
                    int bValue = 0;
                    while(CurLoc<SessEndLoc)
                    {
                        sess.BaseFactor += sess.VariantArg;
                        bValue += sess.BaseFactor;
                        yValue[CurLoc] = bValue;

                        ++CurLoc;
                    }
                }

            }
            AllData.yArray = new ArrayList(yValue);
            return false;
        }
    }
}
