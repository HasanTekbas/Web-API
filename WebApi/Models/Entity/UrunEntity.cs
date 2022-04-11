namespace WebApi.Models.Entity
{
    public class UrunEntity
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string Adi { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }
        public bool IsSale { get; set; }
    }
}
