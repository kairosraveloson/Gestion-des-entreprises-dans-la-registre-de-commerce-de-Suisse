namespace Gestion_des_entreprises_dans_la_registre_de_commerce_de_Suisse
{
    public class CompanyList
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public int LegalSeatId { get; set; }
        public string LegalSeat { get; set; }
        public int RegistryOfCommerceId { get; set; }
        public LegalForm LegalForm { get; set; }
    }
}
