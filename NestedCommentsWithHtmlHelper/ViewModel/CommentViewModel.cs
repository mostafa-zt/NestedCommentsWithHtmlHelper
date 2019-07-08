using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NestedCommentsWithExtensionHtmlHelper.ViewModel
{
    public class CommentViewModel
    {
        public string Email { get; set; }
        public string Alias { get; set; }
        public string Text { get; set; }
        public int? Id { get; set; }
    }
}