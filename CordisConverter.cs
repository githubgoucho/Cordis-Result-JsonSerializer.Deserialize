    public class CordisConverter
    {
        public hits hits { get; set; }
        public int id { get; set; }
        public string date { get; set; }
        public Title title { get; set; }

    }

    public class hits
    {
        public List<hit> hit { get; set; }
    }

    public class hit
    {
        public article article { get; set; }
        
    }

    public class article
    {
        public string title { get; set; }
        public string teaser { get; set; }
        public body body { get; set; }
    }

    public class body
    {
        List <section> _section = new();
 
        public object section
        {
            get => _section;
            set
            {
                var val = (System.Text.Json.JsonElement)value;
                var valk = val.ValueKind;
                if (val.ValueKind == JsonValueKind.Object)
                {
                    section sb = JsonSerializer.Deserialize<section>(val); 
                    _section.Add(sb);
                }
                else
                {
                    List<section> sbL = JsonSerializer.Deserialize<List<section>>(val);
                    _section.AddRange(sbL);
                }
            }
        }
    }

    public class section
    {
        public string sectionBody { get; set; }
    }
}
