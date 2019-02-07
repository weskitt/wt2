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
        public static ArrayList pArray = new ArrayList();
        public static int Concave = -1; //内凹模式
        public static int Convex = 1; //外凸模式
        public static int Smooth = 0;//
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
        public int arg2Model;
    }

    public class Funcs
    {
        public bool GenAnalogData()
        {

            return false;
        }
    }
}
