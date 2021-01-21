using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// C_Curriculum:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class C_Curriculum
    {
        public C_Curriculum()
        { }
        #region Model
        private int _id;
        private string _curriculumname;
        private string _curriculumremark;
        private DateTime? _curriculumdate;
        private int? _teacherid;
        private string _teacher;
        private int? _curriculum;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CurriculumName
        {
            set { _curriculumname = value; }
            get { return _curriculumname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CurriculumRemark
        {
            set { _curriculumremark = value; }
            get { return _curriculumremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CurriculumDate
        {
            set { _curriculumdate = value; }
            get { return _curriculumdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TeacherID
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Teacher
        {
            set { _teacher = value; }
            get { return _teacher; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Curriculum
        {
            set { _curriculum = value; }
            get { return _curriculum; }
        }
        #endregion Model

    }
}
