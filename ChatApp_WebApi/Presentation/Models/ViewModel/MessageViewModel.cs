using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models.ViewModel
{
    /// <summary>
    /// Represents a message view model.
    /// </summary>
    public class MessageViewModel
    {
        public string Content;
        public string From;
        public string To;
        public DateTime SentTime;
    }
}