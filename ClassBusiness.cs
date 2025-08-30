using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Memory_Game
{
    public class ClassBusiness
    {
        public static DataTable GetAllImage()
        {
            DataTable dt , dt2 ;
            dt = ClassDataAccess.GetAllImageRandom();
            dt2 = ClassDataAccess.GetAllImageRandom();

            dt.Merge(dt2);

            return dt; 
        }
    }
}
