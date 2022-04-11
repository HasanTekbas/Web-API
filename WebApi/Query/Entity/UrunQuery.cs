namespace WebApi.Query.Entity
{
    public class UrunQuery
    {
        public const string GetUrunSql = 
            @"SELECT * FROM Urun urun WHERE urun.KategoriId = @kategoriId";

        public const string InsertUrunSql = @"INSERT INTO [dbo].[Urun]
           ([KategoriId]
           ,[Adi]
           ,[Stok]
           ,[Fiyat]
           ,[IsSale])
     VALUES
           (@KategoriId
           ,@Adi
           ,@Stok
           ,@Fiyat
           ,@IsSale)";

        public const string UpdateUrunSql = @"UPDATE [dbo].[Urun]
                                       SET [KategoriId] = @KategoriId
                                          ,[Adi] = @Adi
                                          ,[Stok] = @Stok
                                          ,[Fiyat] = @Fiyat
                                          ,[IsSale] = @IsSale
                                     WHERE Id=@Id";

        public const string DeleteUrunSql = @"DELETE FROM [dbo].[Urun]
                                        WHERE Id=@Id";

       
    }
}
