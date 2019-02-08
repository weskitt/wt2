using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wt2
{
    public class AllData
    {
        public static int Concave = -1; //内凹模式
        public static int Convex = 1; //外凸模式
        public static int Smooth = 0;//
         
        public static ArrayList yArray = new ArrayList();
        public static ArrayList ModArray = new ArrayList();
    }

    public class Y_Value
    {
        public float value, arg1;
        public Y_Value(float value, float arg1)
        {
            this.value = value;
            this.arg1 = arg1;
        }
    }
    public class Mod
    {
        public int arg2Model; //凹凸模式
        public int arg3Slope; //斜率
        public int arg4Duration; //持续时长
    }

    public class Funcs
    {
        public bool GenAnalogData(float )
        {

            return false;
        }
    }
}
