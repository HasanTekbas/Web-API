namespace WebApi.Query.Dto
{
    public class KategoriUrunQuery
    {
        public const string GetKategoriUrunByKategoriIdSql = @"
                    Select 
                    kategori.Adi AS KategoriAdi,
                    urun.Id AS urunId,
                    urun.Adi AS UrunAdi,
                    urun.Fiyat
                    from Kategori kategori
                    INNER JOIN Urun urun 
                    ON kategori.Id=urun.KategoriId
                    where kategori.Id=@kategoriId";

        public const string GetKategoriUrunByUrunIdSql = @"
                    Select 
                    kategori.Adi AS KategoriAdi,
                    urun.Id AS urunId,
                    urun.Adi AS UrunAdi,
                    urun.Fiyat
                    from Kategori kategori
                    INNER JOIN Urun urun 
                    ON kategori.Id=urun.KategoriId
                    where urun.Id=@urunId";
        public const string GetUrunDtoVeKategoriListesiSql = @"
        Select 
        kategori.Adi AS KaategoriAdi,
        urun.Id AS urunId,
        urun.Adi AS UrunAdi,
        urun.Fiyat
        from Kategori kategori
        INNER JOIN Urun urun 
        ON kategori.Id=urun.KategoriId
        where (-1=@kategoriId OR urun.KategoriId=@kategoriId);

        Select * from Kategori k where (-1=@kategoriId OR Id=@kategoriId);";
    }
}
