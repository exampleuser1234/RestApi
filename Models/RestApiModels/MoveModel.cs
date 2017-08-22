using System;
using System.Collections.Generic;
using System.Text;

namespace Models.RestApiModels
{
    public class MoveModel:BaseApiModel
    {
        public string column_from { get; set; }
        public string column_to { get; set; }
        public string pattern { get; set; }
        public override bool TransleteColumnsNames(Dictionary<string, string> nameIdDictionary)
        {
            if (nameIdDictionary.ContainsKey(this.column_from))
                this.column_from = nameIdDictionary[this.column_from];
            if (nameIdDictionary.ContainsKey(this.column_to))
                this.column_to = nameIdDictionary[this.column_to];

            return nameIdDictionary.ContainsValue(this.column_to)&& nameIdDictionary.ContainsValue(this.column_from);
        }
    }
}
