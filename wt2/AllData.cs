using System;
using System.Collections;
using System.Drawing;
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
        public double BaseFactor;  //规律参数
        public double VariantArg;    //变异参数
    } 
    public class Mod  //分段作用
    {
        public double argModel; //凹凸模式
        public double argK; //斜率
        public double begin;  // 起点取值范围0-1 
        public double ModDuration; //总持续时长 取值范围0-1 
        public ArrayList sessionList = new ArrayList(); 
    }

    public class WAData //提供全局静态参数
    {
        public static int Concave = -1; //内凹模式
        public static int Convex = 1; //外凸模式
        public static int Smooth = 0;//

        public static int DataLength = 0;
        public static int DataMax = 0;

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
                argModel = WAData.Concave,
                argK = 1,
                begin = 0.2,            //mod起点
                ModDuration = 0.3 //mod作用长度
            };
            mod.sessionList.Add(sess = new Session{
                BaseFactor = 1,
                duration = 0.5,
                VariantArg = 0
            });
            mod.sessionList.Add(sess = new Session
            {
                BaseFactor = 1,
                duration = 0.5,
                VariantArg = -0.07
            });
            //~~~~~~~~~~~~~~~~~~两个mod~~~~~~~~~~~~~~~~~~~~~~
            Mod mod1 = new Mod
            {
                argModel = WAData.Convex,
                argK = -1,
                begin = 0.8,
                ModDuration = 0.2
            };
            mod1.sessionList.Add(sess = new Session
            {
                BaseFactor = 1,
                duration = 0.5,
                VariantArg = 0
            });
            mod1.sessionList.Add(sess = new Session
            {
                BaseFactor =1,
                duration = 0.5,
                VariantArg = 0.1
            });
            
            WAData.SimpleModArray.Add(mod);
            WAData.SimpleModArray.Add(mod1);
        }
        public bool GenAnalogData(double pre)  //modEnd 或 1 跳出
        {
            double[] yValue = new double[WAData.DataLength];
            //PointF[] pts = new PointF[WAData.DataLength];

            foreach (Mod mod in WAData.SimpleModArray)  //迭代每一个mod
            {
                double bValue = 0;   //默认初始值
                int CurLoc = (int)(mod.begin * WAData.DataLength);     //获取mod起点位置
                int ModLength = (int)(mod.ModDuration * WAData.DataLength); //mod作用长度
                foreach(Session sess in mod.sessionList)  //迭代mod内部session
                {
                    int SessEndLoc = CurLoc + (int)(sess.duration * ModLength); //获取sess结束位置

                    double mixArg = sess.BaseFactor; //混合参数
                    while (CurLoc<SessEndLoc)  //处理sess内部数据
                    {
                        mixArg += sess.VariantArg;  //混合参数
                        bValue += mixArg;  //赋予混合参数
                        yValue[CurLoc] = bValue;
                        //pts[CurLoc].X = CurLoc;
                        //pts[CurLoc].Y = bValue;
                        ++CurLoc;
                    }
                }

            }
            WAData.yArray = new ArrayList(yValue);
            return false;
        }
    }
}
