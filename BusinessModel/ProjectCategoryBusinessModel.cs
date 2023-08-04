using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel
{
    public class ProjectCategoryBusinessModel : BusinessModelBase
    {
        public int? ProjectCategoryId { get; set; }

        public string TitleFa { get; set; } = null!;

        public string? TitleEn { get; set; }

        public string? TitleTr { get; set; }

        public string? TitleAr { get; set; }

        public string? TitleDu { get; set; }

        public string? TitleFr { get; set; }
        public virtual ICollection<ProjectBusinessModel>? Projects { get; set; } = new List<ProjectBusinessModel>();

    }
}
