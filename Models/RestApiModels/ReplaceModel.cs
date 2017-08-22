using System;
using System.Collections.Generic;
using System.Text;

namespace Models.RestApiModels
{
    public class ReplaceModel : BaseApiModel
    {
        public string column { get; set; }
        public string pattern { get; set; }
        public string  change_to { get; set; }
        public override bool TransleteColumnsNames(Dictionary<string, string> nameIdDictionary)
        {
            if (nameIdDictionary.ContainsKey(this.column))
                this.column = nameIdDictionary[this.column];
            return nameIdDictionary.ContainsValue(this.column);
        }
    }
}
