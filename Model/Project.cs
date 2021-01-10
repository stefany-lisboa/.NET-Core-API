using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SS_API.Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Why { get; set; }
        public string What { get; set; }
        public string WhatWillWeDo { get; set; }
        public ProjectStatus ProjStatus { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public int CourseId { get; set; }

        public enum ProjectStatus
        {
            development = 0,
            publicated = 1
        }
    }
}