namespace Scharff.Domain.Entities
{
    public class AddressModel
    {      

        public int id { get; set; }
        public Boolean? status { get; set; }
        public int type_param { get; set; }
        public int client_id { get; set; }
        public int? ubigeo_id { get; set; }
        public int? unit_id { get; set; }
        public string? address { get; set; }
        public string? postal_code { get; set; }
        public DateTime? creation_date { get; set; }
        public int? creation_author { get; set; }
        public DateTime? modification_date { get; set; }
        public int? modification_author { get; set; }

        //Descripciones tabla Parametro
        public string type_address { get; set; }
        public string district_id { get; set; }
        public string ubigeo_code_description { get; set; }
        public string province_description { get; set; }
        public string status_description { get; set; }
        public string district_description { get; set; }
        public int province_id { get; set; }
    }
}
