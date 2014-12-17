using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CopyCourseScore
{
    class Permissions
    {
        public static string CopyCourseScore { get { return "CopyCourseScore.9DC057E5-ED9D-49DE-9A8F-C78CDDF4CDE1"; } }

        public static bool CopyCourseScore權限
        {
            get { return FISCA.Permission.UserAcl.Current[CopyCourseScore].Executable; }
        }
    }
}
