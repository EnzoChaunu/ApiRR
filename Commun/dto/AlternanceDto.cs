
namespace RRelationnelle.dto
{
    public class AlternanceDto : RessourceDto
    {
        public  string DiplomaLevel { get; set; }
        public  string Period { get; set; }
        public  string Capacity { get; set; }
        public  string Ville { get; set; }
        public  string Departement { get; set; }
        public  string Zipcode { get; set; }
        public  string emailContact { get; set; }
        public  string RomeDomain { get; set; }
        public  string entreprise { get; set; }

        public AlternanceDto(string title, int categoryId, string _reference, string url, int userId,int id ,string diplome, string perio, string cap, string city, string cod, string email,string Department, string rome,string enter) : base(title,categoryId,_reference,url,userId,id)
        {
            DiplomaLevel = diplome;
            Period = perio;
            Capacity = cap;
            Ville = city;
            Zipcode = cod;
            emailContact = email;
            Departement = Department;
            RomeDomain = rome;
            entreprise = enter;

        }

        public AlternanceDto()
        {

        }
    }
}
