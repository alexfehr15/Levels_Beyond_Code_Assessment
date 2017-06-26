using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoteManager.Models
{
    /// <summary>
    /// A note with unique id and descriptive body.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Note descriptive body.
        /// </summary>
        public string Body { get; set; }
    }
}