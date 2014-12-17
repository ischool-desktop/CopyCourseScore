using FISCA.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyCourseScore
{
    public class Program
    {
        [FISCA.MainMethod]
        public static void main()
        {
            FISCA.Presentation.RibbonBarItem item1 = FISCA.Presentation.MotherForm.RibbonBarItems["課程", "教務"];
            item1["複製課程成績"].Image = Properties.Resources.attribute_up_64;
            item1["複製課程成績"].Enable = false;
            item1["複製課程成績"].Click += delegate
            {
                new MainForm().ShowDialog();
            };

            K12.Presentation.NLDPanels.Course.SelectedSourceChanged += delegate
            {
                item1["複製課程成績"].Enable = Permissions.CopyCourseScore權限 && K12.Presentation.NLDPanels.Course.SelectedSource.Count == 1;
            };

            Catalog permission1 = RoleAclSource.Instance["課程"]["功能按鈕"];
            permission1.Add(new RibbonFeature(Permissions.CopyCourseScore, "複製課程成績"));
        }
        
    }
}
