using System;
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
    public class Mod  //分段作用
    {
        public int arg2Model; //凹凸模式
        public int arg2PRI;
        public int arg3K; //斜率
        public int arg3PRI;
        public double arg4Duration; //持续时长,按比例算
        public int arg5Factor; //倍增变化因子
        public double[ , ] arg6FC; //因子变化参数,实现变化曲线
        public int arg6PRI;
        public Mod()
        {
            this.arg2PRI = 0;
            this.arg3PRI = 0;
            this.arg6PRI = 0;

            this.arg6FC = new double[6, 2]
            {
                {0, 0 },  {0, 0 },  {0, 0 },
                {0, 0 },  {0, 0 },  {0, 0 }
            };
        }
    }

    public class AllData //提供全局静态参数
    {
        public static int Concave = -1; //内凹模式
        public static int Convex = 1; //外凸模式
        public static int Smooth = 0;//

        public static int DataLength = 0;
         
        public static ArrayList yArray = new ArrayList();
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
            Mod mod = new Mod {
                arg2Model = AllData.Concave,
                arg3K = 1,
                arg4Duration = 0.3,
                arg5Factor = 100
            };
            mod.arg5Factor = 50;
            mod.arg6FC[1, FCpos] = 0.2;
            mod.arg6FC[2, FCpos] = ModEND;
            //分1段 0 - 0.2 - 1 ，默认每段FC=0
            mod.arg6FC[0, FCvalue] = 20;//第一段0 - 0.2 配置FC=20

            Mod mod1 = new Mod{
                arg2Model = AllData.Convex,
                arg3K = -1,
                arg4Duration = 0.3,
                arg5Factor = 100
            };
            mod1.arg5Factor = 50;
            mod1.arg6FC[1, FCpos] = 0.8;
            mod1.arg6FC[2, FCpos] = ModEND;
            //分2段 0 - 0.8 - 1 ，默认每段FC=0
            mod1.arg6FC[1, FCvalue] = 20;//第二段0.8 - 1 配置FC=20

            AllData.SimpleModArray.Add(mod);
            AllData.SimpleModArray.Add(mod1);
        }
        public bool GenAnalogData(float pre)  //modEnd 或 1 跳出
        {
            foreach (Mod mod in AllData.SimpleModArray)
            {
                double[] pos = new double[mod.];
                double locBgn = mod.arg6FC[1, FCpos] * AllData.DataLength;
                double locEnd = mod.arg6FC[2, FCpos] * AllData.DataLength;

            }
            return false;
        }
    }
}
