using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NestedCommentsWithExtensionHtmlHelper.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public string Text { get; set; }
        public DateTime CreatorDateTime { get; set; }
        public int? QuestionId { get; set; }
        public virtual Comment Question { get; set; }
        public virtual ICollection<Comment> Responses { get; set; }
    }
}