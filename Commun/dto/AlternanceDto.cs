
namespace RRelationnelle.dto
{
    public class AlternanceDto : RessourceDto
    {
        public  string DiplomaLevel { get; set; }
        public  string Period { get; set; }
        public  string Capacity { get; set; }
        public  string Ville { get; set; }
        public  string Zipcode { get; set; }
        public  string emailContact { get; set; }

        public AlternanceDto(string title, int categoryId, string _reference, string url, int userId ,string diplome, string perio, string cap, string city, string cod, string email) : base( title,categoryId,_reference,url,userId)
        {
            DiplomaLevel = diplome;
            Period = perio;
            Capacity = cap;
            Ville = city;
            Zipcode = cod;
            emailContact = email;

        }

        public AlternanceDto()
        {

        }
    }
}
