using System;
namespace DTcms.Model
{
    /// <summary>
    /// S_Student_Info:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class S_Student_Info
    {
        public S_Student_Info()
        { }
        #region Model
        private int _st_id;
        private int _fk_belong_teacher;
        private string _st_name;
        private string _st_telphone;
        private string _st_education;
        private string _st_sex;
        private string _st_nation;
        private string _st_native;
        private string _st_age;
        private string _st_long;
        private string _st_weight;
        private string _st_class;
        private string _st_disease;
        private string _st_school;
        private string _st_idcard;
        private string _st_ballage;
        private string _st_introducer;
        private string _st_remark;
        private int? _fk_class_level;
        private int? _st_status;
        private DateTime? _create_time;
        private int? _account_amount;
        private string _student_openid;
        /// <summary>
        /// 
        /// </summary>
        public int st_id
        {
            set { _st_id = value; }
            get { return _st_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FK_belong_teacher
        {
            set { _fk_belong_teacher = value; }
            get { return _fk_belong_teacher; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string st_name
        {
            set { _st_name = value; }
            get { return _st_name; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string st_telphone
        {
            set { _st_telphone = value; }
            get { return _st_telphone; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string st_education
        {
            set { _st_education = value; }
            get { return _st_education; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string st_sex
        {
            set { _st_sex = value; }
            get { return _st_sex; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string st_nation
        {
            set { _st_nation = value; }
            get { return _st_nation; }
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string st_native
        {
            set { _st_native = value; }
            get { return _st_native; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string st_age
        {
            set { _st_age = value; }
            get { return _st_age; }
        }
        /// <summary>
        /// 身高
        /// </summary>
        public string st_long
        {
            set { _st_long = value; }
            get { return _st_long; }
        }
        /// <summary>
        /// 体重
        /// </summary>
        public string st_weight
        {
            set { _st_weight = value; }
            get { return _st_weight; }
        }
        /// <summary>
        /// 所属班级
        /// </summary>
        public string st_class
        {
            set { _st_class = value; }
            get { return _st_class; }
        }
        /// <summary>
        /// 有无病史
        /// </summary>
        public string st_disease
        {
            set { _st_disease = value; }
            get { return _st_disease; }
        }
        /// <summary>
        /// 学校
        /// </summary>
        public string st_school
        {
            set { _st_school = value; }
            get { return _st_school; }
        }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string st_idcard
        {
            set { _st_idcard = value; }
            get { return _st_idcard; }
        }
        /// <summary>
        /// 小篮球年龄段
        /// </summary>
        public string st_ballage
        {
            set { _st_ballage = value; }
            get { return _st_ballage; }
        }
        /// <summary>
        /// 介绍人
        /// </summary>
        public string st_introducer
        {
            set { _st_introducer = value; }
            get { return _st_introducer; }
        }
        /// <summary>
        /// 学生备注
        /// </summary>
        public string st_remark
        {
            set { _st_remark = value; }
            get { return _st_remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_class_level
        {
            set { _fk_class_level = value; }
            get { return _fk_class_level; }
        }
        /// <summary>
        /// 学生状态
        /// </summary>
        public int? st_status
        {
            set { _st_status = value; }
            get { return _st_status; }
        }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? create_time
        {
            set { _create_time = value; }
            get { return _create_time; }
        }
        /// <summary>
        /// 剩余课次
        /// </summary>
        public int? account_amount
        {
            set { _account_amount = value; }
            get { return _account_amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string student_openid
        {
            set { _student_openid = value; }
            get { return _student_openid; }
        }
        #endregion Model

    }
}

