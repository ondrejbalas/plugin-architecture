using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaSoft.Plugins;

namespace PizzaSoft.Models
{
    public class PizzaCreationViewModel
    {
        public string CurrentStateId { get; set; }

        public string CurrentStepName { get; set; }
        public string HeaderText { get; set; }
        public string DetailsHtml { get; set; }

        public IEnumerable<string> Options { get; set; }
        public bool CanSelectMultiple { get; set; }

        public bool ShowValidationMessage { get; set; }
        public string ValidationMessage { get; set; }
    }
}