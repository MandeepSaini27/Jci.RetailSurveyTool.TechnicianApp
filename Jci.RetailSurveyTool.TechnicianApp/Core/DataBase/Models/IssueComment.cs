﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JCI.RetailSurveyTool.DataBase.Models
{
    public class IssueComment
    {
        [Key]
        public int ID { set; get; }
        public int IssueID { set; get; }
        public virtual Issue Issue { set; get; }
        public string AuthorEmail { set; get; }
        public DateTime CreatedAt { set; get; }
        public string CommentText { set; get; }
    }
}
