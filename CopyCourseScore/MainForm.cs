using DevComponents.DotNetBar;
using FISCA.Presentation.Controls;
using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CopyCourseScore
{

    public partial class MainForm : BaseForm
    {
        CourseRecord _sourceCourse;
        CourseRecord _targetCourse;
        List<CourseRecord> _courses;
        List<SCAttendRecord> _sourceSCAs;
        Dictionary<string, SCAttendRecord> _targetSCADic;
        Dictionary<string, StudentRecord> _studentDic;
        TeacherRecord _teacher;

        public MainForm()
        {
            InitializeComponent();

            _targetSCADic = new Dictionary<string, SCAttendRecord>();
            _studentDic = new Dictionary<string, StudentRecord>();

            //來源課程
            string course_id = K12.Presentation.NLDPanels.Course.SelectedSource[0];
            _sourceCourse = K12.Data.Course.SelectByID(course_id);

            //來源課程教師
            string teacher_id = _sourceCourse.MajorTeacherID;
            _teacher = K12.Data.Teacher.SelectByID(teacher_id);

            if (_teacher != null)
            {
                //取得該教師其他授課課程
                List<K12.Data.TCInstructRecord> tcs = K12.Data.TCInstruct.SelectByTeacherIDAndCourseID(new string[] { teacher_id }, new string[] { });

                List<string> courses = new List<string>();
                foreach (K12.Data.TCInstructRecord tr in tcs)
                {
                    if (tr.Sequence == 1 && tr.RefCourseID != _sourceCourse.ID)
                        courses.Add(tr.RefCourseID);
                }

                _courses = K12.Data.Course.SelectByIDs(courses);
                lblTitle.Text = string.Format("{0} ({1})", _sourceCourse.Name, _teacher.Name);

                //呈現該教師其他授課課程
                foreach (CourseRecord cr in _courses)
                {
                    ButtonItem item = new ButtonItem();
                    item.OptionGroup = "course";
                    item.Text = cr.Name;
                    item.Tag = cr;
                    item.Click += new EventHandler(item_click);
                    itemPanle1.Items.Add(item);
                }

                //取得來源修課紀錄
                _sourceSCAs = K12.Data.SCAttend.SelectByCourseIDs(new string[] { _sourceCourse.ID });

                //學生對照
                List<string> stu_ids = _sourceSCAs.Select(x => x.RefStudentID).ToList();
                foreach (StudentRecord stu in K12.Data.Student.SelectByIDs(stu_ids))
                {
                    _studentDic.Add(stu.ID, stu);
                }
            }
        }

        private void item_click(object sender, EventArgs e)
        {
            ButtonItem item = sender as ButtonItem;
            _targetCourse = item.Tag as CourseRecord;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_teacher == null)
            {
                MessageBox.Show("評分教師(教師一)尚未被設定,無法複製課程成績");
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<SCAttendRecord> update = new List<SCAttendRecord>();

            if (_targetCourse != null)
            {
                //MessageBox.Show(_targetCourse.Name + ":" + _targetCourse.MajorTeacherName);

                //取得目標修課紀錄
                List<SCAttendRecord> sca_records = K12.Data.SCAttend.SelectByCourseIDs(new string[] { _targetCourse.ID });

                //整理對照目標修課紀錄
                _targetSCADic.Clear();
                foreach (SCAttendRecord scr in sca_records)
                {
                    _targetSCADic.Add(scr.RefStudentID, scr);
                }

                bool mustAsk = true;
                //複製課程成績
                foreach (SCAttendRecord source in _sourceSCAs)
                {
                    //只複製兩邊皆有的學生資料
                    if (_targetSCADic.ContainsKey(source.RefStudentID))
                    {
                        SCAttendRecord target = _targetSCADic[source.RefStudentID];
                        StudentRecord stu = _studentDic[source.RefStudentID];
                        //目標已有成績資料
                        if (target.Score.HasValue)
                        {
                            //選過一律覆寫就不再提問
                            if (mustAsk)
                            {
                                DialogResult result = new AskForm(string.Format("學生:{0} 已存在成績資料,確認覆寫?", stu.Name)).ShowDialog();
                                if (result == DialogResult.No)
                                {
                                    continue;
                                }
                                else if (result == DialogResult.Abort)
                                {
                                    mustAsk = false;
                                }
                            }
                        }

                        string old_score = target.Score + "";
                        string new_score = source.Score + "";

                        //前後不同的成績將被加入update清單並寫進log
                        if (old_score != new_score)
                        {
                            target.Score = source.Score;
                            update.Add(target);
                            sb.AppendLine(string.Format("學生:{0} 學號:{1} 成績由「{2}」改為「{3}」", stu.Name, stu.StudentNumber, old_score, new_score));
                        }
                    }
                }

                if (update.Count > 0)
                {
                    K12.Data.SCAttend.Update(update);
                    WriteLog(sb);
                }
                    
                MessageBox.Show("複製完成");
            }
            else
            {
                MessageBox.Show("請選擇目標課程");
            }
        }

        private void WriteLog(StringBuilder sb)
        {
                sb.Insert(0, string.Format("課程:{0} \r\n",_targetCourse.Name));
                FISCA.LogAgent.ApplicationLog.Log("複製課程成績", "編輯", sb.ToString());
        }
    }
}
