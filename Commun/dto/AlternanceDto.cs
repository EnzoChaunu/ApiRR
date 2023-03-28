
namespace RRelationnelle.dto
{
    public class AlternanceDto : RessourceDto
    {
        public readonly string DiplomaLevel;
        public readonly string LienAnnonce;
        public readonly string Period;
        public readonly string Capacity;
        public readonly string Ville;
        public readonly string Zipcode;
        public readonly string emailContact;

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
