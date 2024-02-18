namespace Gestion_des_entreprises_dans_la_registre_de_commerce_de_Suisse
{
    public class LegalForm
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public LocalizedText Name { get; set; }
        public LocalizedText ShortName { get; set; }
    }
}
