using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
    public class Language : IEntity 
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}
